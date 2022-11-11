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

        public Spieler() { }

        public Spieler(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public void SetName()
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
        }
        public string GetName()
        {
            return name;
        }
        public void SetScore(int versuche, List<Spieler> h_score)
        {
            score = versuche;
            h_score.Add(new Spieler(name, score));
        }
        public int GetScore() //Test
        {
            return score;
        }
        public void Ausgabe(List<Spieler> h_score)
        {
            List<Spieler> sort_list = h_score.OrderBy(x => x.score).ToList(); //OrderByDescending
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
