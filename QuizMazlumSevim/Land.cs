using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMazlumSevim
{
    // Diese Klasse repräsentiert ein Land aus der Datenbank.
    // Sie wird im Quiz benutzt, um Fragen zu Ländern, Flaggen und Hauptstädten zu erzeugen.
    public class Land
    {
        // Eindeutige ID des Landes (Primärschlüssel aus der Tabelle land)
        private int LandID;

        // Name des Landes (z.B. "Deutschland", "Norwegen")
        private string Landname;

        // Hauptstadt des Landes (z.B. "Berlin", "Oslo")
        private string Hauptstadt;

        // ISO-2-Code des Landes (z.B. "de", "no")
        // Wird verwendet, um Flaggen- und Länderbilder zu laden
        private string iso2;

        // Property für die LandID
        // Wird z.B. für Vergleiche und Fremdschlüssel (Punkte → Land) benutzt
        public int LandID1 { get => LandID; set => LandID = value; }

        // Property für den Ländernamen
        // Wird für Fragen und Antwortmöglichkeiten verwendet
        public string Landname1 { get => Landname; set => Landname = value; }

        // Property für die Hauptstadt
        // Wird für Hauptstadt-Fragen und falsche Antwortmöglichkeiten benutzt
        public string Hauptstadt1 { get => Hauptstadt; set => Hauptstadt = value; }

        // Property für den ISO-Code
        // Wichtig für das Laden von Flaggen (FlagCDN) und Kartenbildern aus dem Projektordner
        public string Iso2 { get => iso2; set => iso2 = value; }

        // Konstruktor:
        // Wird verwendet, wenn ein Land aus der Datenbank gelesen wird
        // und in ein Land-Objekt umgewandelt wird
        public Land(int landID, string landName, string hauptstadt, string iso2)
        {
            LandID = landID;
            Landname = landName;
            Hauptstadt = hauptstadt;
            Iso2 = iso2;
        }
    }
}
