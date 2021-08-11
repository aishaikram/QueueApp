using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System.Threading.Tasks;


namespace QueueApp
{
    class Program
    {
        const string  connectionstr = "<DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=storageacct11082021;AccountKey=<Storage Account Key>";
        const string queueName = "queue11082021";
        static async Task Main(string[] args)
        {
            Console.WriteLine("Queue App started, it will create a queue in your storage account and send and receive the messages");
            
            SendQueueMessageAsync("This is the content of the queue message... which will be 48K in Base 64").Wait();

            string value = await ReceiveQueueMessageAsync();
            Console.WriteLine($"Received->: {value}");
                  
             Console.WriteLine("Program Finished");
        }

        static CloudQueue GetQueue()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstr);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            return queueClient.GetQueueReference("queue11082021");
        
                    
        }
        static async Task SendQueueMessageAsync(string Message)
        {
            //get reference to the queue
            CloudQueue queue = GetQueue();
            bool createdQueue = await queue.CreateIfNotExistsAsync();
            if (createdQueue)
            {
                Console.WriteLine($"The queue {queueName} is created.");
            }
       
            Console.WriteLine("Sending Message to Queue....");
            CloudQueueMessage queMessage = new CloudQueueMessage(Message);
            await queue.AddMessageAsync(queMessage);
        }

        static async Task<string> ReceiveQueueMessageAsync()
        {
             //get reference to the queue
            CloudQueue queue = GetQueue();
            bool exists = await queue.ExistsAsync();
            if (exists)
            {
                Console.WriteLine("Receiving Message from Queue....");
                CloudQueueMessage msg = await queue.GetMessageAsync();

                if (msg != null)
                {
                    //convert to string
                    string messageContent = msg.AsString;
                    // Process the message
                    Console.WriteLine("Message Received is " + msg.AsString);
                    Console.WriteLine("Delete Message from Queue after Processing (otherwise msg will come back in 30 secs to manage at-least once delivery)....");
                    await queue.DeleteMessageAsync(msg);         
                    return messageContent;
                }
                
            }
            return "Queue empty or not created";
        }
    }
}
