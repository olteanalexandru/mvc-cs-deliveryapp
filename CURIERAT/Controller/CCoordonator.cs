using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Curierat.Model;
using Curierat.Model.Persistenta;
using Curierat.View;

namespace Curierat.Controller
{
    public class CCoordonator
    {
        private CoordonatorV CoordonatorV;
        private ColetPersistent coletPersistent;

        public CCoordonator()
        {
            this.CoordonatorV = new CoordonatorV();
            this.coletPersistent = new ColetPersistent();
            this.gestionareEvenimente();
        }

        public CoordonatorV AccesCoordonatorV()
        {
            return this.CoordonatorV;
        }

        public void gestionareEvenimente()
        {
            this.CoordonatorV.AccesbtnAdaugareCol().Click += new EventHandler(adaugare);
            this.CoordonatorV.AccesbtnActualizareCol().Click += new EventHandler(actualizare);
            this.CoordonatorV.AccesbtnStergereCol().Click += new EventHandler(stergere);
            this.CoordonatorV.AccesbtnListaCol().Click += new EventHandler(vizualizare);
            this.CoordonatorV.AccesbtnCautareDupaNumar().Click += new EventHandler(cauta);
            this.CoordonatorV.AccesbtnDeconectare2().Click += new EventHandler(deconectare);
        }



     

    private void adaugare(object sender, EventArgs e)
        {

            bool dateCorecte = true;
            string cod_col = this.CoordonatorV.AccestxtCod().Text;
            string locatie = this.CoordonatorV.AccestxtLocatie().Text;
            string curier = this.CoordonatorV.AccestxtDisponibilitate().Text;


            if (cod_col == "" || locatie == "" || curier == "")
            {
                dateCorecte = false;
                MessageBox.Show("Nu au fost introduse toate datele necesare!");
            }
            else
            {
                uint cod;

                bool conversie = uint.TryParse(cod_col, out cod);
                if (conversie)
                {
                    cod = Convert.ToUInt32(cod_col);
                    if (cod == 0)
                    {
                        dateCorecte = false;
                        MessageBox.Show("COD-ul nu poate fi 0!");
                    }
                }

                if ((!Regex.IsMatch(cod_col, @"^\d+$")) && cod_col != "")
                {
                    MessageBox.Show("COD-ul trebuie sa fie compus din cifre!!!");
                    dateCorecte = false;
                }



                if (this.coletPersistent.CautareColet(cod) != null)
                {
                    MessageBox.Show("Exista alt colet cu acest COD!");
                    dateCorecte = false;
                }

                if (dateCorecte)
                {


                    string traseuoptim = "";

                    switch (locatie)
                    {
                        case "Cluj":
                            traseuoptim = "prioriatar";
                            break;
                        case "Turda":
                            traseuoptim = "Daca s-au terminat coletele in Cluj";
                            break;
                        case "Floresti":
                            traseuoptim = "Dupa Cluj si Turda";
                            break;

                    }



                    Colet ut = new Colet(cod, locatie, curier , traseuoptim);
                    bool succes = this.coletPersistent.AdaugareColet(ut);
                    if (!succes)
                        MessageBox.Show("Eroare la adaugare!");
                    else
                    {
                        this.refreshLista();
                    }
                }

            }
        }



        private void actualizare(object sender, EventArgs e)
        {
            if (this.CoordonatorV.AccesdataGridView1().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nici un colet selectat pentru a fi actualizat!");
            }
            else
            {
                bool dateCorecte = true;
                string cod_col = this.CoordonatorV.AccestxtCod().Text;
                string locatie = this.CoordonatorV.AccestxtLocatie().Text;
                string curier = this.CoordonatorV.AccestxtDisponibilitate().Text;         
                uint cod_col_selectat = Convert.ToUInt32(this.CoordonatorV.AccesdataGridView1().SelectedRows[0].Cells[0].Value);

                uint cod_col_nou;

                bool conversie = uint.TryParse(cod_col, out cod_col_nou);
                if (conversie)
                {
                    cod_col_nou = Convert.ToUInt32(cod_col);
                    if (cod_col_nou == 0)
                    {
                        dateCorecte = false;
                        MessageBox.Show("COD-ul nu poate fi 0!");
                    }
                }

                if ((!Regex.IsMatch(cod_col, @"^\d+$")) && cod_col != "")
                {
                    MessageBox.Show("COD-ul trebuie sa fie compus din cifre!!!");
                    dateCorecte = false;
                }

                if (this.coletPersistent.CautareColet(cod_col_nou) != null)
                {
                    MessageBox.Show("Exista alt colet cu acest COD!");
                    dateCorecte = false;
                }
                

                    if (dateCorecte)
                    {


                    string traseuoptim = "";

                    switch (locatie)
                    {
                        case "Cluj":
                            traseuoptim = "prioriatar";
                            break;
                        case "Turda":
                            traseuoptim = "Daca s-au terminat coletele in Cluj";
                            break;
                        case "Floresti":
                            traseuoptim = "Dupa Cluj si Turda";
                            break;

                    }

                    Colet col = new Colet(cod_col_nou, locatie, curier , traseuoptim);
                        bool succes = this.coletPersistent.ActualizareColet(cod_col_selectat, col);
                        if (!succes)
                            MessageBox.Show("Eroare la actualizare!");
                        else
                            this.refreshLista();
                    }
                }

            }
        

        private void stergere(object sender, EventArgs e)
        {
            if (this.CoordonatorV.AccesdataGridView1().SelectedRows.Count == 0)
            {
                MessageBox.Show("Nu exista nici un colet selectat pentru a fi sters!");
            }
            else
            {
                uint cod_col = Convert.ToUInt32(this.CoordonatorV.AccesdataGridView1().SelectedRows[0].Cells[0].Value);
                if (this.coletPersistent.StergereColet(cod_col))
                {
                    this.refreshLista();

                }
                else
                    MessageBox.Show("Nu s-a realizat stergerea in fisier!");
            }
        }

        private void vizualizare(object sender, EventArgs e)
        {
            List<Colet> lista = this.coletPersistent.ListaColete();

            if (lista != null)
            {
                this.CoordonatorV.AccesdataGridView1().Rows.Clear();
                foreach (Colet m in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.CoordonatorV.AccesdataGridView1());
                    rand.Cells[0].Value = m.AccesCodColet();
                    rand.Cells[1].Value = m.AccesLocatie();
                    rand.Cells[2].Value = m.AccesCurier();
                    rand.Cells[3].Value = m.AccesTraseuoptim();
                    this.CoordonatorV.AccesdataGridView1().Rows.Add(rand);
                }
            }
            else
                MessageBox.Show("Lista coletelor este vida!");
        }

        private void refreshLista()
        {
            List<Colet> lista = this.coletPersistent.ListaColete();

            if (lista != null)
            {
                this.CoordonatorV.AccesdataGridView1().Rows.Clear();
                foreach (Colet m in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.CoordonatorV.AccesdataGridView1());
                    rand.Cells[0].Value = m.AccesCodColet();
                    rand.Cells[1].Value = m.AccesLocatie();
                    rand.Cells[2].Value = m.AccesCurier();
                    rand.Cells[3].Value = m.AccesTraseuoptim();
                    this.CoordonatorV.AccesdataGridView1().Rows.Add(rand);
                }
            }
            else
                MessageBox.Show("Lista coletelor este vida!");
        }

        private void cauta(object sender, EventArgs e)
        {

            List<Colet> lista = this.coletPersistent.ListaColete();
            string txtCautare = this.CoordonatorV.AccestxtCautareNumar().Text;
       

            if (txtCautare.Equals(""))
            {
                MessageBox.Show("Nu ati introdus numarul coletului!");

            }
            else
            {
                lista = this.coletPersistent.CautareColeteNumar(txtCautare);


                if (lista != null)
                {
                    List<DataGridViewRow> randuri = new List<DataGridViewRow>();
                    this.CoordonatorV.AccesdataGridView1().Rows.Clear();
                    foreach (Colet colet in lista)
                    {
                        DataGridViewRow rand = new DataGridViewRow();
                        rand.CreateCells(this.CoordonatorV.AccesdataGridView1());
                        rand.Cells[0].Value = colet.AccesCodColet();
                        rand.Cells[1].Value = colet.AccesLocatie();
                        rand.Cells[2].Value = colet.AccesCurier();
                        rand.Cells[3].Value = colet.AccesTraseuoptim();
                        
                        this.CoordonatorV.AccesdataGridView1().Rows.Add(rand);
                    }
                }
                else
                    MessageBox.Show("Lista coletelor este vida!");
            }
        }

       
       

        private void deconectare(object sender, EventArgs e)
        {
            this.CoordonatorV.Hide();
            CAutentificare autentificareC = new CAutentificare();
            autentificareC.AccesAutentificareView().Show();
        }
    }
}
