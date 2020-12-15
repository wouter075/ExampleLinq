using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace ExampleLinq
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Opdracht 10 en 13. Dit is een voorbeeld over hoe je het kan doen.
            
            // lijst aanmaken
            List<Mp3Player> mp3Players = new List<Mp3Player>();
            
            // lijst vullen
            mp3Players = Mp3Player.Init();
            
            // stats, Linq manier
            int total_players = mp3Players.Sum(m => m.stock);
            double total_value = mp3Players.Sum(m => m.stock * m.price);
            double avarage_value = mp3Players.Average(m => m.price);
            
            // Om deze functie te gebruiken, moet je via NuGet (tool window) MoreLinq installeren en toevoegen
            // aan je project.
            Mp3Player bestPriceMb = mp3Players.MinBy(m => m.price / m.mbSize).First();

            Console.WriteLine($"Totaal aantal spelers op voorraad: {total_players}");
            Console.WriteLine($"Totale waarde van de voorraad: {total_value}");
            Console.WriteLine($"Gemiddelde prijs: {avarage_value}");
            Console.WriteLine($"Mp3 speler met de beste prijs per Mb: {bestPriceMb.id}: {bestPriceMb.make} - {bestPriceMb.model}");
        }

        public class Mp3Player
        {
            // publieke velden
            public int id;
            public string model;
            public string make;
            public int mbSize;
            public double price;
            public int stock;

            // constructor
            public Mp3Player()
            {
                
            }

            public Mp3Player(int id, string make, string model, int mbSize, double price)
            {
                this.id = id;
                this.model = model;
                this.make = make;
                this.mbSize = mbSize;
                this.price = price;
                this.stock = 500; // default
            }
            
            // method
            public static List<Mp3Player> Init()
            {
                List<Mp3Player> temp = new List<Mp3Player>();
                temp.Add(new Mp3Player(1, "GET technologies .inc", "HF 410", 4096, 129.95));
                temp.Add(new Mp3Player(2, "Far & Loud", "XM 600", 8192, 224.95));
                temp.Add(new Mp3Player(3, "Innotivative", "Z3", 512, 79.95));
                temp.Add(new Mp3Player(4, "Resistance S.A.", "3001", 4096, 124.95));
                temp.Add(new Mp3Player(5, "CBA", "NXT volume", 2048, 159.05));

                
                // lijst teruggeven:
                return temp;
            }
        }
    }
}