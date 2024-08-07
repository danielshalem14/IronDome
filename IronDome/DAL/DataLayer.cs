using IronDome.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IronDome.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string cs) : base(GetOptions(cs))
        {
            Database.EnsureCreated();
            Seed();
        }

        public DbSet<DefenceAmmunition> DefenceAmmunitions { get; set; }
        public DbSet<TerrorOrg> TerrorOrgs { get; set; }
        public DbSet<Threat> Threats { get; set; }
        public DbSet<ThreatAmmunition> ThreatAmmunitions { get; set; }

        private void Seed()
        {
            if (!DefenceAmmunitions.Any())
            {
                DefenceAmmunitions.AddRange(
                    new DefenceAmmunition { name = "Iron Dome Missile", amount = 100 },
                    new DefenceAmmunition { name = "Patriot Missile", amount = 50 }
                );
                SaveChanges();
            }

            if (!TerrorOrgs.Any())
            {
                TerrorOrgs.AddRange(
                    new TerrorOrg { name = "Hamas", distance = 70, location = "Lebanon" },
                    new TerrorOrg { name = "Hezbollah", distance = 100, location = "Lebanon" },
                    new TerrorOrg { name = "Houthi", distance = 2377, location = "Yamen" },
                    new TerrorOrg { name = "Iran", distance = 1600, location = "Iran" }
                );
                SaveChanges();
            }

            if (!ThreatAmmunitions.Any())
            {
                ThreatAmmunitions.AddRange(
                    new ThreatAmmunition { name = "Balisti", speed = 18000 },
                    new ThreatAmmunition { name = "Rocket", speed = 880 },
                    new ThreatAmmunition { name = "Catbam", speed = 300 }
                );
                SaveChanges();
            }

            if (!Threats.Any())
            {
                TerrorOrg? hamas = TerrorOrgs.FirstOrDefault(t => t.name == "Hamas");
                ThreatAmmunition? rocket = ThreatAmmunitions.FirstOrDefault(t => t.name == "Rocket");
                if (hamas != null && rocket != null)
                    Threats.AddRange(
                        new Threat
                        {
                            Org = hamas,
                            type = rocket,

                        }
                    );
                SaveChanges();
            }
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString)
                .Options;
        }
    }
}
