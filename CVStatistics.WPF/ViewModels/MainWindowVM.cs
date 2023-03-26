using CVStatistics.Domain.BaseObjects;
using CVStatistics.WPF.Commands;
using CVStatistics.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
