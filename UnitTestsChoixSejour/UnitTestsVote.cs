using ChoixSejour.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestsChoixVote
{
    [Collection("Database tests")]
    public class UnitTestsVote
    {/*
        [Fact]
        public void Creation_Vote_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                dal.CreerSejour("Chambord", "1111111111");
                dal.CreerUtilisateur("Vincent");
                dal.CreerSondage(DateTime.Now);

                // Nous vérifions que le lieu a bien été créé
                List<Vote> votes = dal.ObtientTousLesVotes();
                Assert.NotNull(votes);
                Assert.Single(votes);
                

                // Nettoyage de la bdd
                dal.DeleteCreateDatabase();
            }
        }

        [Fact]
        public void Modification_Vote_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                dal.CreerSejour("Chambord", "1111111111");
                dal.CreerUtilisateur("Vincent");
                

                // nous appelons la méthode de modification
                dal.ModifierVote(1, "Malakoff", "222222222222");

                // Nous vérifions que le lieu a bien été créé
                List<Vote> Votes = dal.ObtientTousLesVotes();
                Assert.NotNull(Votes);
                Assert.Single(Votes);
                Assert.Equal("Malakoff", Votes[0].Lieu);
                Assert.Equal("222222222222", Votes[0].Telephone);

                // Nous nettoyons la base
                dal.DeleteCreateDatabase();
            }


        }
        [Fact]
        public void Suppression_Vote_Verification()
        {

            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                dal.CreerVote("Chambord", "1111111111");
                //Fin de la préparation du test

                //appel de la méthode à tester
                dal.SupprimerVote(1);

                // Vérification que la méthode a bien fait son travail
                // Nous vérifions que le lieu a bien été supprimé
                List<Vote> Votes = dal.ObtientTousLesVotes();
                Assert.NotNull(Votes);
                Assert.Empty(Votes);

                // Nettoyage de la bdd
                dal.DeleteCreateDatabase();

            }

        }*/
    }
}
