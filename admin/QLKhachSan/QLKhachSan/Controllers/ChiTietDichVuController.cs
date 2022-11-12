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
    public class ChiTietDichVuController : ApiController
    {
        QLKhachSanDBContext dBContext = new QLKhachSanDBContext();

        public IEnumerable<ChiTietDichVu> GetChiTietDichVu()
        {
            var query = from x in dBContext.CHI_TIET_DICH_VU
                        join y in dBContext.DICH_VU on x.ID_DICH_VU equals y.ID_DICH_VU
                        select new ChiTietDichVu
                        {
                            id = x.ID_CHI_TIET_DICH_VU,
                            TenPhong = x.TEN_PHONG,
                            TenDichVu = y.TENDICHVU,
                            SoLuong = (int)x.SOLUONG,
                            ThanhTien = (int)x.THANHTIEN
                        };
            var chitietdichvu = query.ToList();
            return chitietdichvu;
        }

        public IEnumerable<ChiTietDichVu> GetChiTietDichVuById(int id)
        {
            var query = from x in dBContext.CHI_TIET_DICH_VU
                        join y in dBContext.DICH_VU on x.ID_DICH_VU equals y.ID_DICH_VU
                        where x.ID_CHI_TIET_DICH_VU == id
                        select new ChiTietDichVu
                        {
                            TenPhong = x.TEN_PHONG,
                            TenDichVu = y.TENDICHVU,
                            SoLuong = (int)x.SOLUONG,
                            ThanhTien = (int)x.THANHTIEN
                        };
            return query;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CHI_TIET_DICH_VU chitietdichvu)
        {
            dBContext.CHI_TIET_DICH_VU.Add(chitietdichvu);
            //dBContext.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] CHI_TIET_DICH_VU chitiet)
        {
            var query = (from x in dBContext.CHI_TIET_DICH_VU
                         join y in dBContext.DICH_VU on x.ID_DICH_VU equals y.ID_DICH_VU
                         where x.ID_CHI_TIET_DICH_VU == id
                         select x).FirstOrDefault();
            if (query != null)
            {
                //query.ID_DICH_VU = chitiet.ID_DICH_VU;
                query.SOLUONG = chitiet.SOLUONG;
                query.THANHTIEN = chitiet.THANHTIEN;
                dBContext.SaveChanges();
            }
            else return NotFound();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var deletect = (from x in dBContext.CHI_TIET_DICH_VU
                            where x.ID_CHI_TIET_DICH_VU == id
                            select x).FirstOrDefault();
            dBContext.CHI_TIET_DICH_VU.Remove(deletect);
            dBContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetDichVu()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var chitietdichvus = dbContext.CHI_TIET_DICH_VU.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, chitietdichvus);
        //    }
        //} //GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.CHI_TIET_DICH_VU.FirstOrDefault(e => e.ID_CHI_TIET_DICH_VU == id);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay dich vu nay");
        //        }
        //    }
        //} //GET(int id)

        //public HttpResponseMessage Post([FromBody] CHI_TIET_DICH_VU chitietdichvu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.CHI_TIET_DICH_VU.Add(chitietdichvu);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, chitietdichvu);
        //            message.Headers.Location = new Uri(Request.RequestUri + chitietdichvu.ID_CHI_TIET_DICH_VU.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST()

        //public HttpResponseMessage Put(int id, [FromBody] CHI_TIET_DICH_VU chitietdichvu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.CHI_TIET_DICH_VU.FirstOrDefault(e => e.ID_CHI_TIET_DICH_VU == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay dich vu nay");
        //            }
        //            else
        //            {
        //                entity.TEN_PHONG = chitietdichvu.TEN_PHONG;
        //                entity.ID_DICH_VU = chitietdichvu.ID_DICH_VU;
        //                entity.SOLUONG = chitietdichvu.SOLUONG;
        //                entity.THANHTIEN = chitietdichvu.THANHTIEN;
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
        //            var entity = dbContext.CHI_TIET_DICH_VU.FirstOrDefault(e => e.ID_CHI_TIET_DICH_VU == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Dich vu khong tim thay");
        //            }
        //            else
        //            {
        //                dbContext.CHI_TIET_DICH_VU.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, "Dich vu voi id " + id.ToString() + " da duoc xoa");
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
