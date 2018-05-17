﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WareItsMade.com.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WaresEntities : DbContext
    {
        public WaresEntities()
            : base("name=WaresEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Commodity> Commoditys { get; set; }
        public virtual DbSet<Family> Familys { get; set; }
        public virtual DbSet<Iso3166> Iso3166 { get; set; }
        public virtual DbSet<Iso3166_2> Iso3166_2 { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<Unspsc> Unspscs { get; set; }
    
        public virtual ObjectResult<GetWeightedCommodities_Result> GetWeightedCommodities(string commodityId, string countryId, Nullable<int> ownershipWeight, Nullable<int> capitalWeight, Nullable<int> laborWeight, Nullable<int> landWeight)
        {
            var commodityIdParameter = commodityId != null ?
                new ObjectParameter("CommodityId", commodityId) :
                new ObjectParameter("CommodityId", typeof(string));
    
            var countryIdParameter = countryId != null ?
                new ObjectParameter("CountryId", countryId) :
                new ObjectParameter("CountryId", typeof(string));
    
            var ownershipWeightParameter = ownershipWeight.HasValue ?
                new ObjectParameter("OwnershipWeight", ownershipWeight) :
                new ObjectParameter("OwnershipWeight", typeof(int));
    
            var capitalWeightParameter = capitalWeight.HasValue ?
                new ObjectParameter("CapitalWeight", capitalWeight) :
                new ObjectParameter("CapitalWeight", typeof(int));
    
            var laborWeightParameter = laborWeight.HasValue ?
                new ObjectParameter("LaborWeight", laborWeight) :
                new ObjectParameter("LaborWeight", typeof(int));
    
            var landWeightParameter = landWeight.HasValue ?
                new ObjectParameter("LandWeight", landWeight) :
                new ObjectParameter("LandWeight", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetWeightedCommodities_Result>("GetWeightedCommodities", commodityIdParameter, countryIdParameter, ownershipWeightParameter, capitalWeightParameter, laborWeightParameter, landWeightParameter);
        }
    }
}
