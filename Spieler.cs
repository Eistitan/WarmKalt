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
        private string vorname;
        private string zuname;
        private int score;


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
        //public void Printname()
        //{
        //    Console.WriteLine($"Jetzt spielt {name}.");
        //}

        public string GetName()
        {
            return name;
        }

        public void SetScore(int versuche)
        {
            score = versuche;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
