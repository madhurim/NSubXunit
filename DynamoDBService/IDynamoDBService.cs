
using System.Collections.Generic;
using Amazon.DynamoDBv2;
using System.Threading.Tasks;

namespace DynamoDBService
{
    public interface IDynamoDBService
    {
        AmazonDynamoDBClient GetClient();

       // int PutItem(T item);
        string GetItem(string attribute);
        Task<string> GetAsyncItem(string attribute);
      //  int UpdateItem(T item);
      //  int DeleteItem(T item);

    }
}
