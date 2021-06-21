using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Province
    {
        private string provinceName;
        private int airTemperature;

        public Province(string pName, int aTemp)
        {
            provinceName = pName;
            airTemperature = aTemp;
        }

        public string getProvinceName()
        {
            return provinceName;
        }

        public int getAirTemperature()
        {
            return airTemperature;
        }
    }
}
