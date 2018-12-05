using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuyetTienWeb.Controllers;
using System.Web.Mvc;
using QuyetTienWeb.Models;
using System.Collections.Generic;


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
    }
}
