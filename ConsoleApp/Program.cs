using Microsoft.VisualBasic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Net;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Branch> branches = new List<Branch>() 
            {
                new Branch() 
                {
                    Id = 1,
                    Name = "Московская",
                },
                new Branch()
                {
                    Id = 2,
                    Name = "Автозаводская",
                },
                new Branch()
                {
                    Id = 3,
                    Name = "Зеленолужская",
                },
            };

            List<Station> stations = new List<Station>()
            {
                new Station()
                {
                    Id = 1,
                    Name = "Уручье",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 2,
                    Name = "Борисовский тракт",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 3,
                    Name = "Восток",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 4,
                    Name = "Московская",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 5,
                    Name = "Парк Челюскинцев",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 6,
                    Name = "Академия наук",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 7,
                    Name = "Площадь Якуба Коласа",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 8,
                    Name = "Площадь Победы",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 9,
                    Name = "Октябрьская",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 10,
                    Name = "Площадь Ленина",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 11,
                    Name = "Институт культуры",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 12,
                    Name = "Грушевка",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 13,
                    Name = "Михалово",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 14,
                    Name = "Петровщина",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 15,
                    Name = "Малиновка",
                    Branch = branches.Where(m => m.Id == 1).First()
                },
                new Station()
                {
                    Id = 16,
                    Name = "Каменная Горка",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 17,
                    Name = "Кунцевщина",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 18,
                    Name = "Спортивная",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 19,
                    Name = "Пушкинская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 20,
                    Name = "Молодёжная",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 21,
                    Name = "Фрунзенская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 22,
                    Name = "Немига",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 23,
                    Name = "Купаловская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 24,
                    Name = "Первомайская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 25,
                    Name = "Пролетарская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 26,
                    Name = "Тракторный завод",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 27,
                    Name = "Партизанская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 28,
                    Name = "Автозаводская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 29,
                    Name = "Могилёвская",
                    Branch = branches.Where(m => m.Id == 2).First()
                },
                new Station()
                {
                    Id = 30,
                    Name = "Юбилейная площадь",
                    Branch = branches.Where(m => m.Id == 3).First()
                },
                new Station()
                {
                    Id = 31,
                    Name = "Площадь Франтишка Богушевича",
                    Branch = branches.Where(m => m.Id == 3).First()
                },
                new Station()
                {
                    Id = 32,
                    Name = "Вокзальная",
                    Branch = branches.Where(m => m.Id == 3).First()
                },
                new Station()
                {
                    Id = 33,
                    Name = "Ковальская Слобода",
                    Branch = branches.Where(m => m.Id == 3).First()
                },
            };

            HashSet<Route> routes = new HashSet<Route>()
            {
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 1).First(),
                    FinishStation = stations.Where(m => m.Id == 2).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 2).First(),
                    FinishStation = stations.Where(m => m.Id == 3).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 3).First(),
                    FinishStation = stations.Where(m => m.Id == 4).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 4).First(),
                    FinishStation = stations.Where(m => m.Id == 5).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 5).First(),
                    FinishStation = stations.Where(m => m.Id == 6).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 6).First(),
                    FinishStation = stations.Where(m => m.Id == 7).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 7).First(),
                    FinishStation = stations.Where(m => m.Id == 8).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 8).First(),
                    FinishStation = stations.Where(m => m.Id == 9).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 9).First(),
                    FinishStation = stations.Where(m => m.Id == 10).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 9).First(),
                    FinishStation = stations.Where(m => m.Id == 23).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 10).First(),
                    FinishStation = stations.Where(m => m.Id == 11).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 10).First(),
                    FinishStation = stations.Where(m => m.Id == 32).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 11).First(),
                    FinishStation = stations.Where(m => m.Id == 12).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 12).First(),
                    FinishStation = stations.Where(m => m.Id == 13).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 13).First(),
                    FinishStation = stations.Where(m => m.Id == 14).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 14).First(),
                    FinishStation = stations.Where(m => m.Id == 15).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 16).First(),
                    FinishStation = stations.Where(m => m.Id == 17).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 17).First(),
                    FinishStation = stations.Where(m => m.Id == 18).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 18).First(),
                    FinishStation = stations.Where(m => m.Id == 19).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 19).First(),
                    FinishStation = stations.Where(m => m.Id == 20).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 20).First(),
                    FinishStation = stations.Where(m => m.Id == 21).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 21).First(),
                    FinishStation = stations.Where(m => m.Id == 22).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 21).First(),
                    FinishStation = stations.Where(m => m.Id == 30).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 22).First(),
                    FinishStation = stations.Where(m => m.Id == 23).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 23).First(),
                    FinishStation = stations.Where(m => m.Id == 24).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 23).First(),
                    FinishStation = stations.Where(m => m.Id == 9).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 24).First(),
                    FinishStation = stations.Where(m => m.Id == 25).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 25).First(),
                    FinishStation = stations.Where(m => m.Id == 26).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 26).First(),
                    FinishStation = stations.Where(m => m.Id == 27).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 27).First(),
                    FinishStation = stations.Where(m => m.Id == 28).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 28).First(),
                    FinishStation = stations.Where(m => m.Id == 29).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 30).First(),
                    FinishStation = stations.Where(m => m.Id == 31).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 30).First(),
                    FinishStation = stations.Where(m => m.Id == 21).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 31).First(),
                    FinishStation = stations.Where(m => m.Id == 32).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 32).First(),
                    FinishStation = stations.Where(m => m.Id == 33).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 32).First(),
                    FinishStation = stations.Where(m => m.Id == 10).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 2).First(),
                    FinishStation = stations.Where(m => m.Id == 1).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 3).First(),
                    FinishStation = stations.Where(m => m.Id == 2).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 4).First(),
                    FinishStation = stations.Where(m => m.Id == 3).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 5).First(),
                    FinishStation = stations.Where(m => m.Id == 4).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 6).First(),
                    FinishStation = stations.Where(m => m.Id == 5).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 7).First(),
                    FinishStation = stations.Where(m => m.Id == 6).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 8).First(),
                    FinishStation = stations.Where(m => m.Id == 7).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 9).First(),
                    FinishStation = stations.Where(m => m.Id == 8).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 10).First(),
                    FinishStation = stations.Where(m => m.Id == 9).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 23).First(),
                    FinishStation = stations.Where(m => m.Id == 9).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 11).First(),
                    FinishStation = stations.Where(m => m.Id == 10).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 32).First(),
                    FinishStation = stations.Where(m => m.Id == 10).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 12).First(),
                    FinishStation = stations.Where(m => m.Id == 11).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 13).First(),
                    FinishStation = stations.Where(m => m.Id == 12).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 14).First(),
                    FinishStation = stations.Where(m => m.Id == 13).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 15).First(),
                    FinishStation = stations.Where(m => m.Id == 14).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 17).First(),
                    FinishStation = stations.Where(m => m.Id == 16).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 18).First(),
                    FinishStation = stations.Where(m => m.Id == 19).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 19).First(),
                    FinishStation = stations.Where(m => m.Id == 18).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 20).First(),
                    FinishStation = stations.Where(m => m.Id == 19).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 21).First(),
                    FinishStation = stations.Where(m => m.Id == 20).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 22).First(),
                    FinishStation = stations.Where(m => m.Id == 21).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 30).First(),
                    FinishStation = stations.Where(m => m.Id == 21).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 23).First(),
                    FinishStation = stations.Where(m => m.Id == 22).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 24).First(),
                    FinishStation = stations.Where(m => m.Id == 23).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 9).First(),
                    FinishStation = stations.Where(m => m.Id == 23).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 25).First(),
                    FinishStation = stations.Where(m => m.Id == 24).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 26).First(),
                    FinishStation = stations.Where(m => m.Id == 25).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 27).First(),
                    FinishStation = stations.Where(m => m.Id == 26).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 28).First(),
                    FinishStation = stations.Where(m => m.Id == 27).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 29).First(),
                    FinishStation = stations.Where(m => m.Id == 28).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 31).First(),
                    FinishStation = stations.Where(m => m.Id == 30).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 21).First(),
                    FinishStation = stations.Where(m => m.Id == 30).First(),
                    Length = 0,
                    Time = 0,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 32).First(),
                    FinishStation = stations.Where(m => m.Id == 31).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 33).First(),
                    FinishStation = stations.Where(m => m.Id == 32).First(),
                    Length = 10,
                    Time = 10,
                },
                new Route
                {
                    StartStation = stations.Where(m => m.Id == 10).First(),
                    FinishStation = stations.Where(m => m.Id == 32).First(),
                    Length = 0,
                    Time = 0,
                }
            };

            Stopwatch stopwatch = new Stopwatch();
            var p = Process.GetCurrentProcess();
            var mem = p.PeakVirtualMemorySize64;
            stopwatch.Start();
            RoutingService service = new RoutingService(stations, routes, branches);
            for (int i = 0; i < stations.Count; i++)
            {
                var r = service.MinTimeForAllBranch(stations[i]);

                Stack<Station> stations1 = new Stack<Station>();
                stations1.Push(r.Last.Value);
                r.RemoveLast();
                while (stations1.Count > 0)
                {
                    Station temp = stations1.Pop();
                    Console.Write($"{temp.Name}");
                    Console.Write("->");
                    if (r.First is not null)
                    {
                        stations1.Push(r.Last.Value);
                        r.RemoveLast();
                    }
                }
                Console.WriteLine();
            }
            stopwatch.Stop();
        }
    }

    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Branch Branch { get; set; }
    }

    public struct Route
    {
        public Station StartStation { get; set; }
        public Station FinishStation { get; set; }
        public int Time { get; set; }
        public int Length { get; set; }
    }

    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }   

    public class RoutingService
    {
        private readonly List<Station> _stations;
        private readonly HashSet<Route> _routes;
        private readonly List<Branch> _branches;
        
        public RoutingService(List<Station> stations, HashSet<Route> routes, List<Branch> branches)
        {
            _stations = stations;
            _routes = routes;
            _branches = branches;
        }
        
        private record StationLink (StationLink? Prev, Station Current, HashSet<Branch> VisitedBranches, HashSet<Station> VisitedStation, int WayLangth);
        public LinkedList<Station> MinTimeForAllBranch(Station startStation) 
        {
            StationLink? link = null;
            int minDistant = int.MaxValue;
            Queue<StationLink> queue = new Queue<StationLink>();
            queue.Enqueue(new StationLink(null, startStation, new(){ startStation.Branch }, new(){ startStation }, 0));
            while (queue.Count > 0) 
            {
                var temp = queue.Dequeue();
                temp.VisitedStation.Add(temp.Current);

                if (_branches.Count == temp.VisitedBranches.Count)
                {
                    if (temp.WayLangth < minDistant) 
                    {
                        minDistant = temp.WayLangth;
                        link = temp;
                    }
                    continue;
                }

                var notVisitedStation = _routes.Where(m => m.StartStation.Id == temp.Current.Id 
                && !temp.VisitedStation.Contains(m.FinishStation));
                foreach (Route route in notVisitedStation)
                {
                    HashSet<Branch> branches = new HashSet<Branch>(temp.VisitedBranches) { route.FinishStation.Branch };
                    HashSet<Station> stations = new HashSet<Station>(temp.VisitedStation);
                    queue.Enqueue(new StationLink(temp, route.FinishStation, branches, stations, temp.WayLangth + route.Time));
                }
            }
            return StationLinkToLinkedList(link);
        }

        private LinkedList<Station> StationLinkToLinkedList(StationLink? link) 
        {
            LinkedList<Station> result = new();

            while (link != null)
            {
                result.AddLast(link.Current);
                link = link.Prev;
            }

            result.Reverse();
            return result;
        }
    }
}