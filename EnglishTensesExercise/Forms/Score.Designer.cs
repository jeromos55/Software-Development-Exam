
namespace EnglishTensesExercise.Forms
{
    partial class Score
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customImageButton1 = new MyImageButton.CustomImageButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cButton2 = new CustomButtons.CButton();
            this.cButton1 = new CustomButtons.CButton();
            ((System.ComponentModel.ISupportInitialize)(this.customImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(69, 140);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(875, 329);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Verdana", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "HIGH SCORE";
            // 
            // customImageButton1
            // 
            this.customImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.customImageButton1.HoverImage = global::EnglishTensesExercise.Properties.Resources.x12;
            this.customImageButton1.Image = global::EnglishTensesExercise.Properties.Resources.x1;
            this.customImageButton1.Location = new System.Drawing.Point(911, 29);
            this.customImageButton1.Name = "customImageButton1";
            this.customImageButton1.NormalImage1 = global::EnglishTensesExercise.Properties.Resources.x1;
            this.customImageButton1.Size = new System.Drawing.Size(33, 33);
            this.customImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.customImageButton1.TabIndex = 6;
            this.customImageButton1.TabStop = false;
            this.customImageButton1.Click += new System.EventHandler(this.customImageButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(290, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "USERNAME / TENSE  / SCORE";
            // 
            // cButton2
            // 
            this.cButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.cButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.cButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cButton2.BorderRadius = 40;
            this.cButton2.BorderSize = 0;
            this.cButton2.FlatAppearance.BorderSize = 0;
            this.cButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cButton2.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cButton2.ForeColor = System.Drawing.Color.Black;
            this.cButton2.Location = new System.Drawing.Point(295, 496);
            this.cButton2.Name = "cButton2";
            this.cButton2.Size = new System.Drawing.Size(150, 40);
            this.cButton2.TabIndex = 8;
            this.cButton2.Text = "DELETE";
            this.cButton2.TextColor = System.Drawing.Color.Black;
            this.cButton2.UseVisualStyleBackColor = false;
            this.cButton2.Click += new System.EventHandler(this.cButton2_Click);
            // 
            // cButton1
            // 
            this.cButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.cButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.cButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.cButton1.BorderRadius = 40;
            this.cButton1.BorderSize = 0;
            this.cButton1.FlatAppearance.BorderSize = 0;
            this.cButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cButton1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cButton1.ForeColor = System.Drawing.Color.Black;
            this.cButton1.Location = new System.Drawing.Point(520, 496);
            this.cButton1.Name = "cButton1";
            this.cButton1.Size = new System.Drawing.Size(150, 40);
            this.cButton1.TabIndex = 2;
            this.cButton1.Text = "CLOSE";
            this.cButton1.TextColor = System.Drawing.Color.Black;
            this.cButton1.UseVisualStyleBackColor = false;
            this.cButton1.Click += new System.EventHandler(this.cButton1_Click);
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EnglishTensesExercise.Properties.Resources.title1Background;
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.cButton2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customImageButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cButton1);
            this.Controls.Add(this.listBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Score";
            this.Text = "Score";
            this.Load += new System.EventHandler(this.Score_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private CustomButtons.CButton cButton1;
        private System.Windows.Forms.Label label1;
        private MyImageButton.CustomImageButton customImageButton1;
        private System.Windows.Forms.Label label4;
        private CustomButtons.CButton cButton2;
    }
}