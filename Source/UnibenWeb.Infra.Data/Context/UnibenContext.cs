using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Infra.Data.EntityConfig;

namespace UnibenWeb.Infra.Data.Context
{
    public class UnibenContext : DbContext
    {
        public UnibenContext()
            : base("UnibenConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UnibenContext>());
        }

        public DbSet<Banco> Bancos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ~~~ Precisa comentar o modelBuilder para gerar o scatfold, pois ele não entende.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new BancoEFConfig());
            // ~~~

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Data_inclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Data_inclusao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Data_inclusao").IsModified = false;
                }
            }


                foreach (var relationship in this.GetAddedRelationships())
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Relationship added between {0} and {1}",
                        relationship.Item1,
                        relationship.Item2);
                }

                foreach (var relationship in this.GetDeletedRelationships())
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Relationship removed between {0} and {1}",
                        relationship.Item1,
                        relationship.Item2);
                }

                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //Write to file
                System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
                throw;

                // Showing it on screen
                throw new Exception(string.Join(",", outputLines.ToArray()));
            }
        }

    }
}