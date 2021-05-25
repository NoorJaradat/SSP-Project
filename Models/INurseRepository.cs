using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    interface INurseRepository
    {
        public Nurse GetNurse(int? id);
        public IEnumerable<Nurse> getAll();
        public Nurse Add(Nurse nurse);
        public Nurse Delete(int id);
        public Nurse Update(Nurse changedNurse);


    }
}
