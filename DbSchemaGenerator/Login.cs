using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbSchemaGenerator
{
    public partial class Login : Form
    {
        private int[] key = new List<int>()
        {
            38,38,40,40,37,39,37,39,65,66,65,66
        }.ToArray();
        private int position = 0;
        private Form1 _form;
        public Login(Form1 f)
        {
            _form = f;
            InitializeComponent();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            checkkey(e.KeyValue);
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void checkkey(int keycode)
        {
            if (key[position] == keycode)
            {
                position++;
                if (position == key.Length)
                {
                    this.Close();
                }
            }
            else
            {
                position = 0;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (position != key.Length)
            {
                _form.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wrong password.");
        }
    }
}
