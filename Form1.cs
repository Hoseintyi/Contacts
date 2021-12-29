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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ContactListGridView.CurrentRow!=null)
            {
                string name = ContactListGridView.CurrentRow.Cells[1].Value.ToString();
                string family = ContactListGridView.CurrentRow.Cells[2].Value.ToString();
                string fullName = name + " " + family;

                if (MessageBox.Show($"آیا از حذف {fullName} مطمئن هستید ؟؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    int contactId = int.Parse(ContactListGridView.CurrentRow.Cells[0].Value.ToString());
                        repository.Delete(contactId);
                        BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را انتخاب کنید","توجه توجه", MessageBoxButtons.OK , MessageBoxIcon.Warning );
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ContactListGridView.CurrentRow!=null)
            {
                var ContactId = int.Parse(ContactListGridView.CurrentRow.Cells[0].Value.ToString());

                addOrEditForm newAddOrEditForm = new addOrEditForm();
                newAddOrEditForm.contactId = ContactId;
                newAddOrEditForm.ShowDialog();

                if (newAddOrEditForm.DialogResult == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }

        private void inputSearch_TextChanged(object sender, EventArgs e)
        {
            ContactListGridView.DataSource = repository.Search(inputSearch.Text);
        }
    }
}
