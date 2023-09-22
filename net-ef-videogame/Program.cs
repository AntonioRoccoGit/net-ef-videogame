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
                Console.WriteLine("-1 Aggiungi un videogame\n-2 Cerca videogame per ID\n-3 Cerca videogame per Titolo\n-4 Elimina un videogioco\n-5 Chiudi il programma");

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

                    //case 2:
                    //    Console.WriteLine("\nScegliere l'ID del gioco da cercare: ");
                    //    videoGameId = long.Parse(Console.ReadLine());
                    //    try
                    //    {
                    //        Console.WriteLine(DbVideogameManager.GetVideoGameById(videoGameId).ToString());

                    //    }
                    //    catch (Exception ex) { Console.WriteLine(ex.Message); }

                    //    break;

                    //case 3:
                    //    Console.WriteLine("\nScegliere il nome del gioco da cercare: ");
                    //    videoGameName = Console.ReadLine();
                    //    List<Videogame> videogames = DbVideogameManager.GetVideoGameByName(videoGameName);

                    //    if (videogames.Count() > 0)
                    //    {
                    //        foreach (var item in videogames)
                    //        {
                    //            Console.WriteLine("--------------------------------------------");
                    //            Console.WriteLine(item.ToString());
                    //            Console.WriteLine("--------------------------------------------");
                    //        }
                    //        Console.WriteLine($"{Environment.NewLine}{videogames.Count()} risultati trovati{Environment.NewLine}");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("Nessuna Corrispondenza");
                    //    }

                    //    break;
                    //case 4:
                    //    Console.WriteLine("\nScegliere l'ID del gioco da eliminare: ");
                    //    videoGameId = long.Parse(Console.ReadLine());
                    //    if (DbVideogameManager.DeleteVideogame(videoGameId))
                    //        Console.WriteLine("Eliminato con successo");
                    //    else
                    //        Console.WriteLine("Nessuna corrispondenza trovata");

                    //    break;
                    default:
                        userChoice = 5;
                        break;
                }


            }
            while (userChoice != 5);
        }
    }
}