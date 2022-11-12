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
    public class QLNhanVienController : ApiController
    {
        QLKhachSanDBContext dbContext = new QLKhachSanDBContext();

        [HttpGet]
        public IEnumerable<QLNhanVien> GetNhanVien()
        {
            var query = from x in dbContext.NHANVIENs
                        select new QLNhanVien
                        {
                            MaNhanVien = x.MANHANVIEN,
                            HoTen = x.HOTEN,
                            UserName = x.USERNAME,
                            Password = x.PASSWORD,
                            Sdt = x.SDT,
                            Email = x.EMAIL,
                            NgaySinh = (DateTime)x.NGAYSINH,
                            Gioitinh = x.GIOITINH,
                            ChucVu = x.CHUCVU,
                            Loaitk = x.LOAITK
                        };
            var nv = query.ToList();
            return nv;
        }

        //public IEnumerable<QLNhanVien> GetNhanVienById(string manhanvien)
        //{
        //    var query = from x in dbContext.NHANVIENs
        //                where x.MANHANVIEN.Equals(manhanvien)
        //                select new QLNhanVien
        //                {
        //                    MaNhanVien = x.MANHANVIEN,
        //                    HoTen = x.HOTEN,
        //                    UserName = x.USERNAME,
        //                    Password = x.PASSWORD,
        //                    Sdt = x.SDT,
        //                    Email = x.EMAIL,
        //                    NgaySinh = (DateTime)x.NGAYSINH,
        //                    Gioitinh = x.GIOITINH,
        //                    ChucVu = x.CHUCVU,
        //                    Loaitk = x.LOAITK
        //                };
        //    //var nv = query.ToList();
        //    //return nv;
        //    return query;
        //}

        public HttpResponseMessage GetNhanVienById(string manhanvien)
        {
            using (QLKhachSanDBContext db = new QLKhachSanDBContext())
            {
                var getFalse = "getfalse";
                var log = db.NHANVIENs.Where(e => e.MANHANVIEN.Equals(manhanvien)).FirstOrDefault();
                if (log != null)
                {
                    var query = from x in db.NHANVIENs
                                where x.MANHANVIEN.Equals(manhanvien)
                                select new QLNhanVien
                                {
                                    MaNhanVien = x.MANHANVIEN,
                                    HoTen = x.HOTEN,
                                    UserName = x.USERNAME,
                                    Password = x.PASSWORD,
                                    Sdt = x.SDT,
                                    Email = x.EMAIL,
                                    NgaySinh = (DateTime)x.NGAYSINH,
                                    Gioitinh = x.GIOITINH,
                                    ChucVu = x.CHUCVU,
                                    Loaitk = x.LOAITK
                                };
                    var nv = query.ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, nv);
                    //return query;
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.OK, getFalse);
                }

            }
        }


        public HttpResponseMessage Post([FromBody] NHANVIEN nhanvien)
        {
            try
            {
                dbContext.NHANVIENs.Add(nhanvien);
                dbContext.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, nhanvien);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Created, ex);
            }

        }

        public IHttpActionResult Put(string manhanvien, [FromBody] NHANVIEN nhanvien)
        {
            var query = (from x in dbContext.NHANVIENs where x.MANHANVIEN.Equals(manhanvien) select x).FirstOrDefault();
            if (query != null)
            {
                //query.MANHANVIEN = nhanvien.MANHANVIEN;
                query.HOTEN = nhanvien.HOTEN;
                query.USERNAME = nhanvien.USERNAME;
                query.PASSWORD = nhanvien.PASSWORD;
                query.SDT = nhanvien.SDT;
                query.EMAIL = nhanvien.EMAIL;
                query.NGAYSINH = nhanvien.NGAYSINH;
                query.GIOITINH = nhanvien.GIOITINH;
                query.CHUCVU = nhanvien.CHUCVU;
                query.LOAITK = nhanvien.LOAITK;
                dbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        //[HttpDelete]
        public IHttpActionResult Delete(string manhanvien)
        {
            var deletenv = (from x in dbContext.NHANVIENs where x.MANHANVIEN.Equals(manhanvien) select x).FirstOrDefault();
            dbContext.NHANVIENs.Remove(deletenv);
            dbContext.SaveChanges();
            return Ok("Deleted!");
        }

        //public HttpResponseMessage GetNhanvien()
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var Nhanviens = dbContext.NHANVIENs.ToList();
        //        return Request.CreateResponse(HttpStatusCode.OK, Nhanviens);
        //    }
        //} //Get()


        //public HttpResponseMessage Get(string manhanvien)
        //{
        //    using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //    {
        //        var entity = dbContext.NHANVIENs.FirstOrDefault(e => e.MANHANVIEN == manhanvien);
        //        if(entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay nguoi nay trong co so du lieu.");
        //        }
        //    }
        //} //Get(string manhanvien)


        //public HttpResponseMessage Post([FromBody] NHANVIEN nhanvien)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dBContext = new QLKhachSanDBContext())
        //        {
        //            dBContext.NHANVIENs.Add(nhanvien);
        //            dBContext.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, nhanvien);
        //            message.Headers.Location = new Uri(Request.RequestUri + nhanvien.MANHANVIEN.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //POST


        //public HttpResponseMessage Put(string manhanvien, [FromBody] NHANVIEN qlnhanvien)
        //{
        //    try
        //    {
        //        using (QLKhachSanDBContext dBContext = new QLKhachSanDBContext())
        //        {
        //            var entity = dBContext.NHANVIENs.FirstOrDefault(e => e.MANHANVIEN == manhanvien);
        //            if(entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK,"Khong tim thay nguoi nay trong co so du lieu.");
        //            }
        //            else
        //            {
        //                entity.HOTEN = qlnhanvien.HOTEN;
        //                entity.USERNAME = qlnhanvien.USERNAME;
        //                entity.PASSWORD = qlnhanvien.PASSWORD;
        //                entity.SDT = qlnhanvien.SDT;
        //                entity.EMAIL = qlnhanvien.EMAIL;
        //                entity.NGAYSINH = qlnhanvien.NGAYSINH;
        //                entity.GIOITINH = qlnhanvien.GIOITINH;
        //                entity.CHUCVU = qlnhanvien.CHUCVU;
        //                entity.LOAITK = qlnhanvien.LOAITK;
        //                dBContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} // PUT()


        //public HttpResponseMessage Delete(string manhanvien)
        //{
        //    try
        //    {
        //        //using (QLKhachSanDBContext dbContext = new QLKhachSanDBContext())
        //        //{
        //            var entity = dbContext.NHANVIENs.FirstOrDefault(e => e.MANHANVIEN == manhanvien);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.OK, "Khong tim thay nguoi nay trong co so du lieu.");
        //            }
        //            else
        //            {
        //                dbContext.NHANVIENs.Remove(entity);
        //                dbContext.SaveChanges();
        //                return Request.CreateResponse(HttpStatusCode.OK, "Xoa nhan vien thanh cong");
        //            }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //} //DELETE
    }
}
