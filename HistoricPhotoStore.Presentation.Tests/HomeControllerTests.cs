using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using HistoricPhotoStore;
using HistoricPhotoStore.Presentation.Controllers;
using System.Linq;

namespace HistoricPhotoStore.Presentation.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexShowsViewWithImagesFromService()
        {
            var service = new Mock<HistoricPhotoStoreService>();
            var controller = new HomeController(service.Object);

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
    }
}
