using CVStatistics.Domain.BaseObjects;
using CVStatistics.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.WPF.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        #region Properties
        /// <summary>
        /// Сервис навигации
        /// </summary>
        private readonly INavigationService _navigationService;
        /// <summary>
        /// Текущия модель представления
        /// </summary>
        public BaseVM CurrentViewModel => _navigationService.CurrentViewModel;
        #endregion
        #region Constructor
        public MainWindowVM(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.CurrentViewModelChanged = () => OnPropertyChanged(() => CurrentViewModel);
        }
        #endregion
    }
}
