using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamoDBService;
using NSubstitute;
using DemoCode;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Xunit;

namespace DemoCode.Tests
{
    public class DynamoDBServiceTests
    {
        IDynamoDBService dynamoDBService;
        DynamoDBCaller serviceCaller;

        public DynamoDBServiceTests()
        {
            //stub
            dynamoDBService = Substitute.For<IDynamoDBService>();           
            String key1 = String.Empty;
            String key2 = String.Empty;
            var config = new AmazonDynamoDBConfig();
            config.ServiceURL = "http://localhost";
            
            dynamoDBService.GetClient().Returns<AmazonDynamoDBClient>(new AmazonDynamoDBClient(key1,key2,config));
            dynamoDBService.GetItem(Arg.Any<string>()).Returns<string>("activity");
           
            dynamoDBService.GetItem("test null").Returns<string>(x => null);

            //subject under test
            serviceCaller = new DynamoDBCaller(dynamoDBService);
        }
        [Fact]
        public void DoesTheCallerCallGetClient()
        {
            serviceCaller.GetDynamoDB();
            dynamoDBService.Received().GetClient();    
         }
        [Fact]
        public void DoesTheCallerCallGetAValidClient()
        {
            Object actual = serviceCaller.GetDynamoDB();

            //silly test , but should pass
            Assert.IsType<AmazonDynamoDBClient>(actual);
            
        }
        [Fact]
        public void DoesTheCallerFormatReturnedData()
        {
            var actual = serviceCaller.GetItem("test");

            Assert.Matches("This is the string returned from AWS activity", actual);

        }
        [Fact]
        public void DidServiceReceiveGetItemCall()
        {
            var actual = serviceCaller.GetItem("test");
            dynamoDBService.Received().GetItem("test");
        }
        [Theory]
        [InlineData("test1", "This is the string returned from AWS activity")]
        [InlineData("test2", "This is the string returned from AWS activity")]
        [InlineData("test3", "This is the string returned from AWS activity")]
        [InlineData("test4", "This is the string returned from AWS activity")]
        public void DoesTheCallerReturnDataCorrectly(string input,string expected)
        {
            var actual = serviceCaller.GetItem(input);

            Assert.Matches(expected, actual);

        }
        [Fact]
        public void DoesCallerReturnNullOnServiceReturnNull()
        {
            var actual = serviceCaller.GetItem("test null");
            Assert.Equal(null, actual);
        }
    }
}
