using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tweak8._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void HideAll()
        {
            pictureBox1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl1.Visible = false;
            label1.Font = new Font(label1.Font, FontStyle.Regular);
            label2.Font = new Font(label2.Font, FontStyle.Regular);
            label3.Font = new Font(label2.Font, FontStyle.Regular);
            label4.Font = new Font(label2.Font, FontStyle.Regular);
            label5.Font = new Font(label2.Font, FontStyle.Regular);
            label6.Font = new Font(label2.Font, FontStyle.Regular);
            label7.Font = new Font(label2.Font, FontStyle.Regular);
            label8.Font = new Font(label2.Font, FontStyle.Regular);
            label9.Font = new Font(label2.Font, FontStyle.Regular);
        }

        private void EnableSet(int i)
        {
            HideAll();

            if (i == 1)
            {
                tabControl1.Visible = true;
                label1.Font = new Font(label1.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 2)
            {
                tabControl2.Visible = true;
                label2.Font = new Font(label2.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 3)
            {
                tabControl3.Visible = true;
                label3.Font = new Font(label3.Font, FontStyle.Underline | FontStyle.Bold);
            }

        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label.Font.Bold)
                label.Font = new Font(label.Font, FontStyle.Bold | FontStyle.Underline);
            else
                label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label.Font.Bold)
                label.Font = new Font(label.Font, FontStyle.Bold);
            else
                label.Font = new Font(label.Font, FontStyle.Regular);
        }

// label1
        private void label1_Click(object sender, EventArgs e)
        {
            EnableSet(1);
        }

// label2
        private void label2_Click(object sender, EventArgs e)
        {
            EnableSet(2);
        }

// label3
        private void label3_Click(object sender, EventArgs e)
        {
            EnableSet(3);
        }
    }
}
