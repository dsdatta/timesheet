using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BLL
{
    public class Login
    {
       
        public static void  SaltHash(string user,string password)
        {
        
            DAL.UserData.GenSaltSHA256(user,password);
        }
        public static void DeleteTask(string taskId)
        {
           
            DAL.UserData.DeleteRow(taskId);
        }
        public static void UpdateTask(string taskId,string fromTime,string toTime,string desc)
        {
            
            DAL.UserData.UpdateRow(taskId, fromTime, toTime, desc);
        }
         public static bool AuthenticateUser(string uname,string pwd)
        {
          
            
            return DAL.UserData.Authenticate(uname, pwd);
        }

        public static List<STO.User> Gridsheet(string userName,string date)
        {
            
            return DAL.UserData.ShowGrid(userName, date);
        }

        public static int Employeeid(string userName)
        {
            
            return DAL.UserData.EmployeeId(userName);
        }
        public static List<STO.User> DatePick(string empId, string date)
        {
          
            return DAL.UserData.DatePicker(empId, date);
        }

        public static STO.User AddTask( string fromTime,string toTime,  string Description,string employeeId,string date)
        {
           
            return DAL.UserData.AddDetails(fromTime, toTime, Description, employeeId,date);
        }

        public static object Gridsheet(object p, string dt)
        {
            throw new NotImplementedException();
        }
    }
}
