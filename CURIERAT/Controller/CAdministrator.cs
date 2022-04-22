using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Curierat.Model;
using Curierat.Model.Persistenta;
using Curierat.View;

namespace Curierat.Controller
{
    public class CAdministrator
    {
        private AdministratorV AdministratorV;
        private UtilizatorPersistent utilizatorPersistent;

        public CAdministrator()
        {
            this.AdministratorV = new AdministratorV();
            this.utilizatorPersistent = new UtilizatorPersistent();
            this.gestionareEvenimente();
        }

        public AdministratorV AccesAdministratorV()
        {
            return this.AdministratorV;
        }

        public void gestionareEvenimente()
        {
            this.AdministratorV.AccesbtnAdaugareU().Click += new EventHandler(adaugare);
            this.AdministratorV.AccesbtnActualizare().Click += new EventHandler(actualizare);
            this.AdministratorV.AccesbtnStergere().Click += new EventHandler(stergere);
            this.AdministratorV.AccesbtnLista().Click += new EventHandler(vizualizare);
            this.AdministratorV.AccesbtnDeconectare().Click += new EventHandler(deconectare);
            this.AdministratorV.AccesBtnFiltrare().Click += new EventHandler(filtrare);
        }

        private void adaugare(object sender, EventArgs e)
        {
            bool dateCorecte = true;
            string legitimatie = this.AdministratorV.AccestxtLegitimatie().Text;
            string nume = this.AdministratorV.AccestxtNume().Text;
            string user = this.AdministratorV.AccestxtUser().Text;
            string parola = this.AdministratorV.AccestxtParola().Text;
            string rolSelectat = this.AdministratorV.AccescmbRolU().Text;
            //int rolSelectat = int.Parse(roluSelectat);


            if (rolSelectat ==  "" || nume == "" || user == "" || parola == "" || legitimatie == "")
            {
                dateCorecte = false;
                MessageBox.Show("Nu ati introdus toate datele necesare!");
            }
            else
            {
                uint nrLeg;

                bool conversie = uint.TryParse(legitimatie, out nrLeg);
                if (conversie)
                {
                    nrLeg = Convert.ToUInt32(legitimatie);
                    if (nrLeg == 0)
                    {
                        dateCorecte = false;
                        MessageBox.Show("ID-ul nu poate fi 0!");
                    }
                }

                if ((!Regex.IsMatch(legitimatie, @"^\d+$")) && legitimatie != "")
                {
                    MessageBox.Show("ID-ul trebuie sa fie compus din cifre!!!");
                    dateCorecte = false;
                }


                if (this.utilizatorPersistent.CautareUtilizator(nrLeg) != null)
                {
                    MessageBox.Show("Exista alt utilizator cu acest ID!");
                    dateCorecte = false;
                }
                else
                {


                  





                    if (dateCorecte)
                    {
                        Utilizator ut = new Utilizator(nrLeg, nume, user, parola, rolSelectat);
                        bool succes = this.utilizatorPersistent.AdaugareUtilizator(ut);
                        if (!succes)
                            MessageBox.Show("Eroare la adaugare!");
                        else
                        {
                            this.refreshLista();
                        }
                    }

                }
            }

        }
        private void actualizare(object sender, EventArgs e)
        {
            if (this.AdministratorV.AccesdataGridView1().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nici un utilizator selectat pentru a fi actualizat!");
            }
            else
            {
                bool dateCorecte = true;
                string legitimatie = this.AdministratorV.AccestxtLegitimatie().Text;
                string nume = this.AdministratorV.AccestxtNume().Text;
                string user = this.AdministratorV.AccestxtUser().Text;
                string parola = this.AdministratorV.AccestxtParola().Text;
                string rolSelectat = this.AdministratorV.AccescmbRolU().Text;
               // int rolSelectat = int.Parse(roluSelectat);


                uint legit = Convert.ToUInt32(this.AdministratorV.AccesdataGridView1().SelectedRows[0].Cells[0].Value);

                uint nrLegNou;

                bool conversie = uint.TryParse(legitimatie, out nrLegNou);
                if (conversie)
                {
                    nrLegNou = Convert.ToUInt32(legitimatie);
                    if (nrLegNou == 0)
                    {
                        dateCorecte = false;
                        MessageBox.Show("ID-ul nu poate fi 0!");
                    }
                }

                if ((!Regex.IsMatch(legitimatie, @"^\d+$")) && legitimatie != "")
                {
                    MessageBox.Show("ID-ul trebuie sa fie compus din cifre!!!");
                    dateCorecte = false;
                }

                if (this.utilizatorPersistent.CautareUtilizator(nrLegNou) != null)
                {
                    MessageBox.Show("Exista alt utilizator cu acest ID!");
                    dateCorecte = false;
                }
                else
                {

                    if (dateCorecte)
                    {



                        Utilizator ut = new Utilizator(nrLegNou, nume, user, parola, rolSelectat);
                        bool succes = this.utilizatorPersistent.ActualizareUtilizator(legit, ut);
                        if (!succes)
                            MessageBox.Show("Eroare la actualizare!");
                        else
                            this.refreshLista();
                    }
                }

            }
        }
        private void stergere(object sender, EventArgs e)
        {
            if (this.AdministratorV.AccesdataGridView1().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nici un utilizator selectat pentru a fi sters!");
            }
            else
            {
                uint legitimatie = Convert.ToUInt32(this.AdministratorV.AccesdataGridView1().SelectedRows[0].Cells[0].Value);
                if (this.utilizatorPersistent.StergereUtilizator(legitimatie))
                {
                    this.refreshLista();

                }
                else
                    MessageBox.Show("Nu s-a realizat stergerea in fisier!");
            }
        }

        private void vizualizare(object sender, EventArgs e)
        {
            List<Utilizator> lista = this.utilizatorPersistent.ListaUtilizatori();

            if (lista != null)
            {
                this.AdministratorV.AccesdataGridView1().Rows.Clear();
                foreach (Utilizator ut in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.AdministratorV.AccesdataGridView1());
                    rand.Cells[0].Value = ut.AccesLegitimatie();
                    rand.Cells[1].Value = ut.AccesNume();
                    rand.Cells[2].Value = ut.AccesCont();
                    rand.Cells[3].Value = ut.AccesParola();
                    rand.Cells[4].Value = ut.AccesRol();
                    this.AdministratorV.AccesdataGridView1().Rows.Add(rand);
                }
            }
            else
                MessageBox.Show("Lista utilizatorilor este vida!");

        }




        private void filtrare(object sender, EventArgs e)
        {
            List<Utilizator> lista = new List<Utilizator>();
            lista = this.utilizatorPersistent.ListaUtilizatori();
            string rolSelectat = this.AdministratorV.AcessFiltrareBox().Text;
            if (rolSelectat == "") MessageBox.Show("Selectati un rol pentru filtrare!");
            else
            {
                if (lista != null)
                {
                    this.AdministratorV.AccesdataGridView1().Rows.Clear();
                    foreach (Utilizator ut in lista)
                    {
                        if (rolSelectat == ut.AccesRol())
                        {
                            DataGridViewRow rand = new DataGridViewRow();
                            rand.CreateCells(this.AdministratorV.AccesdataGridView1());
                            rand.Cells[0].Value = ut.AccesLegitimatie();
                            rand.Cells[1].Value = ut.AccesNume();
                            rand.Cells[2].Value = ut.AccesCont();
                            rand.Cells[3].Value = ut.AccesParola();
                            rand.Cells[4].Value = ut.AccesRol();
                            this.AdministratorV.AccesdataGridView1().Rows.Add(rand);
                        }
                    }
                }
                else MessageBox.Show("Lista de utilizatori este vida!");
            }

        }





        private void refreshLista()
        {
            List<Utilizator> lista = this.utilizatorPersistent.ListaUtilizatori();

            if (lista != null)
            {
                this.AdministratorV.AccesdataGridView1().Rows.Clear();
                foreach (Utilizator ut in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.AdministratorV.AccesdataGridView1());
                    rand.Cells[0].Value = ut.AccesLegitimatie();
                    rand.Cells[1].Value = ut.AccesNume();
                    rand.Cells[2].Value = ut.AccesCont();
                    rand.Cells[3].Value = ut.AccesParola();
                    rand.Cells[4].Value = ut.AccesRol();
                    this.AdministratorV.AccesdataGridView1().Rows.Add(rand);
                }
            }
            else
                MessageBox.Show("Lista utilizatorilor este vida!");
        }

       

        private void deconectare(object sender, EventArgs e)
        {
            this.AdministratorV.Hide();
            CAutentificare autentificareC = new CAutentificare();
            autentificareC.AccesAutentificareView().Show();
        }
    }
}

