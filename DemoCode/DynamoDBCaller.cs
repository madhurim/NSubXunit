
using DynamoDBService;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

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
    }
}
