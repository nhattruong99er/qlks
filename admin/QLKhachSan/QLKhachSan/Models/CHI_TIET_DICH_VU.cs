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
    
    public partial class CHI_TIET_DICH_VU
    {
        public CHI_TIET_DICH_VU()
        {
            this.CHI_TIET_HOA_DON = new HashSet<CHI_TIET_HOA_DON>();
        }
    
        public int ID_CHI_TIET_DICH_VU { get; set; }
        public string TEN_PHONG { get; set; }
        public Nullable<int> ID_DICH_VU { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<int> THANHTIEN { get; set; }
    
        public virtual DICH_VU DICH_VU { get; set; }
        public virtual ICollection<CHI_TIET_HOA_DON> CHI_TIET_HOA_DON { get; set; }
    }
}
