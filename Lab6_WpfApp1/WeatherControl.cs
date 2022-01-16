using System.Windows;

namespace Lab6_WpfApp1
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        private string windDirection;
        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }
        private int windSpeed;
        public int WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                if (value >= 0)
                {
                    windSpeed = value;
                }
                else
                {
                    windSpeed = 0;
                }
            }
        }
        public enum PresencePrecipitation
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 3
        }
        public WeatherControl(int temperature, string windDirection, int windSpeed)
        {
            this.Temperature = temperature;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }
        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50)
                return t;
            else
                return -50;
        }
        public string Print()
        {
            return $"{Temperature}, {WindDirection}, {WindSpeed}, {PresencePrecipitation.Sunny}";
        }
    }
}
