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

        public int contactId=0;
        public addOrEditForm()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void addOrEditForm_Load(object sender, EventArgs e)
        {
            if (contactId==0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش ";
               DataTable dt =  repository.SelectContactById(contactId);
               inputName.Text = dt.Rows[0][1].ToString();
               inputFamily.Text = dt.Rows[0][2].ToString();
               inputMobile.Text = dt.Rows[0][3].ToString();
               inputStaticPhone.Text = dt.Rows[0][4].ToString();
               inputEmail.Text = dt.Rows[0][5].ToString();
               btnSubmit.Text = "ویرایش";
            }
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
                bool isSuccess;

                if (contactId==0)
                {
                    isSuccess = repository.Insert(inputName.Text, inputFamily.Text, inputMobile.Text, inputStaticPhone.Text,
                        inputEmail.Text);
                }
                else
                {
                    isSuccess = repository.Update(contactId,inputName.Text, inputFamily.Text, inputMobile.Text, inputStaticPhone.Text,
                        inputEmail.Text);
                }

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
