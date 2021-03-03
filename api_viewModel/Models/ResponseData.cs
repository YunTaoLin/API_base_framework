using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_viewModel.Models
{
    public class ResponseData
    {
        public int Code { get; set; } = 200;

        public object  Data { get; set; }

        public string ErrorMessage  { get; set; }
    }
}