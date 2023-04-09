using CVStatistics.Domain.BaseObjects;
using CVStatistics.Domain.Interfaces;
using CVStatistics.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CVStatistics.WPF.ViewModels
{
    public class MainWindowVM : VM
    {
        #region Properties
        /// <summary>
        /// Сервис навигации
        /// </summary>
        private readonly INavigationService _navigationService;
        /// <summary>
        /// Текущия модель представления
        /// </summary>
        public VM CurrentViewModel => _navigationService.CurrentViewModel;
        #endregion
        #region Commsnds
        public ICommand CommandNavigateToDemo { get; }
        #endregion
        #region Constructor
        public MainWindowVM(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.CurrentViewModelChanged = () => OnPropertyChanged(() => CurrentViewModel);

            CommandNavigateToDemo = new DelegateCommand(() => _navigationService.Navigate<DemoVM>());
        }
        #endregion
    }
}
