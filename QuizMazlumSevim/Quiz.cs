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
    public partial class Quiz : Form
    {
        // Datenbank-Zugriff (Länder holen, Punkte speichern)
        private DB db = new DB();

        // Hier kommen alle Länder aus der Datenbank rein (Grundliste)
        private List<Land> alleLaender = new List<Land>();

        // Das sind die 10 zufälligen Länder, die im Quiz verwendet werden
        private List<Land> quizLaender = new List<Land>();

        // Zeigt auf das aktuelle Land in quizLaender (0..9)
        private int index = 0;

        // Zufallsgenerator (damit Reihenfolge/Antworten zufällig sind)
        private Random rnd = new Random();

        // Das aktuelle Land, zu dem gerade die Frage gestellt wird
        private Land aktuellesLand;

        // Die richtige Lösung als Text (je nach Frage Landname oder Hauptstadt)
        private string richtigeAntwort;

        // Hier wird alles zusammengezählt (5 Punkte pro richtige Antwort)
        private int punkteGesamt = 0;

        // Der Spieler, der das Quiz gestartet hat
        private Spieler spieler;

        // Die Kategorie, die der Spieler gewählt hat (Land / Flagge / Hauptstadt)
        private Kategorie kategorie;

        // Zähler für "Frage x von 10"
        private int frageNr = 1;
        private const int MAX_FRAGEN = 10;

        // Frage-Typ: pro Kategorie gibt es 2 Varianten (0 oder 1)
        private int frageTyp = 0; // 0 oder 1 (je nach Kategorie)

        public Quiz(Spieler spieler, Kategorie kategorie)
        {
            // Baut das Quiz-Fenster mit allen Controls (Labels, Radiobuttons, PictureBox, Buttons)
            InitializeComponent();

            // Merkt sich den Spieler + die gewählte Kategorie
            this.spieler = spieler;
            this.kategorie = kategorie;

            // Lädt alle Länder aus der Datenbank
            alleLaender = db.getLand();

            // Mischt alle Länder zufällig durch und nimmt daraus 10 Stück für diese Runde
            quizLaender = alleLaender.OrderBy(x => rnd.Next()).Take(MAX_FRAGEN).ToList();

            // Startwerte setzen
            index = 0;
            frageNr = 1;

            // Erste Frage laden + Zähler anzeigen
            NaechsteFrage();
            updateFragenZaehler();

            // Wenn ein Bild aus dem Internet geladen wird (FlagCDN) und das schiefgeht,
            // dann verstecken wir die PictureBox, damit keine Fehlermeldungen stören
            pB_quiz.LoadCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    pB_quiz.Visible = false;
                }
            };
        }

        private void NaechsteFrage()
        {
            // Wenn alle 10 Fragen durch sind, wechseln wir zur Gesamtpunktzahl-Tabelle
            if (index >= quizLaender.Count)
            {
                Gesamtpunktzahl gp = new Gesamtpunktzahl();
                gp.Show();
                this.Close();
                return;
            }

            // Nächstes Land aus der 10er Liste holen
            aktuellesLand = quizLaender[index];

            // Pro Frage wählen wir zufällig eine von 2 Varianten (damit es abwechslungsreich ist)
            frageTyp = rnd.Next(2); // 0 oder 1

            // ISO2 Code holen (z.B. "de", "fr", "no") -> wichtig für Flaggen und Bilddateien
            string code = (aktuellesLand.Iso2 ?? "").Trim().ToLower();

            // Lokaler Pfad zu deinem Länder-Bild (PNG), das du in /bilder/laender/ gespeichert hast
            string pfadLand = Application.StartupPath + "\\bilder\\laender\\" + code + ".png";

            // PictureBox am Anfang zurücksetzen (damit nicht ein altes Bild stehen bleibt)
            pB_quiz.Image = null;
            pB_quiz.Visible = false;

            // ------------------------
            // Kategorie LAND => 2 Varianten
            // ------------------------
            if (kategorie == Kategorie.Land)
            {
                if (frageTyp == 0)
                {
                    // Variante: Land anhand Flagge erraten
                    lbl_frage.Text = "Welches Land gehört zu dieser Flagge?";
                    richtigeAntwort = aktuellesLand.Landname1;

                    // Flagge von FlagCDN laden (Internet)
                    pB_quiz.ImageLocation = "https://flagcdn.com/w320/" + code + ".png";
                    pB_quiz.SizeMode = PictureBoxSizeMode.Zoom;
                    pB_quiz.Visible = true;
                }
                else
                {
                    // Variante: Land anhand Hauptstadt erraten
                    lbl_frage.Text = "Welches Land hat die Hauptstadt: " + aktuellesLand.Hauptstadt1 + "?";
                    richtigeAntwort = aktuellesLand.Landname1;

                    // Optional: dazu das Länder-Umrissbild anzeigen (lokale Datei)
                    if (File.Exists(pfadLand))
                    {
                        pB_quiz.ImageLocation = pfadLand;
                        pB_quiz.SizeMode = PictureBoxSizeMode.Zoom;
                        pB_quiz.Visible = true;
                    }
                }
            }

            // ------------------------
            // Kategorie FLAGGE => 2 Varianten
            // (Bild = Flagge, Antworten = Länder)
            // ------------------------
            else if (kategorie == Kategorie.Flagge)
            {
                if (frageTyp == 0)
                {
                    // Variante: Flagge anhand Land (klassisch)
                    lbl_frage.Text = "Zu welchem Land gehört diese Flagge?";
                    richtigeAntwort = aktuellesLand.Landname1;
                }
                else
                {
                    // Variante: Flagge anhand Hauptstadt (Antwort bleibt trotzdem Land)
                    lbl_frage.Text = "Zu welchem Land gehört die Hauptstadt: " + aktuellesLand.Hauptstadt1 + "?";
                    richtigeAntwort = aktuellesLand.Landname1;
                }

                // Flagge anzeigen
                pB_quiz.ImageLocation = "https://flagcdn.com/w320/" + code + ".png";
                pB_quiz.SizeMode = PictureBoxSizeMode.Zoom;
                pB_quiz.Visible = true;
            }

            // ------------------------
            // Kategorie HAUPTSTADT => 2 Varianten
            // ------------------------
            else if (kategorie == Kategorie.Hauptstadt)
            {
                if (frageTyp == 0)
                {
                    // Variante: Hauptstadt anhand Land
                    lbl_frage.Text = "Was ist die Hauptstadt von " + aktuellesLand.Landname1 + "?";
                    richtigeAntwort = aktuellesLand.Hauptstadt1;

                    // Optional: Länderbild dazu anzeigen
                    if (File.Exists(pfadLand))
                    {
                        pB_quiz.ImageLocation = pfadLand;
                        pB_quiz.SizeMode = PictureBoxSizeMode.Zoom;
                        pB_quiz.Visible = true;
                    }
                }
                else
                {
                    // Variante: Hauptstadt anhand Flagge
                    lbl_frage.Text = "Was ist die Hauptstadt zu dieser Flagge?";
                    richtigeAntwort = aktuellesLand.Hauptstadt1;

                    // Flagge anzeigen
                    pB_quiz.ImageLocation = "https://flagcdn.com/w320/" + code + ".png";
                    pB_quiz.SizeMode = PictureBoxSizeMode.Zoom;
                    pB_quiz.Visible = true;
                }
            }

            // Antwortmöglichkeiten erzeugen (4 Stück, davon 1 richtig)
            List<string> antw = AntwortenErzeugen();

            // Texte in die 4 Radiobuttons schreiben
            rB_antw1.Text = antw[0];
            rB_antw2.Text = antw[1];
            rB_antw3.Text = antw[2];
            rB_antw4.Text = antw[3];

            // Radiobutton-Auswahl zurücksetzen (damit nicht die alte Auswahl bleibt)
            rB_antw1.Checked = false;
            rB_antw2.Checked = false;
            rB_antw3.Checked = false;
            rB_antw4.Checked = false;
        }

        private List<string> AntwortenErzeugen()
        {
            // 3 falsche Länder aus allen Ländern auswählen (ohne das aktuelle Land)
            List<Land> falsch = alleLaender
                .Where(x => x.LandID1 != aktuellesLand.LandID1)
                .OrderBy(x => rnd.Next())
                .Take(3)
                .ToList();

            // Hier sammeln wir die 4 Antworttexte
            List<string> antworten = new List<string>();

            // Wenn Kategorie "Hauptstadt" ist, müssen die Antworten Hauptstädte sein
            bool antwortIstHauptstadt = (kategorie == Kategorie.Hauptstadt);

            // Hauptstadt-Quiz: 1 richtige Hauptstadt + 3 falsche Hauptstädte
            if (antwortIstHauptstadt)
            {
                antworten.Add(aktuellesLand.Hauptstadt1);
                antworten.AddRange(falsch.Select(x => x.Hauptstadt1));
            }
            else
            {
                // Land / Flagge Quiz: 1 richtiger Ländername + 3 falsche Ländernamen
                antworten.Add(aktuellesLand.Landname1);
                antworten.AddRange(falsch.Select(x => x.Landname1));
            }

            // Am Ende alles nochmal mischen, damit die richtige Antwort nicht immer oben steht
            return antworten.OrderBy(x => rnd.Next()).ToList();
        }

        private void btn_qWeit_Click(object sender, EventArgs e)
        {
            // Auslesen, welche Antwort der Spieler ausgewählt hat
            string auswahl = null;

            if (rB_antw1.Checked) auswahl = rB_antw1.Text;
            else if (rB_antw2.Checked) auswahl = rB_antw2.Text;
            else if (rB_antw3.Checked) auswahl = rB_antw3.Text;
            else if (rB_antw4.Checked) auswahl = rB_antw4.Text;

            // Wenn keine Antwort angeklickt ist, darf es nicht weitergehen
            if (auswahl == null)
            {
                MessageBox.Show("Bitte eine Antwort auswählen!");
                return;
            }

            // Prüfen ob richtig / falsch und Punkte vergeben
            bool richtig = (auswahl == richtigeAntwort);
            int punkte = richtig ? 5 : 0;
            punkteGesamt += punkte;

            // Direktes Feedback nach jeder Frage
            if (richtig)
                MessageBox.Show("Richtig! ✅ +5 Punkte");
            else
                MessageBox.Show("Falsch! ❌ Richtige Antwort: " + richtigeAntwort);

            // Ergebnis dieser Frage in der DB speichern (SpielerID + LandID + Punktzahl + Kategorie)
            Punkte p = new Punkte(0, spieler.SpielerID1, aktuellesLand.LandID1, punkte, kategorie);
            db.savePunkte(p);

            // Zur nächsten Frage weiterzählen
            index++;
            frageNr++;

            // Wenn die 10 Fragen vorbei sind, direkt zur Gesamtpunktzahl wechseln
            if (frageNr > MAX_FRAGEN)
            {
                Gesamtpunktzahl gp = new Gesamtpunktzahl();
                gp.Show();
                this.Close();
                return;
            }

            // Nächste Frage laden + Label aktualisieren
            NaechsteFrage();
            updateFragenZaehler();
        }

        private void updateFragenZaehler()
        {
            // "Frage 1 von 10" usw.
            lbl_zaehler.Text = "Frage " + frageNr + " von " + MAX_FRAGEN;
        }

    }
}
