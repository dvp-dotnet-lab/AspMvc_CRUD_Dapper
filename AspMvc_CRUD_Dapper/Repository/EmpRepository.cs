using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AspMvc_CRUD_Dapper.Models;
using Dapper;
using System.Configuration;

namespace AspMvc_CRUD_Dapper.Repository
{
    public class EmpRepository
    {
        public SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            string constr2 = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            con = new SqlConnection(constr);
        }
        //To Add Employee details
        public void AddEmployee(EmpModel objEmp)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("AddNewEmpDetails", objEmp, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EmpModel> GetAllEmployee()
        {
            try
            {
                connection();
                con.Open();
                IList<EmpModel> EmpList = SqlMapper.Query<EmpModel>(
                        con, "GetEmployee").ToList();
                con.Close();
                return EmpList.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
        //To update employee details
        public void UpdateEmployee(EmpModel odjUpdate)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("UpdateEmpDetails", odjUpdate, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //To delete Employee details
        public bool DeleteEmployee(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", Id);
                connection();
                con.Open();
                con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need
                throw ex;
            }
        }
    }
}