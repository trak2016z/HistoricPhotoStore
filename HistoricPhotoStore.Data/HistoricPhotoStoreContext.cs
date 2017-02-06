using HistoricPhotoStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricPhotoStore.Data
{
    public class HistoricPhotoStoreContext : DbContext
    {
        public HistoricPhotoStoreContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<Image> Images { get; set; }
    }
}