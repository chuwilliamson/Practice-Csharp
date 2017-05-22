using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manatee.Trello;
using Manatee.Trello.ManateeJson;
using Manatee.Trello.WebApi;


namespace TrelloForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string appkey = "16dd83fb7ecf4ffcc19a19491674100f";
            string secret = "bd1a0e9339cddaa21c64895ecdd8748880e7c49fde99da99d4e07f9e456f7615";
            var serializer = new ManateeSerializer();
            TrelloConfiguration.Serializer = serializer;
            TrelloConfiguration.Deserializer = serializer;
            TrelloConfiguration.JsonFactory = new ManateeFactory();
            TrelloConfiguration.RestClientProvider = new WebApiClientProvider();
            TrelloAuthorization.Default.AppKey = appkey;
            TrelloAuthorization.Default.UserToken = secret;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string studentworklogid = "5693dcababc42ff7503d8271";
            var board = new Board(studentworklogid);
            
            var query = SearchFor.TextInName(textBox1.Text);
            
            var results = new Search(query, 100, SearchModelType.Cards);
            var card = results.Cards.ToList();

            foreach(var s in card[0].Comments)
            {
                richTextBox1.Text += string.Format("{0} \n {1} \n {2}", s, s.Date, "=============================\n");
                
                    
            }
                



        }
    }
}
