using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    class NurseRepository : INurseRepository
    {
        private IEnumerable<Nurse> nurses;
        public NurseRepository()
        {
            nurses = new List<Nurse>()
            {
                new Nurse()
                { Id = 1, Name = "Ahmad", Email="ahmad@nurses.com",Section = SectionEnum.Clinical },
                new Nurse()
                { Id = 2, Name = "Muna", Email="muna@nurses.com",Section = SectionEnum.ER }
            };
            
        }
        public Nurse GetNurse(int? id)
        {
            return nurses.Where(n => n.Id == id).FirstOrDefault();
        }
        public IEnumerable<Nurse> ShowAllNurses()
        {
            return nurses;
        }

        public Nurse Add(Nurse nurse)
        {
            nurse.Id=nurses.Max(n => n.Id) + 1;
            ((List<Nurse>)nurses).Add(nurse);
            return nurse;
        }

        public Nurse Delete(int id)
        {
            Nurse nurseToDelete=nurses.FirstOrDefault(n => n.Id == id);
            if(nurseToDelete!=null)
            {
                ((List<Nurse>)nurses).Remove(nurseToDelete);
            }
            return nurseToDelete;
        }

        public Nurse Update(Nurse changedNurse)
        {
            Nurse nurseToUpdate = nurses.FirstOrDefault(n => n.Id == changedNurse.Id);
            if (nurseToUpdate != null)
            {
                nurseToUpdate.Name = changedNurse.Name;
                nurseToUpdate.Email = changedNurse.Email;
                nurseToUpdate.Section = changedNurse.Section;
            }
            return nurseToUpdate;
        }
    }
}
