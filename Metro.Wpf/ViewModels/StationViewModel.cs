using Prism.Mvvm;

namespace Metro.Wpf.ViewModels
{
    internal class StationViewModel : BindableBase
    {
        private int _id;
        /// <summary>
        /// Идентификатор станции
        /// </summary>
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string? _name;
        /// <summary>
        /// Название станции
        /// </summary>
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private BranchViewModel _branch = null!;

        public BranchViewModel Branch 
        {
            get => _branch;
            set => SetProperty(ref _branch, value);
        }

    }
}
