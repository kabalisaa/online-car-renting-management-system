﻿using Microsoft.Data.SqlClient;
using onlinecarrenting.Tables;

namespace onlinecarrenting.Dao
{
    public class UserDao
    {public static User user=new User();
        public static String  saveUser(User user)
        { 
            try
            {
                using(SqlConnection conn=new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using(SqlCommand cmd=new SqlCommand("createuser", conn))
                    { 
                        cmd.CommandType=System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@phone", user.Phone);
                        cmd.Parameters.AddWithValue("@gender", user.Gender);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Credentials Saved Successfully";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public static Boolean deleteUser(User user)
        {
            Boolean isSaved = false;
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@phone", user.Phone);
                        cmd.Parameters.AddWithValue("@gender", user.Gender);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                isSaved = true;
            }
            catch (Exception e)
            {
                isSaved = false;
            }
            return isSaved;
        }
        public static Boolean updateUser(User user)
        {
            Boolean isSaved = false;
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@phone", user.Phone);
                        cmd.Parameters.AddWithValue("@gender", user.Gender);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                isSaved = true;
            }
            catch (Exception e)
            {
                isSaved = false;
            }
            return isSaved;
        }
        public static List<User> getAllUser()
        {
            List<User> users = new List<User>();
            User user = new User();
            using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("displayallcustomer", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                         conn.Open();
                        SqlDataReader rd=cmd.ExecuteReader(); 
                        while(rd.Read())
                        {
                            user = new User();
                            user.Email = rd.GetString(0);
                            user.Name= rd.GetString(1);
                            user.Phone= rd.GetString(2);
                            user.Gender= rd.GetString(3);
                            users.Add(user);
                        }
                    }
                }
                return users;
   
            }
        public static String UserLogin(User user)
        {
            string result="";
                using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrent;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("customerlogin", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        conn.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        while(rd.Read())
                        {
                        result = rd.GetString(0);
                        }
                    }
                }

            return result;
        }

        public static User findUserbyEmail(string email)     
        {
            User usr = new User();
            using (SqlConnection conn = new SqlConnection("Data Source=KABALISA-PC\\KABALISA;Initial Catalog=carrent;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("finduserbyemail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        usr.Email = rd.GetString(0);
                        usr.Name = rd.GetString(1);
                        usr.Phone = rd.GetString(2);
                        usr.Gender = rd.GetString(3);
                    }
                }
            }
            return usr;
        }

    }
    
}
