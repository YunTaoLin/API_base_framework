
using api_viewModel.Models.Auth;
using api_viewModel.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace api_viewModel.Filters
{
    public class MyAuthAttribute : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            IEnumerable<string> token;
            // 獲取token
            if (actionContext.Request.Headers.TryGetValues("token", out token))
            {
                string loginName = JwtTools.Decode(token.First(), JwtTools.key)["LoginName"].ToString();
                // User是一個實作了IIdentity的物件(裡面的Identity.Name等內容是唯獨的，所以只能創立個新的給他賦值)
                (actionContext.ControllerContext.Controller as ApiController).User = new ApplicationUser(loginName);
                return await continuation();
            }
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}