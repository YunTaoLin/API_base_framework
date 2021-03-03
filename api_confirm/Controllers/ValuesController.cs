using api_confirm.Models;
using api_confirm.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api_confirm.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [Route("test")]
        public string Get()
        {
            return "Hello world";
        }
        [HttpPost]
        [Route("login")]
        public string Login(UserLogin user)
        {

            if (user.username.Length > 2 && user.pwd == "123456")
            {
                return JwtTools.Encode(new Dictionary<string, object>()
                {
                    { "loginName",user.username}
                }
                    ,JwtTools.key);
            }
            else
            {
                return "失敗";
            }
        }
        [HttpGet]
        [Route("getInfo")]
        public string GetUserInfo()
        {
           var username =  JwtTools.ValideLogined(ControllerContext.Request.Headers);
            return   "用戶資料"+ username;
        }
    }
}
