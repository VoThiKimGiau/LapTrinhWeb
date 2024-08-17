using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebBanSach.Identity
{
    public class ManagerUserIdentity : UserManager<User>
    {
        public ManagerUserIdentity(IUserStore<User> store) : base(store) { }
    }
}