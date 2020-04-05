using System.Net;
using System.Web.Mvc;
using EHI.WebApp.Data;
using EHI.WebApp.Models;

namespace EHI.WebApp.Controllers {
    public class PatientController : Controller {
        private readonly IEHIDataRepository _ehiDataRepository;
        public PatientController() {

        }
        public PatientController(IEHIDataRepository ehiDataRepository) {
            _ehiDataRepository = ehiDataRepository;
        }

        public ActionResult Index() {
            var patientList = _ehiDataRepository.GetPatients();
            return View(patientList);
        }

        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientContact patientContact = _ehiDataRepository.GetPatient(id);
            if (patientContact == null) {
                return HttpNotFound();
            }
            return View(patientContact);
        }

        public ActionResult Create() {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientContact patientContact) {
            if (ModelState.IsValid) {
                _ehiDataRepository.Add(patientContact);
                _ehiDataRepository.SaveAsync(patientContact);
                return RedirectToAction("Index");
            }

            return View(patientContact);
        }

        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientContact patientContact = _ehiDataRepository.GetPatient(id);
            if (patientContact == null) {
                return HttpNotFound();
            }
            return View(patientContact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientContact patientContact) {
            if (ModelState.IsValid) {
                _ehiDataRepository.Update(patientContact);
                _ehiDataRepository.SaveAsync(patientContact);
                return RedirectToAction("Index");
            }
            return View(patientContact);
        }

        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientContact patientContact = _ehiDataRepository.GetPatient(id);
            if (patientContact == null) {
                return HttpNotFound();
            }
            return View(patientContact);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            PatientContact patientContact = _ehiDataRepository.GetPatient(id);
            patientContact.Status = true;
            _ehiDataRepository.Update(patientContact);
            _ehiDataRepository.SaveAsync(patientContact);
            return RedirectToAction("Index");
        }
    }
}
