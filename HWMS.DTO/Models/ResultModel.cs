using System;
using System.Collections.Generic;
using System.Text;

namespace HWMS.DTO.Models
{
    public class ResultModel<T>
    {
        public List<T> resultdata {get;set;}

        public StatusModel statusmodel { get; set; }

    }
}
