
using DynamoDBService;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.Threading.Tasks;

namespace DemoCode
{

    public class DynamoDBCaller
    {
        IDynamoDBService _dbservice;

        public DynamoDBCaller(IDynamoDBService dbservice)
        {
            _dbservice = dbservice;
        }
        public AmazonDynamoDBClient GetDynamoDB()
        {
           AmazonDynamoDBClient client = _dbservice.GetClient();
           return client;
        }
        public string GetItem(string attribute)
        {

           string val =  _dbservice.GetItem(attribute);

           if (val == null) return null;

           val = "This is the string returned from AWS " + val;

           return val;
            
        }
        public async Task<string> GetAsyncItem(string attribute)
        {

            Task<string> val = _dbservice.GetAsyncItem(attribute);

            string ret = await val;

            if (ret == null) return null;

            ret = "This is the string returned from AWS " + ret;

            return ret;

        }
    }
}
