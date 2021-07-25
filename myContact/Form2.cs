using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myContact.Repository;
using myContact.Services;

namespace myContact
{ 
    
    
    public partial class frmAddorEdite : Form
    {
        IcontanctsRepository repository;
        public frmAddorEdite()
        {
            InitializeComponent();
            repository = new contactsRipository();
        }

        private void frmAddorEdite_Load(object sender, EventArgs e)
        {

        }
        bool validateInputs()
        {
            bool isvalid = true;
            if(txtName.Text == "")
            {
                isvalid = false;
                MessageBox.Show("نام را وارد کن اسکل", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtFamily.Text== "")
            {
                isvalid = false;
                MessageBox.Show("نام خانوادگی را وارد کن اسکل", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAge.Value == 0)
            {
                isvalid = false;
                MessageBox.Show("سن را وارد کن اسکل", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMobil.Text == "")
            {
                isvalid = false;
                MessageBox.Show("موبایل را وارد کن اسکل", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEmail.Text == "")
            {
                isvalid = false;
                MessageBox.Show("ایمیل را وارد کن اسکل", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isvalid;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(validateInputs())
            {
                repository.Insert(txtName.Text, txtFamily.Text, txtMobil.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);
            }
        }

        private void txtMobil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar))&& !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
