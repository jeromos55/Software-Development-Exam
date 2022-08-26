using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EnglishTensesExercise.Forms
{
    public partial class Arrange : Form
    {
        int score, questionPosition, wordPosition, xQuestion, yQuestion;
        string answer;
        List<Mondatok> englishSentencesFromDB = new List<Mondatok>();
        List<Mondatok> englishSentencesGroupFromDB = new List<Mondatok>();
        List<string> englishSentences = new List<string>();
        List<string> englishQuestionWords = new List<string>();
        List<Button> englishQuestionWordsButton = new List<Button>();
        List<Button> englishAnsweWordsButton = new List<Button>();


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
            //ha a felhasználó neve és az ige idők valahol megegyezbek akkor módosítás (true) ha nem marad (false)
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

        public Arrange()
        {
            InitializeComponent();
            score = 0;
            questionPosition = 0;
            wordPosition = 0;
            xQuestion = 80;
            yQuestion = 400;

            
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

            //------------TODO Csoportok behívása megírni
            //englishSentencesGroupFromDB.AddRange(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PastSimple));
            //englishSentencesGroupFromDB.AddRange(EnglishTenses_DB_Handler.ReadSentences(Igeidok.PresentSimple));

            //englishSentencesFromDB = englishSentencesGroupFromDB;

            //------------TODO Csoportok behívása megírni

            //for (int i = 0; i < englishSentencesFromDB.Count; i++)
            //{              
            //    englishSentences.Add(englishSentencesFromDB[i].Mondat.Replace("_", " "));
            //}          

            randomSentences(englishSentences);
        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            cButton5.Visible = false;
            cButton1.Visible = false;
            cButton6.Visible = true;
            cButton2.Visible = false;

            if (questionPosition < 19)
            {
                deleteBottuns(wordPosition);
                cButton5.Visible = false;

                questionPosition++;

                string[] splitWords = englishSentences[questionPosition].Split(' ');

                randomWords(splitWords);
                englishQuestionWords.Clear();

                foreach (string item in splitWords)
                {
                    englishQuestionWords.Add(item);
                }

                xQuestion = 80;
                yQuestion = 400;
                wordPosition = 0;
                drawButtonsQuestion(englishQuestionWords);
            }
            else
            {
                deleteBottuns(wordPosition);
                cButton5.Visible = false;

                timer1.Stop();
                cButton1.Visible = false;
                cButton6.Visible = false;
                cButton5.Visible = false;
                cButton4.Visible = true;
                cButton3.Visible = true;
            }

            englishQuestionWordsButton.Clear();
            englishAnsweWordsButton.Clear();
        }

        private void cButton6_Click(object sender, EventArgs e)
        {
            answer = "";
            for (int i = 0; i <= englishAnsweWordsButton.Count - 1; i++)
            {
                answer += englishAnsweWordsButton[i].Text + " ";

            }

            if (answer.Trim() == englishSentences[questionPosition].Trim())
            {
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
                score++;
                label7.Text = (questionPosition + 1).ToString() + " / " + score.ToString();
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
                label7.Text = (questionPosition + 1).ToString() + " / " + score.ToString();
                if (questionPosition == 1)
                {
                    cButton5.Text = englishSentences[questionPosition];
                }
                else
                {
                    cButton5.Text = englishSentences[questionPosition];
                }
                cButton5.Visible = true;
            }

            cButton6.Visible = false;
            cButton1.Visible = true;
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
                cButton6.Visible = false;
                cButton4.Visible = true;
                cButton3.Visible = true;

                deleteBottuns(wordPosition);
                cButton5.Visible = false;
                
            }
        }

        private void Arrange_Load(object sender, EventArgs e)
        {
            timer1.Start();
            cButton3.Visible = false;
            cButton4.Visible = false;
            cButton1.Visible = false;
            cButton2.Visible = false;
            cButton5.Visible = false;
            cButton6.Visible = true;

            string[] splitWords = englishSentences[questionPosition].Split(' ');

            randomWords(splitWords);
            foreach (string item in splitWords)
            {
                englishQuestionWords.Add(item);
            }

            drawButtonsQuestion(englishQuestionWords);

            label7.Text = (questionPosition + 1).ToString() + " / " + score.ToString();

            languageText(Form1.language);

        }

        private void SzamGombClick(object sender, EventArgs e)
        {
            Button button = (sender as Button);

            if (button.Location.Y > 300)
            {
                englishQuestionWordsButton.Remove(button);
                englishAnsweWordsButton.Add(button); ;
            }
            else
            {
                englishAnsweWordsButton.Remove(button);
                englishQuestionWordsButton.Add(button);
            }
            drawButtons();
        }

        private void customImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void drawButtonsQuestion(List<string> englishQuestionWords)
        {
            foreach (string item in englishQuestionWords)
            {
                Button gomb = new Button
                {
                    Parent = this,
                    Top = yQuestion,
                    Left = xQuestion,
                    Width = item.Length * 13 + 20,
                    Height = 35
                };

                wordPosition++;
                gomb.Text = item;
                gomb.Name = wordPosition.ToString();

                gomb.BackColor = Color.FromArgb(255, 180, 0);
                gomb.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                gomb.FlatStyle = FlatStyle.Flat;
                gomb.FlatAppearance.BorderSize = 0;

                xQuestion += gomb.Width + 5;
                if (xQuestion > 860)
                {
                    xQuestion = 80;
                    yQuestion += 40;
                }

                gomb.Click += SzamGombClick;
                englishQuestionWordsButton.Add(gomb);
                this.Controls.Add(gomb);
            }
        }

        private void drawButtons()
        {
            int X = 80;
            int Y = 400;

            for (int i = 0; i < englishQuestionWordsButton.Count; i++)
            {
                englishQuestionWordsButton[i].Location = new Point(X, Y);
                X += englishQuestionWordsButton[i].Width + 5;
                if (X > 860)
                {
                    X = 80;
                    Y += 40;
                }
            }

            int Xa = 80;
            int Ya = 250;

            for (int i = 0; i < englishAnsweWordsButton.Count; i++)
            {
                englishAnsweWordsButton[i].Location = new Point(Xa, Ya);
                Xa += englishAnsweWordsButton[i].Width + 5;
                if (Xa > 860)
                {
                    Xa = 80;
                    Ya += 40;
                }
            }
        }

        private void randomWords(string[] splitwords)
        {
            var random = new Random();
            for (int i = 0; i < splitwords.Length; i++)
            {
                int ujindex = random.Next(0, splitwords.Length);
                string masik = splitwords[ujindex];
                splitwords[ujindex] = splitwords[i];
                splitwords[i] = masik;
            }
        }

        private void randomSentences(List<string> randomSentence)
        {
            var random = new Random();
            for (int i = 0; i < randomSentence.Count; i++)
            {
                int ujindex = random.Next(0, randomSentence.Count);
                string masik = randomSentence[ujindex];
                randomSentence[ujindex] = randomSentence[i];
                randomSentence[i] = masik;
            }
        }

        private void deleteBottuns(int wordPosition)
        {
            for (int i = 0; i <= wordPosition; i++)
            {
                foreach (Control controlItem in this.Controls)
                {
                    if (controlItem.Name == i.ToString())
                    {
                        this.Controls.Remove(controlItem);
                    }
                }
            }
        }

        private void listAdd(List<Mondatok> englishSentencesFromDB)
        {
            for (int i = 0; i < englishSentencesFromDB.Count; i++)
            {
                englishSentences.Add(englishSentencesFromDB[i].Mondat.Replace("_", " "));
            }
        }

        private void languageText(bool language)
        {
            if (language == false)
            {
                label2.Text = "ARRANING SENTENCE";
                label3.Text = "Put the words in the right order!";
                cButton4.Text = "EXIT";
                cButton6.Text = "CHECK";
                cButton1.Text = "NEXT";
                cButton3.Text = "EXERCISE SUCCESFULL";
            }
            else
            {
                label2.Text = "MONDATRENDEZÉS";
                label3.Text = "Tedd a szavakat helyes sorrendbe!";
                cButton4.Text = "KILÉPÉS";
                cButton6.Text = "JAVÍT";
                cButton1.Text = "KÖVETKEZŐ";
                cButton3.Text = "FELADAT BEFEJEZŐDÖTT";
            }

        }

    }
}
