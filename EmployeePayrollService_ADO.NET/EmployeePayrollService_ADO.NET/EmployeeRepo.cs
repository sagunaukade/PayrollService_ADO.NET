using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService_ADO.NET
{
    public class EmployeeRepo
    {
        //Give path for Database Connection
        public static string connection = @"Data Source=DESKTOP-IAGIDN5;Initial Catalog=Payroll_Service;Integrated Security=True";
        //Represents a connection to Sql Server Database
        //  SqlConnection sqlConnection = new SqlConnection(connection);
        //SqlConnection
        public static SqlConnection sqlConnection = null;

        //Method to check the sql connection is established
        public static void GetAllEmployees()
        {
            try
            {
                using (sqlConnection = new SqlConnection(connection))
                {
                    //Object for employee class
                    EmployeeModel model = new EmployeeModel();
                    //Qurey to retreive data
                    string query = "Select * From Employee_Payroll";
                    //pass query to TSQL
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    //Open Connection
                    sqlConnection.Open();
                    //Returns object of result set UC-2
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Will Loop until rows are null
                        while (reader.Read())
                        {
                            model.EmployeeID = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                            model.EmployeeName = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                            model.EmployeePhoneNumber = Convert.ToInt64(reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"]);
                            model.StartDate = (DateTime)(reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]);
                            model.Gender = Convert.ToChar(reader["Gender"] == DBNull.Value ? default : reader["Gender"]);
                            model.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                            model.EmployeeDepartment = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                            model.BasicPay = Convert.ToDouble(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);
                            model.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                            model.IncomeTax = Convert.ToDouble(reader["IncomeTax"] == DBNull.Value ? default : reader["IncomeTax"]);
                            model.Deduction = Convert.ToDouble(reader["Deductions"] == DBNull.Value ? default : reader["Deductions"]);
                            model.NetPay = Convert.ToDouble(reader["NetPay"] == DBNull.Value ? default : reader["NetPay"]);
                            Console.WriteLine(model);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no records in the db table");
                    }
                    Console.ReadLine();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //close connection
                sqlConnection.Close();
            }
        }
        public static void GetAllEmployeesUsingDataAdapter()
        {
            try
            {
                using (sqlConnection = new SqlConnection(connection))
                {
                    //Created the object of dataset class
                    DataSet dataSet = new DataSet();
                    //Using Stored procedure query to retreive data
                    SqlDataAdapter adapter = new SqlDataAdapter("dbo.ViewAllEmployee", sqlConnection);
                    //Open Sql Connection
                    sqlConnection.Open();
                    adapter.Fill(dataSet);
                    foreach (DataRow data in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"Id : {data["id"]} || Name : {data["Name"]} || PhoneNo : {data["PhoneNumber"]} || Address : {data["Address"]}" +
                            $" || StartDate : {data["StartDate"]} || Gender : {data["Gender"]} || Department : {data["Department"]} || Basic Pay : {data["BasicPay"]}" +
                            $" || Deductions : {data["Deductions"]} || Taxable Pay : {data["TaxablePay"]} || Income Tax : {data["IncomeTax"]} || Net Pay : {data["NetPay"]}\n");
                    }
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
                
