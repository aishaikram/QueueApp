# QueueApp - A console app developed using.net core 5.0 to create a Queue in the Azure Storage specified in your Connection String. The Application sends and receive (receive and delete after processign) queue message using Microsoft.Storage.Queue SDK

Please make sure you have permission/role to create a queue in your storage account or your account will be locked.
This application uses account key/connectionstring which provides full access to the storage access. In production application the connectionstring should be stored in Key Vault


A Learn exercise inspired by Microsoft Learn tutorial about creating storage/messaging infrastructure and code by Aisha Ikram

https://docs.microsoft.com/en-us/learn/modules/communicate-between-apps-with-azure-queue-storage/1-introduction

Replace the connection string with your storage account connection string
