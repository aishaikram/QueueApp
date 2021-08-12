# QueueApp - A console app developed using.net core 5.0 to create a Queue in the Azure Storage specified in your Connection String. The Application sends and receive (receive and delete after processign) queue message using Microsoft.Storage.Queue SDK

Step1: Create a storage account in your subscription using Azure CLI command

az storage account create --name <unique storage account name> -g <resource group name> --kind <storagev2 or storagev1> --sku standard_lrs -l <prefered location>

Please make sure you have permission/role to create a storage account.
Step2: Replace the connection string with your storage account connection string in Azure portal or 
Azure CLI command: 

az storage account show-connection-string --name<Storage Account name> --resource-group <rgroupName>


Also before running the code make sure you have create permissions for queue in your storage account or your account will be locked.
This application uses account key/connectionstring which provides full access to the storage access. In production application the connectionstring should be stored in Key Vault


A Learn exercise inspired by Microsoft Learn tutorial about creating storage/messaging infrastructure and code by Aisha Ikram

https://docs.microsoft.com/en-us/learn/modules/communicate-between-apps-with-azure-queue-storage/1-introduction

