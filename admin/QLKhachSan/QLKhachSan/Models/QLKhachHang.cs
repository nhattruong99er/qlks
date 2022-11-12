using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKhachSan.Models
{
    public class QLKhachHang
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Cmnd { get; set; }
    }
}