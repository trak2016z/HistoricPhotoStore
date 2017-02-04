using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricPhotoStore
{
    public class HistoricPhotoStoreService
    {
        private readonly DataStorage dataStorage;

        public HistoricPhotoStoreService(DataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public IEnumerable<Guid> GetImages()
        {
            return dataStorage.GetImages();

        }
    }
}
