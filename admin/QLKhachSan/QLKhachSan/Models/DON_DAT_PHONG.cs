//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKhachSan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DON_DAT_PHONG
    {
        public DON_DAT_PHONG()
        {
            this.CHI_TIET_HOA_DON = new HashSet<CHI_TIET_HOA_DON>();
        }
    
        public int ID_DON_DAT_PHONG { get; set; }
        public Nullable<int> ID_KHACH_HANG { get; set; }
        public Nullable<System.DateTime> NGAYDAT { get; set; }
        public Nullable<System.DateTime> NGAYDEN { get; set; }
        public Nullable<System.DateTime> NGAYDI { get; set; }
        public Nullable<int> SOLUONGNGUOIDICUNG { get; set; }
        public string TRANGTHAI { get; set; }
    
        public virtual ICollection<CHI_TIET_HOA_DON> CHI_TIET_HOA_DON { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
