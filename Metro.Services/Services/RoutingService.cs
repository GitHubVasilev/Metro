using Metro.Data.Entities;
using Metro.Data.Interfaces;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;
using Metro.Services.Models.ServiceModels;

namespace Metro.Services.Services
{
    /// <summary>
    /// Класс сервиса для расчета пути
    /// </summary>
    public class RoutingService : IRoutingService
    {
        private readonly IFactory<Station, StationDTO> _factoryStantion;
        private readonly IRepository<Station> _stationsRepository;
        private readonly IRepository<Route> _routesRepository;
        private readonly IRepository<Branch> _branchesRepository;

        public RoutingService(IFactory<Station, StationDTO> factoryStantion,
            IUnitOfWork unitOfWork)
        {
            _factoryStantion = factoryStantion;
            _stationsRepository = unitOfWork.GetRepository<Station>();
            _routesRepository = unitOfWork.GetRepository<Route>();
            _branchesRepository = unitOfWork.GetRepository<Branch>();
        }

        /// <summary>
        /// Вовзращает минимальный путь для обхода всех веток метро
        /// "Ветка считается пройденой, если была посещена хотя бы одна станция"
        /// </summary>
        /// <param name="idStation">Идентификатор станции для начала пути</param>
        /// <returns>Связанный список станций проложенного пути</returns>
        public List<StationDTO> MinTimeForAllBranch(int idStation)
        {
            int branchesCount = _branchesRepository.GetAll().Count();
            Station startStation = _stationsRepository.Find(m => m.Id == idStation).First();
            StationLink? link = null;
            double minDistant = int.MaxValue;
            Queue<StationLink> queue = new Queue<StationLink>();
            queue.Enqueue(new StationLink() 
            {
                Prev = null,
                Current = startStation,
                VisitedBranches = new() { startStation.Branch },
                VisitedStation = new() { startStation },
                WayLangth = 0,

            });
            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                temp.VisitedStation.Add(temp.Current);

                if (branchesCount == temp.VisitedBranches.Count)
                {
                    if (temp.WayLangth < minDistant)
                    {
                        minDistant = temp.WayLangth;
                        link = temp;
                    }
                    continue;
                }

                var notVisitedStation = _routesRepository.Find(m => m.StartStation.Id == temp.Current.Id
                && !temp.VisitedStation.Contains(m.FinishStation));
                foreach (Route route in notVisitedStation)
                {
                    queue.Enqueue(new StationLink() 
                    {
                        Prev = temp,
                        Current = route.FinishStation,
                        VisitedBranches = new HashSet<Branch>(temp.VisitedBranches) { route.FinishStation.Branch },
                        VisitedStation = new HashSet<Station>(temp.VisitedStation),
                        WayLangth = temp.WayLangth + route.Time
                    });
                }
            }
            return StationLinkToList(link);
        }

        /// <summary>
        /// Конвертирует сервисную модель проложенного пути в связанный список
        /// </summary>
        /// <param name="link">Конечный элемент пути</param>
        /// <returns></returns>
        private List<StationDTO> StationLinkToList(StationLink? link)
        {
            List<StationDTO> result = new();

            while (link != null)
            {
                result.Add(_factoryStantion.ConvertTo(link.Current));
                link = link.Prev;
            }

            result.Reverse();
            return result;
        }
    }
}
