using CVStatistics.Domain.BaseObjects;
using CVStatistics.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace CVStatistics.WPF.Services
{
    /// <summary>
    /// Класс-навигатор для смены текущего представления CurrentViewModel
    /// </summary>
    public class NavigationService : INavigationService
    {
        #region Events
        /// <summary>
        /// Событие изменения текущей вью-модели
        /// </summary>
        public Action CurrentViewModelChanged { get; set; }
        #endregion
        #region Properties
        private readonly Func<Type, BaseVM> _viewModelFactory;
        /// <summary>
        /// Текущая вью-модель
        /// </summary>
        public BaseVM CurrentViewModel
        {
            get => _CurrentViewModel;
            private set
            {
                _CurrentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
        private BaseVM _CurrentViewModel;
        #endregion
        #region Constructor
        public NavigationService(Func<Type, BaseVM> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Навигация через фабрику DI
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        public void Navigate<TViewModel>() where TViewModel : BaseVM
        {
            BaseVM viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentViewModel = viewModel;
        }
        #endregion
    }
}
