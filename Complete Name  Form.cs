using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NamesManager
{
    public partial class Complete_Name__Form : Form
    {
        public string SelectedName { get; set; }
        public Complete_Name__Form(List<string> listFromMain)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            listBox1.Items.AddRange(listFromMain.ToArray());

        }

        private void Complete_Name__Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                SelectedName = listBox1.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
