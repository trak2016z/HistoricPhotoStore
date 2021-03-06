﻿using System;
using System.Collections.Generic;

namespace HistoricPhotoStore
{
    public interface HistoricPhotoStoreService
    {
        IEnumerable<Guid> GetImages();
        byte[] GetImageDataForID(string v, Guid guid);
    }
}