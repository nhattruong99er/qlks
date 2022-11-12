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
    public class QLPhongController : ApiController
    {
        QLKhachSanDBContext dbContext = new QLKhachSanDBContext();

        [HttpGet]
        public IEnumerable<QLPhong> GetPhong()
        {
            var phong = (from x in dbContext.PHONGs
                         join y in dbContext.LOAI_PHONG on x.ID_LOAIPHONG equals y.ID_LOAI_PHONG
                         select new QLPhong
                         { 
                             TenPhong = x.TEN_PHONG,
                             TenLoaiPhong = y.TENLOAIPHONG,
                             SoGiuong = (int)y.SOGIUONG,
                             Gia = (int)y.GIA,
                             ViTri = x.VITRI,
                             TrangThai = x.TRANGTHAI
                         });
            var chitietphong = phong.ToList();
            return chitietphong;
        }

        public IEnumerable<QLPhong> GetPhongById(string tenphong)
        {
            var phong = (from x in dbContext.PHONGs
                         join y in dbContext.LOAI_PHONG on x.ID_LOAIPHONG equals y.ID_LOAI_PHONG
                         where x.TEN_PHONG.Equals(tenphong)
                         select new QLPhong
                         {
                             TenPhong = x.TEN_PHONG,
                             TenLoaiPhong = y.TENLOAIPHONG,
                             SoGiuong = (int)y.SOGIUONG,
                             Gia = (int)y.GIA,
                             ViTri = x.VITRI,
                             TrangThai = x.TRANGTHAI
                         });
            return phong;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] PHONG phg)
        {
            dbContext.PHONGs.Add(phg);
            dbContext.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Put(string tenphong, [FromBody] PHONG qlphong)
        {
            var phong = (from x in dbContext.PHONGs where x.TEN_PHONG.Equals(tenphong) select x).FirstOrDefault();
            if(phong != null)
            {
                phong.ID_LOAIPHONG = qlphong.ID_LOAIPHONG;
                phong.VITRI = qlphong.VITRI;
                phong.TRANGTHAI = qlphong.TRANGTHAI;
                dbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(string tenphong)
        {
            var deletephong = (from x in dbContext.PHONGs where x.TEN_PHONG.Equals(tenphong) select x).FirstOrDefault();
            dbContext.PHONGs.Remove(deletephong);
            dbContext.SaveChanges();
            return Ok();
        }


        //public HttpResponseMessage GetPhong()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var phongs = dbContext.PHONGs.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, phongs);
        //    }
        //} //GET()

        //public HttpResponseMessage Get(string tenphong)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.PHONGs.FirstOrDefault(e => e.TEN_PHONG == tenphong);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK,"Khong tim thay phong");
        //        }
        //    }
        //} //GET(string tenphong)

        //public HttpResponseMessage Post(PHONG phong)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.PHONGs.Add(phong);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, phong);
        //            message.Headers.Location = new Uri(Request.RequestUri + phong.TEN_PHONG.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST()

        //public HttpResponseMessage Put(string tenphong, [FromBody] PHONG phong)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.PHONGs.FirstOrDefault(e => e.TEN_PHONG == tenphong);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK,"Khong tim thay phong");
        //            }
        //            else
        //            {
        //                entity.ID_LOAIPHONG = phong.ID_LOAIPHONG;
        //                entity.VITRI = phong.VITRI;
        //                entity.TRANGTHAI = phong.TRANGTHAI;
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

        //public HttpResponseMessage Delete(string tenphong)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.PHONGs.FirstOrDefault(e => e.TEN_PHONG == tenphong);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay phong");
        //            }
        //            else
        //            {
        //                dbContext.PHONGs.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, "Phong co ten " + tenphong.ToString() + "da duoc xoa");
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} // DELETE()
    }
}
