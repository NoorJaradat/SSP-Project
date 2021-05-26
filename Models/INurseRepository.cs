using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public interface INurseRepository
    {
        public Nurse GetNurse(int? id);
        public IEnumerable<Nurse> ShowAllNurses();
        public Nurse Add(Nurse nurse);
        public Nurse Delete(int id);
        public Nurse Update(Nurse changedNurse);


    }
}
