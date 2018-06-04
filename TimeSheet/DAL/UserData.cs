using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Web;
using System.Net.Http;
using System.Globalization;

namespace DAL
{
    public class UserData
    {

        
      static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

        public object Response { get; private set; }

        public static  void GenSaltSHA256(string iput, string pwd)
        {
          
            string added;
            string salt = CreateSalt(36);

            added= string.Concat(pwd, salt);
            string hashedPassword = GenerateSHA256Hash(added);            
            string qry = "insert into User_Details(UserName,Hash,Salt) values(@userName,@hashpwd,@salt)";

            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@userName", iput);
            cmd.Parameters.AddWithValue("@hashpwd", hashedPassword);
            cmd.Parameters.AddWithValue("@salt", salt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
        }
        private static string CreateSalt(int size)
        {           
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        
        public static string GenerateSHA256Hash(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            string base64 = Convert.ToBase64String(hash);
            return base64;

           
        }
        public static bool Authenticate(string userName, string password)
        {
                           
            try
            {
               
                string qrySalt = "select * from User_Details where Username=@uName";

                SqlCommand cmdSalt = new SqlCommand(qrySalt, con);
                cmdSalt.Parameters.AddWithValue("@uName", userName);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdSalt);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if(ds.Tables.Count==0 || ds.Tables[0].Rows.Count==0)
                   return false;                             
                string getSalt = ds.Tables[0].Rows[0]["Salt"].ToString();
                string added;
                added = string.Concat(password, getSalt);
                string hashed = GenerateSHA256Hash(added);              
                string getHash = ds.Tables[0].Rows[0]["Hash"].ToString();              
              

                if (hashed == getHash)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

           

        }
        public static void UpdateRow(string tId,string fTime,string tTime,string desc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update Time_Sheet set FromTime=@fromTime, ToTime=@toTime, Description=@description where TaskId=@taskId", con);
                cmd.Parameters.AddWithValue("@fromTime", fTime);
                cmd.Parameters.AddWithValue("@toTime", tTime);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@taskId", tId);

                con.Open();
                cmd.ExecuteNonQuery();
               
               
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public static void DeleteRow(string taskId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete from Time_Sheet where TaskId=@tId", con);
                cmd.Parameters.AddWithValue("@tId", taskId);
                con.Open();
                cmd.ExecuteNonQuery();
               
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            
        }

        public static List<STO.User> DatePicker(string id, string date)
        {
            var datePick = ShowGrid(id, date);
            return datePick;
        }

        public static STO.User AddDetails(string fromTime,string toTime,string description,string empId,string date)
        {
            try
            {
                var fT = Convert.ToDateTime(fromTime);
                var tT = Convert.ToDateTime(toTime);
                string qry = "insert into Time_Sheet(Date,FromTime,ToTime,Description,EmpId) values(@date,@fTime,@tTime,@descrption,@eId)";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@fTime", fromTime);
                cmd.Parameters.AddWithValue("@tTime", toTime);
                cmd.Parameters.AddWithValue("@descrption", description);
                cmd.Parameters.AddWithValue("@eId", empId);

                con.Open();
                cmd.ExecuteNonQuery();
                
                var user = new STO.User();
                return user;              
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
          
        }
        
        public static int  EmployeeId(string userName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select EmpId from User_Details where UserName=@userName", con);
                cmd.Parameters.AddWithValue("@userName", userName);
                con.Open();
                int empId=(int)cmd.ExecuteScalar();
              
                return empId;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public static List< STO.User >ShowGrid(string userName, string gridDate) 
        {
            try
            {
              
                SqlCommand cmd = new SqlCommand("select ts.EmpId,ud.UserName,ts.Date,ts.FromTime,ts.ToTime,ts.TaskId,ts.[Description],ud.First_Name,ud.Last_Name from Time_Sheet ts join User_Details ud on ts.EmpId = ud.EmpId where ud.EmpId=@userName and ts.Date =@gridDate", con);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@gridDate", gridDate);
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);                            
                DataSet ds = new DataSet();
                ad.Fill(ds); 
                                            
               
                STO.User user = new STO.User();
                List<STO.User> listValues = new List<STO.User>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {


                    DateTime date =Convert.ToDateTime(dr["Date"]);
                   var dateGv = date.ToString("dd/MM/yyyy");

                    DateTime fTime = Convert.ToDateTime(dr["FromTime"]);
                  

                    DateTime tTime = Convert.ToDateTime(dr["ToTime"]);
                   


                    listValues.Add(new STO.User { EmpId = Convert.ToInt16(dr["EmpId"]), UserName = Convert.ToString(dr["UserName"]), Date =dateGv.ToString(), FromTime =fTime, ToTime = tTime , TaskId = Convert.ToInt16(dr["TaskId"]), Description = Convert.ToString(dr["Description"]), FirstName = Convert.ToString(dr["First_Name"]), LastName = Convert.ToString(dr["Last_Name"]),  });
                }
                return listValues;       
                    }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

    }
}
