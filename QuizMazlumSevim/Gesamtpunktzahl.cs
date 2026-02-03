using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMazlumSevim
{
    public partial class Gesamtpunktzahl : Form
    {
        // Verbindung zur Datenbank-Klasse, damit wir die Gesamtpunkte laden können
        DB db = new DB();

        public Gesamtpunktzahl()
        {
            // Baut das Fenster mit allen Controls (DataGridView, Buttons, Labels usw.)
            InitializeComponent();
        }

        private void Gesamtpunktzahl_Load(object sender, EventArgs e)
        {
            // Sorgt dafür, dass die Spalten automatisch aus der DataTable erstellt werden
            // (sonst bleibt das DataGridView oft grau / leer)
            dGV_gPunkte.AutoGenerateColumns = true;

            // Holt die Punkte-Tabelle (Scoreboard) aus der DB und zeigt sie im DataGridView an
            dGV_gPunkte.DataSource = db.getGesamtpunkte();

            // Die SpielerID braucht man intern, aber der Benutzer soll sie nicht sehen
            dGV_gPunkte.Columns["spielerid"].Visible = false;

            // Passt die Spaltenbreite automatisch an, damit alles schön den Platz ausfüllt
            dGV_gPunkte.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
