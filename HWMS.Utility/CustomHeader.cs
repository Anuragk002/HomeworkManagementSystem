using HWMS.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
namespace HWMS.Utility
{
    public class CustomHeader: ControllerBase
    {
        public void PutHeader(StatusModel sm)
        {
            Response.Headers.Add("Status", sm.Status.ToString());
            Response.Headers.Add("Message", sm.Message);
            
        }
    }
}
