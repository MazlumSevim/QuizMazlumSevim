namespace QuizMazlumSevim
{
    partial class Gesamtpunktzahl
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
            dGV_gPunkte = new DataGridView();
            Spielername = new DataGridViewTextBoxColumn();
            Land_Punkte = new DataGridViewTextBoxColumn();
            Hauptstadt_Punkte = new DataGridViewTextBoxColumn();
            Flagge_Punkte = new DataGridViewTextBoxColumn();
            Gesamtpunkte = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dGV_gPunkte).BeginInit();
            SuspendLayout();
            // 
            // dGV_gPunkte
            // 
            dGV_gPunkte.AllowUserToAddRows = false;
            dGV_gPunkte.AllowUserToDeleteRows = false;
            dGV_gPunkte.AllowUserToResizeColumns = false;
            dGV_gPunkte.AllowUserToResizeRows = false;
            dGV_gPunkte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGV_gPunkte.BackgroundColor = Color.White;
            dGV_gPunkte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_gPunkte.Columns.AddRange(new DataGridViewColumn[] { Spielername, Land_Punkte, Hauptstadt_Punkte, Flagge_Punkte, Gesamtpunkte });
            dGV_gPunkte.Dock = DockStyle.Fill;
            dGV_gPunkte.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGV_gPunkte.Location = new Point(0, 0);
            dGV_gPunkte.MultiSelect = false;
            dGV_gPunkte.Name = "dGV_gPunkte";
            dGV_gPunkte.ReadOnly = true;
            dGV_gPunkte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_gPunkte.Size = new Size(1281, 450);
            dGV_gPunkte.TabIndex = 0;
            // 
            // Spielername
            // 
            Spielername.DataPropertyName = "name";
            Spielername.HeaderText = "Spielername";
            Spielername.Name = "Spielername";
            Spielername.ReadOnly = true;
            // 
            // Land_Punkte
            // 
            Land_Punkte.DataPropertyName = "landpunkte";
            Land_Punkte.HeaderText = "Land-Punkte";
            Land_Punkte.Name = "Land_Punkte";
            Land_Punkte.ReadOnly = true;
            // 
            // Hauptstadt_Punkte
            // 
            Hauptstadt_Punkte.DataPropertyName = "hauptstadtpunkte";
            Hauptstadt_Punkte.HeaderText = "Hauptstadt-Punkte";
            Hauptstadt_Punkte.Name = "Hauptstadt_Punkte";
            Hauptstadt_Punkte.ReadOnly = true;
            // 
            // Flagge_Punkte
            // 
            Flagge_Punkte.DataPropertyName = "flaggenpunkte";
            Flagge_Punkte.HeaderText = "Flagge-Punkte";
            Flagge_Punkte.Name = "Flagge_Punkte";
            Flagge_Punkte.ReadOnly = true;
            // 
            // Gesamtpunkte
            // 
            Gesamtpunkte.DataPropertyName = "gesamtpunkte";
            Gesamtpunkte.HeaderText = "Gesamtpunkte";
            Gesamtpunkte.Name = "Gesamtpunkte";
            Gesamtpunkte.ReadOnly = true;
            // 
            // Gesamtpunktzahl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 450);
            Controls.Add(dGV_gPunkte);
            Name = "Gesamtpunktzahl";
            Text = "Gesamtpunktzahl";
            Load += Gesamtpunktzahl_Load;
            ((System.ComponentModel.ISupportInitialize)dGV_gPunkte).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dGV_gPunkte;
        private DataGridViewTextBoxColumn Spielername;
        private DataGridViewTextBoxColumn Land_Punkte;
        private DataGridViewTextBoxColumn Hauptstadt_Punkte;
        private DataGridViewTextBoxColumn Flagge_Punkte;
        private DataGridViewTextBoxColumn Gesamtpunkte;
    }
}