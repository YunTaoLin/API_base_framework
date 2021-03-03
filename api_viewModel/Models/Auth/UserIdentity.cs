using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace api_viewModel.Models.Auth
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }
    }
    public class ApplicationUser : IPrincipal
    {
        public ApplicationUser(string name)
        {
            Identity = new UserIdentity(name);
        }
        //介面可以裝實現了 這個介面的物件
        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}