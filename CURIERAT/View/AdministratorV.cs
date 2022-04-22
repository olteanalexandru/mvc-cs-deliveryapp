
using Curierat.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Curierat
{
    public partial class AdministratorV : Form
    {
        public AdministratorV()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }



        public Button AccesbtnActualizare()
        {
            return this.btnActualizare;
        }

        public Button AccesbtnStergere()
        {
            return this.btnStergere;
        }

        public Button AccesbtnLista()
        {
            return this.btnLista;
        }

        public Button AccesbtnDeconectare()
        {
            return this.btnDeconectare;
        }



        public TextBox AccestxtLegitimatie()
        {
            return this.txtLegitimatie;
        }

        public TextBox AccestxtNume()
        {
            return this.txtNume;
        }

        public TextBox AccestxtUser()
        {
            return this.txtUser;
        }

        public TextBox AccestxtParola()
        {
            return this.txtParola;
        }
       
        


        public DataGridView AccesdataGridView1()
        {
            return this.dataGridView1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdministratorV_Load(object sender, EventArgs e)
        {

        }

        private void txtLegitimatie_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNume_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRolU_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public ComboBox AccescmbRolU()
        {
            return this.cmbRolU;
        }

        private void btnAdaugareU_Click(object sender, EventArgs e)
        {

        }

        public Button AccesbtnAdaugareU()
        {
            return this.btnAdaugareU;
        }

        private void btnStergere_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizare_Click(object sender, EventArgs e)
        {

        }

        private void btnLista_Click(object sender, EventArgs e)
        {

        }

        private void btnDeconectare_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FiltrareBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public ComboBox AcessFiltrareBox()
        {
            return this.FiltrareBox;
        }

        private void BtnFiltrare_Click(object sender, EventArgs e)
        {

        }
        public Button AccesBtnFiltrare()
        {
            return this.BtnFiltrare;
        }
    }
}
