using HistoricPhotoStore.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricPhotoStore
{
    public class DefaultHistoricPhotoStoreService : HistoricPhotoStoreService
    {
        private readonly DataStorage dataStorage;
        private readonly ImageStorage imageStorage;

        public DefaultHistoricPhotoStoreService(DataStorage dataStorage, ImageStorage imageStorage)
        {
            this.dataStorage = dataStorage;
            this.imageStorage = imageStorage;
        }

        public byte[] GetImageDataForID(string mainDirectory, Guid guid)
        {
            var imageExtension = dataStorage.GetImageExtensionForID(guid);
            var imageFileName = guid.ToString() + imageExtension;
            var filePath = Path.Combine(mainDirectory, "Images", imageFileName);

            return imageStorage.GetDataForFile(filePath);
        }

        public IEnumerable<Guid> GetImages()
        {
            return dataStorage.GetImages();

        }
    }
}
