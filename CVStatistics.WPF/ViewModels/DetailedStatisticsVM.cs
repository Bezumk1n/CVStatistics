using CVStatistics.Domain.Interfaces;
using CVStatistics.Domain.Models;
using CVStatistics.Services.CoronavirusServices;
using MapControl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.WPF.ViewModels
{
    public class DetailedStatisticsVM : BaseVM
    {
        #region Properties
        /// <summary>
        /// Сервис доступа к API
        /// </summary>
        private readonly ICoronavirusService _coronavirusService;
        /// <summary>
        /// Кэш загруженной информации по странам, добавляется при выборе страны чтобы избежать повторной загрузки данных
        /// </summary>
        private IEnumerable<CountryDetailed> _cacheCountryDetails = Enumerable.Empty<CountryDetailed>();
        /// <summary>
        /// Коллекция детализированных данных по выбранной стране
        /// </summary>
        public IEnumerable<CountryDetailed> CountryDetails
        {
            get => _countryDetails;
            set
            {
                _countryDetails = value;
                OnPropertyChanged();
            }
        }
        private IEnumerable<CountryDetailed> _countryDetails = Enumerable.Empty<CountryDetailed>();
        /// <summary>
        /// Текущая выбранная страна
        /// </summary>
        public CountryInfo SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                if (value == null) return;
                _selectedCountry = value;
                LoadDetails();
            }
        }
        private CountryInfo _selectedCountry = new CountryInfo();
        /// <summary>
        /// Коллекция всех стран
        /// </summary>
        public IEnumerable<CountryInfo> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                OnPropertyChanged(() => FilteredCountries);
            }
        }
        private IEnumerable<CountryInfo> _countries = Enumerable.Empty<CountryInfo>();
        /// <summary>
        /// Фильтрованный список стран
        /// </summary>
        public IEnumerable<CountryInfo> FilteredCountries => Countries.Where(q => q.Country.ToLower().Contains(_searchText.ToLower())).ToArray();
        /// <summary>
        /// Текстовый фильтр
        /// </summary>
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(() => FilteredCountries);
            }
        }
        private string _searchText = string.Empty;
        #endregion
        #region States

        /// <summary>
        /// Статус загрузки списка стран
        /// </summary>
        public bool IsCountryListLoading
        {
            get => _isCountryListLoading;
            set
            {
                _isCountryListLoading = value;
                OnPropertyChanged();
            }
        }
        private bool _isCountryListLoading;
        /// <summary>
        /// Статус загрузки детальной информации для выбранной страны
        /// </summary>
        public bool IsDetailsLoading
        {
            get => _isDetailsLoading;
            set
            {
                _isDetailsLoading = value;
                OnPropertyChanged();
            }
        }
        private bool _isDetailsLoading;
        #endregion
        /// <summary>
        /// Координаты для отображения на карте
        /// </summary>
        public Location CountryLocation
        {
            get => _countryLocation;
            set
            {
                _countryLocation = value;
                OnPropertyChanged();
            }
        }
        private Location _countryLocation;
        #region Constructor
        public DetailedStatisticsVM(ICoronavirusService coronavirusService)
        {
            _coronavirusService = coronavirusService;
            GetCountriesList();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Метод загружает список стран
        /// </summary>
        private async void GetCountriesList()
        {
            IsCountryListLoading = true;
            var result = await _coronavirusService.GetCountriesList();
            if (result != null)
            {
                var countries = await _coronavirusService.GetCountriesList();
                Countries = countries.OrderBy(q => q.Country).ToArray();
            }
            IsCountryListLoading = false;
        }
        /// <summary>
        /// Метод загружает детальную информацию по выбранной стране
        /// </summary>
        /// <returns></returns>
        private async Task LoadDetails()
        {
            if (_selectedCountry == null) return;
            if (_cacheCountryDetails.Any(q => q.Country == _selectedCountry.Country))
            {
                CountryDetails = _cacheCountryDetails.Where(q => q.Country == _selectedCountry.Country).ToArray();
                SetLocation();
                return;
            }

            IsDetailsLoading = true;

            CountryDetails = Enumerable.Empty<CountryDetailed>();
            var result = await _coronavirusService.GetStatisticsByCountry(_selectedCountry.Slug).ConfigureAwait(true);

            if (result != null)
            {
                result = result.OrderByDescending(q => q.Date).ToArray();
                CountryDetails = result;
                _cacheCountryDetails = _cacheCountryDetails.Concat(result);
                SetLocation();
            }

            IsDetailsLoading = false;
        }
        /// <summary>
        /// Задать координаты для отображения на карте
        /// </summary>
        private void SetLocation()
        {
            if (CountryDetails.Any())
            {
                double.TryParse(CountryDetails.First().Lat, NumberStyles.Any, CultureInfo.InvariantCulture, out double latitude);
                double.TryParse(CountryDetails.First().Lon, NumberStyles.Any, CultureInfo.InvariantCulture, out double longitude);
                CountryLocation = new Location(latitude, longitude);
            }
        }
        #endregion
    }
}
