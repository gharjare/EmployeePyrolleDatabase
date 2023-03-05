using EmployeePyrollService;

namespace EmpPyrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given10Employee_WhenAddedToList_ShouldMatchEmployeeEntry()
        {
            List<Pyroll> py = new List<Pyroll>();
            py.Add(new Pyroll { id = 1, name = "Kartik", salary = 60000, Gender = "M", Phonenumber = "7957447839", address = "12 street", department = "IT", deduction = 8733, basic_pay = 9856, taxable_pay = 7464, income_tax = 3453, net_pay = 5084 });
            py.Add(new Pyroll { id = 1, name = "Malik", salary = 60000, Gender = "M", Phonenumber = "7957447839", address = "12 street", department = "IT", deduction = 8733, basic_pay = 9856, taxable_pay = 7464, income_tax = 3453, net_pay = 5084 });
            py.Add(new Pyroll { id = 1, name = "Vishal", salary = 60000, Gender = "M", Phonenumber = "7957447839", address = "12 street", department = "IT", deduction = 8733, basic_pay = 9856, taxable_pay = 7464, income_tax = 3453, net_pay = 5084 });
            py.Add(new Pyroll { id = 1, name = "Rakesh", salary = 60000, Gender = "M", Phonenumber = "7957447839", address = "12 street", department = "IT", deduction = 8733, basic_pay = 9856, taxable_pay = 7464, income_tax = 3453, net_pay = 5084 });
            EmployeePyrollOperation pyrollOperation = new EmployeePyrollOperation();
            DateTime startDateTime = DateTime.Now;
            pyrollOperation.addEmployeeToPyroll(py);
            DateTime stopDateTime = DateTime.Now;   
            Console.WriteLine("Duration without thread"+(stopDateTime - startDateTime));
            DateTime startDateTime1 = DateTime.Now;
            pyrollOperation.addEmpPyrollWithThread(py);
            DateTime stopDateTime1 = DateTime.Now;
            Console.WriteLine("Duration without thread" + (stopDateTime - startDateTime));
        }
    }
}