using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CoucheAcceeDonnees;
using CoucheAcceeDonnees.Model;
using Utilitaire;
using ComptabiliteGenerale.Saisie;
using ComptabiliteGenerale.Properties;
using SaisieCompta;

namespace ComptabiliteGenerale.Saisie.Logic
{
    class SaisieBilanLogic
    {
        CoucheAcceeDonnees.Model.Bilan bilans; 
        Ecritures ecritures;
        Comptes comptes;
        Journaux journaux;
        LibellesAutomatiques libelles;
        private int ret;

        public SaisieBilanLogic(CAD db)
        {

            db.Fill_Comptes();
            db.Fill_Bilan();
            db.Fill_LibellesAutomatiques();
            db.Fill_Journaux();

            bilans = new Bilan(db);
            ecritures = new Ecritures(db);
            comptes = new Comptes(db);
            libelles = new LibellesAutomatiques(db);
            journaux = new Journaux(db);

        }

        public int Enregister(ref ViewModel.SaisieBilanVM view_model, BilanModel bilan)
        {


            int ret = bilans.Enregister(bilan,2);
            // datagrid
            if (ret == 0)
            {

                ViewModel.LigneBilan Ligne = new ViewModel.LigneBilan();

                Ligne.CompteActif = bilan.CompteActif;
                Ligne.LibelleActif = bilan.LibelleActif;
                //Ligne.SoldeActif = bilan.SoldeActif;
                Ligne.ComptePassif = bilan.ComptePassif;
                
                Ligne.LibellePassif = bilan.LibellePassif;
                //Ligne.SoldePassif = bilan.SoldePassif;

                double mntActif = double.Parse(bilan.SoldeActif);
                double mntPassif = double.Parse(bilan.SoldePassif);
                //if (ecriture.Debit == true)
                //{
                //Ligne.DC = "D";
                view_model.TotaleActif += mntActif;
                view_model.TotalePassif += mntPassif;
               
                Ligne.SoldeActif = Fonctions.format1(mntActif.ToString());
                Ligne.SoldePassif = Fonctions.format1(mntPassif.ToString());
                view_model.Lignes.Add(Ligne);
                Console.WriteLine("Add Ligne 1 To Bilan Logic");

                /*if (cpa == true)
                {
                    LigneEcriture Ligne1 = new LigneEcriture();
                    Ligne1.JourMois = ecriture.JourMois;
                    Ligne1.Compte = ecriture.Compte;
                    Ligne1.CPartie = ecriture.ContrePartie;
                    Ligne1.N_Ordre = ecriture.N_Ordre;
                    //Ligne1.La = ecriture.CodeLibelleAutomatique;
                    Ligne1.Libelle = ecriture.Libelle;
                    Ligne1.Libelle2 = ecriture.Libelle2;
                    mnt = double.Parse(ecriture.Montant); ;
                    if (ecriture.Debit == true)
                    {
                        Ligne1.DC = "C";
                        view_model.mouvements_credit += mnt;
                        view_model.cumul_credit += mnt;
                    }
                    else
                    {
                        Ligne1.DC = "D";
                        view_model.mouvements_debit += mnt;
                        view_model.cumul_debit += mnt;
                    }
                    Ligne1.Montant = Fonctions.format1(mnt.ToString());
                    view_model.Lignes.Add(Ligne1);

                }
                Console.WriteLine(" Ligne 2");*/
            }
            else
            {
                Console.WriteLine("Errooor ret SaisieBilanLogic");
            }

            return ret;



        }

       
        public int get_libelle_intitule1(ref ViewModel.SaisieBilanVM view_model, string code)
        {
            LibelleAutomatiqueModel model = new LibelleAutomatiqueModel();
            model.Code = code;

            int ret = libelles.Consulter(ref model);

            if (ret == 0) view_model.LibelleActif = model.Intitule;

            return ret;
        }
        public int get_libelle_intitule2(ref ViewModel.SaisieBilanVM view_model, string code)
        {
            LibelleAutomatiqueModel model = new LibelleAutomatiqueModel();
            model.Code = code;

            int ret = libelles.Consulter(ref model);

            if (ret == 0) view_model.LibellePassif = model.Intitule;

            return ret;
        }
        public int get_compte_intituleActif(ref ViewModel.SaisieBilanVM view_model, string Compte1)
        {
            Console.WriteLine(" Eroor get_Compte SaisieBilanLogic.cs !!!!");
            CompteModel model1 = new CompteModel();
            model1.Compte = Compte1;
            Console.WriteLine(" Avant Consulter Apel !!!!");
            int ret = comptes.Consulter(ref model1);
            Console.WriteLine(" APres Consulter Apel !!!!");
            if (ret == 0) view_model.LibelleActif = model1.Intitule;


            return ret;
        }

        public int get_compte_intitulePassif(ref ViewModel.SaisieBilanVM view_model, string Compte1)
        {
            CompteModel model1 = new CompteModel();
            model1.Compte = Compte1;

            int ret = comptes.Consulter(ref model1);

            if (ret == 0) view_model.LibellePassif = model1.Intitule;


            return ret;
        }

        public int get_compte_SoldeActif(ref ViewModel.SaisieBilanVM view_model, string Compte1)
        {
            CompteModel model1 = new CompteModel();
            model1.Compte = Compte1;

            int ret = comptes.Consulter(ref model1);

            if (ret == 0) view_model.SoldeActif = double.Parse(model1.AnouveauDebit) - double.Parse( model1.AnouveauCredit)  ;


            return ret;
        }

        public int get_compte_SoldePassif(ref ViewModel.SaisieBilanVM view_model, string Compte1)
        {
            CompteModel model1 = new CompteModel();
            model1.Compte = Compte1;

            int ret = comptes.Consulter(ref model1);

            if (ret == 0) view_model.SoldePassif =  double.Parse(model1.AnouveauCredit) - double.Parse(model1.AnouveauDebit) ;


            return ret;
        }
    }
}
