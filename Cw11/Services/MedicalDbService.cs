using Cw11.Models;
using Cw11.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class MedicalDbService : IMedicalDbService
    {
        private readonly MedicalDbContext _context;
        public MedicalDbService(MedicalDbContext context)
        {
            _context = context;
        }
        public Doctor GetDoctor(int id)
        {
            try
            {
                Console.WriteLine("ID:" + id);
                var doctor = _context.Doctors.Where(d => d.IdDoctor.Equals(id)).First();
                return doctor;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return doctor;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Boolean DeleteDoctor(int id)
        {
            try
            {
                var doc = _context.Doctors.Where(d => d.IdDoctor.Equals(id)).First();
                _context.Remove(doc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Doctor EditDoctor(int id, Doctor doctor)
        {
            try
            {
                var doct = _context.Doctors.Where(d => d.IdDoctor.Equals(id)).First();
                doct.SetProperty("FirstName", doctor.FirstName);
                doct.SetProperty("LastName", doctor.LastName);
                doct.SetProperty("Email", doctor.Email);
                _context.SaveChanges();
                return doct;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }
    }
}
