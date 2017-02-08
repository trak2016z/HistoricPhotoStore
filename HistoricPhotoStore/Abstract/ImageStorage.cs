using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricPhotoStore.Abstract
{
    public interface ImageStorage
    {
        byte[] GetDataForFile(string filePath);
    }
}
