using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeRepository
    {
        public readonly string connectionString;



        public EmployeeRepository()
        {
            connectionString = @"Data source=ANIYAAN-1006;Initial catalog=EmployeeManagement;User Id=Anaiyaan;Password=Anaiyaan@123";
        }
        public List<EmployeeModel> GetAllEmployeeData()
        {
            try
            {
                List<EmployeeModel> constrain = new List<EmployeeModel>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                constrain = connection.Query<EmployeeModel>($" exec Getallemployees").ToList();
                connection.Close();

                return constrain;


            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }

        public EmployeeModel GetEmployeeData(int Id)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                var connection = new SqlConnection(connectionString);
                con.Open();
                var Employee = connection.QueryFirst<EmployeeModel>($" exec Getemployeesid {Id} ");
                con.Close();
                return Employee;
            }

            catch (SqlException er)
            {
                throw;
            }
            catch (Exception r)
            {
                throw r;
            }
        }
        public void InsertEmployeeData(EmployeeModel emp)
        {

            try
            {
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec CreateEmployeeDetails '{emp.Name}', '{emp.DateOfBirth}','{emp.Experience}',{emp.Phonenumber},'{emp.EmailAddress}'");

                con.Close();

            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void UpdateEmployeeData(EmployeeModel emp)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($" exec UpdateEmployeeDetails '{emp.Id}','{emp.Name}','{emp.DateOfBirth}','{emp.Experience}','{emp.Phonenumber}','{emp.EmailAddress}'");
                con.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteEmployeeData(int Id)
        {
            try
            {


                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                con.Execute($"  exec DeleteEmployeeDetails { Id}");

                con.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
