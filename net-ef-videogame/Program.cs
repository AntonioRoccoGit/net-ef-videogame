using Microsoft.EntityFrameworkCore;
using net_ef_videogame.Database;
using net_ef_videogame.Models;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int userChoice = 1;
            string videoGameName = "";
            string videoGameOverview = "";
            long videoGameId;
            DateTime videoGamenReleaseDate;

            Console.WriteLine("Gestore Videogame");
            do
            {
                Console.WriteLine("\nSeleziona un operazione: ");
                Console.WriteLine("-1 Aggiungi un videogame\n-2 Cerca videogame per ID\n-3 Cerca videogame per Titolo\n-4 Elimina un videogioco\n-5 Aggiungere software house\n-6 Chiudi il programma");

                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("\nAggiungere un nome: ");
                        videoGameName = Console.ReadLine();

                        Console.WriteLine("\nAggiungere una descrizione: ");
                        videoGameOverview = Console.ReadLine();

                        Console.WriteLine("\nAggiungere una sofware house selezionando l'id: ");

                        using(VideogamesContext db = new VideogamesContext())
                        {
                            List<SoftwareHouse> houses = db.SoftwareHouse.ToList<SoftwareHouse>();
                            foreach(var software in houses)
                            {
                                Console.WriteLine($"ID: {software.SoftwareHouseId} - {software.Name}");
                            }
                        }
                        Console.WriteLine();
                        long sofwareHouseId = int.Parse(Console.ReadLine());
                        videoGamenReleaseDate = DateTime.Now;

                        Videogame videogame = new Videogame()
                        {
                            Name = videoGameName,
                            Overview = videoGameOverview,
                            ReleaseDate = videoGamenReleaseDate,
                            SoftwareHouseId = sofwareHouseId
                        };

                        using(VideogamesContext db = new VideogamesContext())
                        {
                            try
                            {
                                db.Add(videogame);
                                db.SaveChanges();
                                Console.WriteLine($"Videogame {videogame.Name} aggiunto!");
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nScegliere l'ID del gioco da cercare: ");
                        videoGameId = long.Parse(Console.ReadLine());
                        try
                        {
                            using(VideogamesContext db = new VideogamesContext())
                            {
                                Videogame resault = db.Videogames.Where(v => v.VideogameId == videoGameId).Include(v => v.SoftwareHouse).First();
                                Console.WriteLine(resault);
                            }
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 3:
                        Console.WriteLine("\nScegliere il nome del gioco da cercare: ");
                        videoGameName = Console.ReadLine();
                        try
                        {
                            using (VideogamesContext db = new VideogamesContext())
                            {
                                List<Videogame> resaults = db.Videogames.Where(v => v.Name.Contains(videoGameName)).Include(v => v.SoftwareHouse).ToList<Videogame>();

                                if(resaults.Count > 0)
                                {
                                    foreach (var item in resaults)
                                    {
                                        Console.WriteLine(item);
                                    }
                                }
                                else
                                    Console.WriteLine("Nessun risultato :(");
                            }
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                        break;

                    case 4:
                        Console.WriteLine("\nScegliere l'ID del gioco da eliminare: ");
                        videoGameId = long.Parse(Console.ReadLine());

                        try
                        {
                            using (VideogamesContext db = new VideogamesContext())
                            {
                                Videogame resault = db.Videogames.Where(v => v.VideogameId == videoGameId).First();
                                db.Remove(resault);
                                db.SaveChanges();
                            }
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        break;

                    case 5:
                        Console.WriteLine("Inserire nome software house");
                        string softwareHouseName = Console.ReadLine();
                        Console.WriteLine("Inserire P.IVA");
                        string softwareHouseVat = Console.ReadLine();
                        Console.WriteLine("Inserire città");
                        string softwareHouseCity = Console.ReadLine();
                        Console.WriteLine("Inserire nazione");
                        string softwareHouseCountry = Console.ReadLine();

                        SoftwareHouse softwareHouse = new SoftwareHouse()
                        {
                            Name = softwareHouseName,
                            VatNumber = softwareHouseVat,
                            City = softwareHouseCity,
                            Country = softwareHouseCountry
                        };

                        using (VideogamesContext db = new VideogamesContext())
                        {
                            try
                            {
                                db.Add(softwareHouse);
                                db.SaveChanges();
                                Console.WriteLine($"La software house {softwareHouse.Name} è stata aggiunta!");
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                        break;

                    default:
                       
                        break;
                }


            }
            while (userChoice != 6);
        }
    }
}