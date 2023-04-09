using CVStatistics.Domain.BaseObjects;
using CVStatistics.Domain.Interfaces;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services
{
    public class NavigationService : INavigationService
    {
        #region Events
        /// <summary>
        /// Событие изменения текущей вью-модели
        /// </summary>
        public Action CurrentViewModelChanged { get; set; }
        #endregion
        #region Properties
        private readonly Func<Type, VM> _viewModelFactory;
        /// <summary>
        /// Текущая вью-модель
        /// </summary>
        public VM CurrentViewModel
        {
            get => _CurrentViewModel;
            private set
            {
                _CurrentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
        private VM _CurrentViewModel;
        #endregion
        #region Constructor
        public NavigationService(Func<Type, VM> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Навигация через фабрику DI
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        public void Navigate<TViewModel>() where TViewModel : VM
        {
            VM viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentViewModel = viewModel;
        }
        #endregion
    }
}
