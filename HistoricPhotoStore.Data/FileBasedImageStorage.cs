using HistoricPhotoStore.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricPhotoStore.Data
{
    public class FileBasedImageStorage : ImageStorage
    {
        public byte[] GetDataForFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
    }
}
