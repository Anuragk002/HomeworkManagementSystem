using HWMS.DAL;
using HWMS.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWMS.BAL
{
    public class AccountBAL
    {
        AccountDAL obj = new AccountDAL();
        public StatusModel RegisterBAL(Register reg)
        {
            return obj.RegisterDAL(reg);
        }

        public ResultModel<string> GetPasswordSaltBAL(string Email)
        {
            return obj.GetPasswordSaltDAL(Email);
        }

        public ResultModel<UserDetails> LoginBAL(Login lg)
        {
            return obj.LoginDAL(lg);
        }

    }
}
