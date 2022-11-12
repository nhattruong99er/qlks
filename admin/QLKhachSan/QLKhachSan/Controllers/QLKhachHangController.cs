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
    public class QLKhachHangController : ApiController
    {
        QLKhachSanDBContext dbContext = new QLKhachSanDBContext();

        public IEnumerable<QLKhachHang> GetKhachHang()
        {
            var query = from x in dbContext.KHACHHANGs
                        select new QLKhachHang
                        {
                            //ID = x.ID_KHACH_HANG,
                            HoTen = x.HOTEN,
                            Sdt = x.SDT,
                            Email = x.EMAIL,
                            GioiTinh = x.GIOITINH,
                            NgaySinh = (DateTime)x.NGAYSINH,
                            Cmnd = x.CMND
                        };
            var kh = query.ToList();
            return kh;
        }

        public IEnumerable<QLKhachHang> GetKhachHangById(int id)
        {
            var query = from x in dbContext.KHACHHANGs
                        where x.ID_KHACH_HANG.Equals(id)
                        select new QLKhachHang
                        {
                            HoTen = x.HOTEN,
                            Sdt = x.SDT,
                            Email = x.EMAIL,
                            GioiTinh = x.GIOITINH,
                            NgaySinh = (DateTime)x.NGAYSINH,
                            Cmnd = x.CMND
                        };
            return query;
        }

        //public IHttpActionResult Post([FromBody] KHACHHANG khachhang)
        //{
        //    dbContext.KHACHHANGs.Add(khachhang);
        //    dbContext.SaveChanges();
        //    return Ok();
        //}

        public HttpResponseMessage Post([FromBody] KHACHHANG khachhang)
        {
            try
            {
                dbContext.KHACHHANGs.Add(khachhang);
                dbContext.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, khachhang);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Created, ex);
            }

        }

        public IHttpActionResult Put(int id, [FromBody] KHACHHANG khachhang)
        {
            var query = (from x in dbContext.KHACHHANGs
                         where x.ID_KHACH_HANG.Equals(id)
                         select x).FirstOrDefault();
            if(query != null)
            {
                //query.ID_KHACH_HANG = khachhang.ID_KHACH_HANG;
                query.HOTEN = khachhang.HOTEN;
                query.SDT = khachhang.SDT;
                query.EMAIL = khachhang.EMAIL;
                query.GIOITINH = khachhang.GIOITINH;
                query.NGAYSINH = khachhang.NGAYSINH;
                query.CMND = khachhang.CMND;
                dbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var deletekh = (from x in dbContext.KHACHHANGs
                            where x.ID_KHACH_HANG.Equals(id)
                            select x).FirstOrDefault();
            dbContext.KHACHHANGs.Remove(deletekh);
            dbContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetKhachHang()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var khachhangs = dbContext.KHACHHANGs.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, khachhangs);
        //    }
        //} //GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.KHACHHANGs.FirstOrDefault(e => e.ID_KHACH_HANG == id);
        //        if(entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin khach hang");
        //        }
        //    }
        //} //GET(int id)

        //public HttpResponseMessage Post([FromBody] KHACHHANG khachhang)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.KHACHHANGs.Add(khachhang);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, khachhang);
        //            message.Headers.Location = new Uri(Request.RequestUri + khachhang.ID_KHACH_HANG.ToString());
        //            return message;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);            }
        //} //POST()

        //public HttpResponseMessage Put(int id, [FromBody] KHACHHANG khachhang)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.KHACHHANGs.FirstOrDefault(e => e.ID_KHACH_HANG == id);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin khach hang");
        //            }
        //            else
        //            {
        //                entity.HOTEN = khachhang.HOTEN;
        //                entity.SDT = khachhang.SDT;
        //                entity.EMAIL = khachhang.EMAIL;
        //                entity.GIOITINH = khachhang.GIOITINH;
        //                entity.NGAYSINH = khachhang.NGAYSINH;
        //                entity.CMND = khachhang.CMND;
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
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
        //            var entity = dbContext.KHACHHANGs.FirstOrDefault(e => e.ID_KHACH_HANG == id);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin khach hang");
        //            }
        //            else
        //            {
        //                dbContext.KHACHHANGs.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    "Khach hang voi id " + id.ToString() + " da duoc xoa");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
    }
}
