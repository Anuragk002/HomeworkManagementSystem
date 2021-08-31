using HWMS.DTO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HWMS.DAL
{
    public class AccountDAL
    {
        public StatusModel RegisterDAL(Register reg)
        {
            StatusModel ob = new StatusModel();

            using (SqlConnection con = new SqlConnection(ConnectionStr.cName))
            {

                SqlCommand cmd = new SqlCommand("spRegister", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", reg.Email);
                cmd.Parameters.AddWithValue("@Password", reg.Password);
                cmd.Parameters.AddWithValue("@PasswordSalt", reg.PasswordSalt);
                cmd.Parameters.AddWithValue("@RoleID", reg.RoleID);
                cmd.Parameters.AddWithValue("@Name", reg.Name);
                cmd.Parameters.AddWithValue("@Phone", reg.Phone);


                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                int status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                string message = ds.Tables[0].Rows[0]["Message"].ToString();

                ob.Status = status;
                ob.Message = message;

                return ob;
            }
        }
        public ResultModel<string> GetPasswordSaltDAL(string Email)
        {
            ResultModel<string> ob = new ResultModel<string>();
            List<string> lst = new List<string>();
            StatusModel sm = new StatusModel();

            using (SqlConnection con = new SqlConnection(ConnectionStr.cName))
            {

                SqlCommand cmd = new SqlCommand("spGetPasswordSalt", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", Email);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                int status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                string message = ds.Tables[0].Rows[0]["Message"].ToString();

                sm.Status = status;
                sm.Message = message;

                if (status == 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {

                            string st = dr.Field<string>("PasswordSalt").ToString();

                            lst.Add(st);
                        }
                    }
                }

                ob.resultdata = lst;
                ob.statusmodel = sm;
                return ob;
            }
        }
        public ResultModel<UserDetails> LoginDAL(Login lg)
        {
            ResultModel<UserDetails> ob = new ResultModel<UserDetails>();
            List<UserDetails> lst = new List<UserDetails>();
            UserDetails obj = new UserDetails();
            StatusModel sm = new StatusModel();

            using (SqlConnection con = new SqlConnection(ConnectionStr.cName))
            {

                SqlCommand cmd = new SqlCommand("spLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", lg.Email);
                cmd.Parameters.AddWithValue("@Password", lg.Password);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                int status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                string message = ds.Tables[0].Rows[0]["Message"].ToString();

                sm.Status = status;
                sm.Message = message;

                if (status == 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            obj.LoginID = dr.Field<int>("LoginID");
                            obj.Email = dr.Field<string>("Email");
                            obj.RoleID = dr.Field<int>("RoleID");
                            obj.IsActive = dr.Field<bool>("IsActive");
                            obj.Name = dr.Field<string>("Name");
                            obj.Phone = dr.Field<string>("Phone");
                            lst.Add(obj);
                        }
                    }
                }

                ob.resultdata = lst;
                ob.statusmodel = sm;
                return ob;
            }
        }

    }
}
