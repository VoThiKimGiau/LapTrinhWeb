using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebBanSach.Identity
{
    public class UserStoreIdentity: UserStore<User>
    {
        public UserStoreIdentity(MyDbContext dbContext) : base(dbContext) { }
    }
}