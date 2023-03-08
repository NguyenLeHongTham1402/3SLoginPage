using _3SLoginPage.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3SLoginPage.Repository
{
    public class LoginRepo
    {
        private ConfigurationContext context;
        public string isLogin (IFormCollection collection)
        {
            string status = string.Empty;
            TbUser user = new TbUser();
            user.UserId = collection["UserId"].ToString();
            user.Password = collection["Password"].ToString();
            using (context  = new ConfigurationContext())
            {
                try
                {
                    var u = context.TbUsers.FirstOrDefault(x => x.UserId == user.UserId && x.Password == user.Password && x.IsActive == true);
                    if (u != null)
                        status = "t";
                    else
                        status = "f";
                }
                catch (Exception ex)
                {
                    status = ex.Message;
                }               
            }
            return status;
        }
    }
}
