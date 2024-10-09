using ChoixSejour.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestsChoixSejour
{
    [Collection("Database tests")]
    public class UnitTestsSondage
    {
        [Fact]
        public void Creation_Sondage_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                DateTime aujourdhui = DateTime.Now;
                dal.CreerSondage(aujourdhui);


                // Nous vérifions que le lieu a bien été créé
                List<Sondage> Sondages = dal.ObtientTousLesSondages();
                Assert.NotNull(Sondages);
                Assert.Single(Sondages);
                Assert.Equal(aujourdhui.Day, Sondages[0].Date.Day);
                Assert.Equal(aujourdhui.Month, Sondages[0].Date.Month);
                Assert.Equal(aujourdhui.Year, Sondages[0].Date.Year);

                // Nettoyage de la bdd
                dal.DeleteCreateDatabase();
            }
        }

        [Fact]
        public void Modification_Sondage_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                DateTime aujourdhui = DateTime.Now;
                DateTime hier = DateTime.MinValue;
                dal.CreerSondage(aujourdhui);
                dal.ModifierSondage(1, hier);

                // Nous vérifions que le lieu a bien été créé
                // Nous vérifions que le lieu a bien été créé
                List<Sondage> Sondages = dal.ObtientTousLesSondages();
                Assert.NotNull(Sondages);
                Assert.Single(Sondages);
                Assert.Equal(hier.Day, Sondages[0].Date.Day);
                Assert.Equal(hier.Month, Sondages[0].Date.Month);
                Assert.Equal(hier.Year, Sondages[0].Date.Year);


                // Nous nettoyons la base
                dal.DeleteCreateDatabase();
            }


        }
        [Fact]
        public void Suppression_Sondage_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous créons un lieu de vacances
                DateTime aujourdhui = DateTime.Now;
                dal.CreerSondage(aujourdhui);


                // nous appelons la méthode de modification
                dal.SupprimerSondage(1);

                // Nous vérifions que le lieu a bien été créé
                // Nous vérifions que le lieu a bien été créé
                List<Sondage> Sondages = dal.ObtientTousLesSondages();
                Assert.NotNull(Sondages);
                Assert.Empty(Sondages);

                // Nettoyage de la bdd
                dal.DeleteCreateDatabase();

            }

        }
    }
}
