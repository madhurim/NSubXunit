using DemoCode.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoCode.Tests
{
    public class AsyncCarTests
    {
        Car validCar;
        ICreate stubCreate;
        Garage garage;
        public AsyncCarTests()
        {
            validCar = new Car();
            stubCreate = Substitute.For<ICreate>();
            garage = new Garage(stubCreate);
        }
        [Fact]
        public void Garage_addCar_returns_1_run()
        {
            stubCreate
                .CreateCar(validCar)
                .Returns(Task.Run<int>(() => 1));
           
            var result = default(int);
            var task = garage.AddCar(validCar);
            task.Wait();
            result = task.Result;

            Assert.Equal(1, result);
        }
        [Fact]
        public void Garage_addCar_returns_2_fromresult()
        {
            stubCreate
                .CreateCar(validCar)
                .Returns(Task.FromResult<int>(2));

            var result = default(int);
            var task = garage.AddCar(validCar);
            task.Wait();
            result = task.Result;

            Assert.Equal(2, result);
        }
    }
}
