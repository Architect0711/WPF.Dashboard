using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DashboardImpl.DTOs.Tests
{
    [DataContract]
    public class TestDTO
    {
        [DataMember]
        public string TestId { get; set; }
    }
}
