using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace NamesManager
{
    public partial class MainForm : Form
    {

        string path = "Names.json";
        public MainForm()
        {
            InitializeComponent();

            this.Padding = new Padding(10, 10, 10, 10);
            button1.Margin = new Padding(5);
            button2.Margin = new Padding(5);
            button3.Margin = new Padding(5);
            listBox1.Margin = new Padding(5);


            this.FormClosing += SaveListOnFormClosing; ;

            listBox1.Sorted = true;

            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            List<string> names = JsonSerializer.Deserialize<List<string>>(stream);
            stream.Close();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(names.ToArray());

            listBox1.MouseMove += ShowMe;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(textBox1.Text))
            {
                MessageBox.Show("Name already exists");
            }
            else
            {
                listBox1.Items.Add(textBox1.Text);

            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> matchNames = new List<string>();
            foreach (var item in listBox1.Items)
            {
                if (item.ToString().Contains(textBox1.Text))
                {
                    matchNames.Add(item.ToString());
                }
            }
            if (matchNames.Count == 1)
            {
                textBox1.Text = matchNames[0];
            }
            else if (matchNames.Count > 1)
            {
                Complete_Name__Form complete_Name__Form = new Complete_Name__Form(matchNames);

                if (complete_Name__Form.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = complete_Name__Form.SelectedName;

                }

            }
        }
        private void SaveListOnFormClosing(object sender, FormClosingEventArgs e)
        {
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(stream, listBox1.Items.Cast<string>().ToList());
            stream.Close();
        }

        private void ShowMe(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);

            if (index >= 0 && index < listBox1.Items.Count)
            {
                string itemText = listBox1.Items[index].ToString();

                // מציגים את ה־ToolTip
                toolTip1.SetToolTip(listBox1, itemText);
            }
            else
            {
                // אם לא על פריט — לא להציג כלום
                toolTip1.SetToolTip(listBox1, "");
            }
        }
    }
}
