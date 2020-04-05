using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EHI.WebApp.Models;

namespace EHI.WebApp.Data {
    public class EHIDataRepository : IEHIDataRepository {
        private readonly EHIDbContext _ehiDbContext;
        private bool _disposed = false;
        public EHIDataRepository(EHIDbContext ehiDbContext) {
            if (ehiDbContext == null) new ArgumentNullException(nameof(ehiDbContext));

            _ehiDbContext = ehiDbContext;
        }
        public void Add(PatientContact entity) {
            _ehiDbContext.Set<PatientContact>().Add(entity);
        }

        public void Delete(PatientContact entity) {
            _ehiDbContext.Set<PatientContact>().Remove(entity);
        }

        public void Update(PatientContact entity) {
            _ehiDbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<PatientContact> SaveAsync(PatientContact entity) {
            await _ehiDbContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<PatientContact> GetPatients() {
            return _ehiDbContext.PatientContacts.ToList();
        }

        public PatientContact GetPatient(int? id) {
            return _ehiDbContext.PatientContacts.Find(id);
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
            return _ehiDbContext.PatientContacts.Any(e => e.ContactId == id);
        }
    }

    public interface IEHIDataRepository : IDisposable {
        void Add(PatientContact entity);
        void Update(PatientContact entity);
        void Delete(PatientContact entity);
        IEnumerable<PatientContact> GetPatients();
        PatientContact GetPatient(int? id);
        Task<PatientContact> SaveAsync(PatientContact entity);

    }
}