﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class luxoftdatabaseEntities : DbContext
    {
        public luxoftdatabaseEntities()
            : base("name=luxoftdatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<string> getUserLinks(string userIdent)
        {
            var userIdentParameter = userIdent != null ?
                new ObjectParameter("userIdent", userIdent) :
                new ObjectParameter("userIdent", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getUserLinks", userIdentParameter);
        }
    
        public virtual ObjectResult<string> incrementLink(Nullable<int> linkId)
        {
            var linkIdParameter = linkId.HasValue ?
                new ObjectParameter("LinkId", linkId) :
                new ObjectParameter("LinkId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("incrementLink", linkIdParameter);
        }
    
        public virtual ObjectResult<string> insertLinkOrCreateUser(string fullLink, Nullable<int> userId)
        {
            var fullLinkParameter = fullLink != null ?
                new ObjectParameter("fullLink", fullLink) :
                new ObjectParameter("fullLink", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("insertLinkOrCreateUser", fullLinkParameter, userIdParameter);
        }
    }
}
