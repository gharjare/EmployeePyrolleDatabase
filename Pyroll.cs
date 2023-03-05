using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePyrollService
{
    public class Pyroll
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public DateTime start { get; set; }
        public string Gender { get; set; }
        public string Phonenumber { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public int deduction { get; set; }
        public int basic_pay { get; set; }
        public int taxable_pay { get; set; }
        public int income_tax { get; set; }
        public int net_pay { get; set; }

    }
}
