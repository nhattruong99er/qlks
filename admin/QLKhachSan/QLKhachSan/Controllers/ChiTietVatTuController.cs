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
    public class ChiTietVatTuController : ApiController
    {
        QLKhachSanDBContext dbContext = new QLKhachSanDBContext();

        public IEnumerable<ChiTietVatTu> GetChiTietVatTu()
        {
            var query = from x in dbContext.CHI_TIET_VAT_TU
                        join y in dbContext.LOAI_PHONG on x.ID_LOAI_PHONG equals y.ID_LOAI_PHONG
                        join z in dbContext.VAT_TU on x.MA_VAT_TU equals z.MA_VAT_TU
                        select new ChiTietVatTu
                        {
                            id = x.ID,
                            TenVatTu = z.TENVATTU,
                            LoaiPhong = y.TENLOAIPHONG,
                            SoLuong = (int)x.SOLUONG,
                            TinhTrang = x.TINHTRANG
                        };
            var chitiet = query.ToList();
            return chitiet;
        }

        public IEnumerable<ChiTietVatTu> GetChiTietVatTuById(int id)
        {
            var query = from x in dbContext.CHI_TIET_VAT_TU
                        join y in dbContext.LOAI_PHONG on x.ID_LOAI_PHONG equals y.ID_LOAI_PHONG
                        join z in dbContext.VAT_TU on x.MA_VAT_TU equals z.MA_VAT_TU
                        where x.ID == id
                        select new ChiTietVatTu
                        {
                            id = x.ID,
                            TenVatTu = z.TENVATTU,
                            LoaiPhong = y.TENLOAIPHONG,
                            SoLuong = (int)x.SOLUONG,
                            TinhTrang = x.TINHTRANG
                        };
            return query;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] CHI_TIET_VAT_TU chitiet)
        {
            dbContext.CHI_TIET_VAT_TU.Add(chitiet);
            return Ok();
        }

        public IHttpActionResult Put(int id, [FromBody] CHI_TIET_VAT_TU chitiet)
        {
            var query = (from x in dbContext.CHI_TIET_VAT_TU
                         where x.ID == id
                         select x).FirstOrDefault();
            if (query != null)
            {
                //query.MA_VAT_TU = chitiet.MA_VAT_TU;
                query.ID_LOAI_PHONG = chitiet.ID_LOAI_PHONG;
                query.SOLUONG = chitiet.SOLUONG;
                query.TINHTRANG = chitiet.TINHTRANG;
                dbContext.SaveChanges();
            }
            else return NotFound();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var deletevt = (from x in dbContext.CHI_TIET_VAT_TU
                            where x.ID == id
                            select x).FirstOrDefault();
            dbContext.CHI_TIET_VAT_TU.Remove(deletevt);
            dbContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetChiTietVatTu()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var chitietvattus = dbContext.CHI_TIET_VAT_TU.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, chitietvattus);
        //    }
        //}//GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.CHI_TIET_VAT_TU.FirstOrDefault(e => e.ID == id);
        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin vat tu");
        //        }
        //    }
        //} //GET(int id)

        //public HttpResponseMessage Post([FromBody] CHI_TIET_VAT_TU chitietvattu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            dbContext.CHI_TIET_VAT_TU.Add(chitietvattu);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, chitietvattu);
        //            message.Headers.Location = new Uri(Request.RequestUri + chitietvattu.ID.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST()

        //public HttpResponseMessage Put(int id, [FromBody] CHI_TIET_VAT_TU chitietvattu)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dbContext.CHI_TIET_VAT_TU.FirstOrDefault(e => e.ID == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin vat tu");
        //            }
        //            else
        //            {
        //                entity.MA_VAT_TU = chitietvattu.MA_VAT_TU;
        //                entity.ID_LOAI_PHONG = chitietvattu.ID_LOAI_PHONG;
        //                entity.SOLUONG = chitietvattu.SOLUONG;
        //                entity.TINHTRANG = chitietvattu.TINHTRANG;
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
        //            var entity = dbContext.CHI_TIET_VAT_TU.FirstOrDefault(e => e.ID == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay trong co so du lieu");
        //            }
        //            else
        //            {
        //                dbContext.CHI_TIET_VAT_TU.Remove(entity);
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
