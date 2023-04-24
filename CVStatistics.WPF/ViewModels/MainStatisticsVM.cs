using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models.PL;
using CVStatistics.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CVStatistics.WPF.ViewModels
{
    public class MainStatisticsVM : BaseVM
    {
        private readonly ICoronavirusService _coronavirusService;

        public override string Title => "Основная статистика";
        /// <summary>
        /// Общая статистика
        /// </summary>
        public SummaryStatistics SummaryStatistics
        {
            get => _summaryStatistics;
            set
            {
                _summaryStatistics = value;
                OnPropertyChanged();
            }
        }
        private SummaryStatistics _summaryStatistics = new SummaryStatistics();
        #region States
        /// <summary>
        /// Статус загрузки статистики
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        private bool _isLoading;
        #endregion
        #region Commands
        /// <summary>
        /// Комманда обновления статистики
        /// </summary>
        public ICommand CommandRefreshStatistics { get; }
        #endregion
        public MainStatisticsVM(ICoronavirusService coronavirusService)
        {
            _coronavirusService = coronavirusService;
            CommandRefreshStatistics = new DelegateCommand(GetSummaryStatistics);

            GetSummaryStatistics();
        }
        #region Methods
        /// <summary>
        /// Метод загрузки мировой статистики
        /// </summary>
        private async void GetSummaryStatistics()
        {
            IsLoading = true;
            var result = await _coronavirusService.GetSummary();
            if (result != null)
            {
                result.Countries = result.Countries.OrderByDescending(q => q.NewConfirmed).Take(10).OrderBy(q => q.Country).ToArray();
                SummaryStatistics = result;
            }
            IsLoading = false;
        }
        #endregion
    }
}
