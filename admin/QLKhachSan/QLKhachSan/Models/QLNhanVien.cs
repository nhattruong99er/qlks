using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKhachSan.Models
{
    public class QLNhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Gioitinh { get; set; }
        public string ChucVu { get; set; }
        public string Loaitk { get; set; }
    }
}