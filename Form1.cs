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
            ContactListGridView.AutoGenerateColumns = false;
            ContactListGridView.DataSource = repository.SelectAll();
        }
    }
}
