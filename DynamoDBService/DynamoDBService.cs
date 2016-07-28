using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;

namespace DynamoDBService
{
    public class DynamoDBService: IDynamoDBService 
    {
        AmazonDynamoDBClient _client;
        public AmazonDynamoDBClient GetClient()
        {                        
            _client = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
            return _client;
        }

        //public int PutItem(T item) { return 0; }
        public string GetItem(string attribute) {
            
            GetItemResponse resp = _client.GetItem(
            new GetItemRequest
            {                                            
                TableName = "Activity",                                             
                Key = new Dictionary<string, AttributeValue>() { { "cachekey", new AttributeValue { S = "1" } }, },
            }
            );
            if (resp == null) { return null; }
            if (resp.Item == null) { return null; }
            if (resp.Item == null) { return null; }

            return resp.Item["content"].S;
        }

     //   public int UpdateItem(T item) { return 0; }
     //   public int DeleteItem(T item) { return 0; }

        public List<string> GetTables()
        {
            ListTablesResponse response = _client.ListTables();
            return response.TableNames;
            
        }
    }
}
