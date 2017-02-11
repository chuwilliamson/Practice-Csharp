using System;
using System.Windows.Forms;
using CombatForms.Scripts;
using System.Diagnostics;
namespace CombatForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameSingleton.Instance.Init();
        }
        private void UpdateHud()
        {
            Debug.WriteLine("update hud");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            GameSingleton.Instance.Test();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
