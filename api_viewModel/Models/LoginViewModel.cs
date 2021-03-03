using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api_viewModel.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100,MinimumLength =5)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string  LoginPwd { get; set; }
    }
}