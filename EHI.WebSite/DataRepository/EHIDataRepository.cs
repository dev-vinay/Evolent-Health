using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EHI.WebSite.Infrastructure;

namespace EHI.WebSite.DataRepository {
    public class EHIDataRepository : IEHIDataRepository {
        private readonly EHIDBEntities _ehiDbContext;
        private bool _disposed = false;
        public EHIDataRepository(EHIDBEntities ehiDbContext) {
            if (ehiDbContext == null) new ArgumentNullException(nameof(ehiDbContext));

            _ehiDbContext = ehiDbContext;
        }
        public void Add(Patient entity) {
            _ehiDbContext.Set<Patient>().Add(entity);
        }

        public void Delete(Patient entity) {
            _ehiDbContext.Set<Patient>().Remove(entity);
        }

        public void Update(Patient entity) {
            _ehiDbContext.Entry(entity).State = EntityState.Modified;
        }

        public Patient Save(Patient entity) {
            _ehiDbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<Patient> GetPatients() {
            var patientList = _ehiDbContext.Patients.ToList();
            return patientList;
        }

        public Patient GetPatient(int? id) {
            var patient = _ehiDbContext.Patients.Find(id);
            return patient;
        }

        public virtual void Dispose(bool disposing) {
            if (!_disposed) {


                if (disposing) {
                    _ehiDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool PatientContactExists(int id) {
            return _ehiDbContext.Patients.Any(e => e.PatientID == id);
        }
    }

    public interface IEHIDataRepository : IDisposable {
        void Add(Patient entity);
        void Update(Patient entity);
        void Delete(Patient entity);
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int? id);
        Patient Save(Patient entity);

    }
}