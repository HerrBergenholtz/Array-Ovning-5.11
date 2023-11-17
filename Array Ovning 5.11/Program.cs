using System;
using System.Diagnostics.SymbolStore;

namespace Array_Karta
{
    class Program
    {
        public static void Main()
        {
            string[,] karta = new string[4, 4];
            karta[0, 0] = "A";
            karta[1, 0] = "B";
            karta[2, 0] = "C";
            karta[3, 0] = "D";
            karta[0, 1] = "E";
            karta[1, 1] = "F";
            karta[2, 1] = "G";
            karta[3, 1] = "H";
            karta[0, 2] = "I";
            karta[1, 2] = "J";
            karta[2, 2] = "K";
            karta[3, 2] = "L";
            karta[0, 3] = "M";
            karta[1, 3] = "N";
            karta[2, 3] = "O";
            karta[3, 3] = "P";

            int x = 1;
            int y = 2;

            string svar = VisaMeddelande(karta, x, y);

            while (svar != "exit")
            {
                if (y < 0)
                {
                    y = 0;
                    Unavailable();
                }
                else if (y > 3)
                {
                    y = 3;
                    Unavailable();
                }
                else if (x < 0)
                {
                    x = 0;
                    Unavailable();
                }
                else if (x > 3)
                {
                    x = 3;
                    Unavailable();
                }

                switch (svar)
                {
                    case "w":
                        y--;
                        svar = VisaMeddelande(karta, x, y);
                        break;
                    case "a":
                        x--;
                        svar = VisaMeddelande(karta, x, y);
                        break;
                    case "s":
                        y++;
                        svar = VisaMeddelande(karta, x, y);
                        break;
                    case "d":
                        x++;
                        svar = VisaMeddelande(karta, x, y);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måate ha en korrekt input!");
                        Console.WriteLine("Klicka enter för att börja om");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Main();
                        break;
                }
            }
            Console.WriteLine("Tack för att du spelade!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static string VisaMeddelande(string[,] karta, int x, int y)
        {
            Console.Clear();
            if (y < 0)
            {
                y = 0;
                Unavailable();
            }
            else if (y > 3)
            {
                y = 3;
                Unavailable();
            }
            else if (x < 0)
            {
                x = 0;
                Unavailable();
            }
            else if (x > 3)
            {
                x = 3;
                Unavailable();
            }


            Console.WriteLine("Du befinner dig på en karta av bokstäver.");
            Console.WriteLine($"Koordinat: {x}, {y}");
            Console.WriteLine($"Bokstav: {karta[x, y]}");
            for (int i = 0; i < karta.GetLength(0); i++)
            {
                Console.WriteLine(" ----------------");
                Console.Write("| ");
                for (int j = 0; j < karta.GetLength(1); j++)
                {
                    if (karta[j, i] == karta[x, y])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(karta[x, y]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" | ");
                    }
                    else
                    {
                        Console.Write(karta[j, i] + " | ");
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ----------------");
            Console.WriteLine("Vart vill du gå? (wasd)(skriv \"exit\" om du vill avsluta programmet)");
            string svar = Console.ReadLine();
            return svar;
        }

        public static void Unavailable()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du kan inte gå åt det hållet!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}