using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePyrollService
{
    public class EmployeeRepository
    {

        public static string connectionString = "data source=(localdb)\\MSSQLLocalDB; initial catalog=pyroll_service2";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
            try
            {
                List<Pyroll> pyrolls = new List<Pyroll>();
                using (this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    string query = @"select * from employee_pyroll2";
                    SqlCommand command = new SqlCommand(query, this.sqlConnection);
                    command.CommandType = CommandType.Text;
                    SqlDataReader dr = command.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Pyroll pyroll = new Pyroll();
                            pyroll.id = Convert.ToInt16(dr["ID"]);
                            pyroll.name = Convert.ToString(dr["Name"]);
                            pyroll.salary = (int)Convert.ToInt64(dr["Salary"]);
                            pyroll.start = Convert.ToDateTime(dr["Start"]);
                            pyroll.Gender = Convert.ToString(dr["Gender"]);
                            pyroll.Phonenumber = Convert.ToString(dr["PhoneNumber"]);
                            pyroll.address = Convert.ToString(dr["Address"]);
                            pyroll.department = Convert.ToString(dr["Department"]);
                            pyroll.deduction = Convert.ToInt16(dr["Deduction"]);
                            pyroll.basic_pay = Convert.ToInt16(dr["Basic_Pay"]);
                            pyroll.taxable_pay = Convert.ToInt16(dr["Taxable_Pay"]);
                            pyroll.income_tax = Convert.ToInt16(dr["Income_Tax"]);
                            pyroll.net_pay = Convert.ToInt16(dr["Net_Pay"]);
                            Console.WriteLine("id: {0}\nname: {1}\nsalary: {2}\nstart: {3}\nGender: {4}\nPhoneNumber: {5}\naddress: {6}\ndepartment: {7}\ndeduction: {8}\nbasic_pay: {9}\ntaxabalepay: {10}\nincome_tax: {11}\nnet_pay:", pyroll.id, pyroll.name, pyroll.salary, pyroll.start, pyroll.Gender, pyroll.Phonenumber, pyroll.address, pyroll.department, pyroll.deduction, pyroll.basic_pay, pyroll.taxable_pay, pyroll.income_tax, pyroll.net_pay);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    dr.Close();
                    this.sqlConnection.Close();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddEmployee(Pyroll role)
        {
            try
            {
                using(this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("SpAddEmpDeatils", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", role.id);
                    command.Parameters.AddWithValue("@name", role.name);
                    command.Parameters.AddWithValue("@salary",role.salary);
                    command.Parameters.AddWithValue("@start", DateTime.Now);
                    command.Parameters.AddWithValue("@Gender", role.Gender);
                    command.Parameters.AddWithValue("@PhoneNumber", role.Phonenumber);
                    command.Parameters.AddWithValue("@address",role.address);
                    command.Parameters.AddWithValue("@department", role.department);
                    command.Parameters.AddWithValue("@deduction", role.deduction);
                    command.Parameters.AddWithValue("@basic_pay", role.basic_pay);
                    command.Parameters.AddWithValue("@taxable_pay", role.taxable_pay);
                    command.Parameters.AddWithValue("@income_tax", role.income_tax);
                    command.Parameters.AddWithValue("@net_pay", role.net_pay);
                    this.sqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if(result >= 1)
                    {
                        Console.WriteLine("Employee Added Successfully");
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
        