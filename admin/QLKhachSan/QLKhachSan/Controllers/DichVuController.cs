using QLKhachSan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QLKhachSan.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("")]
    public class DichVuController : ApiController
    {
        QLKhachSanDBContext dBContext = new QLKhachSanDBContext();

        public IEnumerable<DichVu> GetDichVu()
        {
            var query = from x in dBContext.DICH_VU
                        select new DichVu
                        {
                            id = x.ID_DICH_VU,
                            TenDichVu = x.TENDICHVU,
                            Gia = (int)x.GIA,
                            TinhTrang = x.TINHTRANG
                        }; ;
            var dv = query.ToList();
            return dv;
        }

        public IEnumerable<DichVu> GetDichVuByIt(int id)
        {
            var query = from x in dBContext.DICH_VU
                        where x.ID_DICH_VU == id
                        select new DichVu
                        {
                            id = x.ID_DICH_VU,
                            TenDichVu = x.TENDICHVU,
                            Gia = (int)x.GIA,
                            TinhTrang = x.TINHTRANG
                        };
            return query;
        }

        public IHttpActionResult Post([FromBody] DICH_VU dichvu)
        {
            dBContext.DICH_VU.Add(dichvu);
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] DICH_VU dichvu)
        {
            var query = (from x in dBContext.DICH_VU
                         where x.ID_DICH_VU == id
                         select x).FirstOrDefault();
            if(query != null)
            {
                query.TENDICHVU = dichvu.TENDICHVU;
                query.GIA = dichvu.GIA;
                query.TINHTRANG = dichvu.TINHTRANG;
                dBContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var deletedv = (from x in dBContext.DICH_VU
                            where x.ID_DICH_VU == id
                            select x).FirstOrDefault();
            dBContext.DICH_VU.Remove(deletedv);
            dBContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetDichVu()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var dichvus = dbContext.DICH_VU.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, dichvus);
        //    }
        //}//GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.DICH_VU.FirstOrDefault(e => e.ID_DICH_VU == id);
        //        if(entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay dich vu");
        //        }
        //    }
        //} //GET(int id)

        //public HttpResponseMessage Post([FromBody] DICH_VU dichvu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.DICH_VU.Add(dichvu);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, dichvu);
        //            message.Headers.Location = new Uri(Request.RequestUri + dichvu.ID_DICH_VU.ToString());
        //            return message;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST()

        //public HttpResponseMessage Put(int id, [FromBody] DICH_VU dichvu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.DICH_VU.FirstOrDefault(e => e.ID_DICH_VU == id);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay dich vu");
        //            }
        //            else
        //            {
        //                entity.TENDICHVU = dichvu.TENDICHVU;
        //                entity.GIA = dichvu.GIA;
        //                entity.TINHTRANG = dichvu.TINHTRANG;
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //PUT()

        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.DICH_VU.FirstOrDefault(e => e.ID_DICH_VU == id);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay trong co so du lieu");
        //            }
        //            else
        //            {
        //                dbContext.DICH_VU.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK,"Doi tuong nay da duoc xoa khoi kho du lieu");
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}//Delete()
    }
}
