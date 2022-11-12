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
    public class ChiTieuController : ApiController
    {
        QLKhachSanDBContext dbContext = new QLKhachSanDBContext();

        [HttpGet]
        public IEnumerable<ChiTieu> GetChiTieu()
        {
            var query = from x in dbContext.CHI_TIEU
                        select new ChiTieu
                        {
                            id = x.ID_CHI_TIET_CHI_TIEU,
                            TenHang = x.TENHANG,
                            DonViTinh = x.DONVITINH,
                            Gia = (int)x.GIA,
                            SoLuong = (int)x.SOLUONG,
                            ThanhTien = (int)x.THANHTIEN,
                            ThoiGian = (DateTime)x.THOIGIAN
                        };
            var ct = query.ToList();
            return ct;
        }

        public IEnumerable<ChiTieu> GetChiTieuById(int id)
        {
            var query = from x in dbContext.CHI_TIEU
                        where x.ID_CHI_TIET_CHI_TIEU == id
                        select new ChiTieu
                        {
                            TenHang = x.TENHANG,
                            DonViTinh = x.DONVITINH,
                            Gia = (int)x.GIA,
                            SoLuong = (int)x.SOLUONG,
                            ThanhTien = (int)x.THANHTIEN,
                            ThoiGian = (DateTime)x.THOIGIAN
                        };
            var ct = query.ToList();
            return ct;
        }

        public IHttpActionResult Post([FromBody] CHI_TIEU chitieu)
        {
            dbContext.CHI_TIEU.Add(chitieu);
            dbContext.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] CHI_TIEU chitieu)
        {
            var query = (from x in dbContext.CHI_TIEU
                         where x.ID_CHI_TIET_CHI_TIEU == id
                         select x).FirstOrDefault();
            if(query != null)
            {
                query.TENHANG = chitieu.TENHANG;
                query.DONVITINH = chitieu.DONVITINH;
                query.GIA = chitieu.GIA;
                query.SOLUONG = chitieu.SOLUONG;
                query.THANHTIEN = chitieu.THANHTIEN;
                query.THOIGIAN = chitieu.THOIGIAN;
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
            var deletect = (from x in dbContext.CHI_TIEU
                            where x.ID_CHI_TIET_CHI_TIEU == id
                            select x).FirstOrDefault();
            dbContext.CHI_TIEU.Remove(deletect);
            dbContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetChiTieu()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var chitieu = dbContext.CHI_TIEU.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, chitieu);
        //    }
        //}//GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.CHI_TIEU.FirstOrDefault(e => e.ID_CHI_TIET_CHI_TIEU == id);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin");
        //        }
        //    }
        //} //GET(int id)

        //public HttpResponseMessage Post([FromBody] CHI_TIEU chitieu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.CHI_TIEU.Add(chitieu);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, chitieu);
        //            message.Headers.Location = new Uri(Request.RequestUri + chitieu.ID_CHI_TIET_CHI_TIEU.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST()

        //public HttpResponseMessage Put(int id, [FromBody] CHI_TIEU chitieu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.CHI_TIEU.FirstOrDefault(e => e.ID_CHI_TIET_CHI_TIEU == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin");
        //            }
        //            else
        //            {
        //                entity.TENHANG = chitieu.TENHANG;
        //                entity.DONVITINH = chitieu.DONVITINH;
        //                entity.GIA = chitieu.GIA;
        //                entity.SOLUONG = chitieu.SOLUONG;
        //                entity.THANHTIEN = chitieu.THANHTIEN;
        //                entity.THOIGIAN = chitieu.THOIGIAN;
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
        //            var entity = dbContext.CHI_TIEU.FirstOrDefault(e => e.ID_CHI_TIET_CHI_TIEU == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay trong co so du lieu");
        //            }
        //            else
        //            {
        //                dbContext.CHI_TIEU.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, "Doi tuong nay da duoc xoa khoi kho du lieu");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}//Delete()
    }
}
