using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading;

namespace ChoixSejour.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public  void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<Sejour> ObtientTousLesSejours()
        {
            return _bddContext.Sejours.ToList();
        }
        public List<Utilisateur> ObtientTousLesUtilisateurs()
        {
            return _bddContext.Utilisateurs.ToList();
        }
        public List<Vote> ObtientTousLesVotes()
        {
            return _bddContext.Votes.ToList();
        }

        public List<Sondage> ObtientTousLesSondages()
        {
            return _bddContext.Sondages.ToList();
        }
        public void Dispose()
        {
            _bddContext.Dispose();
        }

        public int CreerSejour(string lieu, string telephone)
        {
            Sejour sejour = new Sejour() { Lieu = lieu, Telephone = telephone };
            _bddContext.Sejours.Add(sejour);
            _bddContext.SaveChanges();
            return sejour.Id;
        }

        public void ModifierSejour(int id, string lieu, string telephone) 
        {
            Sejour sejour = _bddContext.Sejours.Find(id);

            if (sejour != null)
            {
                sejour.Lieu = lieu;
                sejour.Telephone = telephone;
                _bddContext.SaveChanges();
            }
        }
        public void SupprimerSejour(int id)
        {
            Sejour sejour = _bddContext.Sejours.Find(id);
            if (sejour != null)
            {
                _bddContext.Sejours.Remove(sejour);
                _bddContext.SaveChanges();
            }
        }

        public int CreerUtilisateur(string prenom,string pwd)
        {
            Utilisateur utilisateur = new Utilisateur() { Prenom = prenom, Password  = pwd };
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;
        }

        public void ModifierUtilisateur(int id, string prenom)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(id);

            if (utilisateur != null)
            {
                utilisateur.Prenom = prenom;
                _bddContext.SaveChanges();
            }
        }
        public void SupprimerUtilisateur(int id)
        {
            Utilisateur utilisateur = _bddContext.Utilisateurs.Find(id);
            if (utilisateur != null)
            {
                _bddContext.Utilisateurs.Remove(utilisateur);
                _bddContext.SaveChanges();
            }
        }
        public int CreerVote(Utilisateur utilisateur, Sejour sejour, Sondage sondage)
        {
            Vote vote = new Vote() { Utilisateur = utilisateur, Sejour = sejour, Sondage = sondage };
            _bddContext.Votes.Add(vote);
            _bddContext.SaveChanges();
            return vote.Id;
        }

        public void ModifierVote(int id, Utilisateur utilisateur, Sejour sejour, Sondage sondage)
        {
            Vote vote = _bddContext.Votes.Find(id);

            if (vote != null)
            {
                vote.Utilisateur = utilisateur;
                vote.Sejour = sejour;
                vote.Sondage = sondage;
                _bddContext.SaveChanges();
            }
        }
        public void SupprimerVote(int id)
        {
            Vote vote = _bddContext.Votes.Find(id);
            if (vote != null)
            {
                _bddContext.Votes.Remove(vote);
                _bddContext.SaveChanges();
            }
        }

        public int CreerSondage(DateTime date)
        {
            Sondage sondage = new Sondage() { Date = date};
            _bddContext.Sondages.Add(sondage);
            _bddContext.SaveChanges();
            return sondage.Id;
        }

        public void ModifierSondage(int id, DateTime date)
        {
            Sondage sondage = _bddContext.Sondages.Find(id);

            if (sondage != null)
            {
                sondage.Date = date;
                _bddContext.SaveChanges();
            }
        }
        public void SupprimerSondage(int id)
        {
            Sondage sondage = _bddContext.Sondages.Find(id);
            if (sondage != null)
            {
                _bddContext.Sondages.Remove(sondage);
                _bddContext.SaveChanges();
            }
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
            string motDePasseSel = "ChoixSejour" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
    }
}
