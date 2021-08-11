using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System.Threading.Tasks;


namespace QueueApp
{
    class Program
    {
        const string  connectionstr = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=storageacct11082021;AccountKey=7SMsPBZ29t/xqSR5fHXaPOi8ssscJEbpnEcbsxgXcnSMov6GUohuEDs6l6kkKwFzQPQ7r39IkgRHMsgXTbrZGA==";
        static void Main(string[] args)
        {
            Console.WriteLine("Queue App started, it will create a queue in your storage account and send and receive the messages");
            SendQueueMessageAsync("This is the content of the queue message... which will be 48K in Base 64").Wait();
         /*   Console.WriteLine("Receiving Message from Queue....");
           CloudQueueMessage msg = await queue.GetMessageAsync();

            if (msg != null)
            {
                // Process the message
                Console.WriteLine("Message Received is" + msg.ToString());
                Console.WriteLine("Delete Message from Queue after Processing (otherwise msg will come back in 30 secs to manage at-least once delivery)....");
                await queue.DeleteMessageAsync(message);
            }*/
             Console.WriteLine("Program Finished");
        }

        static async Task SendQueueMessageAsync(string Message)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionstr);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("queue11082021");
            bool createdQueue = await queue.CreateIfNotExistsAsync();
            if (createdQueue)
            {
                Console.WriteLine("The queue queue11082021 is created.");
            }
            Console.WriteLine("Sending Message to Queue....");
            CloudQueueMessage queMessage = new CloudQueueMessage(Message);
            await queue.AddMessageAsync(queMessage);
        }
    }
}
