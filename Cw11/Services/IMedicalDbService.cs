using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;

namespace Cw11.Services
{
    public interface IMedicalDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public Doctor GetDoctor(int id);
        public Doctor AddDoctor(Doctor doctor);
        public Doctor EditDoctor(int id, Doctor doctor);
        public Boolean DeleteDoctor(int id);
    }
}
