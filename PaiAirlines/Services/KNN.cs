using PaiAirlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiAirlines.Services
{
    public class KNN
    {
        public List<Flight> lstFlights { get; set; }

        public List<Flight> lstAllFLights { get; set; }

        private double Mean { get; set; }

        public int NumberK { get; set; }

        private List<int> lstPrices { get; set; }

        private Dictionary<Flight, double> dictDistances { get; set; }

        public KNN(List<Flight> flights, int ParameterK, List<Flight> AllFlights)
        {
            this.lstFlights = flights;
            this.NumberK = ParameterK;
            this.lstPrices = new List<int>();
            this.dictDistances = new Dictionary<Flight, double>();
            this.lstAllFLights = AllFlights;
        }

        public List<Flight> Run()
        {
            // Create list to return
            List<Flight> lstResult = new List<Flight>();

            // Create a list for the prices
            lstFlights.ForEach(flt => lstPrices.Add(flt.Price));

            // Calculate the mean
            this.Mean = lstPrices.Average();

            CalcDistances(this.Mean);

            lstResult = ExtractMinimun();

            return lstResult;
        }

        private void CalcDistances(double mean)
        {
            foreach (Flight flt in lstAllFLights)
            {
                dictDistances.Add(flt, Math.Abs(flt.Price - mean));
            }
        }

        private List<Flight> ExtractMinimun()
        {
            // Create list to return
            List<Flight> lstResult = new List<Flight>();

            for (int i = 0; i < this.NumberK; i++)
            {
                double dMInimum = this.dictDistances.First().Value;
                KeyValuePair<Flight, double> Lowest = this.dictDistances.First();
                foreach (KeyValuePair<Flight,double> item in this.dictDistances)
                {
                    if(item.Value < dMInimum)
                    {
                        dMInimum = item.Value;
                        Lowest = item;
                    }
                }

                lstResult.Add(Lowest.Key);
                this.dictDistances.Remove(Lowest.Key);
            }

            return lstResult;
        }
    }
}
