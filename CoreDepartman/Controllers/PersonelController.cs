using CoreDepartman.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreDepartman.Controllers
{
	public class PersonelController : Controller
	{
		AppDbContext db= new AppDbContext();
		public IActionResult Index()
		{
			var personeller= db.personel.Include(x=>x.Departman).ToList();
			return View(personeller);
		}
		public IActionResult Ekle()
		{
			List<SelectListItem> degerler = db.departman.Select(x => new SelectListItem
			{
				Text = x.Ad,
				Value = x.Id.ToString()
			}).ToList();
			ViewBag.Degerler = degerler;
			return View();
		}
		[HttpPost]
        public IActionResult Ekle(Personel p)
        {
			db.personel.Add(p);
			db.SaveChanges();
            return RedirectToAction("Index");
        }
		public IActionResult Guncelle(int id)
		{
			var personel=db.personel.Find(id);
			return View(personel);
		}
		[HttpPost]
		public IActionResult Guncelle(Personel p)
		{
			var pers = db.personel.Find(p.Id);
			pers.Ad = p.Ad;
            pers.Sehir = p.Sehir;
            pers.Departman=p.Departman;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var result = db.personel.Find(id);
			db.personel.Remove(result);
			db.SaveChanges ();
			return RedirectToAction("Index");
		}
    }
}
