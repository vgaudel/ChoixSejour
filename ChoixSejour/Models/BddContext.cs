using Microsoft.EntityFrameworkCore;

namespace ChoixSejour.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Sejour> Sejours { get; set; }
        public DbSet<Sondage> Sondages { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=choixSejour24");
        }
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Sejours.AddRange(
                new Sejour
                {
                    Id = 1,
                    Lieu = "Disney",
                    Telephone = "000000000"
                },
                new Sejour
                {
                    Id = 2,
                    Lieu = "Chambord",
                    Telephone = "111111111"
                }
            );
            this.Utilisateurs.AddRange(
                new Utilisateur
                {
                    Id = 1,
                    Prenom = "Abed",
                    Password = Dal.EncodeMD5("Abed")
                },
                 new Utilisateur
                 {
                     Id = 2,
                     Prenom = "Fanny",
                     Password = Dal.EncodeMD5("Fanny")
                 },
                 new Utilisateur
                 {
                     Id = 3,
                     Prenom = "Miguel",
                     Password = Dal.EncodeMD5("Miguel")
                 }, 
                 new Utilisateur
                 {
                     Id = 4,
                     Prenom = "Gonzalo",
                     Password = Dal.EncodeMD5("Gonzalo")
                 },
                 new Utilisateur
                 {
                     Id = 5,
                     Prenom = "Thadé",
                     Password = Dal.EncodeMD5("Thadé")
                 },
                 new Utilisateur
                 {
                     Id = 6,
                     Prenom = "Imane",
                     Password = Dal.EncodeMD5("Imane")
                 }
            ) ;

            this.SaveChanges();
        }


    }
}
