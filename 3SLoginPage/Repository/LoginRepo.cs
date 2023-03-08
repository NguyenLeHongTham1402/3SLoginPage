using _3SLoginPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace _3SLoginPage.Repository
{
    public class LoginRepo
    {
        private ConfigurationContext context;
        
        //Trả về "t" là đăng nhập thành công
        //Trả về "f" là đăng nhập không thành công có thể sai tham số truyền vào hoặc đã hết hạn hoạt động
        //Còn lại là trả về chuỗi message của ngoại lệ
        public string isLogin (IFormCollection collection)
        {
            string status = string.Empty;

            string user_name = collection["UserId"].ToString();
            string pass = collection["Password"].ToString();
            using (context  = new ConfigurationContext())
            {
                try
                {
                    //var u = context.TbUsers.SingleOrDefault(x => x.UserId == user_name && x.Password == pass && x.IsActive == true);
                    var u = context.TbUsers.AsEnumerable().SingleOrDefault(x => x.UserId.Contains(user_name) && x.Password.Contains(pass) && x.IsActive == true);
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
