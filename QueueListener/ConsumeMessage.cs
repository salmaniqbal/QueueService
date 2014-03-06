using System;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace QueueListener
{
    public class ConsumeMessage
    {
        static void Consume()
        {
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

           // var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            var client = QueueClient.CreateFromConnectionString(connectionString, "TaskQueue");

            client.Receive();

            while (true)
            {
                var message = client.Receive();

                if (message != null)
                {
                    try
                    {
                        var test = message.GetBody<string>();
                        var messageId = message.MessageId;
                        var keyValue1 = message.Properties["QueueMessageKey"];
                        var taskMessageKey = message.Properties["TaskMessageKey"];

                    }
                    catch (Exception ex)
                    {
                        message.Abandon();
                    }
                }
            }
            
        }
    }
}
