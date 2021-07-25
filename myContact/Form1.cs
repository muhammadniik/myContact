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
        }
    }
}
