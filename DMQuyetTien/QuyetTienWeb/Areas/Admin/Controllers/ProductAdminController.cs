using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuyetTienWeb.Models;
using System.Transactions;

namespace QuyetTienWeb.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        CS4PEEntities db = new CS4PEEntities();
        //
        // GET: /Admin/ProductAdmin/
        public ActionResult Index()
        {
            var product = db.BangSanPhams.OrderByDescending(x => x.id).ToList();
            return View(product);
        }
        // GET: /Admin/AdminProduct/Create
        public ActionResult Create()
        {
            ViewBag.Loai_id = new SelectList(db.LoaiSanPhams, "id", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BangSanPham model)
        {
            CheckBangSanPham(model);
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    db.BangSanPhams.Add(model);
                    db.SaveChanges();

                    var path = Server.MapPath("~/App_Data");
                    path = path + "/" + model.id;
                    if (Request.Files["HinhAnh"] != null && Request.Files["HinhAnh"].ContentLength > 0)
                    {
                        Request.Files["HinhAnh"].SaveAs(path);
                        scope.Complete();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("HinhAnh", "Chưa có hình ảnh sản phẩm");
                    }
                }
            }

            ViewBag.Loai_id = new SelectList(db.LoaiSanPhams, "id", "TenLoai", model.Loai_id);
            return View(model);
        }

        private void CheckBangSanPham(BangSanPham model)
        {
            if (model.GiaGoc < 0)
            {
                ModelState.AddModelError("GiaGoc", "Giá gốc phải lớn hơn 0");
            }
            if (model.GiaBan < 0)
            {
                ModelState.AddModelError("GiaBan", "Giá bán phải lớn hơn 0");
            }
            if (model.GiaGop < 0)
            {
                ModelState.AddModelError("GiaGop", "Giá trả góp phải lớn hơn 0");
            }
        }
	}
}