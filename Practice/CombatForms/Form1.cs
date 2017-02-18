using System;
using System.Windows.Forms;
using Dialogue;
using System.Data;

namespace CombatForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataSet dataSet = new DataSet();
            string inFile = DialogueManager.Instance.inFile;
            dataSet.ReadXml(inFile);
            dataGridView1.DataSource = dataSet.Tables[1];
            DialogueManager.Instance.ToString();
            current = DialogueManager.Instance.tree.Current.Current;
            previous = current;
            textBox1.Text = current.ToString();
            UpdateGrid();

        }
        DialogueNode current,previous;
        private void button1_Click(object sender, EventArgs e)
        {           
            current = DialogueManager.Instance.tree.Current.Next;
            textBox1.Text = current.ToString();
            UpdateGrid();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            previous = current;
            current = DialogueManager.Instance.tree.Next.Current;
            UpdateGrid();
            
        }

        private void UpdateGrid()
        {
            string searchValue = current.ConversationID;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if(row.Cells[0].Value.ToString().Equals(searchValue) && row.DefaultCellStyle.BackColor != System.Drawing.Color.Blue)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Blue;
                        textBox1.Text = current.ToString();
                        break;
                    }
                }
                catch
                {
                    textBox1.Text = current.ToString();
                    textBox1.Text += Environment.NewLine + "dialogue exhausted....";
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var oldp = previous;
            previous = current;
            current = oldp;
            
            textBox1.Text = current.ToString();
        }
    }
}
