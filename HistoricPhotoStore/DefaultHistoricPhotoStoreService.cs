using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricPhotoStore
{
    public class DefaultHistoricPhotoStoreService : HistoricPhotoStoreService
    {
        private readonly DataStorage dataStorage;

        public DefaultHistoricPhotoStoreService(DataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public byte[] GetImageDataForID(string v, Guid guid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guid> GetImages()
        {
            return dataStorage.GetImages();

        }
    }
}
