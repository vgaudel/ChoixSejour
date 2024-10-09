﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public interface IDal: IDisposable
    {
        void DeleteCreateDatabase();
        List<Sejour> ObtientTousLesSejours();
        int CreerSejour(string lieu, string telephone);
        void ModifierSejour(int id, string lieu, string telephone);

        int AjouterUtilisateur(string nom, string password);
        Utilisateur Authentifier(string nom, string password);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idStr);

    }
}
