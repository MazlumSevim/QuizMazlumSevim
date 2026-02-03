namespace QuizMazlumSevim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tB_spName = new TextBox();
            btn_nameSpeichern = new Button();
            lB_spName = new ListBox();
            label2 = new Label();
            rB_land = new RadioButton();
            rB_flaggen = new RadioButton();
            rB_hauptst = new RadioButton();
            btn_katWeit = new Button();
            btn_score = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 65);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Spielername :";
            // 
            // tB_spName
            // 
            tB_spName.Location = new Point(233, 62);
            tB_spName.Name = "tB_spName";
            tB_spName.Size = new Size(125, 23);
            tB_spName.TabIndex = 1;
            // 
            // btn_nameSpeichern
            // 
            btn_nameSpeichern.Location = new Point(255, 116);
            btn_nameSpeichern.Name = "btn_nameSpeichern";
            btn_nameSpeichern.Size = new Size(75, 23);
            btn_nameSpeichern.TabIndex = 2;
            btn_nameSpeichern.Text = "Speichern";
            btn_nameSpeichern.UseVisualStyleBackColor = true;
            btn_nameSpeichern.Click += btn_nameSpeichern_Click;
            // 
            // lB_spName
            // 
            lB_spName.FormattingEnabled = true;
            lB_spName.Location = new Point(509, 48);
            lB_spName.Name = "lB_spName";
            lB_spName.Size = new Size(185, 94);
            lB_spName.TabIndex = 3;
            lB_spName.SelectedIndexChanged += lB_spName_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(297, 248);
            label2.Name = "label2";
            label2.Size = new Size(155, 15);
            label2.TabIndex = 4;
            label2.Text = "Fragen Kategorie auswählen";
            // 
            // rB_land
            // 
            rB_land.AutoSize = true;
            rB_land.Location = new Point(116, 331);
            rB_land.Name = "rB_land";
            rB_land.Size = new Size(51, 19);
            rB_land.TabIndex = 5;
            rB_land.TabStop = true;
            rB_land.Text = "Land";
            rB_land.UseVisualStyleBackColor = true;
            rB_land.CheckedChanged += rB_land_CheckedChanged;
            // 
            // rB_flaggen
            // 
            rB_flaggen.AutoSize = true;
            rB_flaggen.Location = new Point(341, 331);
            rB_flaggen.Name = "rB_flaggen";
            rB_flaggen.Size = new Size(67, 19);
            rB_flaggen.TabIndex = 6;
            rB_flaggen.TabStop = true;
            rB_flaggen.Text = "Flaggen";
            rB_flaggen.UseVisualStyleBackColor = true;
            rB_flaggen.CheckedChanged += rB_flaggen_CheckedChanged;
            // 
            // rB_hauptst
            // 
            rB_hauptst.AutoSize = true;
            rB_hauptst.Location = new Point(558, 331);
            rB_hauptst.Name = "rB_hauptst";
            rB_hauptst.Size = new Size(84, 19);
            rB_hauptst.TabIndex = 7;
            rB_hauptst.TabStop = true;
            rB_hauptst.Text = "Hauptstadt";
            rB_hauptst.UseVisualStyleBackColor = true;
            rB_hauptst.CheckedChanged += rB_hauptst_CheckedChanged;
            // 
            // btn_katWeit
            // 
            btn_katWeit.Location = new Point(309, 390);
            btn_katWeit.Name = "btn_katWeit";
            btn_katWeit.Size = new Size(125, 30);
            btn_katWeit.TabIndex = 8;
            btn_katWeit.Text = "Weiter";
            btn_katWeit.UseVisualStyleBackColor = true;
            btn_katWeit.Click += btn_katWeit_Click;
            // 
            // btn_score
            // 
            btn_score.Location = new Point(543, 158);
            btn_score.Name = "btn_score";
            btn_score.Size = new Size(120, 22);
            btn_score.TabIndex = 9;
            btn_score.Text = "Scoreboard";
            btn_score.UseVisualStyleBackColor = true;
            btn_score.Click += btn_score_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_score);
            Controls.Add(btn_katWeit);
            Controls.Add(rB_hauptst);
            Controls.Add(rB_flaggen);
            Controls.Add(rB_land);
            Controls.Add(label2);
            Controls.Add(lB_spName);
            Controls.Add(btn_nameSpeichern);
            Controls.Add(tB_spName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Anmeldung und Kategorie Auswahl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tB_spName;
        private Button btn_nameSpeichern;
        private ListBox lB_spName;
        private Label label2;
        private RadioButton rB_land;
        private RadioButton rB_flaggen;
        private RadioButton rB_hauptst;
        private Button btn_katWeit;
        private Button btn_score;
    }
}
