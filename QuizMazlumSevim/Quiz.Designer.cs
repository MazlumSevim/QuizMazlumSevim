namespace QuizMazlumSevim
{
    partial class Quiz
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
            lbl_frage = new Label();
            rB_antw1 = new RadioButton();
            rB_antw2 = new RadioButton();
            rB_antw3 = new RadioButton();
            rB_antw4 = new RadioButton();
            pB_quiz = new PictureBox();
            btn_qWeit = new Button();
            lbl_zaehler = new Label();
            ((System.ComponentModel.ISupportInitialize)pB_quiz).BeginInit();
            SuspendLayout();
            // 
            // lbl_frage
            // 
            lbl_frage.AutoSize = true;
            lbl_frage.Location = new Point(276, 37);
            lbl_frage.Name = "lbl_frage";
            lbl_frage.Size = new Size(36, 15);
            lbl_frage.TabIndex = 0;
            lbl_frage.Text = "Frage";
            // 
            // rB_antw1
            // 
            rB_antw1.AutoSize = true;
            rB_antw1.Location = new Point(225, 272);
            rB_antw1.Name = "rB_antw1";
            rB_antw1.Size = new Size(74, 19);
            rB_antw1.TabIndex = 6;
            rB_antw1.TabStop = true;
            rB_antw1.Text = "Antwort1";
            rB_antw1.UseVisualStyleBackColor = true;
            // 
            // rB_antw2
            // 
            rB_antw2.AutoSize = true;
            rB_antw2.Location = new Point(467, 272);
            rB_antw2.Name = "rB_antw2";
            rB_antw2.Size = new Size(74, 19);
            rB_antw2.TabIndex = 7;
            rB_antw2.TabStop = true;
            rB_antw2.Text = "Antwort2";
            rB_antw2.UseVisualStyleBackColor = true;
            // 
            // rB_antw3
            // 
            rB_antw3.AutoSize = true;
            rB_antw3.Location = new Point(225, 332);
            rB_antw3.Name = "rB_antw3";
            rB_antw3.Size = new Size(74, 19);
            rB_antw3.TabIndex = 8;
            rB_antw3.TabStop = true;
            rB_antw3.Text = "Antwort3";
            rB_antw3.UseVisualStyleBackColor = true;
            // 
            // rB_antw4
            // 
            rB_antw4.AutoSize = true;
            rB_antw4.Location = new Point(467, 332);
            rB_antw4.Name = "rB_antw4";
            rB_antw4.Size = new Size(74, 19);
            rB_antw4.TabIndex = 9;
            rB_antw4.TabStop = true;
            rB_antw4.Text = "Antwort4";
            rB_antw4.UseVisualStyleBackColor = true;
            // 
            // pB_quiz
            // 
            pB_quiz.Location = new Point(276, 86);
            pB_quiz.Name = "pB_quiz";
            pB_quiz.Size = new Size(217, 157);
            pB_quiz.TabIndex = 10;
            pB_quiz.TabStop = false;
            // 
            // btn_qWeit
            // 
            btn_qWeit.Location = new Point(328, 386);
            btn_qWeit.Name = "btn_qWeit";
            btn_qWeit.Size = new Size(121, 31);
            btn_qWeit.TabIndex = 11;
            btn_qWeit.Text = "Weiter";
            btn_qWeit.UseVisualStyleBackColor = true;
            btn_qWeit.Click += btn_qWeit_Click;
            // 
            // lbl_zaehler
            // 
            lbl_zaehler.AutoSize = true;
            lbl_zaehler.Location = new Point(609, 37);
            lbl_zaehler.Name = "lbl_zaehler";
            lbl_zaehler.Size = new Size(79, 15);
            lbl_zaehler.TabIndex = 12;
            lbl_zaehler.Text = "Fragen Zähler";
            // 
            // Quiz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_zaehler);
            Controls.Add(btn_qWeit);
            Controls.Add(pB_quiz);
            Controls.Add(rB_antw4);
            Controls.Add(rB_antw3);
            Controls.Add(rB_antw2);
            Controls.Add(rB_antw1);
            Controls.Add(lbl_frage);
            Name = "Quiz";
            Text = "Quiz";
            ((System.ComponentModel.ISupportInitialize)pB_quiz).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_frage;
        private RadioButton rB_antw1;
        private RadioButton rB_antw2;
        private RadioButton rB_antw3;
        private RadioButton rB_antw4;
        private PictureBox pB_quiz;
        private Button btn_qWeit;
        private Label lbl_zaehler;
    }
}