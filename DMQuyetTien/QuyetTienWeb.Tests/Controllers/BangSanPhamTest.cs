using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuyetTienWeb.Controllers;
using System.Web.Mvc;
using QuyetTienWeb.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Moq;


namespace QuyetTienWeb.Tests.Controllers
{
    [TestClass]
    public class BangSanPhamTest
    {
        [TestMethod]
        public void TextIndex()
        {
            var controller = new BangSanPhamController();
            var result = controller.Index() as ViewResult;
            var db = new CS4PEEntities();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<BangSanPham>));
            Assert.AreEqual(db.BangSanPhams.Count(), ((List<BangSanPham>)result.Model).Count);

        }

        [TestMethod]
        public void TestCreate1()
        {
            var controller = new BangSanPhamController();
            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.ViewData["Loai_id"], typeof(SelectList));
        }

        [TestMethod]
        public void TestDetails()
        {
            var controller = new BangSanPhamController();
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Server.MapPath("~/App_Data/0")).Returns("~/App_Data/0");
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            var result = controller.Details("0") as FilePathResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("images", result.ContentType);
            Assert.AreEqual("~/App_Data/0", result.FileName);
        }
    }
}
