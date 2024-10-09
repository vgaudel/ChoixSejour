using ChoixSejour.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestsChoixSejour
{
    [Collection("Database tests")]
    public class UnitTestsUtilisateur
    {

        [Fact]
        public void Creation_Utilisateur_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                dal.CreerUtilisateur("Vincent","pwd"); 


                // Nous vérifions que le lieu a bien été créé
                List<Utilisateur> utilisateurs = dal.ObtientTousLesUtilisateurs();
                Assert.NotNull(utilisateurs);
                Assert.Single(utilisateurs);
                Assert.Equal("Vincent", utilisateurs[0].Prenom);
                

                // Nettoyage de la bdd
                dal.DeleteCreateDatabase();
            }
        }

        [Fact]
        public void Modification_Utilisateur_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                dal.CreerUtilisateur("Vincent", "pwd");

                // nous appelons la méthode de modification
                dal.ModifierUtilisateur(1, "Gilbert");

                // Nous vérifions que le lieu a bien été créé
                // Nous vérifions que le lieu a bien été créé
                List<Utilisateur> utilisateurs = dal.ObtientTousLesUtilisateurs();
                Assert.NotNull(utilisateurs);
                Assert.Single(utilisateurs);
                Assert.Equal("Gilbert", utilisateurs[0].Prenom);


                // Nous nettoyons la base
                dal.DeleteCreateDatabase();
            }


        }
        [Fact]
        public void Suppression_Utilisateur_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                dal.CreerUtilisateur("Vincent", "pwd");

                // nous appelons la méthode de modification
                dal.SupprimerUtilisateur(1);

                // Nous vérifions que le lieu a bien été créé
                // Nous vérifions que le lieu a bien été créé
                List<Utilisateur> utilisateurs = dal.ObtientTousLesUtilisateurs();
                Assert.NotNull(utilisateurs);
                Assert.Empty(utilisateurs);

                // Nettoyage de la bdd
                dal.DeleteCreateDatabase();

            }

        }

    }
}
