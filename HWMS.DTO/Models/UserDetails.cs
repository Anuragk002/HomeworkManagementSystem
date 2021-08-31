using System;
using System.Collections.Generic;
using System.Text;

namespace HWMS.DTO.Models
{
    public class UserDetails
    {
        public int LoginID { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
