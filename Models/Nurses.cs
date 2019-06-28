using System;
using System.Collections.Generic;

namespace CRUD_Operations.Models
{
    public partial class Nurses
    {
        public Nurses()
        {
            Patients = new HashSet<Patients>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTimeOffset Created { get; set; }

        public virtual ICollection<Patients> Patients { get; set; }
    }
}
