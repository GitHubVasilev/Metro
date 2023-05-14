using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Wpf.ViewModels
{
    /// <summary>
    /// Модель предстваления для линни метро
    /// </summary>
    internal class BranchViewModel : BindableBase
    {
        private int _id;
        /// <summary>
        /// Идентификатор линии
        /// </summary>
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string? _name;
        /// <summary>
        /// Название линии
        /// </summary>
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string? _colorHex;
        /// <summary>
        /// цвет линии
        /// </summary>
        public string? ColorHex
        {
            get => _colorHex;
            set => SetProperty(ref _colorHex, value);
        }
    }
}
