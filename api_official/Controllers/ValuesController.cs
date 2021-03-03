using api_official.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_official.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        public string GetTest(string name)
        {
            return $"你的參數是{name}";
        }

        // POST api/values
        public IHttpActionResult Post(Student stu)
        {
            if (stu.Name == "我瘋子")
            {
                return Ok(stu);
            }
            else
            {
                // throw new Exception("你錯誤了");
                return InternalServerError(new Exception("你錯誤了"));
            }
        }
        // 呼叫不到
        public string Post(string Name,int Id)
        {
            return $"你的Post是{Name}+{Id}";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
