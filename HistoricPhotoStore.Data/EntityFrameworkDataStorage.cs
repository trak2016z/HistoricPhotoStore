using HistoricPhotoStore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricPhotoStore.Data
{
    public class EntityFrameworkDataStorage : DataStorage
    {
        private readonly HistoricPhotoStoreContext context;

        public EntityFrameworkDataStorage(string connectionString)
        {
            context = new HistoricPhotoStoreContext(connectionString);
        }

        public string GetImageExtensionForID(Guid guid)
        {
            return context.Images.First(x => x.ID == guid).Extension;
        }

        public IEnumerable<Guid> GetImages()
        {
            return context.Images.Select(x => x.ID);
        }

    }
}
