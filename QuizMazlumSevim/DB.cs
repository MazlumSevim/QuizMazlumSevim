using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QuizMazlumSevim
{
    public class DB
    {
        // Verbindung zur Datenbank (wird in allen Methoden benutzt)
        private MySqlConnection conn;

        public DB()
        {
            // Verbindungsstring: Server + Benutzer + Passwort + Datenbankname
            // Damit verbindet sich dein Programm mit deiner MariaDB/MySQL (xampp) Datenbank quizdb
            string connstr = "Server=localhost;UID='root';Password='';Database=quizdb;";
            conn = new MySqlConnection(connstr);
        }

        public void saveSpieler(Spieler sp)
        {
            // Speichert einen Spieler in der DB
            // -> Wenn SpielerID = 0: neuer Spieler (INSERT)
            // -> Wenn SpielerID != 0: Spieler existiert schon (UPDATE)
            try
            {
                // Verbindung öffnen
                conn.Open();

                // SQL-Befehl erstellen
                MySqlCommand cmd = conn.CreateCommand();

                if (sp.SpielerID1 == 0)
                {
                    // Neuer Spieler: wird in die Tabelle spieler eingefügt
                    // NULL bedeutet: SpielerID wird automatisch vergeben (Auto-Increment)
                    cmd.CommandText = string.Format("INSERT INTO spieler " +
                       "VALUES (NULL, '{0}', {1});",
                       sp.Name1, sp.Gesamtpunkte1);
                }
                else
                {
                    // Spieler existiert: Name und Gesamtpunkte werden aktualisiert
                    cmd.CommandText = string.Format("UPDATE spieler " +
                        "SET Name = '{0}', Gesamtpunkte = {1} " +
                        "WHERE SpielerID = {2};",
                        sp.Name1, sp.Gesamtpunkte1, sp.SpielerID1);
                }

                // SQL ausführen (INSERT/UPDATE)
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Wenn etwas schiefgeht: Fehlermeldung anzeigen
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Verbindung immer wieder schließen, egal ob Fehler oder nicht
                if (conn != null)
                    conn.Close();
            }
        }

        public void savePunkte(Punkte p)
        {
            // Speichert Punkte pro Frage in der Tabelle punkte
            // -> Wenn PunkteID = 0: neuer Datensatz (INSERT)
            // -> Wenn PunkteID != 0: Datensatz existiert (UPDATE)
            try
            {
                // Verbindung öffnen
                conn.Open();

                // SQL-Befehl erstellen
                MySqlCommand cmd = conn.CreateCommand();

                if (p.PunkteID1 == 0)
                {
                    // Neuer Punkteeintrag:
                    // NULL = PunkteID wird automatisch vergeben
                    // gespeichert werden: SpielerID, LandID, Punktzahl, Kategorie
                    cmd.CommandText = string.Format("INSERT INTO punkte " +
                       "VALUES (NULL, '{0}', {1}, {2}, '{3}');",
                       p.SpielerID1, p.LandID1, p.Punktzahl1, p.Kategorie);
                }
                else
                {
                    // Existierender Punkteeintrag wird aktualisiert
                    cmd.CommandText = string.Format("UPDATE punkte " +
                        "SET SpielerID = {0}, LandID = {1}, Punktzahl = {2}, Kategorie = '{3}' " +
                        "WHERE PunkteID = {4};",
                        p.SpielerID1, p.LandID1, p.Punktzahl1, p.Kategorie, p.PunkteID1);
                }

                // SQL ausführen
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Fehler anzeigen (z.B. wenn DB offline ist, falsche Spalten, usw.)
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Verbindung schließen
                if (conn != null)
                    conn.Close();
            }
        }

        public DataTable getGesamtpunkte()
        {
            // Holt eine „Scoreboard“-Tabelle zurück (DataTable)
            // Idee: pro Spieler werden die Punkte aus der Tabelle punkte summiert
            // und in Land/Hauptstadt/Flagge aufgeteilt + Gesamtpunkte berechnet
            DataTable dt = new DataTable();
            MySqlDataAdapter da = null;

            try
            {
                // Verbindung öffnen
                conn.Open();

                // SQL-Befehl erstellen
                MySqlCommand cmd = conn.CreateCommand();

                // SELECT:
                // - spielerid, name
                // - Summe der Punkte je Kategorie (Land/Hauptstadt/Flagge)
                // - Summe aller Punkte als gesamtpunkte
                // LEFT JOIN: Spieler werden auch angezeigt, wenn sie noch keine Punkte haben
                // GROUP BY: damit pro Spieler eine Zeile entsteht
                // ORDER BY: höchste Gesamtpunkte zuerst
                cmd.CommandText =
                 "SELECT " +
                 "spielerid, " +
                 "name, " +
                 "COALESCE(SUM(CASE WHEN kategorie = 'Land' THEN punktzahl END), 0) AS landpunkte, " +
                 "COALESCE(SUM(CASE WHEN kategorie = 'Hauptstadt' THEN punktzahl END), 0) AS hauptstadtpunkte, " +
                 "COALESCE(SUM(CASE WHEN kategorie = 'Flagge' THEN punktzahl END), 0) AS flaggenpunkte, " +
                 "COALESCE(SUM(punktzahl), 0) AS gesamtpunkte " +
                 "FROM spieler " +
                 "LEFT JOIN punkte USING (spielerid) " +
                 "GROUP BY spielerid, name " +
                 "ORDER BY gesamtpunkte DESC;";

                // Adapter füllt DataTable mit dem Ergebnis
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                // Fehler anzeigen (z.B. falsche Spaltennamen, DB nicht erreichbar)
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Verbindung schließen
                if (conn != null)
                    conn.Close();
            }

            // Fertige DataTable zurückgeben (für DataGridView)
            return dt;
        }

        public List<Land> getLand()
        {
            // Holt alle Länder aus der Tabelle land
            // und baut daraus eine Liste von Land-Objekten
            List<Land> liLa = new List<Land>();
            MySqlDataReader reader = null;

            try
            {
                // SQL-Befehl erstellen
                MySqlCommand com = conn.CreateCommand();

                // Verbindung öffnen
                conn.Open();

                // Alle Spalten aus land holen (SELECT * FROM land)
                com.CommandText = "SELECT * FROM land";

                // Reader liest Zeile für Zeile
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    // Pro Zeile ein neues Land-Objekt erstellen
                    // (0=LandID, 1=Landname, 2=Hauptstadt, 3=Iso2)
                    liLa.Add(
                        new Land(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3)
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                // Fehler anzeigen
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Reader schließen (wichtig, sonst bleibt Verbindung „blockiert“)
                if (reader != null)
                    reader.Close();

                // Verbindung schließen
                conn.Close();
            }

            // Liste mit allen Ländern zurückgeben
            return liLa;
        }

        public List<Punkte> getPunkte()
        {
            // Holt alle Punkteeinträge aus der Tabelle punkte
            // und baut daraus eine Liste von Punkte-Objekten
            List<Punkte> liP = new List<Punkte>();
            MySqlDataReader reader = null;

            try
            {
                // SQL-Befehl erstellen
                MySqlCommand com = conn.CreateCommand();

                // Verbindung öffnen
                conn.Open();

                // Alle Datensätze aus punkte holen
                com.CommandText = "SELECT * FROM punkte";

                // Reader liest Zeile für Zeile
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    // Pro Zeile ein neues Punkte-Objekt erstellen
                    // (0=PunkteID, 1=SpielerID, 2=LandID, 3=Punktzahl, 4=Kategorie)
                    liP.Add(
                        new Punkte(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetInt32(3),
                            Enum.Parse<Kategorie>(reader.GetString(4))
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                // Fehler anzeigen
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Reader schließen
                if (reader != null)
                    reader.Close();

                // Verbindung schließen
                conn.Close();
            }

            // Liste mit allen Punkte-Einträgen zurückgeben
            return liP;
        }

        public List<Spieler> getSpieler()
        {
            // Holt alle Spieler aus der Tabelle spieler
            // und baut daraus eine Liste von Spieler-Objekten
            List<Spieler> liSp = new List<Spieler>();
            MySqlDataReader reader = null;

            try
            {
                // SQL-Befehl erstellen
                MySqlCommand com = conn.CreateCommand();

                // Verbindung öffnen
                conn.Open();

                // Alle Spieler holen
                com.CommandText = "SELECT * FROM spieler";

                // Reader liest Zeile für Zeile
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    // Pro Zeile ein Spieler-Objekt erstellen
                    // (0=SpielerID, 1=Name, 2=Gesamtpunkte)
                    liSp.Add(
                        new Spieler(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt32(2)
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                // Fehler anzeigen
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Reader schließen
                if (reader != null)
                    reader.Close();

                // Verbindung schließen
                conn.Close();
            }

            // Liste mit allen Spielern zurückgeben
            return liSp;
        }
    }
}
