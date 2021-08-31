using HWMS.BAL;
using HWMS.DTO.Models;
using HWMS.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HomeworkManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public string salt { get; set; }
        AccountBAL objbal = new AccountBAL();

        [HttpPost]
        [Route("api/[controller]/Login")]
        public UserDetails Login(Login lg)
        {
            ResultModel<string> ps = objbal.GetPasswordSaltBAL(lg.Email);
            if (ps.statusmodel.Status == 1)
            {
                salt=ps.resultdata[0];
                lg.Password = SecurityHelper.HashPassword(lg.Password,salt);

                ResultModel<UserDetails> rm = objbal.LoginBAL(lg);
                if(rm.statusmodel.Status==1)
                {
                    Response.Headers.Add("Status", rm.statusmodel.Status.ToString());
                    Response.Headers.Add("Message", rm.statusmodel.Message);
                    return rm.resultdata[0];
                }
                else
                {
                    Response.Headers.Add("Status", rm.statusmodel.Status.ToString());
                    Response.Headers.Add("Message", rm.statusmodel.Message);
                    return null;
                }
            }
            Response.Headers.Add("Status", ps.statusmodel.Status.ToString());
            Response.Headers.Add("Message", ps.statusmodel.Message);
            return null;
        }

        [HttpPost]
        [Route("api/[controller]/Register")]
        public string Register(Register reg)
        {
            reg.PasswordSalt=SecurityHelper.GenerateSalt();
            reg.Password = SecurityHelper.HashPassword(reg.Password,reg.PasswordSalt);
            StatusModel sm=objbal.RegisterBAL(reg);
            Response.Headers.Add("Status", sm.Status.ToString());
            Response.Headers.Add("Message", sm.Message);
            return null;
        }

    }
}
