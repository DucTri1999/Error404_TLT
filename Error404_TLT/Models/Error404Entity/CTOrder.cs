//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Error404_TLT.Models.Error404Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTOrder
    {
        public string MaDH { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Description { get; set; }
        public Nullable<int> SL { get; set; }
        public Nullable<int> GiaBan { get; set; }
        public Nullable<int> Tong { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}