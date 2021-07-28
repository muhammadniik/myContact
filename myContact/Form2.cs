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
        public int contactIDForNemeForm = 0;
        IcontanctsRepository repository;
        public frmAddorEdite()
        {
            InitializeComponent();
            repository = new contactsRipository();
        }

        private void frmAddorEdite_Load(object sender, EventArgs e)
        {
            if(contactIDForNemeForm == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش شخص مورد نظر";
                DataTable dt = repository.SelectRow(contactIDForNemeForm);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtMobil.Text = dt.Rows[0][3].ToString();
                txtAge.Value = int.Parse( dt.Rows[0][4].ToString());
                txtEmail.Text = dt.Rows[0][5].ToString();
               txtAddress.Text = dt.Rows[0][6].ToString();
                btnSubmit.Text = "ویرایش";
            }
            
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
            if(validateInputs() )
            {
                bool isSuccess;
                if(contactIDForNemeForm== 0)
                {
                     isSuccess =  repository.Insert(txtName.Text, txtFamily.Text, txtMobil.Text, txtEmail.Text, int.Parse(txtAge.Value.ToString()), txtAddress.Text);
                }
                else
                {
                    isSuccess = repository.Update(contactIDForNemeForm, txtName.Text, txtFamily.Text, txtMobil.Text, txtEmail.Text, (int)(txtAge.Value), txtAddress.Text);
                }
                if(isSuccess == true)
                {
                    MessageBox.Show("عملیات موفق با موفقیت", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات ناموفق", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
