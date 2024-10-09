using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public class Dal: IDal
    {
        private BddContext _bddContext;

        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<Sejour> ObtientTousLesSejours()
        {
            return _bddContext.Sejours.ToList();
        }

        public int CreerSejour(string lieu, string telephone)
        {
            Sejour sejour = new Sejour {Lieu=lieu, Telephone=telephone };
            _bddContext.Sejours.Add(sejour);
            _bddContext.SaveChanges();

            return sejour.Id;
        }

        public void ModifierSejour(int id, string lieu, string telephone)
        {
            Sejour sejour = _bddContext.Sejours.Find(id);
            if(sejour != null)
            {
                sejour.Lieu = lieu;
                sejour.Telephone = telephone;
                _bddContext.SaveChanges();
            }
        }

        public void ModifierSejour(Sejour sejour)
        {
            _bddContext.Sejours.Update(sejour);
            _bddContext.SaveChanges();
        }

        public int AjouterUtilisateur(string prenom, string password)
        {
            string motDePasse = EncodeMD5(password);
            Utilisateur user = new Utilisateur() { Prenom = prenom, Password = motDePasse };
            this._bddContext.Utilisateurs.Add(user);
            this._bddContext.SaveChanges();
            return user.Id;
        }

        public Utilisateur Authentifier(string prenom, string password)
        {
            string motDePasse = EncodeMD5(password);
            Utilisateur user = this._bddContext.Utilisateurs.FirstOrDefault(u => u.Prenom == prenom && u.Password == motDePasse);
            return user;
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return this._bddContext.Utilisateurs.Find(id);
        }

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirUtilisateur(id);
            }
            return null;
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
