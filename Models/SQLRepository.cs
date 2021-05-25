using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class SQLRepository : INurseRepository
    {
        private NurseDbContext context;
        public SQLRepository(NurseDbContext context)
        {
            this.context = context;
        }

        public Nurse Add(Nurse nurse)
        {
            context.Nurses.Add(nurse);
            context.SaveChanges();
            return nurse;
        }

        public Nurse Delete(int id)
        {
            Nurse nurseToDelete = context.Nurses.Find(id);
            if(nurseToDelete!=null)
            {
                context.Nurses.Remove(nurseToDelete);
                context.SaveChanges();
            }
            return nurseToDelete;
            
        }

        public IEnumerable<Nurse> getAll()
        {
            return context.Nurses;
        }

        public Nurse GetNurse(int? id)
        {
            return context.Nurses.Find(id ?? 1);
        }

        public Nurse Update(Nurse changedNurse)
        {
            var nurseToUpdate=context.Nurses.Attach(changedNurse);
            nurseToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return changedNurse;
        }
    }
}
