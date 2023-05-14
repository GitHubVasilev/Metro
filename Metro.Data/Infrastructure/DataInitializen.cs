using Metro.Data.DataAccess;
using Metro.Data.Entities;


namespace Metro.Data.Infrastructure
{
    /// <summary>
    /// Первоначальная заполнение базы данных
    /// </summary>
    public static class DataInitializer
    {
        private static IEnumerable<Branch> br = new List<Branch>();
        private static IEnumerable<Station> st = new List<Station>();
        private static IEnumerable<Route> rt = new List<Route>();

        /// <summary>
        /// Заполняет базу данных начальными значениями если она пуста
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async Task InitializerAsync(ApplicationDbContext context)
        {
            br = GetBranches();
            st = GetStation();
            rt = GetRoutes();

            if (!context!.Branches.Any())
            {
                await context.AddRangeAsync(br);
                await context.SaveChangesAsync();
            }

            if (!context!.Stations.Any())
            {
                await context.AddRangeAsync(st);
                await context.SaveChangesAsync();
            }

            if (!context!.Routes.Any())
            {
                foreach (var route in rt) 
                {
                    await context.AddAsync(new Route() 
                    {
                        Id = route.Id,
                        StartStation = context.Stations.First(m => m.Id == route.StartStationId),
                        FinishStation = context.Stations.First(m => m.Id == route.FinishStationId),
                        StartStationId = route.StartStationId,
                        FinishStationId = route.FinishStationId,
                        Length = route.Length,
                        Time = route.Time
                    });
                    await context.SaveChangesAsync();
                }
                
            }
        }

        private static IEnumerable<Branch> GetBranches() 
        {
            List<Branch> branches = new List<Branch>();

            foreach (var b in Branches) 
            {
                branches.Add(new Branch
                {
                    Id = b.Id,
                    Name = b.Name,
                    ColorHex = b.ColorHex
                });
            }

            return branches;
        }

        private static IEnumerable<Station> GetStation()
        {
            List<Station> stations = new List<Station>();

            foreach (var s in Stations)
            {
                stations.Add(new Station
                {
                    Id = s.Id,
                    Name = s.Name,
                    Branch = br.Where(m => m.Id == s.BranchT.Id).First(),
                    BranchId = br.Where(m => m.Id == s.BranchT.Id).First().Id
                });
            }

            return stations;
        }

        private static IEnumerable<Route> GetRoutes()
        {
            List<Route> routes = new List<Route>();
            int counter = 1;
            foreach (var r in Routes)
            {
                Station start = new Station
                {
                    Id = r.StartStationT.Id,
                    Name = r.StartStationT.Name,
                    Branch = br.Where(m => m.Id == r.StartStationT.BranchT.Id).First(),
                    BranchId = br.Where(m => m.Id == r.StartStationT.BranchT.Id).First().Id
                };
                Station finish = new Station
                {
                    Id = r.FinishStationT.Id,
                    Name = r.FinishStationT.Name,
                    Branch = br.Where(m => m.Id == r.FinishStationT.BranchT.Id).First(),
                    BranchId = br.Where(m => m.Id == r.FinishStationT.BranchT.Id).First().Id
                };
                routes.Add(new Route
                {
                    Id = counter,
                    StartStation = start,
                    FinishStation = finish,
                    StartStationId = r.StartStationT.Id,
                    FinishStationId = r.FinishStationT.Id,
                    Time = r.Time,
                    Length = r.Length
                });
                counter++;
            }

            return routes;
        }

        #region Готовые сущности с данными
        private class StationT
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public BranchT BranchT { get; set; }
        }

        private class RouteT
        {
            public StationT StartStationT { get; set; }
            public StationT FinishStationT { get; set; }
            public int Time { get; set; }
            public int Length { get; set; }
        }

        private class BranchT
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? ColorHex { get; set; }
        }

        static List<BranchT> Branches = new List<BranchT>()
            {
                new BranchT()
                {
                    Id = 1,
                    Name = "Московская",
                    ColorHex = "#000064"
                },
                new BranchT()
                {
                    Id = 2,
                    Name = "Автозаводская",
                    ColorHex = "#640000"
                },
                new BranchT()
                {
                    Id = 3,
                    Name = "Зеленолужская",
                    ColorHex = "#006400"
                },
            };

        static List<StationT> Stations = new List<StationT>()
            {
                new StationT()
                {
                    Id = 1,
                    Name = "Уручье",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 2,
                    Name = "Борисовский тракт",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 3,
                    Name = "Восток",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 4,
                    Name = "Московская",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 5,
                    Name = "Парк Челюскинцев",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 6,
                    Name = "Академия наук",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 7,
                    Name = "Площадь Якуба Коласа",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 8,
                    Name = "Площадь Победы",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 9,
                    Name = "Октябрьская",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 10,
                    Name = "Площадь Ленина",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 11,
                    Name = "Институт культуры",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 12,
                    Name = "Грушевка",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 13,
                    Name = "Михалово",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 14,
                    Name = "Петровщина",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 15,
                    Name = "Малиновка",
                    BranchT = Branches.Where(m => m.Id == 1).First()
                },
                new StationT()
                {
                    Id = 16,
                    Name = "Каменная Горка",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 17,
                    Name = "Кунцевщина",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 18,
                    Name = "Спортивная",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 19,
                    Name = "Пушкинская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 20,
                    Name = "Молодёжная",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 21,
                    Name = "Фрунзенская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 22,
                    Name = "Немига",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 23,
                    Name = "Купаловская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 24,
                    Name = "Первомайская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 25,
                    Name = "Пролетарская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 26,
                    Name = "Тракторный завод",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 27,
                    Name = "Партизанская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 28,
                    Name = "Автозаводская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 29,
                    Name = "Могилёвская",
                    BranchT = Branches.Where(m => m.Id == 2).First()
                },
                new StationT()
                {
                    Id = 30,
                    Name = "Юбилейная площадь",
                    BranchT = Branches.Where(m => m.Id == 3).First()
                },
                new StationT()
                {
                    Id = 31,
                    Name = "Площадь Франтишка Богушевича",
                    BranchT = Branches.Where(m => m.Id == 3).First()
                },
                new StationT()
                {
                    Id = 32,
                    Name = "Вокзальная",
                    BranchT = Branches.Where(m => m.Id == 3).First()
                },
                new StationT()
                {
                    Id = 33,
                    Name = "Ковальская Слобода",
                    BranchT = Branches.Where(m => m.Id == 3).First()
                },
            };

        static HashSet<RouteT> Routes = new HashSet<RouteT>()
            {
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 1).First(),
                    FinishStationT = Stations.Where(m => m.Id == 2).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 2).First(),
                    FinishStationT = Stations.Where(m => m.Id == 3).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 3).First(),
                    FinishStationT = Stations.Where(m => m.Id == 4).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 4).First(),
                    FinishStationT = Stations.Where(m => m.Id == 5).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 5).First(),
                    FinishStationT = Stations.Where(m => m.Id == 6).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 6).First(),
                    FinishStationT = Stations.Where(m => m.Id == 7).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 7).First(),
                    FinishStationT = Stations.Where(m => m.Id == 8).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 8).First(),
                    FinishStationT = Stations.Where(m => m.Id == 9).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 9).First(),
                    FinishStationT = Stations.Where(m => m.Id == 10).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 9).First(),
                    FinishStationT = Stations.Where(m => m.Id == 23).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 10).First(),
                    FinishStationT = Stations.Where(m => m.Id == 11).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 10).First(),
                    FinishStationT = Stations.Where(m => m.Id == 32).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 11).First(),
                    FinishStationT = Stations.Where(m => m.Id == 12).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 12).First(),
                    FinishStationT = Stations.Where(m => m.Id == 13).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 13).First(),
                    FinishStationT = Stations.Where(m => m.Id == 14).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 14).First(),
                    FinishStationT = Stations.Where(m => m.Id == 15).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 16).First(),
                    FinishStationT = Stations.Where(m => m.Id == 17).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 17).First(),
                    FinishStationT = Stations.Where(m => m.Id == 18).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 18).First(),
                    FinishStationT = Stations.Where(m => m.Id == 19).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 19).First(),
                    FinishStationT = Stations.Where(m => m.Id == 20).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 20).First(),
                    FinishStationT = Stations.Where(m => m.Id == 21).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 21).First(),
                    FinishStationT = Stations.Where(m => m.Id == 22).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 21).First(),
                    FinishStationT = Stations.Where(m => m.Id == 30).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 22).First(),
                    FinishStationT = Stations.Where(m => m.Id == 23).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 23).First(),
                    FinishStationT = Stations.Where(m => m.Id == 24).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 23).First(),
                    FinishStationT = Stations.Where(m => m.Id == 9).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 24).First(),
                    FinishStationT = Stations.Where(m => m.Id == 25).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 25).First(),
                    FinishStationT = Stations.Where(m => m.Id == 26).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 26).First(),
                    FinishStationT = Stations.Where(m => m.Id == 27).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 27).First(),
                    FinishStationT = Stations.Where(m => m.Id == 28).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 28).First(),
                    FinishStationT = Stations.Where(m => m.Id == 29).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 30).First(),
                    FinishStationT = Stations.Where(m => m.Id == 31).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 30).First(),
                    FinishStationT = Stations.Where(m => m.Id == 21).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 31).First(),
                    FinishStationT = Stations.Where(m => m.Id == 32).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 32).First(),
                    FinishStationT = Stations.Where(m => m.Id == 33).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 32).First(),
                    FinishStationT = Stations.Where(m => m.Id == 10).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 2).First(),
                    FinishStationT = Stations.Where(m => m.Id == 1).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 3).First(),
                    FinishStationT = Stations.Where(m => m.Id == 2).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 4).First(),
                    FinishStationT = Stations.Where(m => m.Id == 3).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 5).First(),
                    FinishStationT = Stations.Where(m => m.Id == 4).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 6).First(),
                    FinishStationT = Stations.Where(m => m.Id == 5).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 7).First(),
                    FinishStationT = Stations.Where(m => m.Id == 6).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 8).First(),
                    FinishStationT = Stations.Where(m => m.Id == 7).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 9).First(),
                    FinishStationT = Stations.Where(m => m.Id == 8).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 10).First(),
                    FinishStationT = Stations.Where(m => m.Id == 9).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 23).First(),
                    FinishStationT = Stations.Where(m => m.Id == 9).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 11).First(),
                    FinishStationT = Stations.Where(m => m.Id == 10).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 32).First(),
                    FinishStationT = Stations.Where(m => m.Id == 10).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 12).First(),
                    FinishStationT = Stations.Where(m => m.Id == 11).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 13).First(),
                    FinishStationT = Stations.Where(m => m.Id == 12).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 14).First(),
                    FinishStationT = Stations.Where(m => m.Id == 13).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 15).First(),
                    FinishStationT = Stations.Where(m => m.Id == 14).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 17).First(),
                    FinishStationT = Stations.Where(m => m.Id == 16).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 18).First(),
                    FinishStationT = Stations.Where(m => m.Id == 19).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 19).First(),
                    FinishStationT = Stations.Where(m => m.Id == 18).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 20).First(),
                    FinishStationT = Stations.Where(m => m.Id == 19).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 21).First(),
                    FinishStationT = Stations.Where(m => m.Id == 20).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 22).First(),
                    FinishStationT = Stations.Where(m => m.Id == 21).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 30).First(),
                    FinishStationT = Stations.Where(m => m.Id == 21).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 23).First(),
                    FinishStationT = Stations.Where(m => m.Id == 22).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 24).First(),
                    FinishStationT = Stations.Where(m => m.Id == 23).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 9).First(),
                    FinishStationT = Stations.Where(m => m.Id == 23).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 25).First(),
                    FinishStationT = Stations.Where(m => m.Id == 24).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 26).First(),
                    FinishStationT = Stations.Where(m => m.Id == 25).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 27).First(),
                    FinishStationT = Stations.Where(m => m.Id == 26).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 28).First(),
                    FinishStationT = Stations.Where(m => m.Id == 27).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 29).First(),
                    FinishStationT = Stations.Where(m => m.Id == 28).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 31).First(),
                    FinishStationT = Stations.Where(m => m.Id == 30).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 21).First(),
                    FinishStationT = Stations.Where(m => m.Id == 30).First(),
                    Length = 0,
                    Time = 0,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 32).First(),
                    FinishStationT = Stations.Where(m => m.Id == 31).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 33).First(),
                    FinishStationT = Stations.Where(m => m.Id == 32).First(),
                    Length = 10,
                    Time = 10,
                },
                new RouteT
                {
                    StartStationT = Stations.Where(m => m.Id == 10).First(),
                    FinishStationT = Stations.Where(m => m.Id == 32).First(),
                    Length = 0,
                    Time = 0,
                }
            };
        #endregion
    }
}
