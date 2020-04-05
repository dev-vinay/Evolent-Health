using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using EHI.WebSite.DataRepository;
using EHI.WebSite.Infrastructure;

namespace EHI.WebSite.Controllers {

    public class PatientApiController : ApiController {
        private IEHIDataRepository _ehiDataRepository;
        public PatientApiController(IEHIDataRepository ehiDataRepository) {
            _ehiDataRepository = ehiDataRepository;
        }

        // GET: api/Patient
        public IEnumerable<Patient> GetPatients() {
            return _ehiDataRepository.GetPatients();
        }

        // GET: api/Patient/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(int id) {
            Patient patient = _ehiDataRepository.GetPatient(id);
            if (patient == null) {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/Patient/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(int id, Patient patient) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != patient.PatientID) {
                return BadRequest();
            }
            try {
                _ehiDataRepository.Update(patient);

                _ehiDataRepository.Save(patient);
            } catch (DbUpdateConcurrencyException) {
                if (!PatientExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Patient
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient(Patient patient) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _ehiDataRepository.Add(patient);
            _ehiDataRepository.Save(patient);

            return CreatedAtRoute("DefaultApi", new { id = patient.PatientID }, patient);
        }

        // DELETE: api/Patient/5
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(int id) {
            Patient patient = _ehiDataRepository.GetPatient(id);

            if (patient == null) {
                return NotFound();
            }
            patient.IsActive = false;
            _ehiDataRepository.Update(patient);
            _ehiDataRepository.Save(patient);
            return Ok(patient);
        }

        private bool PatientExists(int id) {
            return _ehiDataRepository.GetPatients().Any(e => e.PatientID == id);
        }
    }
}