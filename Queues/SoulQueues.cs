using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace Queues
{
    public class SoulQueues
    {
        static void Main()
        {
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.QueueExists("TaskQueue"))
            {
                namespaceManager.CreateQueue("TaskQueue");
            }

            var message = new BrokeredMessage();

            message.Properties["Task"] = "Bring Some Milk";
            //message.Properties["TaskMessageKey"] = "Message02";

            var client = QueueClient.CreateFromConnectionString(connectionString, "TaskQueue");

            client.Send(message);

        }
    }
}
