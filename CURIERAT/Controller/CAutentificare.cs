using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Curierat.Model;
using Curierat.Model.Persistenta;
using Curierat.View;


namespace Curierat.Controller
    {
        public class CAutentificare
        {
            private AutentificareV autentificareV;
            private UtilizatorPersistent utilizatorPersistent;

            public CAutentificare()
            {
                this.autentificareV = new AutentificareV();
                this.utilizatorPersistent = new UtilizatorPersistent();
                this.gestionareEvenimente();
            }

            public AutentificareV AccesAutentificareView()
            {
                return this.autentificareV;
            }

            private void gestionareEvenimente()
            {
                this.autentificareV.AccesbtnAutentificare().Click += new EventHandler(autentificare);
            }

            private void autentificare(object sender, EventArgs e)
            {
                string user = this.autentificareV.AccestxtUserAutentificare().Text;
                string parola = this.autentificareV.AccestxtParolaAutentificare().Text;

                if (user == "" || parola == "")
                {
                    MessageBox.Show("Introduceti toate datele de logare!!");
                }
                else
                {
                    Utilizator utilizator = this.utilizatorPersistent.CautareUtilizator(user, parola);

                    if (utilizator == null)
                    {
                        MessageBox.Show("Nu exista utilizator cu datele specificate!");
                        this.autentificareV.AccestxtUserAutentificare().Text = "";
                        this.autentificareV.AccestxtParolaAutentificare().Text = "";
                    }
                    else
                    {
                        this.autentificareV.Hide();
                        string rol = utilizator.AccesRol();
                        if (rol == "Administrator")
                        {
                            CAdministrator adminC = new CAdministrator();
                            adminC.AccesAdministratorV().Show();
                        }
                        else if (rol == "Coordonator")
                        {
                            CCoordonator angajatC = new CCoordonator();
                            angajatC.AccesCoordonatorV().Show();

                        } else
                    {
                        CCurier curierC = new CCurier();
                        curierC.AccesCurierV().Show();
                    }
                    }
                }

            }

        }
    }
