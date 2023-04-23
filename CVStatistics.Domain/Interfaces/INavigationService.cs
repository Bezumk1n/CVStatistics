using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Interfaces
{
    public interface INavigationService
    {
        /// <summary>
        /// Событие смены текущей вью-модели
        /// </summary>
        public event Action CurrentViewModelChanged;
        /// <summary>
        /// Текущая вью-модель
        /// </summary>
        public IViewModel CurrentViewModel { get; }
        /// <summary>
        /// Задать новую вью модель
        /// </summary>
        /// <typeparam name="TViewModel">Класс вью-модели</typeparam>
        public void Navigate<IViewModel>();
    }
}
