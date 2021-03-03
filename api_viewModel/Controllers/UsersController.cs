using api_viewModel.Filters;
using api_viewModel.Models;
using api_viewModel.Models.Auth;
using api_viewModel.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_viewModel.Controllers
{
    [RoutePrefix("api/user")]
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginViewModel model)
        {
            //通過model校驗
            if (ModelState.IsValid)
            {
                return Ok(new ResponseData()
                { 
                    Data = JwtTools.Encode(new Dictionary<string, object> ()
                    {
                        {"LoginName", model.LoginName }
                    }, JwtTools.key)
                });;
            }
            else
            {
                return Ok(new ResponseData() { Code = 500, ErrorMessage = "帳號密碼有誤" });
            }
        }

        [HttpGet]
        [Route("userInfo")]
        [MyAuth]  
        public IHttpActionResult GetUserInfo()
        {
            //通過model校驗
            //var username = User.Identity.Name;
            // return Ok(username);

            return Ok(new ResponseData() { Data =User.Identity.Name });
        }
    }
}
