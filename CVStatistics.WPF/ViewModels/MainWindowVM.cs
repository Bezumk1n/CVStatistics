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
    public class MainWindowVM : BaseVM
    {
        #region Properties
        public override string Title => "Coronavirus Statistics";
        /// <summary>
        /// Сервис навигации
        /// </summary>
        private readonly INavigationService _navigationService;
        /// <summary>
        /// Текущия модель представления
        /// </summary>
        public IViewModel CurrentViewModel => _navigationService.CurrentViewModel;
        #endregion
        #region Commsnds
        public ICommand CommandNavigateToMain { get; }
        public ICommand CommandNavigateToDetails { get; }
        public ICommand CommandNavigateToDemo { get; }
        public ICommand CommandNavigateToInfo { get; }
        #endregion
        #region Constructor
        public MainWindowVM(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.CurrentViewModelChanged += () => OnPropertyChanged(() => CurrentViewModel);

            CommandNavigateToMain = new DelegateCommand(() => _navigationService.Navigate<MainStatisticsVM>());
            CommandNavigateToDetails = new DelegateCommand(() => _navigationService.Navigate<DetailedStatisticsVM>());
            CommandNavigateToDemo = new DelegateCommand(() => _navigationService.Navigate<DemoVM>());
            CommandNavigateToInfo = new DelegateCommand(() => _navigationService.Navigate<InfoVM>());
        }
        #endregion
    }
}
