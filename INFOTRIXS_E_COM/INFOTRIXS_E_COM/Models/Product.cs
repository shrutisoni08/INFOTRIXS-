//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INFOTRIXS_E_COM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int id { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public Nullable<decimal> ratingRate { get; set; }
        public Nullable<int> ratingCount { get; set; }
        public string image { get; set; }
        public string title { get; set; }
    }
}