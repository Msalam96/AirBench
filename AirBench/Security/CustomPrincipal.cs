using AirBench.Models;
using System;
using System.Security.Principal;

namespace AirBench.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity identity;
        private User user;

        public CustomPrincipal(CustomIdentity identity, User user)
        {
            this.identity = identity;
            this.user = user;
        }

        public User User
        {
            get
            {
                return user;
            }
        }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}