using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMazlumSevim
{
    // Diese Klasse repräsentiert einen Spieler des Quiz.
    // Jeder Spieler wird in der Datenbank gespeichert und kann mehrere Quizrunden spielen.
    public class Spieler
    {
        // Eindeutige ID des Spielers (Primärschlüssel der Tabelle spieler)
        private int SpielerID;

        // Name des Spielers
        // Dieser wird vom Benutzer eingegeben oder aus der Liste ausgewählt
        private string Name;

        // Gesamtpunktzahl des Spielers über alle gespielten Quizrunden hinweg
        // Kann entweder direkt gespeichert oder aus den einzelnen Punkten berechnet werden
        private int Gesamtpunkte;

        // Property für die SpielerID
        // Wird intern für Datenbankoperationen und Verknüpfungen verwendet
        public int SpielerID1 { get => SpielerID; set => SpielerID = value; }

        // Property für den Namen des Spielers
        // Wird für Anzeige, Auswahl und Speicherung verwendet
        public string Name1 { get => Name; set => Name = value; }

        // Property für die Gesamtpunkte des Spielers
        // Wird für Highscore-Listen und Auswertungen benutzt
        public int Gesamtpunkte1 { get => Gesamtpunkte; set => Gesamtpunkte = value; }

        // Konstruktor:
        // Wird verwendet, um einen Spieler entweder neu anzulegen
        // oder aus der Datenbank in ein Objekt zu laden
        public Spieler(int id, string name, int gPunkte)
        {
            SpielerID = id;
            Name = name;
            Gesamtpunkte = gPunkte;
        }
    }
}
