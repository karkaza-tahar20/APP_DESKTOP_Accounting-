using ComptabiliteGenerale.Saisie.View;
using SharpCompta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SharpCompta2007
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SharpComptaUI());
            Application.Run(new Authentification());

            // Application.Run(new ComptabiliteGenerale.Saisie.View.Authentification() );
        }
    }
}
