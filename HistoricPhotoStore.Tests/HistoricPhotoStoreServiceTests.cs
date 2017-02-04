using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace HistoricPhotoStore.Tests
{
    [TestClass]
    public class HistoricPhotoStoreServiceTests
    {
        [TestMethod]
        public void ReturnsAllImagesReturnedByDataStorage()
        {
            var dataStorage = new Mock<DataStorage>();
            var service = new HistoricPhotoStoreService(dataStorage.Object);

            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();

            dataStorage.Setup(x => x.GetImages())
                .Returns(new List<Guid>() { guid1, guid2, guid3 });

            var images = service.GetImages().ToList();

            Assert.AreEqual(guid1, images[0]);
            Assert.AreEqual(guid2, images[1]);
            Assert.AreEqual(guid3, images[2]);
        }
    }
}
