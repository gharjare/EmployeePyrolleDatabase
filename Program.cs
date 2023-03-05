namespace EmployeePyrollService
{
    class  program
    {
        public static void Main(string[] args)
        {
            EmployeeRepository employee = new EmployeeRepository();
            Pyroll py = new Pyroll();
            py.id = 6;
            py.name = "Virat";
            py.salary = 80000;
            py.Gender ="M";
            py.Phonenumber = "8999563531";
            py.address = "Delhi";
            py.department = "Hr";
            py.deduction = 40000;
            py.basic_pay = 50000;
            py.taxable_pay = 30000;
            py.income_tax = 20000;
            py.net_pay = 60000;

            employee.AddEmployee(py);
            employee.GetAllEmployee();
        }
    }
}