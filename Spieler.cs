using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WarmKalt
{
    internal class Spieler
    {
        private string name;
        private int score;

        public Spieler() //Der Name wird automatisch beim Erstellen des Objekts erzeugt
        {
            this.name=SetName(); 
        }

        public Spieler(string name, int score) //Konstruktorüberladung fürs Befüllen der Liste benötigt
        {
            this.name = name;
            this.score = score;
        }
        public string SetName() //Erzeugt Namen der Spieler kopiert aus anderem Spiel.
        {
            List<string> vornamen = new()
            {
                "Dietrich",
                "Frank",
                "Ilyass",
                "Alexander",
                "Georg",
                "Stephanus"
            };

            List<string> zunamen = new()
            {
                ", der Alte",
                ", der Gänse-Würger",
                ", der Welpen-Schmeißer",
                ", der SI'ler",
                ", der Warmduscher",
                ", der Bleiche",
                ", der Lord",
                ", der Pessimist"
            };

            Random rand = new Random();
            int index = rand.Next(0, (vornamen.Count));
            name = vornamen[index];
            index = rand.Next(0, zunamen.Count);
            name = name + zunamen[index];
            return name; 
        }
        public string GetName() //Zeigt den Namen
        {
            return name;
        }
        public void SetScore(int versuche, List<Spieler> h_score) // Befüllt die Liste mit dem Namen und dem Score
        {
            score = versuche;
            h_score.Add(new Spieler(name, score));
        }
        public int GetScore() //Test
        {
            return score;
        }
        public static void Ausgabe(List<Spieler> h_score) //Gibt die Liste mit Highscore aus
        {
            List<Spieler> sort_list = h_score.OrderBy(x => x.score).ToList(); //erstellt eine neue sortierte Liste, sortiert nach score
            int i = 1;
            foreach (var item in sort_list)
            {
                if (item.score == 1)
                {
                    Console.WriteLine($"Platz {i}. {item.name} mit {item.score} Versuch.\n ");
                    i++;
                }
                else
                {
                    Console.WriteLine($"Platz {i}. {item.name} mit {item.score} Versuchen.\n ");
                    i++;
                }
            }
        }
    }
}
