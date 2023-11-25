using CoreDepartman.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDepartman.Controllers
{
	public class DepartmanController : Controller
	{
        AppDbContext db = new AppDbContext();

        public IActionResult Index()
		{
			var departmanlar = db.departman.ToList();
			return View(departmanlar);
		}
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Departman d) 
		{ 
            db.departman.Add(d);
            db.SaveChanges();
			return RedirectToAction("Index"); 
		}
        public IActionResult Guncelle(int id)
        {
            var depart = db.departman.Find(id);
            return View("Guncelle", depart);
        }
        [HttpPost]
        public IActionResult Guncelle(Departman d)
        {
            var dep=db.departman.Find(d.Id);
            dep.Ad = d.Ad;
            db.departman.Update(dep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            var dep= db.departman.Find(id);
            db.departman.Remove(dep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detaylar(int id)
        {
            var detay=db.personel.Where(x=>x.DepartmanId==id).ToList();
            var departmanAd = db.departman.Where(x => x.Id == id).Select(x => x.Ad).FirstOrDefault();
            ViewBag.departman = departmanAd;
            return View(detay);
        }
    }
}
