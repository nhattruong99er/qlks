using QLKhachSan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QLKhachSan.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class LoginController : ApiController
    {

        public HttpResponseMessage GetLogin(string username, string password)
        {
            using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
            {
                var loginFalse = "login false";
                var log = dbContext.NHANVIENs.Where(e => e.USERNAME.Equals(username) && e.PASSWORD.Equals(password)).FirstOrDefault();
                if (log != null)
                {
                    var query = from x in dbContext.NHANVIENs
                                where x.USERNAME.Equals(username) && x.PASSWORD.Equals(password)
                                select new Login
                                { 
                                    UserName = x.USERNAME,
                                    manhanvien = x.MANHANVIEN,
                                    loaitk = x.LOAITK
                                };
                    //return query; 
                    var logi = query.ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, logi);
                }
               else {
                    return Request.CreateResponse(HttpStatusCode.OK, loginFalse); 
                }

            }
        }

        //QLKhachSanDBContext dbContext = new QLKhachSanDBContext();
        //public IEnumerable<Login> GetLogin(string UserName, string Password)
        //{
        //    //List<Login> logi;
        //    var log = dbContext.NHANVIENs.Where(e => e.USERNAME.Equals(UserName) && e.PASSWORD.Equals(UserName)).FirstOrDefault();
        //    if(log != null) {             
        //        var query = from x in dbContext.NHANVIENs
        //        where x.USERNAME.Equals(UserName) && x.PASSWORD.Equals(Password)
        //        select new Login
        //           {
        //             UserName = x.USERNAME,
        //             Password = x.PASSWORD,
        //             manhanvien = x.MANHANVIEN,
        //             loaitk = x.LOAITK
        //            };
        //        logi = query.ToList();
        //        return logi;
        //    }

        //    //return logi;
        //}

    }
}
