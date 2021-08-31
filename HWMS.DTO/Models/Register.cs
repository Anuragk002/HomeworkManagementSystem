using System;
using System.Collections.Generic;
using System.Text;

namespace HWMS.DTO.Models
{
    public class Register
    {
        public int LoginID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int RoleID { get; set; }
        public int IsActive { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

    }
}
