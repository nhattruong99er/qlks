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
    public class DonDatPhongController : ApiController
    {
        QLKhachSanDBContext dbContext = new QLKhachSanDBContext();


        public IEnumerable<DonDatPhong> GetDonDatPhong()
        {
            var query = from x in dbContext.DON_DAT_PHONG
                        join y in dbContext.KHACHHANGs on x.ID_KHACH_HANG equals y.ID_KHACH_HANG
                        select new DonDatPhong
                        {
                            TenKhachHang = y.HOTEN,
                            Cmnd = y.CMND,
                            NgayDat = (DateTime)x.NGAYDAT,
                            NgayDen = (DateTime)x.NGAYDEN,
                            NgayDi = (DateTime)x.NGAYDI,
                            SoLuongNguoiDiCung = (int)x.SOLUONGNGUOIDICUNG,
                            TrangThai = x.TRANGTHAI
                        };
            var dondatphong = query.ToList();
            return dondatphong;
        }


        public IEnumerable<DonDatPhong> GetDonDatPhongById(int id)
        {
            var query = from x in dbContext.DON_DAT_PHONG
                        join y in dbContext.KHACHHANGs on x.ID_KHACH_HANG equals y.ID_KHACH_HANG
                        where x.ID_DON_DAT_PHONG.Equals(id)
                        select new DonDatPhong
                        {
                            TenKhachHang = y.HOTEN,
                            Cmnd = y.CMND,
                            NgayDat = (DateTime)x.NGAYDAT,
                            NgayDen = (DateTime)x.NGAYDEN,
                            NgayDi = (DateTime)x.NGAYDI,
                            SoLuongNguoiDiCung = (int)x.SOLUONGNGUOIDICUNG,
                            TrangThai = x.TRANGTHAI
                        };
            return query;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] DON_DAT_PHONG dondat)
        {
            dbContext.DON_DAT_PHONG.Add(dondat);
            dbContext.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] DON_DAT_PHONG dondat)
        {
            var query = (from x in dbContext.DON_DAT_PHONG 
                         join y in dbContext.KHACHHANGs on x.ID_KHACH_HANG equals y.ID_KHACH_HANG
                         where x.ID_DON_DAT_PHONG.Equals(id) select x).FirstOrDefault();
            if(query != null)
            {
                //query.KHACHHANG = dondat.KHACHHANG;
                query.NGAYDAT = dondat.NGAYDAT;
                query.NGAYDEN = dondat.NGAYDEN;
                query.NGAYDI = dondat.NGAYDI;
                query.SOLUONGNGUOIDICUNG = dondat.SOLUONGNGUOIDICUNG;
                query.TRANGTHAI = dondat.TRANGTHAI;
                dbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Delete (int id)
        {
            var deletedd = (from x in dbContext.DON_DAT_PHONG where x.ID_DON_DAT_PHONG == id select x).FirstOrDefault();
            dbContext.DON_DAT_PHONG.Remove(deletedd);
            dbContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetDonDatPhong()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var phongs = dbContext.DON_DAT_PHONG.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, phongs);
        //    }
        //} //GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.DON_DAT_PHONG.FirstOrDefault(e => e.ID_DON_DAT_PHONG == id);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay don dat phong");
        //        }
        //    }
        //} //GET(string tenphong)

        //public HttpResponseMessage Post([FromBody] DON_DAT_PHONG dondatphong)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.DON_DAT_PHONG.Add(dondatphong);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, dondatphong);
        //            message.Headers.Location = new Uri(Request.RequestUri + dondatphong.ID_DON_DAT_PHONG.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST()

        //public HttpResponseMessage Put(int id, [FromBody] DON_DAT_PHONG dondatphong)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.DON_DAT_PHONG.FirstOrDefault(e => e.ID_DON_DAT_PHONG == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay don dat phong");
        //            }
        //            else
        //            {
        //                entity.ID_KHACH_HANG = dondatphong.ID_KHACH_HANG;
        //                entity.NGAYDAT = dondatphong.NGAYDAT;
        //                entity.NGAYDEN = dondatphong.NGAYDEN;
        //                entity.NGAYDI = dondatphong.NGAYDI;
        //                entity.SOLUONGNGUOIDICUNG = dondatphong.SOLUONGNGUOIDICUNG;
        //                entity.TRANGTHAI = dondatphong.TRANGTHAI;
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
        //            var entity = dbContext.DON_DAT_PHONG.FirstOrDefault(e => e.ID_DON_DAT_PHONG == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay don dat phong");
        //            }
        //            else
        //            {
        //                dbContext.DON_DAT_PHONG.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, "Phong co ten " + id.ToString() + "da duoc xoa");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} // DELETE()
    }
}
