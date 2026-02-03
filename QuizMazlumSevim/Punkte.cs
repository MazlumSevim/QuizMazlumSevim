using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMazlumSevim
{
    // Diese Klasse repräsentiert einen Punkteeintrag in der Datenbank.
    // Pro beantworteter Frage wird genau ein Objekt dieser Klasse erzeugt.
    // Sie verknüpft einen Spieler mit einem Land, einer Kategorie und einer Punktzahl.
    public class Punkte
    {
        // Eindeutige ID des Punkteeintrags (Primärschlüssel der Tabelle punkte)
        private int PunkteID;

        // Fremdschlüssel auf den Spieler, der die Frage beantwortet hat
        private int SpielerID;

        // Fremdschlüssel auf das Land, zu dem die Frage gehört
        private int LandID;

        // Anzahl der Punkte für diese einzelne Frage
        // z.B. 5 Punkte bei richtiger Antwort, 0 bei falscher
        private int Punktzahl;

        // Kategorie der Frage (Land, Flagge oder Hauptstadt)
        // Wird als Enum gespeichert, damit nur gültige Kategorien verwendet werden
        private Kategorie kategorie;

        // Property für die PunkteID
        // Wird hauptsächlich intern und für Datenbankoperationen benötigt
        public int PunkteID1 { get => PunkteID; set => PunkteID = value; }

        // Property für die SpielerID
        // Verbindet diesen Punkteeintrag mit einem bestimmten Spieler
        public int SpielerID1 { get => SpielerID; set => SpielerID = value; }

        // Property für die LandID
        // Zeigt, zu welchem Land diese Frage gehört
        public int LandID1 { get => LandID; set => LandID = value; }

        // Property für die Punktzahl
        // Enthält die erreichten Punkte für diese Frage
        public int Punktzahl1 { get => Punktzahl; set => Punktzahl = value; }

        // Property für die Kategorie
        // Wichtig für die spätere Auswertung (Landpunkte, Flaggenpunkte, Hauptstadtpunkte)
        public Kategorie Kategorie { get => kategorie; set => kategorie = value; }

        // Konstruktor:
        // Wird aufgerufen, wenn nach einer beantworteten Frage
        // ein neuer Punkteeintrag erstellt und gespeichert wird
        public Punkte(int punktID, int spielerID, int landID, int punktzahl, Kategorie kate)
        {
            PunkteID = punktID;
            SpielerID = spielerID;
            LandID = landID;
            Punktzahl = punktzahl;
            Kategorie = kate;
        }
    }
}
