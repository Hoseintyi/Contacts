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
    public partial class addOrEditForm : Form
    {
        private IContactRepository repository;
        public addOrEditForm()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void addOrEditForm_Load(object sender, EventArgs e)
        {
            this.Text = "افزودن شخص جدید";
        }


        bool ValidateInputs()
        {
            
            if (inputName.Text == "")
            {
                
                MessageBox.Show("لطفا نام را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (inputFamily.Text == "")
            {
                
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
              bool isSuccess =   repository.Insert(inputName.Text, inputFamily.Text, inputMobile.Text, inputStaticPhone.Text,
                    inputEmail.Text);

              if (isSuccess==true)
              {
                  MessageBox.Show("با موفقیت ثبت شد", "تبرییک", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  DialogResult = DialogResult.OK;
              }
              else
              {
                  MessageBox.Show("عملیات با شکست مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              }


            }
        }
    }
}
