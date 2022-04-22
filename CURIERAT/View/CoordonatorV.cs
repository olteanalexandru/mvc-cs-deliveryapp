
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Curierat.View
{
    public partial class CoordonatorV : Form
    {
            public CoordonatorV()
            {
                InitializeComponent();
            }

            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                base.OnFormClosing(e);
                Environment.Exit(0);
            }




        
      

        private void txtLocatie_TextChanged(object sender, EventArgs e)
        {

        }
        public TextBox AccestxtLocatie()
        {
            return this.txtLocatie;
        }

        private void txtCautareNumar_TextChanged(object sender, EventArgs e)
        {

        }
        public TextBox AccestxtCautareNumar()
        {
            return this.txtCautareNumar;
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }
        public TextBox AccestxtCod()
        {
            return this.txtCod;
        }


        private void txtDisponibilitate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public ComboBox AccestxtDisponibilitate()
        {
            return this.txtDisponibilitate;
        }

        private void btnCautareDupaNumar_Click(object sender, EventArgs e)
        {

        }

        public Button AccesbtnCautareDupaNumar()
        {
            return this.btnCautareDupaNumar;
        }

        private void btnAdaugareCol_Click(object sender, EventArgs e)
        {

        }
        public Button AccesbtnAdaugareCol()
        {
            return this.btnAdaugareCol;
        }

        private void btnActualizareCol_Click(object sender, EventArgs e)
        {

        }
        public Button AccesbtnActualizareCol()
        {
            return this.btnActualizareCol;
        }

        private void btnStergereCol_Click(object sender, EventArgs e)
        {

        }
        public Button AccesbtnStergereCol()
        {
            return this.btnStergereCol;
        }

        private void btnListaCol_Click(object sender, EventArgs e)
        {

        }
        public Button AccesbtnListaCol()
        {
            return this.btnListaCol;
        }

        private void btnDeconectare2_Click(object sender, EventArgs e)
        {

        }
        public Button AccesbtnDeconectare2()
        {
            return this.btnDeconectare2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public DataGridView AccesdataGridView1()
        {
            return this.dataGridView1;
        }

        private void CoordonatorV_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Locatie_Click(object sender, EventArgs e)
        {

        }
    }
    
}
