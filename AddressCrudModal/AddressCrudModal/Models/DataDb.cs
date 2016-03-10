using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AddressCrudModal.Models
{
    public class DataDb : DbContext 
    {
        public DataDb()
            : base("name=DataDb")
        {
        }

        public System.Data.Entity.DbSet<AddressCrudModal.Models.Address> Addresses { get; set; }
    }
}