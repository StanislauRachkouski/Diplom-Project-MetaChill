using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaChill.model
{
    public class ChillLists
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String phoneNumber { get; set; }
        public float priceUSD { get; set; }
        public float courseOfUSD { get; set; }
        public float priceBYN { get; set; }

        public ChillLists (int id, String Name, String phoneNumber, float priceUSD, float courseOfUSD, float priceBYN)
        {
            this.id = id;
            this.Name = Name;
            this.phoneNumber = phoneNumber;
            this.priceUSD = priceUSD;
            this.courseOfUSD = courseOfUSD;
            this.priceBYN = priceBYN;
        }

        public ChillLists()
        {
            this.id = 0;
            this.Name = "";
            this.phoneNumber = "";
            this.priceUSD = 0;
            this.courseOfUSD = 0;
            this.priceBYN = 0;
        }


    }
}
