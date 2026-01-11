using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVeterinaraAPI.Models
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }      
        public string UserRole { get; set; }   
        public int BusinessId { get; set; }    
    }
}
