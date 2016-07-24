using Xunit;
using NSubstitute;
using DemoCode;
using System;
using System.Threading.Tasks;
using DemoCode.Interfaces;

namespace DemoCode.Tests
{
   
    public class RepositoryTests
    {
        IRepository _repo;  // for stubbing purposes , no asserts on these
        IDatabase _db;      // for stubbing purposes , no asserts on these

        Calculator mycalc;  // subject under test
        NumberRepository repository; // subject under test - ideally it's better to create a separate class to test it , it is for demo purposes only
        
        IView _displaySum;

        public RepositoryTests()
        {
            // for stubbing purposes
            _db = Substitute.For<IDatabase>();
            _repo = Substitute.For<IRepository>();

            // our mock so we can test the external object if it received what we wanted to send. 
            _displaySum = new CalculatorView();             

            mycalc = new Calculator(_repo , _displaySum);
            repository = new NumberRepository(_db);
        }            
        [Fact]
        public void IsSumCorrect()
        {
            //Arrange - stub
            _repo.GetNumbers().Returns<int[]>(new int[] { 1, 2, 3});
           
            //Act
            int sum = mycalc.AddFromRepo();

            //Assert
            Assert.Equal(6, sum);

            return;
        }
        [Fact]
        public void DidViewReceiveTheSum()
        {
            //Arrange - stub
            _repo.GetNumbers().Returns<int[]>(new int[] { 1, 2, 3 });

            //Act
            int sum = mycalc.AddFromRepo();

            //Assert - assert is on the mock this time to see if the calculator business class interacts with View class correctly
            Assert.Equal(6, _displaySum.Sum);

            return;
        }
        [Fact]
        public void IsRepositoryCalled()
        {
            //Arrange - stub
            _repo.GetNumbers().Returns<int[]>(new int[] { 1, 2, 3 });

            //Act
            int sum = mycalc.AddFromRepo();

            //Assert
            _repo.Received().GetNumbers();

            return;
        }
        [Fact]
        public void DoesConnectThrowException()
        {
            //Arrange - stub         
            _db.Connect(Arg.Any<string>()).Returns(false);
           
            //Act
            Exception thrownException =
                Assert.Throws<Exception>(() => repository.GetNumbersFromDatabase("numbers"));

            //Asset
            Assert.Equal("Could not connect to the numbers database", thrownException.Message);

            return;
        }
        [Fact]
        public void DoesDivideThrowException()
        {
                       
            //Act
            ArgumentOutOfRangeException thrownException =
                Assert.Throws<ArgumentOutOfRangeException>(() => mycalc.Divide(500,10));

            //Asset
            Assert.Equal("value", thrownException.ParamName);

            return;
        }
       
    }
}
