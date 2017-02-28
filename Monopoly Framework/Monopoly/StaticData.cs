using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    public static class StaticData
    {
        private static Dictionary<int, double> rollProbabilities = new Dictionary<int, double>();
        public struct subDivision   //represents a single monopoly
        {
            public string type;  //colors for std properties, "rail" for RR, "util" for utilities
            public string[] propertiesIncluded; //a list of each property included in the monopoly
            public int num; //number of properties included in this monopoly
            public int[] positions; //list of positions for properties
        }
        private static List<subDivision> monopolies = new List<subDivision>();

        private static bool initialized = false;

        public static void initialize()
        {
            if (!initialized)
            {
                initMonopolies();
                initRollProbabilities();
                initialized = true;
            }
        }

        private static void initMonopolies()
        {
            subDivision s = new subDivision();
            s.type = "purple";
            s.num = 2;
            s.propertiesIncluded = new string[] {"Mediterranean Avenue", "Baltic Avenue"};
            s.positions = new int[] { 1, 3 };
            monopolies.Add(s);

            s.type = "lightblue";
            s.num = 3;
            s.propertiesIncluded = new string[] { "Oriental Avenue", "Vermont Avenue", "Connecticut Avenue" };
            s.positions = new int[] { 6,8,9 };
            monopolies.Add(s);

            s.type = "lightpurple";
            s.num = 3;
            s.propertiesIncluded = new string[] { "St. Charles Place", "States Avenue", "Virginia Avenue" };
            s.positions = new int[] { 11,13,14 };
            monopolies.Add(s);

            s.type = "orange";
            s.num = 3;
            s.propertiesIncluded = new string[] { "St. James Place", "Tennessee Avenue", "New York Avenue" };
            s.positions = new int[] { 16,18,19 };
            monopolies.Add(s);

            s.type = "red";
            s.num = 3;
            s.propertiesIncluded = new string[] { "Kentucky Avenue", "Indiana Avenue", "Illinois Avenue" };
            s.positions = new int[] { 21,23,24 };
            monopolies.Add(s);

            s.type = "yellow";
            s.num = 3;
            s.propertiesIncluded = new string[] { "Atlantic Avenue", "Ventnor Avenue", "Marvin Gardens" };
            s.positions = new int[] { 26,27,29 };
            monopolies.Add(s);

            s.type = "green";
            s.num = 3;
            s.propertiesIncluded = new string[] { "Pacific Avenue", "North Carolina Avenue", "Pennsylvania Avenue" };
            s.positions = new int[] { 31,32,34 };
            monopolies.Add(s);

            s.type = "blue";
            s.num = 2;
            s.propertiesIncluded = new string[] { "Park Place", "Boardwalk" };
            s.positions = new int[] { 37,39 };
            monopolies.Add(s);

            s.type = "rail";
            s.num = 4;
            s.propertiesIncluded = new string[] { "Reading Railroad", "Pennsylvania Railroad", "B & O Railroad", "Short Line" };
            s.positions = new int[] { 5,15,25,35 };
            monopolies.Add(s);

            s.type = "util";
            s.num = 2;
            s.propertiesIncluded = new string[] { "Electric Company", "Water Works" };
            s.positions = new int[] { 12,28 };
            monopolies.Add(s);
        }

        private static void initRollProbabilities()
        {
            rollProbabilities.Add(2, 2.78365);
            rollProbabilities.Add(3, 5.56292);
            rollProbabilities.Add(4, 8.32862);
            rollProbabilities.Add(5, 11.1031);
            rollProbabilities.Add(6, 13.9074);
            rollProbabilities.Add(7, 16.6791);
            rollProbabilities.Add(8, 13.8875);
            rollProbabilities.Add(9, 11.0838);
            rollProbabilities.Add(10, 8.32481);
            rollProbabilities.Add(11, 5.56227);
            rollProbabilities.Add(12, 2.77688);
        }

        public static List<subDivision> Monopolies
        {
            get {return monopolies;}
        }
    }
}
