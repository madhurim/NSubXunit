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
    public class AsyncRepositoryTests
    {
        public AsyncRepositoryTests()
        { }

        public void GetNumbersReturnsIntArray()
        {
            IAsyncRepository stubRepo = Substitute.For<IAsyncRepository>();

            stubRepo
               .GetNumbers()
               .Returns(Task.Run<int[]>(() => new int[]{ 1,2,3 }));

            var result = new int[]{};
            var task = stubRepo.GetNumbers();
            task.Wait();
            result = task.Result;

            var expected = new int[] { 1, 2, 3 };

            Assert.Equal(expected, result);
        }
        public void GetNumbersReturnsIntArrayOneMoreWay()
        {
            IAsyncRepository stubRepo = Substitute.For<IAsyncRepository>();

            stubRepo
               .GetNumbers()
               .Returns(Task.FromResult<int[]>(new int[] { 1, 2, 3 }));

            var result = new int[] { };
            var task = stubRepo.GetNumbers();
            task.Wait();
            result = task.Result;

            var expected = new int[] { 1, 2, 3 };

            Assert.Equal(expected, result);
        }
    }
}
