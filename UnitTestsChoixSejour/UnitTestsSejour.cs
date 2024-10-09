using ChoixSejour.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestsChoixSejour
{
    [Collection("Database tests")]
    public class UnitTestsSejour
    {
        [Fact]
        public void Creation_Sejour_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la cr�ons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et cr�ons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous cr�ons un lieu de vacances
                dal.CreerSejour("Chambord", "1111111111");
                

                // Nous v�rifions que le lieu a bien �t� cr��
                List<Sejour> sejours = dal.ObtientTousLesSejours();
                Assert.NotNull(sejours);
                Assert.Single(sejours);
                Assert.Equal("Chambord", sejours[0].Lieu);
                Assert.Equal("1111111111", sejours[0].Telephone);

                // Nettoyage de la bdd
                dal.DeleteCreateDatabase();
            }
        }

        [Fact]
        public void Modification_Sejour_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la cr�ons
            using (Dal dal = new Dal())
            {
                // Nous supprimons et cr�ons la db avant le test
                dal.DeleteCreateDatabase();
                // Nous cr�ons un lieu de vacances
                dal.CreerSejour("Chambord", "1111111111");

                // nous appelons la m�thode de modification
                dal.ModifierSejour(1,"Malakoff", "222222222222");

                // Nous v�rifions que le lieu a bien �t� cr��
                List<Sejour> sejours = dal.ObtientTousLesSejours();
                Assert.NotNull(sejours);
                Assert.Single(sejours);
                Assert.Equal("Malakoff", sejours[0].Lieu);
                Assert.Equal("222222222222", sejours[0].Telephone);

                // Nous nettoyons la base
                dal.DeleteCreateDatabase();
            }


        }
        [Fact]
        public void Suppression_Sejour_Verification()
        {
            
                // Nous supprimons la base si elle existe puis nous la cr�ons
                using (Dal dal = new Dal())
                {
                    // Nous supprimons et cr�ons la db avant le test
                    dal.DeleteCreateDatabase();
                    // Nous cr�ons un lieu de vacances
                    dal.CreerSejour("Chambord", "1111111111");
                    //Fin de la pr�paration du test

                    //appel de la m�thode � tester
                    dal.SupprimerSejour(1);

                    // V�rification que la m�thode a bien fait son travail
                    // Nous v�rifions que le lieu a bien �t� supprim�
                    List<Sejour> sejours = dal.ObtientTousLesSejours();
                    Assert.NotNull(sejours);
                    Assert.Empty(sejours);

                    // Nettoyage de la bdd
                    dal.DeleteCreateDatabase();

                }
           
        }
    }
}
