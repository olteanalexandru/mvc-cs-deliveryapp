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
    public class CCurier
    {
        private CurierV CurierV;
        private ColetPersistent coletPersistent;

        public CCurier()
        {
            this.CurierV = new CurierV();
            this.coletPersistent = new ColetPersistent();
            this.gestionareEvenimente();
        }

        public CurierV AccesCurierV()
        {
            return this.CurierV;
        }

        public void gestionareEvenimente()
        {
            this.CurierV.AccesbtnListaCol().Click += new EventHandler(vizualizare);
            this.CurierV.AccesbtnDeconectare2().Click += new EventHandler(deconectare);
            this.CurierV.AccesbtnCautareDupaNumar().Click += new EventHandler(cauta);
        }





        private void vizualizare(object sender, EventArgs e)
        {
            List<Colet> lista = this.coletPersistent.ListaColete();

            if (lista != null)
            {
                this.CurierV.AccesdataGridView1().Rows.Clear();
                foreach (Colet m in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.CurierV.AccesdataGridView1());
                    rand.Cells[0].Value = m.AccesCodColet();
                    rand.Cells[1].Value = m.AccesLocatie();
                    rand.Cells[2].Value = m.AccesCurier();
                    rand.Cells[3].Value = m.AccesTraseuoptim();
                    this.CurierV.AccesdataGridView1().Rows.Add(rand);
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
                this.CurierV.AccesdataGridView1().Rows.Clear();
                foreach (Colet m in lista)
                {
                    DataGridViewRow rand = new DataGridViewRow();
                    rand.CreateCells(this.CurierV.AccesdataGridView1());
                    rand.Cells[0].Value = m.AccesCodColet();
                    rand.Cells[1].Value = m.AccesLocatie();
                    rand.Cells[2].Value = m.AccesCurier();
                    rand.Cells[3].Value = m.AccesTraseuoptim();
                    this.CurierV.AccesdataGridView1().Rows.Add(rand);
                }
            }
            else
                MessageBox.Show("Lista coletelor este vida!");
        }

        private void cauta(object sender, EventArgs e)
        {

            List<Colet> lista = this.coletPersistent.ListaColete();
            string txtCautare = this.CurierV.AccestxtCautareNumar().Text;


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
                    this.CurierV.AccesdataGridView1().Rows.Clear();
                    foreach (Colet colet in lista)
                    {
                        DataGridViewRow rand = new DataGridViewRow();
                        rand.CreateCells(this.CurierV.AccesdataGridView1());
                        rand.Cells[0].Value = colet.AccesCodColet();
                        rand.Cells[1].Value = colet.AccesLocatie();
                        rand.Cells[2].Value = colet.AccesCurier();
                        rand.Cells[3].Value = colet.AccesTraseuoptim();

                        this.CurierV.AccesdataGridView1().Rows.Add(rand);
                    }
                }
                else
                    MessageBox.Show("Lista coletelor este vida!");
            }
        }




        private void deconectare(object sender, EventArgs e)
        {
            this.CurierV.Hide();
            CAutentificare autentificareC = new CAutentificare();
            autentificareC.AccesAutentificareView().Show();
        }
    }
}

