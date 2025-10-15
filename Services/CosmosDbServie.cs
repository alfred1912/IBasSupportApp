using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using IBasSupportApp.Models;

namespace IBasSupportApp.Services
{
    public class CosmosDbService
    {
        private readonly Container _container;

        public CosmosDbService(string connectionString, string databaseName, string containerName)
        {
            var client = new CosmosClient(connectionString);
            _container = client.GetContainer(databaseName, containerName);
        }

        public async Task AddSupportMessageAsync(SupportMessage message)
        {
            await _container.CreateItemAsync(message, new PartitionKey(message.Category));
        }

        public async Task<IEnumerable<SupportMessage>> GetAllMessagesAsync()
        {
            var query = _container.GetItemQueryIterator<SupportMessage>("SELECT * FROM c");
            List<SupportMessage> results = new();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }
    }
}