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
    public class VatTuController : ApiController
    {
        QLKhachSanDBContext dbContext = new QLKhachSanDBContext();

        [HttpGet]
        public IHttpActionResult GetVatTu()
        {
            var vattu = (from x in dbContext.VAT_TU
                         select new VatTu
                         {
                             MaVatTu = x.MA_VAT_TU,
                             TenVatTu = x.TENVATTU,
                             DonGia = (int)x.DONGIA
                         });
            var vattus = vattu.ToList();
            return Ok(vattus);
        }

        public IQueryable<VatTu> GetVatTuById(int mavattu)
        {
            var vattu = (from x in dbContext.VAT_TU
                         where x.MA_VAT_TU.Equals(mavattu)
                         select new VatTu 
                         { 
                             MaVatTu = x.MA_VAT_TU,
                             TenVatTu = x.TENVATTU,
                             DonGia = (int)x.DONGIA
                         });
            return vattu;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] VAT_TU vattu)
        {
            dbContext.VAT_TU.Add(vattu);
            dbContext.SaveChanges();
            return Ok();
        }


        public IHttpActionResult Put(int mavattu, [FromBody] VAT_TU vattu)
        {
            var query = (from x in dbContext.VAT_TU where x.MA_VAT_TU.Equals(mavattu) select x).FirstOrDefault();
            if(query!= null)
            {
                query.TENVATTU = vattu.TENVATTU;
                query.DONGIA = vattu.DONGIA;
                dbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }


        public IHttpActionResult Delete(int mavattu)
        {
            var deletevattu = (from x in dbContext.VAT_TU where x.MA_VAT_TU.Equals(mavattu) select x).FirstOrDefault();
            dbContext.VAT_TU.Remove(deletevattu);
            dbContext.SaveChanges();
            return Ok();
        }
        //public HttpResponseMessage GetVatTu()
        //{
        //    using (QLkhachsanDBContext dbContext = new QLkhachsanDBContext())
        //    {
        //        var vattus = dbContext.VAT_TUs.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, vattus);
        //    }
        //}//GET()

        //public HttpResponseMessage Get(int id)
        //{
        //    using (QLkhachsanDBContext dbContext = new QLkhachsanDBContext())
        //    {
        //        var entity = dbContext.VAT_TUs.FirstOrDefault(e => e.MA_VAT_TU == id);
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

        //public HttpResponseMessage Post([FromBody] VAT_TU vattu)
        //{
        //    try
        //    {
        //        using (QLkhachsanDBContext dbContext = new QLkhachsanDBContext())
        //        {
        //            dbContext.VAT_TUs.Add(vattu);
        //            dbContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, vattu);
        //            message.Headers.Location = new Uri(Request.RequestUri + vattu.MA_VAT_TU.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST()

        //public HttpResponseMessage Put(int id, [FromBody] VAT_TU vattu)
        //{
        //    try
        //    {
        //        using (QLkhachsanDBContext dbContext = new QLkhachsanDBContext())
        //        {
        //            var entity = dbContext.VAT_TU.FirstOrDefault(e => e.MA_VAT_TU == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay thong tin vat tu");
        //            }
        //            else
        //            {
        //                entity.TENVATTU = vattu.TENVATTU;
        //                entity.DONGIA = vattu.DONGIA;
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
        //        using (QLkhachsanDBContext dbContext = new QLkhachsanDBContext())
        //        {
        //            var entity = dbContext.VAT_TU.FirstOrDefault(e => e.MA_VAT_TU == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay trong co so du lieu");
        //            }
        //            else
        //            {
        //                dbContext.VAT_TU.Remove(entity);
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
