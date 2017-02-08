using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using HistoricPhotoStore.Abstract;

namespace HistoricPhotoStore.Tests
{
    [TestClass]
    public class DefaultHistoricPhotoStoreServiceTests
    {
        private Mock<DataStorage> dataStorage;
        private Mock<ImageStorage> imageStorage;

        private DefaultHistoricPhotoStoreService service;


        [TestInitialize]
        public void Initialize()
        {
            dataStorage = new Mock<DataStorage>();
            imageStorage = new Mock<ImageStorage>();

            service = new DefaultHistoricPhotoStoreService(dataStorage.Object, imageStorage.Object);
        }


        [TestMethod]
        public void ReturnsAllImagesReturnedByDataStorage()
        {

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

        [TestMethod]
        public void ReturnsByteDataForImageWithAGivenID()
        {
            var guid = new Guid("12341234-1234-1234-1234-123412341234");
            dataStorage.Setup(x => x.GetImageExtensionForID(guid))
                .Returns(".jpg");
            imageStorage.Setup(x => x.GetDataForFile(@"Path\Images\12341234-1234-1234-1234-123412341234.jpg"))
                .Returns(new byte[] { 1, 2, 5, 4 });

            var data = service.GetImageDataForID("Path", guid);

            Assert.AreEqual(1, data[0]);
            Assert.AreEqual(2, data[1]);
            Assert.AreEqual(5, data[2]);
            Assert.AreEqual(4, data[3]);
        }
    }
}
