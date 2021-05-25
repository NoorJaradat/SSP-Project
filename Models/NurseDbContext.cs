using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class NurseDbContext: DbContext
    {
        public NurseDbContext(DbContextOptions<NurseDbContext> options):base(options)
        {

        }
        public DbSet<Nurse> Nurses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nurse>().HasData(
            new Nurse
                {
                    Id = 1,
                    Name = "Ali",
                    Email = "ali@nurses.com",
                    Section = SectionEnum.Geriatric
                },
            new Nurse
            {
                Id=2,
                Name="Ahmad",
                Email="ahmad@nurses.com",
                Section=SectionEnum.Clinical
            },
            new Nurse
            {
                Id = 3,
                Name = "Muna",
                Email = "muna@nurses.com",
                Section = SectionEnum.ER
            }
            );
        }
    }

}
