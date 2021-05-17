using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPP___Core.Models.HistoricalData

{
    


    public class Temp
    {
        
        public double record_min { get; set; }
        public double record_max { get; set; }
        public double average_min { get; set; }
        public double average_max { get; set; }
        public double median { get; set; }
        public double mean { get; set; }
        public double p25 { get; set; }
        public double p75 { get; set; }
        public double st_dev { get; set; }
        public int num { get; set; }

        public double m_value
        {
            get
            {
                return median;
            }
            set
            {
                m_value = median;
            }
        }
        public double celsius
        {
            get
            {
                return (m_value - 273.15);
            }
            set
            {
                celsius = (value - 273.15);
            }
        }
        public double round
        {
            get
            {
                return celsius;
            }
            set => round = Math.Round(celsius, 2);
        }


    }

     
        public class Pressure
        {
            public int min { get; set; }
            public int max { get; set; }
            public double median { get; set; }
            public double mean { get; set; }
            public double p25 { get; set; }
            public double p75 { get; set; }
            public double st_dev { get; set; }
            public int num { get; set; }
        }

        public class Humidity
        {
            public int min { get; set; }
            public int max { get; set; }
            public double median { get; set; }
            public double mean { get; set; }
            public double p25 { get; set; }
            public double p75 { get; set; }
            public double st_dev { get; set; }
            public int num { get; set; }
        }

        public class Wind
        {
            public double min { get; set; }
            public double max { get; set; }
            public double median { get; set; }
            public double mean { get; set; }
            public double p25 { get; set; }
            public double p75 { get; set; }
            public double st_dev { get; set; }
            public int num { get; set; }
        }

        public class Precipitation
        {
            public int min { get; set; }
            public double max { get; set; }
            public int median { get; set; }
            public double mean { get; set; }
            public int p25 { get; set; }
            public double p75 { get; set; }
            public double st_dev { get; set; }
            public int num { get; set; }
        }

        public class Clouds
        {
            public int min { get; set; }
            public int max { get; set; }
            public double median { get; set; }
            public double mean { get; set; }
            public double p25 { get; set; }
            public double p75 { get; set; }
            public double st_dev { get; set; }
            public int num { get; set; }
        }

        public class Result
        {
            public int month { get; set; }
            public int day { get; set; }
            public Temp temp { get; set; }
            public Pressure pressure { get; set; }
            public Humidity humidity { get; set; }
            public Wind wind { get; set; }
            public Precipitation precipitation { get; set; }
            public Clouds clouds { get; set; }
        }

        public class Rooth
        {
            public int cod { get; set; }
            public int city_id { get; set; }
            public double calctime { get; set; }
            public List<Result> result { get; set; }
        }

    }

