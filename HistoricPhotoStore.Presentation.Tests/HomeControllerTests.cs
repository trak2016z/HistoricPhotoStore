using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using HistoricPhotoStore;
using HistoricPhotoStore.Presentation.Controllers;
using System.Linq;
using HistoricPhotoStore.Presentation.Helpers;

namespace HistoricPhotoStore.Presentation.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private Mock<HistoricPhotoStoreService> service;
        private Mock<PathHelper> pathHelper;

        private HomeController controller;

        [TestInitialize]
        public void Initialize()
        {
            service = new Mock<HistoricPhotoStoreService>();
            pathHelper = new Mock<PathHelper>();

            controller = new HomeController(service.Object, pathHelper.Object);
        }


        [TestMethod]
        public void IndexShowsViewWithImagesFromService()
        {

            service.Setup(x => x.GetImages())
                .Returns(new List<Guid>() {
                    new Guid("b8078ae5-82e7-4831-af03-264beae3d075"),
                    new Guid("a4843e01-2bc9-45ce-978c-58c7689fa6e8"),
                    new Guid("92159ce3-8d1a-4dd6-ae39-8993599199d5"),
                    new Guid("372e7e76-6497-4761-96ef-acf93c61f967"),
                    new Guid("8bd8935b-457d-4bb3-81ae-c0dc70a84e75"),
                    new Guid("97e4643e-56f6-4cc3-aa7d-d75433d2d2bd")
                });

            var result = controller.Index();
            var model = ((IEnumerable<string>)result.Model).ToList();

            Assert.AreEqual("b8078ae5-82e7-4831-af03-264beae3d075", model[0]);
            Assert.AreEqual("a4843e01-2bc9-45ce-978c-58c7689fa6e8", model[1]);
            Assert.AreEqual("92159ce3-8d1a-4dd6-ae39-8993599199d5", model[2]);
            Assert.AreEqual("372e7e76-6497-4761-96ef-acf93c61f967", model[3]);
            Assert.AreEqual("8bd8935b-457d-4bb3-81ae-c0dc70a84e75", model[4]);
            Assert.AreEqual("97e4643e-56f6-4cc3-aa7d-d75433d2d2bd", model[5]);
        }

        [TestMethod]
        public void ImageReturnsFileWithDataFromService()
        {
            var guid = new Guid("12345678-1234-1234-1234-123456789012");

            pathHelper.SetupGet(x => x.RootDirectoryPath).Returns("Path");

            service.Setup(x => x.GetImageDataForID("Path", guid))
                .Returns(new byte[] { 1, 9, 2, 8, 3, 7, 5, 6 });

            var file = controller.Image(guid.ToString());

            Assert.AreEqual(8, file.FileContents.Length);
            Assert.AreEqual(1, file.FileContents[0]);
            Assert.AreEqual(9, file.FileContents[1]);
            Assert.AreEqual(2, file.FileContents[2]);
            Assert.AreEqual(8, file.FileContents[3]);
            Assert.AreEqual(3, file.FileContents[4]);
            Assert.AreEqual(7, file.FileContents[5]);
            Assert.AreEqual(5, file.FileContents[6]);
            Assert.AreEqual(6, file.FileContents[7]);
        }
    }
}
