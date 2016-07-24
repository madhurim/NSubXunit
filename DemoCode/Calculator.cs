using System;


namespace DemoCode
{
    public class Calculator
    {
        IRepository _repo;
        IView _view;
        public Calculator(IRepository repo , IView view)
        {
            _repo = repo;
            _view = view;

        }
        public int AddInts(int a, int b)
        {
            return a + b;
        }
        public int AddFromRepo()
        {
            int [] nums = _repo.GetNumbers();
            int sum = 0;

            foreach(int num in nums)
            {
                sum += num;
            }

            _view.Sum = sum;

            return sum;
        }
       
        public int AddFromRepoDb()
        {
            int[] nums = _repo.GetNumbersFromDatabase("numbers");
            int sum = 0;

            foreach (int num in nums)
            {
                sum += num;
            }

            return sum;
        }
        public int Divide(int value, int by)
        {
            if (value > 200) // for demo purposes
            {
                throw new ArgumentOutOfRangeException("value");
            }

            return value / by;
        }
    }
}