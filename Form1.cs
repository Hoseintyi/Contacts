using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contacts.Repository;
using Contacts.Services;

namespace Contacts
{
    public partial class Form1 : Form
    {
        private IContactRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            ContactListGridView.AutoGenerateColumns = false;
            ContactListGridView.DataSource = repository.SelectAll();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
          BindGrid();
        }

        private void BtnAddNewContact_Click(object sender, EventArgs e)
        {
            addOrEditForm newAddOrEditForm = new addOrEditForm();

            newAddOrEditForm.ShowDialog();

            if (newAddOrEditForm.DialogResult== DialogResult.OK )
            {
                BindGrid();
            }
        }
    }
}
