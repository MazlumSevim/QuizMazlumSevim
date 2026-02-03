namespace QuizMazlumSevim
{
    public partial class Form1 : Form
    {
        // Datenbank-Objekt, damit wir Spieler/Länder/Punkte laden und speichern können
        DB db;

        // Listen (bei dir teilweise vorbereitet, auch wenn du sie nicht überall nutzt)
        List<Spieler> liSp = new List<Spieler>();
        List<Punkte> liP = new List<Punkte>();
        List<Land> liLa = new List<Land>();

        // Der aktuell ausgewählte/registrierte Spieler
        private Spieler aktiverSpieler = null;

        // Die ausgewählte Kategorie (Land/Flagge/Hauptstadt)
        // Kategorie? = nullable, damit am Anfang "keine Kategorie gewählt" möglich ist
        private Kategorie? gewaehlteKategorie = null;

        public Form1()
        {
            InitializeComponent();

            // Datenbank verbinden / bereitstellen
            db = new DB();

            // Beim Start direkt die vorhandenen Spielernamen in die ListBox laden
            dispSpieler();
        }

        private void dispSpieler()
        {
            // ListBox leeren, damit keine doppelten Einträge entstehen
            lB_spName.Items.Clear();

            // Alle Spieler aus der DB holen und deren Namen anzeigen
            foreach (Spieler sp in db.getSpieler())
                lB_spName.Items.Add(sp.Name1);
        }

        private void btn_nameSpeichern_Click(object sender, EventArgs e)
        {
            // Name aus Textbox holen und Leerzeichen entfernen
            string name = tB_spName.Text.Trim();

            // Sicherheitscheck: Name darf nicht leer sein
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Bitte einen Spielernamen eingeben.");
                return;
            }

            // Prüfen: Gibt es den Spieler schon in der DB?
            // FirstOrDefault gibt den Spieler zurück oder null, falls es keinen gibt
            Spieler vorhanden = db.getSpieler()
                .FirstOrDefault(x => x.Name1 == name);

            if (vorhanden != null)
            {
                // Spieler existiert schon -> wir wählen ihn als aktiven Spieler aus
                aktiverSpieler = vorhanden;
                MessageBox.Show("Spieler ausgewählt. Bitte Kategorie wählen.");
                return;
            }

            // Wenn der Spieler nicht existiert:
            // Neuen Spieler anlegen (SpielerID 0 = neu, Gesamtpunkte 0)
            Spieler sp = new Spieler(0, name, 0);

            // In Datenbank speichern (INSERT)
            db.saveSpieler(sp);

            // Danach nochmal aus der DB holen, damit die echte SpielerID drin ist
            aktiverSpieler = db.getSpieler()
                .FirstOrDefault(x => x.Name1 == name);

            // ListBox aktualisieren, damit der neue Spieler angezeigt wird
            dispSpieler();

            // Hinweis für den User
            MessageBox.Show("Neuer Spieler gespeichert. Bitte Kategorie auswählen.");
        }

        private void rB_land_CheckedChanged(object sender, EventArgs e)
        {
            // Wenn der RadioButton "Land" aktiv ist -> Kategorie setzen
            if (rB_land.Checked) gewaehlteKategorie = Kategorie.Land;
        }

        private void rB_flaggen_CheckedChanged(object sender, EventArgs e)
        {
            // Wenn der RadioButton "Flaggen" aktiv ist -> Kategorie setzen
            if (rB_flaggen.Checked) gewaehlteKategorie = Kategorie.Flagge;
        }

        private void rB_hauptst_CheckedChanged(object sender, EventArgs e)
        {
            // Wenn der RadioButton "Hauptstadt" aktiv ist -> Kategorie setzen
            if (rB_hauptst.Checked) gewaehlteKategorie = Kategorie.Hauptstadt;
        }

        private void btn_katWeit_Click(object sender, EventArgs e)
        {
            // Sicherheitscheck: Es muss ein Spieler ausgewählt/gespeichert sein
            if (aktiverSpieler == null)
            {
                MessageBox.Show("Bitte zuerst Namen speichern!");
                return;
            }

            // Sicherheitscheck: Es muss eine Kategorie ausgewählt sein
            if (gewaehlteKategorie == null)
            {
                MessageBox.Show("Bitte eine Kategorie auswählen!");
                return;
            }

            // Quiz-Fenster starten und Spieler + Kategorie mitgeben
            Quiz quiz = new Quiz(aktiverSpieler, gewaehlteKategorie.Value);

            // Wenn das Quiz geschlossen wird, soll Form1 wieder erscheinen
            quiz.FormClosed += (s, args) => this.Show();

            // Quiz anzeigen
            quiz.Show();

            // Startformular verstecken (damit nicht beide Fenster gleichzeitig „im Weg“ sind)
            this.Hide();
        }

        private void lB_spName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Wenn nichts ausgewählt ist -> raus
            if (lB_spName.SelectedItem == null)
                return;

            // Ausgewählten Namen aus der ListBox holen
            string name = lB_spName.SelectedItem.ToString();

            // Passenden Spieler aus der DB suchen und als aktiven Spieler setzen
            aktiverSpieler = db.getSpieler()
                .FirstOrDefault(x => x.Name1 == name);

            // Wenn Spieler gefunden: Name in die TextBox übernehmen
            if (aktiverSpieler != null)
            {
                tB_spName.Text = aktiverSpieler.Name1;
            }
        }

        private void btn_score_Click(object sender, EventArgs e)
        {
            // Scoreboard-Fenster öffnen (Highscore / Gesamtpunkte)
            Gesamtpunktzahl gp = new Gesamtpunktzahl();
            gp.Show();
        }
    }
}
