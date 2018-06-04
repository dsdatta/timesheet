using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO
{
    public class User
    { 
        public int EmpId { get; set; }
        public string UserName { get; set; }           
        public string FirstName { get; set; }       
        public string LastName { get; set; } 
        public string Date { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }    
        public int TaskId { get; set; }
        public string Description { get; set; }
      
    }

}
