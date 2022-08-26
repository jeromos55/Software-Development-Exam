using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishTensesExercise
{
    partial class Form1 : Form
    {
        public static bool language = true;  // ha true angol a nyelv ha false akkor magyar
        public static Igeidok igeido;
        public static string user;
        private CustomButtons.CButton currentButton;
        private Form activeForm;

        public Form1()
        {
            InitializeComponent();
            user = null;
            try
            {
                EnglishTenses_DB_Handler.ConnectionOpen("EnglishTensesDatabaseConStr");
            }
            catch (DB_Exeption ex)
            {
                MessageBox.Show(ex.Message + " - Original error: " + ex.InnerException.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {                      
                EnglishTenses_DB_Handler.ConnetionClose();
            }
            catch (DB_Exeption)
            {
                //TODO Ide logolást kellene írni!!!
                return;
            }
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (btnSender.GetType().Name != "CButton")
                {
                    MyImageButton.CustomImageButton currentButton;
                    currentButton = (MyImageButton.CustomImageButton)btnSender;
                }
                else
                {
                    if (currentButton != (CustomButtons.CButton)btnSender)
                    {
                        currentButton = (CustomButtons.CButton)btnSender;
                    }
                }              
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
       
        private void customImageButton1_Click(object sender, EventArgs e)
        {
            if (language == true)
            {
                label2.Font = new Font("Verdana", 40, FontStyle.Bold);
                languageText(language);
                language = false;
            }
            else
            {
                label2.Font = new Font("Verdana", 50, FontStyle.Bold);
                languageText(language);
                language = true;
            }
        }

        private void customImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 180, 0);
            timer1.Start();
            cButton1.Visible = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            panelDesktopPane.Visible = false;
            panelChoose.Visible = false;
            panelUser.Visible = false;
            language = true;
            languageText(language);
        }

        private void customImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void customImageButton4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
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
                cButton1.Visible = true;
            }
        }

        private void cButton1_Click(object sender, EventArgs e)
        {
            panelUser.Visible = true;
        }

        private void customImageButton27_Click(object sender, EventArgs e)
        {
            panelUser.Visible = false;
        }

        private void cButton2_Click(object sender, EventArgs e)
        {
            panelUser.Visible = false;
        }

        private void cButton6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {               
                label8.Visible = false;
                user = textBox1.Text;
                if (Form1.language == false)
                {
                    label6.Text = "Welcome " + user;
                }
                else
                {
                    label6.Text = "Üdvözöllek " + user;
                }
                panelUser.Visible = false;
                panelDesktopPane.Visible = true;
            }
            else
            {               
                label8.Visible = true;
            }
        }

        private void customImageButton9_Click(object sender, EventArgs e)
        {
            panelDesktopPane.Visible = false;
        }

        private void customImageButton3_Click_1(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "TENSE";
            igeido = Igeidok.All;
            label9.Text = "(Exercises all tenses)"; ;
        }

        private void customImageButton26_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
        }

        private void cButton4_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
        }

        private void cButton3_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
            OpenChildForm(new Forms.Arrange(), sender);
        }

        private void customImageButton4_Click_1(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PAST";
            label9.Text = "(simple, perfect, continuous, perfect continuous)";
            igeido = Igeidok.Past;
        }

        private void customImageButton5_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PERSENT";
            label9.Text = "(simple, perfect, continuous, perfect continuous)";
            igeido = Igeidok.Present;
        }

        private void customImageButton6_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "FUTURE";
            label9.Text = "(simple, perfect, continuous, perfect continuous)";
            igeido = Igeidok.Future;
        }

        private void customImageButton13_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "SIMPLE";
            label9.Text = "(past, present,future)";
            igeido = Igeidok.Simple;
        }

        private void customImageButton12_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PAST SIMPLE";
            igeido = Igeidok.PastSimple;
            label9.Text = "";
        }

        private void customImageButton11_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PRESENT SIMPLE";
            igeido = Igeidok.PresentSimple;
            label9.Text = "";
        }

        private void customImageButton10_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "FUTURE SIMPLE";
            igeido = Igeidok.FutureSimple;
            label9.Text = "";
        }

        private void customImageButton17_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PERFECT";
            label9.Text = "(past, present,future)";
            igeido = Igeidok.Perfect;
        }

        private void customImageButton16_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PAST PERFECT";
            igeido = Igeidok.PastPerfect;
            label9.Text = "";
        }

        private void customImageButton15_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PRESENT PERFECT";
            igeido = Igeidok.PresentPerfect;
            label9.Text = "";
        }

        private void customImageButton14_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "FUTURE PERFECT";
            igeido = Igeidok.FuturePerfect;
            label9.Text = "";
        }

        private void customImageButton21_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "CONTINUOUS";
            label9.Text = "(past, present,future)";
            igeido = Igeidok.Continouos;
        }

        private void customImageButton20_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PAST CONTINUOUS";
            igeido = Igeidok.PastContinous;
            label9.Text = "";
        }

        private void customImageButton19_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PRESENT CONTINUOUS";
            igeido = Igeidok.PresentContinous;
            label9.Text = "";
        }

        private void customImageButton18_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "FUTURE CONTINUOUS";
            igeido = Igeidok.FutureContinous;
            label9.Text = "";
        }

        private void customImageButton25_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PERFECT CONTINUOUS";
            label9.Text = "(past, present,future)";
            igeido = Igeidok.PerfectContinuos;
        }

        private void customImageButton24_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PAST PERFECT CONTINUOUS";
            igeido = Igeidok.PastPerfectContinous;
            label9.Text = "";
        }

        private void customImageButton23_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "PRESENT PERFECT CONTINUOUS";
            igeido = Igeidok.PresentPerfectContinous;
            label9.Text = "";
        }

        private void customImageButton22_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = true;
            labelChoose.Text = "FUTURE PERFECT CONTINUOUS";
            igeido = Igeidok.FuturePerfectContinous;
            label9.Text = "";
        }

        private void cButton5_Click(object sender, EventArgs e)
        {
            panelChoose.Visible = false;
            OpenChildForm(new Forms.Choose(), sender);
        }

        private void customImageButton8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Score(), sender);
        }

        private void languageText(bool language)
        {
            if (language == false)
            {
                label2.Font = new Font("Verdana", 40, FontStyle.Bold);
                label2.Text = "ANGOL NYELVI IGEIDŐ";
                label1.Text = "GYAKORLATOK";
                label6.Text = "Üdvözöllek " + textBox1.Text;

                foreach (Control item in panelUser.Controls)
                {
                    if (item == label4) 
                    { 
                        label4.Text = "FELHASZNÁLÓ NEVE";
                        label4.Location = new Point(321, 185);
                    }
                    if (item == label5) { label5.Text = "Írde be a neved!";}
                    if (item == label8) { label8.Text = "A felhasználó név nem lehet üres!";}
                    if (item == cButton2) { cButton2.Text = "Bezár"; }
                    if (item == cButton6) { cButton6.Text = "OK"; }
                }

                foreach (Control item in panelChoose.Controls)
                {
                    if (item == cButton5) { cButton5.Text = "VÁLASZTÓS KÉRDÉSEK";}
                    if (item == cButton3) { cButton3.Text = "MONDAT- RENDEZÉS"; }
                    if (item == cButton4) { cButton4.Text = "BEZÁR"; }
                }

                foreach (Control item in panelDesktopPane.Controls)
                {
                    if (item == label3) { label3.Text = "Angol Igeidők"; }
                    if (item == label7) { label7.Text = "Pontok"; }
                }
            }
            else
            {
                label2.Font = new Font("Verdana", 50, FontStyle.Bold);
                label2.Text = "ENGLISH TENSES";
                label1.Text = "EXERCISE";
                label6.Text = "Wellcome " + textBox1.Text;

                foreach (Control item in panelUser.Controls)
                {
                    if (item == label4) 
                    { 
                        label4.Text = "USER NAME";
                        label4.Location = new Point(378, 185);
                    }
                    if (item == label5) { label5.Text = "Please enter your name!"; }
                    if (item == label8) { label8.Text = "The  user name cann't be empty!"; }
                    if (item == cButton2) { cButton2.Text = "Cancel"; }
                    if (item == cButton6) { cButton6.Text = "OK"; }
                }

                foreach (Control item in panelChoose.Controls)
                {
                    if (item == cButton5) { cButton5.Text = "MULTI CHOICE"; }
                    if (item == cButton3) { cButton3.Text = "ARRANGE SENTENCE"; }
                    if (item == cButton4) { cButton4.Text = "CLOSE"; }
                }

                foreach (Control item in panelDesktopPane.Controls)
                {
                    if (item == label3) { label3.Text = "English Gramar"; }
                    if (item == label7) { label7.Text = "Score"; }
                }
            }
        }
    }
}
