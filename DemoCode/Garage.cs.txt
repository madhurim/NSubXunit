using DemoCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class Garage
    {
        private ICreate Creator { get; set; }
        public Garage(ICreate creator)
        {
            Creator = creator;
        }
        public async Task<int> AddCar(Car carToAdd)
        {
            // add some logic here to validate the car
            var newId = await Creator.CreateCar(carToAdd);
            return newId;
        }
    }
}
