using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DashboardImpl.Models.Test
{
    public class TestModel
    {
        public string TestId { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is TestModel model &&
                   TestId == model.TestId;
        }

        public override int GetHashCode()
        {
            return -1448189120 + EqualityComparer<string>.Default.GetHashCode(TestId);
        }
    }
}
