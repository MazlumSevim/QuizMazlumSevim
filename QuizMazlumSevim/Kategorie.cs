using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMazlumSevim
{
    // Dieses Enum definiert die möglichen Quiz-Kategorien.
    // Ein Enum ist eine feste Liste von erlaubten Werten.
    // Dadurch kann man im Code nicht aus Versehen falsche Kategorien benutzen.
    public enum Kategorie
    {
        // Fragen rund um Ländernamen
        // z.B. Land anhand Flagge oder Hauptstadt erraten
        Land,

        // Fragen rund um Flaggen
        // z.B. Flagge anhand Land oder Hauptstadt erraten
        Flagge,

        // Fragen rund um Hauptstädte
        // z.B. Hauptstadt anhand Land oder Flagge erraten
        Hauptstadt
    }
}
