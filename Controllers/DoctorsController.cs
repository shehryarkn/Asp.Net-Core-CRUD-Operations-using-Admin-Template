using System.Linq;
using CRUD_Operations.Models;
using Microsoft.AspNetCore.Mvc;
namespace AdminPanelTutorial
{
    public class DoctorsController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDoctor(Doctors doctor){
            db.Doctors.Add(doctor);
            db.SaveChanges();
            return RedirectToAction("Index", "Doctors");
        }
        [HttpPost]
        public bool Delete(int id){
            try
            {
                Doctors doctor = db.Doctors.Where(s => s.Id == id).First();
                db.Doctors.Remove(doctor);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }
        public ActionResult Update(int id){
            return View(db.Doctors.Where(s => s.Id == id).First());
        }
        [HttpPost]
        public ActionResult UpdateDoctor(Doctors doctor){
            Doctors d = db.Doctors.Where(s => s.Id == doctor.Id).First();
            d.Name = doctor.Name;
            d.Phone = doctor.Phone;
            d.Specialist = doctor.Specialist;
            db.SaveChanges();
            return RedirectToAction("Index", "Doctors");
        }
    }
}