using System;
using System.Windows.Forms;

namespace Curierat.View
{
    public partial class CurierV : Form
    {
        public CurierV()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }

        private void btnCautareDupaLocatie_Click(object sender, EventArgs e)
        {

        }
        public Button AccesbtnCautareDupaNumar()
        {
            return this.btnCautareDupaLocatie;
        }

     

        private void btnListaCol_Click(object sender, EventArgs e)
        {

        }
        public Button AccesbtnListaCol()
        {
            return this.btnListaCol;
        }

        private void txtCautareLocatie_TextChanged(object sender, EventArgs e)
        {

        }

        public TextBox AccestxtCautareNumar()
        {
            return this.txtCautareLocatie;
        }

        public TextBox AccestxtCautareLocatie()
        {
            return this.txtCautareLocatie;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public DataGridView AccesdataGridView1()
        {
            return this.dataGridView1;
        }


        private void btnDeconectare2_Click(object sender, EventArgs e)
        {

        }

        

            public Button AccesbtnDeconectare2()
        {
            return this.btnDeconectare2;
        }

        private void CurierV_Load(object sender, EventArgs e)
        {

        }
    }
    
}


