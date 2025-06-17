using PinedaLApuntesV2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static PinedaLApuntesV2.Models.WeatherModels.WeatherModel;

namespace PinedaLApuntesV2.ViewModels
{
    internal class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherData _weatherData;

        public WeatherData WeatherDataInfo
        {
            get => _weatherData;
            set
            {
                if(_weatherData != value)
                {
                    _weatherData = value;
                    OnPropertyChanged();
                }
            }
        }

        
        public WeatherViewModel()
        {
            _weatherData = new WeatherData();
            GetCurrentWeather();
            
            
        }
        //Para conectarme al repositoritorio

        public async Task GetCurrentWeather()
        {
            WeatherRepository weatherRepository = new WeatherRepository();
            WeatherDataInfo = await weatherRepository.GetWeatherCurrentLocationAsync();

        }

        
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") => 
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
