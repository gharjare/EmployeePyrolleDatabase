using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePyrollService
{
    public class EmployeePyrollOperation
    {
        public List<Pyroll> pyrollList = new List<Pyroll>();
        public void addEmployeeToPyroll(List<Pyroll> pyrollList)
        {
            pyrollList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being Added:" + employeeData.name);
                this.addEmployeeToPyroll(pyrollList);
                Console.WriteLine("Employee Added:" + employeeData.name);
            });
            Console.WriteLine(this.pyrollList.ToString());
        }
        public void addEmpPyrollWithThread(List<Pyroll> pyrollList)
        {
            pyrollList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added:" + employeeData.name);
                    this.addEmployeePyroll(employeeData);
                    Console.WriteLine("Employee Added:" + employeeData.name);
                });
                thread.Start();
                Console.WriteLine(this.pyrollList.Count);
                
            });
        }
        public void addEmployeePyroll(Pyroll py)
        {
            pyrollList.Add(py);
        }
    }
}
