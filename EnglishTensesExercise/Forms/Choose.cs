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
    public partial class Choose : Form
    {
        int score, questionPosition;
        int[] rightAnswer = new int[20];
        string[] englishSentences = new string[20];
        string[,] question = new string[4, 20];

        List<Mondatok> englishSentencesFromDB = new List<Mondatok>();
        List<string> englishSentencesOriginalList = new List<string>();
        List<Mondatok> englishSentencesFromMondatok = new List<Mondatok>();


        public Choose()
        {
            InitializeComponent();
            questionPosition = 0;

            switch (Form1.igeido)
            {
                case Igeidok.Simple:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FutureSimple));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastSimple));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentSimple));
                    break;
                case Igeidok.Perfect:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FuturePerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastPerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentPerfect));
                    break;
                case Igeidok.Continouos:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FutureContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentContinous));
                    break;
                case Igeidok.PerfectContinuos:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FuturePerfectContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastPerfectContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentPerfectContinous));
                    break;
                case Igeidok.Past:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastPerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastPerfectContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastSimple));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastContinous));
                    break;
                case Igeidok.Present:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentPerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentSimple));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentPerfectContinous));
                    break;
                case Igeidok.Future:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FutureContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FuturePerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FuturePerfectContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FutureSimple));
                    break;
                case Igeidok.All:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastPerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastPerfectContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastSimple));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentPerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentSimple));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentPerfectContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FutureContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FuturePerfect));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FuturePerfectContinous));
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Igeidok.FutureSimple));
                    break;
                default:
                    listAdd(EnglishTenses_DB_Handler.ReadSentences(Form1.igeido));
                    break;
            }

            //englishSentencesFromDB = EnglishTenses_DB_Handler.ReadSentences(Form1.igeido);
            //listAdd(EnglishTenses_DB_Handler.ReadSentences(Form1.igeido));

            randomSentencesDB(englishSentencesFromMondatok);

            // angol mondatok betöltése adatbázisból
            for (int i = 0; i < englishSentencesFromMondatok.Count; i++) 
            {
                int j = 0;
                string englishSentence = englishSentencesFromMondatok[i].Mondat;
                englishSentencesOriginalList.Add(englishSentencesFromMondatok[i].Mondat.Replace("_", " "));
                string rightEnglishSentence = null;
                string[] splitSentence = englishSentence.Split(' ');
                foreach (string item in splitSentence)
                {
                    if (j != englishSentencesFromMondatok[i].Kerdes[0].MondatPozicio - 1)
                    {
                        rightEnglishSentence += item + " ";
                    }
                    else
                    {
                        rightEnglishSentence += "......" + " ";
                    }
                    j++;
                }

                englishSentencesFromMondatok[i].Mondat = rightEnglishSentence;
            }

        }

        private void cButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customImageButton2_Click(object sender, EventArgs e)
        {
            customImageButton2.Visible = false;
            customImageButton3.Visible = true;
            customImageButton4.Visible = true;
            customImageButton5.Visible = true;
        }

        private void customImageButton3_Click(object sender, EventArgs e)
        {
            customImageButton2.Visible = true;
            customImageButton3.Visible = false;
            customImageButton4.Visible = true;
            customImageButton5.Visible = true;
        }

        private void customImageButton4_Click(object sender, EventArgs e)
        {
            customImageButton2.Visible = true;
            customImageButton3.Visible = true;
            customImageButton4.Visible = false;
            customImageButton5.Visible = true;
        }

        private void customImageButton5_Click(object sender, EventArgs e)
        {
            customImageButton2.Visible = true;
            customImageButton3.Visible = true;
            customImageButton4.Visible = true;
            customImageButton5.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                cButton1.Visible = false;
                cButton2.Visible = false;
                cButton4.Visible = true;
                cButton3.Visible = true;
        }
            }

        private void Choose_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labelFontSize(englishSentencesFromMondatok[0].Mondat);
            label2.Text = englishSentencesFromMondatok[0].Mondat;
            label3.Text = englishSentencesFromMondatok[0].Kerdes[0].Kerdes.Replace("_", " ");
            label4.Text = englishSentencesFromMondatok[0].Kerdes[1].Kerdes.Replace("_", " ");
            label5.Text = englishSentencesFromMondatok[0].Kerdes[2].Kerdes.Replace("_", " ");
            label6.Text = englishSentencesFromMondatok[0].Kerdes[3].Kerdes.Replace("_", " ");
            cButton3.Visible = false;
            cButton2.Visible = false;
            label7.Text = (questionPosition + 1).ToString() + " / " + score.ToString();
            cButton1.Visible = false;
            cButton5.Visible = true;
            languageText(Form1.language);
        }

        private void cButton1_Click(object sender, EventArgs e)
        {

            cButton2.Visible = false;
            cButton5.Visible = true;
            cButton1.Visible = false;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Black;

            if (questionPosition >= 19)
            {
                timer1.Stop();
                cButton1.Visible = false;
                cButton2.Visible = false;
                cButton4.Visible = true;
                cButton3.Visible = true;
            }
            else //if (questionPosition <= 19)
            {
                label7.Text = (questionPosition + 2).ToString() + " / " + score.ToString();
                questionPosition++;

                labelFontSize(englishSentencesFromMondatok[questionPosition].Mondat);
                label2.Text = englishSentencesFromMondatok[questionPosition].Mondat;
                label3.Text = englishSentencesFromMondatok[questionPosition].Kerdes[0].Kerdes.Replace("_", " ");
                label4.Text = englishSentencesFromMondatok[questionPosition].Kerdes[1].Kerdes.Replace("_", " ");
                label5.Text = englishSentencesFromMondatok[questionPosition].Kerdes[2].Kerdes.Replace("_", " ");
                label6.Text = englishSentencesFromMondatok[questionPosition].Kerdes[3].Kerdes.Replace("_", " ");

                customImageButton2.Visible = true;
                customImageButton3.Visible = true;
                customImageButton4.Visible = true;
                customImageButton5.Visible = true;
            }
        }

        private void cButton4_Click(object sender, EventArgs e)
        {
            bool isModify = false;
            this.Close();
            Pontszamok pontok = new Pontszamok((Igeidok)Form1.igeido, Form1.user, score);

            // Ha nem volt még felhívva a Score tábla akkor még nincs az adatbázisban semmi ezért beolvassuk (a pontszamok lista üres)
            if (Score.pontszamok == null)
            {
                try
                {
                    Score.pontszamok = EnglishTenses_DB_Handler.ReadScore();

                }
                catch (DB_Exeption ex)
                {
                    MessageBox.Show(ex.Message + " - Original error: " + ex.InnerException.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Ha van valami az adatbázisban (a pontszamok lista nem üres) és
            //ha a felhasználó neve és az ige idők valahol megegyezbek akkor módosítás (ture) ha nem marad (false)
            foreach (Pontszamok item in Score.pontszamok)
            {
                if (item.FelhasznaloNeve == pontok.FelhasznaloNeve && item.Igeidok == pontok.Igeidok)
                {
                    isModify = true;
                    pontok.ID = item.ID;
                }
            }

            if (isModify)
            {
                EnglishTenses_DB_Handler.ModifyScore(pontok);
            }
            else
            {
                EnglishTenses_DB_Handler.InsertScore(pontok);
            }
        }

        private void cButton5_Click(object sender, EventArgs e)
        {
            if (customImageButton2.Visible == false && englishSentencesFromMondatok[questionPosition].Kerdes[0].HelyesE == true)
            {
                score++;
                cButton2.BackColor = Color.Green;
                if (Form1.language == true)
                {
                    cButton2.Text = "RIGHT";
                }
                else
                {
                    cButton2.Text = "HELYES";
                }
                cButton2.Visible = true;
                labelFontSize(englishSentencesOriginalList[questionPosition]);
                label2.Text = englishSentencesOriginalList[questionPosition];
            }
            else if (customImageButton3.Visible == false && englishSentencesFromMondatok[questionPosition].Kerdes[1].HelyesE == true)
            {
                score++;
                cButton2.BackColor = Color.Green;
                if (Form1.language == false)
                {
                    cButton2.Text = "RIGHT";
                }
                else
                {
                    cButton2.Text = "HELYES";
                }
                cButton2.Visible = true;
                labelFontSize(englishSentencesOriginalList[questionPosition]);
                label2.Text = englishSentencesOriginalList[questionPosition];
            }
            else if (customImageButton4.Visible == false && englishSentencesFromMondatok[questionPosition].Kerdes[2].HelyesE == true)
            {
                score++;
                cButton2.BackColor = Color.Green;
                if (Form1.language == false)
                {
                    cButton2.Text = "RIGHT";
                }
                else
                {
                    cButton2.Text = "HELYES";
                }
                cButton2.Visible = true;
                labelFontSize(englishSentencesOriginalList[questionPosition]);
                label2.Text = englishSentencesOriginalList[questionPosition];
            }
            else if (customImageButton5.Visible == false && englishSentencesFromMondatok[questionPosition].Kerdes[3].HelyesE == true)
            {
                score++;
                cButton2.BackColor = Color.Green;
                if (Form1.language == false)
                {
                    cButton2.Text = "RIGHT";
                }
                else
                {
                    cButton2.Text = "HELYES";
                }
                cButton2.Visible = true;
                labelFontSize(englishSentencesOriginalList[questionPosition]);
                label2.Text = englishSentencesOriginalList[questionPosition];
            }
            else
            {
                cButton2.BackColor = Color.Red;
                if (Form1.language == false)
                {
                    cButton2.Text = "WRONG";
                }
                else
                {
                    cButton2.Text = "ROSSZ";
                }
                cButton2.Visible = true;
                labelFontSize(englishSentencesOriginalList[questionPosition]);
                label2.Text = englishSentencesOriginalList[questionPosition];
                label2.BackColor = Color.Red;
                label2.ForeColor = Color.White;
            }



            cButton5.Visible = false;
            cButton1.Visible = true;
        }

        private void cButton3_Click(object sender, EventArgs e)
        {

        }

        private void randomSentencesDB(List<Mondatok> englishSentencesFromMondatok)
        {
            var random = new Random();
            for (int i = 0; i < englishSentencesFromMondatok.Count; i++)
            {
                int ujindex = random.Next(0, englishSentencesFromMondatok.Count);
                Mondatok masik = englishSentencesFromMondatok[ujindex];
                englishSentencesFromMondatok[ujindex] = englishSentencesFromMondatok[i];
                englishSentencesFromMondatok[i] = masik;
            }
        }

        private void labelFontSize(string txt)
        {
            if (txt.Length > 65)
            {
                label2.Font = new Font("Verdana", 16);
                label2.Location = new Point(100, 166);
            }
            else
            {
                label2.Font = new Font("Verdana", 18);
                label2.Location = new Point(195, 166);
            }
        }

        private void listAdd(List<Mondatok> englishSentencesFromDB)
        {
            for (int i = 0; i < englishSentencesFromDB.Count; i++)
            {
                englishSentencesFromMondatok.Add(englishSentencesFromDB[i]);
            }
        }

        private void languageText(bool language)
        {
            if (language == false)
            {
                label1.Text = "MULTI CHOICE";
                cButton3.Text = "EXERCISE SUCCESFULL";
                cButton4.Text = "EXIT";
                cButton5.Text = "CHECK";
                cButton1.Text = "NEXT";
            }
            else
            {
                label1.Text = "VÁLASZTÁS";
                cButton3.Text = "FELADAT BEFEJEZŐDÖTT";
                cButton4.Text = "KILÉPÉS";
                cButton5.Text = "JAVÍT";
                cButton1.Text = "KÖVETKEZŐ";
            }

        }
    }
}
