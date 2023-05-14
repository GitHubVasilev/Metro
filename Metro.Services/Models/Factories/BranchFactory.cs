using Metro.Data.Entities;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;

namespace Metro.Services.Models.Factories
{
    /// <summary>
    /// Класс для конвертации данных между <see cref="BranchDTO"/> и <see cref="Branch"/>
    /// </summary>
    public class BranchFactory : IFactory<Branch, BranchDTO>
    {
        /// <summary>
        /// Создает новую модель <see cref="BranchDTO"/>
        /// </summary>
        /// <param name="val">модель базы данных <see cref="Branch"/></param>
        /// <returns></returns>
        public BranchDTO ConvertTo(Branch val)
        {
            return new BranchDTO
            {
                Id = val.Id,
                Name = val.Name,
                ColorHex = val.ColorHex
            };
        }

        /// <summary>
        /// Создает новую модель <see cref="Branch"/>
        /// </summary>
        /// <param name="val">модель базы данных <see cref="BranchDTO"/></param>
        /// <returns></returns>
        public Branch ConvertTo(BranchDTO val)
        {
            return new Branch
            {
                Id = val.Id,
                Name = val.Name,
                ColorHex = val.ColorHex,
            };
        }
    }
}
