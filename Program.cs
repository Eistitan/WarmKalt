﻿using System.Reflection;
using System.Security.AccessControl;

namespace WarmKalt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int siege = 0;

            //Easy();
            Game();

        }
        static int Menu()
        {
            int mode = 0;
            bool check;
            string sw_menu;
            do
            {
                Console.Write("(E)asy oder (H)ard Mode starten? ");
                sw_menu = Console.ReadLine().ToLower();
                switch (sw_menu)
                {
                    case "e":
                    case "easy":
                        mode = 100;
                        Console.WriteLine("Easy Mode mit Highscore gestartet.\n");
                        check = true;

                        break;
                    case "h":
                    case "hard":
                        mode = 1000;
                        Console.WriteLine("Hard Mode mit Highscore gestartet.\n");
                        check = true;

                        break;
                    default:
                        Console.WriteLine("Falsch! h oder e eingeben.\n");
                        check = false;
                        break;
                }

            } while (!check);
            return mode;
        }

        static void Game() //mode wird aus der Methode Menu erstellt
        {
            Spieler sp1 = new Spieler();
            HiScore hs1 = new HiScore();
            List<string> h_score = new List<string>(); //??
            List<string> scoreL = new List<string>(); //??
            List<string> nameL = new List<string>(); //??

            int rnd_max = Menu();
            bool spiel = true;
            string name;
            do    //ein Spiel
            {
                sp1.SetName();
                name = sp1.GetName();
                Console.WriteLine($"Jetzt spielt {name}.");
                int versuche = 0;
                int gegeben1 = 0;
                int gegeben2 = 0;
                int gesucht = Generator(rnd_max);
                bool durchlauf = true;
                do //eine Eingabe
                {
                    if (versuche == 0)
                    {
                        Console.WriteLine(gesucht); //Test

                        gegeben1 = Eingabe(rnd_max);
                        versuche = Abgleich_start(gesucht, gegeben1, versuche);
                        //Console.WriteLine($"Versuche {versuche}");
                    }
                    else
                    {
                        //Console.WriteLine(gesucht); //Test
                        gegeben2 = gegeben1;
                        gegeben1 = Eingabe(rnd_max);
                        versuche = Abgleich_next(gesucht, gegeben1, gegeben2, versuche);
                        //Console.WriteLine($"Versuche {versuche}");
                    }

                    if (gegeben1 == gesucht)
                    {
                        spiel = Ende();
                        durchlauf = false;
                    }
                } while (durchlauf == true); 
                hs1.Eintrag(name,versuche, h_score);

            } while (spiel == true);
            Console.WriteLine("Highscore Liste\n");
            hs1.Ausgabe(h_score);

        }

        static int Generator(int rndmax) //Generator anpassen v
        {
            int rnd_max = rndmax + 1;
            Random ra = new Random();
            int wert = ra.Next(1, rnd_max);
            return wert;
        }

        static int Eingabe(int rndmax) //Eingabe für 2 Fälle anpassen. 100 und 1000 v
        {
            int u_zahl;
            bool check;
            do
            {
                Console.Write($"Die gesuchte Zahl (1-{rndmax}) eingeben: ");
                check = int.TryParse(Console.ReadLine(), out u_zahl);
                if (!check)
                    Console.WriteLine("Nur die Ziffern eingeben.\n");
                if ((check && u_zahl < 1) || (check && u_zahl > rndmax))
                {
                    Console.WriteLine("Die Zahl liegt ausserhalb des Wertebereichs.\n");
                    check = false;
                }
            } while (!check);

            return u_zahl;
        }
        static int Abgleich_start(int gesucht, int gegeben, int versuche)
        {
            versuche++;
            if (gesucht == gegeben)
                Console.WriteLine("Gratulation. Beim ersten Versucht gefunden.");
            else
                Console.WriteLine("Nein, suchen Sie weiter.");
            return versuche;

        }
        static int Abgleich_next(int gesucht, int gegeben1, int gegeben2, int versuche) //muss überarbeitet werden
        {
            int einheit1 = 0;
            int einheit2 = 0;
            if (gesucht == gegeben1)  //die neue Zahl
            {
                versuche++;
                Console.WriteLine($"Richtig, die gesuchte Zahl war {gegeben1}");
                Console.WriteLine($"Die Anzahl der Versuche: {versuche}");
                return versuche;
            }
            else if (gesucht > gegeben1)
            {
                einheit1 = gesucht - gegeben1;
            }
            else
            {
                einheit1 = gegeben1 - gesucht;
            }

            if (gesucht > gegeben2) //die alte Zahl
            {
                einheit2 = gesucht - gegeben2;
            }
            else
            {
                einheit2 = gegeben2 - gesucht;
            }

            if (einheit1 < einheit2) //Vergleich des Abstandes
            {
                versuche++;
                Console.WriteLine("wärmer!");
            }
            else
            {
                versuche++;
                Console.WriteLine("kälter!");
            }
            return versuche;
        }

        static bool Ende()
        {
            bool result = true;
            string text;
            Console.Write("Spiel beenden? y/n "); //??
            text = Console.ReadLine().ToLower();
            if (text == "y" || text == "ja" || text == "yes" || text == "j")
            {
                Console.WriteLine("Schönen Tag noch.\n");
                result = false;
            }
            else
            {
                Console.WriteLine("Eine gute Wahl.\n");
                result = true;
            }
            return result;
        }

        //In Main Start() -- Auswahl Methode, Name Methoden (generiert Namen) 
        //Hard Mode - Generator erhöhen und die CW anpassen
        //Bestenliste mit Index LIST Name und LIST Score
        //Listen Sortieren nach Score absteigend
        //Name eingeben vor dem Start jeder Runde
        //

    }
}