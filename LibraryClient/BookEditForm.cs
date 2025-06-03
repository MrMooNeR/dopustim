using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClient
{
    public partial class BookEditForm : Form
    {
        public string BookTitle => textBoxTitle.Text;
        public string BookAuthor => textBoxAuthor.Text;

        public BookEditForm()
        {
            InitializeComponent();
        }

        public BookEditForm(string title, string author) : this()
        {
            textBoxTitle.Text = title;
            textBoxAuthor.Text = author;
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
