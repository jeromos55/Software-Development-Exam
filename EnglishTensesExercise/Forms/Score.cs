using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishTensesExercise.Forms
{
    partial class Score : Form
    {
        public static List<Pontszamok> pontszamok;

        internal List<Pontszamok> Pontszamok { get => pontszamok; set => pontszamok = value; }

        public Score()
        {
            InitializeComponent();
            Pontszamok = pontszamok;
            //try
            //{
            //    Pontszamok = EnglishTenses_DB_Handler.ReadScore();

            //}
            //catch (DB_Exeption ex)
            //{
            //    MessageBox.Show(ex.Message + " - Original error: " + ex.InnerException.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //ListBoxRefresh();
        }

        void ListBoxRefresh()
        {          
                listBox1.DataSource = null;
                listBox1.DataSource = Pontszamok;
        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cButton2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Pontszamok.Remove((Pontszamok)listBox1.SelectedItem);
                EnglishTenses_DB_Handler.DeleteScores((Pontszamok)listBox1.SelectedItem);
            }
            ListBoxRefresh();
        }

        private void Score_Load(object sender, EventArgs e)
        {          
            try
            {
                Pontszamok = EnglishTenses_DB_Handler.ReadScore();

            }
            catch (DB_Exeption ex)
            {
                MessageBox.Show(ex.Message + " - Original error: " + ex.InnerException.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ListBoxRefresh();
            languageText(Form1.language);
        }

        private void languageText(bool language)
        {
            if (language == false)
            {
                label1.Text = "HIGH SCORE";
                label4.Text = "USERNAME / TENSE  / SCORE";
                label4.Location = new Point(290, 91);
                cButton2.Text = "Delete";
                cButton1.Text = "Close";
            }
            else
            {
                label1.Text = "PONTSZÁMOK";
                label4.Text = "FELHASZÁLÓ NEVE / IGEIDŐ  / PONTSZÁM";
                label4.Location = new Point(200, 91);
                cButton2.Text = "Törlés";
                cButton1.Text = "Bezárás";
            }
            
        }
    }
}
