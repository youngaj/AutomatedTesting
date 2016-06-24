using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject
{
    public class Calculator
    {
        private IUser _user;
        private ILogger _logger;
        private List<int> _numbers;
        public Calculator(IUser user, ILogger log)
        {
            _logger = log;
            _user = user;
            _numbers = new List<int>();
        }

        public Calculator Add(int num)
        {
            //var msg = string.Format("Added {0}", num);
            var msg = string.Format("{0} Added {1}", _user.Name, num);
            _logger.info(msg);
            _numbers.Add(num);
            return this;
        }

        public int Execute()
        {
            var value = 0;
            foreach (var num in _numbers)
            {
                value = value + num;
            }
            var msg = string.Format("Equals {0}", value);
            _logger.info(msg);
            return value;
        }

        public Calculator Subtract(int num)
        {
            //var msg = string.Format("Subtract {0}", num);
            //var msg = string.Format("{0} subtracted {1}", _user.Name, num);
            //_logger.info(msg);
            _numbers.Add(num * -1);
            return this;
        }
    }
}
