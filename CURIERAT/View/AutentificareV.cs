using System;
using System.Windows.Forms;
using Curierat.Model;
using Curierat.Model.Persistenta;

namespace Curierat.View
{
    public partial class AutentificareV : Form
    {
        public AutentificareV()
        {
            InitializeComponent();
        }

      

       

      

        private void AutentificareV_Load(object sender, System.EventArgs e)
        {

        }

        private void btnAutentificare_Click(object sender, System.EventArgs e)
        {

        }

        public Button AccesbtnAutentificare()
        {
            return this.btnAutentificare;
        }

        private void txtParolaAutentificare_TextChanged(object sender, EventArgs e)
        {

        }
        public TextBox AccestxtParolaAutentificare()
        {
            return this.txtParolaAutentificare;
        }

        private void txtUserAutentificare_TextChanged(object sender, EventArgs e)
        {

        }

        public TextBox AccestxtUserAutentificare()
        {
            return this.txtUserAutentificare;
        }

    }
}
