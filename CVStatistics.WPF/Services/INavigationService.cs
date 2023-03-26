using CVStatistics.Domain.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.WPF.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// Событие смены текущей вью-модели
        /// </summary>
        public Action CurrentViewModelChanged { get; set; }
        /// <summary>
        /// Текущая вью-модель
        /// </summary>
        public BaseVM CurrentViewModel { get; }
        /// <summary>
        /// Задать новую вью модель
        /// </summary>
        /// <typeparam name="TViewModel">Класс вью-модели</typeparam>
        public void Navigate<TViewModel>() where TViewModel : BaseVM;
    }
}
