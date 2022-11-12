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
    public class QLLoaiPhongController : ApiController
    {
        QLKhachSanDBContext dBContext = new QLKhachSanDBContext();
        public IEnumerable<QLLoaiPhong> GetLoaiPhong()
        {
            var query = from x in dBContext.LOAI_PHONG
                        select new QLLoaiPhong
                        {
                            Id = x.ID_LOAI_PHONG,
                            TenLoaiPhong = x.TENLOAIPHONG,
                            Gia = (int)x.GIA,
                            SoGiuong = (int)x.SOGIUONG
                        };
            var lp = query.ToList();
            return lp;
        }

        public IEnumerable<QLLoaiPhong> GetLoaiPhongById(int id)
        {
            var query = from x in dBContext.LOAI_PHONG
                        where x.ID_LOAI_PHONG == id
                        select new QLLoaiPhong
                        {
                            Id = x.ID_LOAI_PHONG,
                            TenLoaiPhong = x.TENLOAIPHONG,
                            Gia = (int)x.GIA,
                            SoGiuong = (int)x.SOGIUONG
                        };
            return query;
        }

        //public IHttpActionResult Post([FromBody] LOAI_PHONG loaiphong)
        //{
        //    dBContext.LOAI_PHONG.Add(loaiphong);
        //    dBContext.SaveChanges();
        //    return Ok();
        //}

        public HttpResponseMessage Post([FromBody] LOAI_PHONG loaiphong)
        {
            try
            {
                dBContext.LOAI_PHONG.Add(loaiphong);
                dBContext.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, loaiphong);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Created, ex);
            }

        }

        public IHttpActionResult Put(int id, [FromBody] LOAI_PHONG loaiphong)
        {
            var query = (from x in dBContext.LOAI_PHONG
                         where x.ID_LOAI_PHONG == id
                         select x).FirstOrDefault();
            if (query != null)
            {
                query.TENLOAIPHONG = loaiphong.TENLOAIPHONG;
                query.GIA = loaiphong.GIA;
                query.SOGIUONG = loaiphong.SOGIUONG;
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
            var deletelp = (from x in dBContext.LOAI_PHONG
                            where x.ID_LOAI_PHONG == id
                            select x).FirstOrDefault();
            dBContext.LOAI_PHONG.Remove(deletelp);
            dBContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetLoaiPhong()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var loaiphong = dbContext.LOAI_PHONG.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, loaiphong);
        //    }
        //} //GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.LOAI_PHONG.FirstOrDefault(e => e.ID_LOAI_PHONG == id);
        //        if(entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin loai phong");
        //        }
        //    }
        //} //GET(int id)

        //public HttpResponseMessage Post([FromBody] LOAI_PHONG loaiphong)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.LOAI_PHONG.Add(loaiphong);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, loaiphong);
        //            message.Headers.Location = new Uri(Request.RequestUri + loaiphong.ID_LOAI_PHONG.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST

        //public HttpResponseMessage Put(int id, [FromBody] LOAI_PHONG loaiphong)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.LOAI_PHONG.FirstOrDefault(e => e.ID_LOAI_PHONG == id);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin loai phong");
        //            }
        //            else
        //            {
        //                entity.TENLOAIPHONG = loaiphong.TENLOAIPHONG;
        //                entity.GIA = loaiphong.GIA;
        //                entity.SOGIUONG = loaiphong.SOGIUONG;
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} // PUT()

        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.LOAI_PHONG.FirstOrDefault(e => e.ID_LOAI_PHONG == id);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin loai phong");
        //            }
        //            else
        //            {
        //                dbContext.LOAI_PHONG.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, "Loai phong voi id " + id.ToString() + " da duoc xoa");
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //DELETE()


    }
}
