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
    
    public partial class Form1 : Form
    {
        IcontanctsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new contactsRipository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void bindGrid()
        {
            dgContacts.AutoGenerateColumns = false;
            dgContacts.DataSource = repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            bindGrid();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            frmAddorEdite frm = new frmAddorEdite();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                bindGrid();
            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow != null)
            {
                string name = dgContacts.CurrentRow.Cells[0].Value.ToString() + dgContacts.CurrentRow.Cells[2].Value.ToString();
               if(MessageBox.Show($"از حذف {name} مطمِن هستید؟" ,"",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    int indecs = int.Parse(dgContacts.CurrentRow.Cells[1].Value.ToString());
                    repository.Delet(indecs);
                    bindGrid();
                }
            }
            else{
                MessageBox.Show("شخصی انتخاب نشده است!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow!= null)
            {
                int contactId = int.Parse(dgContacts.CurrentRow.Cells[1].Value.ToString());
                frmAddorEdite frm = new frmAddorEdite();
                frm.contactIDForNemeForm = contactId;
               if( frm.ShowDialog()== DialogResult.OK)
                {
                    bindGrid();
                }
                
                
                

            }
            else
            {
                MessageBox.Show(" شخصی انتخاب نشده!", " هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgContacts.DataSource = repository.search(txtSearch.Text);
        }
    }
}
