using System;
using System.Windows.Forms;

namespace Enrolment_Register
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            

            if (txtName.Text.Length > 0)
            {
                foreach (Student student in e_Data.s_List)
                {
                    if (student.name == txtName.Text)
                    {

                        lblOutput.Text = txtName.Text + " is in the list!";
                        break;
                    }

                    else
                    {
                        lblOutput.Text = txtName.Text + " is not in the list!";
                    }

                }
            }

            else
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
