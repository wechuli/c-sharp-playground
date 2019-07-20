using System;

namespace ex2
{

    public enum BatteryType
    {
        Li_Ion, NiMH, NiCd, Li_Pol
    }
    internal class Model
    {
        private string name = "";

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public Model(string name)
        {
            this.name = name;
        }
    }

    internal class Owner
    {
        private string name = "";


        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public Owner(string name)
        {
            this.name = name;
        }
    }

    internal class Manufacturer
    {
        private string name = "";
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public Manufacturer(string name)
        {
            this.name = name;
        }
    }

    internal class Screen
    {
        private string color = "";
        private double size = 0;

        public string PhoneInfo
        {
            get
            {
                return $"{color},{size}";
            }
        }
        public Screen(string color, double size)
        {
            this.color = color;
            this.size = size;
        }
    }

    internal class Battery
    {

        private BatteryType batteryType;
        private string model = "";
        private double idleTime = 0;
        private int talkHours = 0;

        public string Model
        {
            get
            {
                return this.model;
            }
        }

        public Battery(string model, double idleTime, int talkHours)
        {
            this.model = model;
            this.idleTime = idleTime;
            this.talkHours = talkHours;
        }
    }



}