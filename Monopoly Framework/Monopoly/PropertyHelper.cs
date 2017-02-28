using System.Collections.Generic;
using Static;
using System;

namespace Monopoly_Framework
{
    public static class PropertyHelper
    {
        private static Dictionary<int, int> assets = new Dictionary<int, int>();
        
        public struct Property
        {
            public int position;    //the position of the property 
            public int assets;      //the number of assets; 1-4 are houses, 5 is a hotel
            public bool mortgaged;
        }
        private static List<Property> myProperties = new List<Property>();

        public static void initialize()
        {
            myProperties = new List<Property>();
            assets = new Dictionary<int, int>();
        }

        public static void buyProperty(int position)
        {
            Property p = new Property();
            p.position = position;
            p.mortgaged = false;
            myProperties.Add(p);
        }
        
        public static bool buyAsset(int position, int num)
        {
            int index = searchProperties(position);
            if (index != -1)
            {
                if (assets.ContainsKey(index) && assets[index] < 5)
                {
                    assets[index]++;
                }
                else if (!assets.ContainsKey(index))
                {
                    assets.Add(index, 1);
                }
                else
                    return false;

                Property p = myProperties[index];
                p.assets += num;
                myProperties[index] = p;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// returns a list of properties that are BUY PRIORITY based on the following conditions
        /// 1:  property is a STANDARD type and player is only missing one position to complete a monopoly
        /// 2:  property is a RAILROAD and player owns 2 or 3 of the 4
        /// 3:  property is a UTILITY and player owns one utility
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static int[] needToBuy()
        {
            List<int> properties = new List<int>();
            List<int> buyMe = new List<int>();
            foreach(Property p in myProperties)
            {
                properties.Add(p.position);
            }
            int sum = 0;
            foreach (StaticData.subDivision s in StaticData.Monopolies)
            {
                string type = s.type;
                int num = s.num;
                List<int> notOwned = new List<int>();
                for (int i = 0; i < num; i++)
                {
                    if(properties.Contains(num))
                        sum++;
                    else
                        notOwned.Add(num);
                }
                switch(s.type)
                {
                    case("rail"):
                        if (sum > 1)
                            for (int i = 0; i < notOwned.Count; i++)
                                buyMe.Add(notOwned[i]);
                        break;
                    case("util"):
                        if (sum > 0)
                            for (int i = 0; i < notOwned.Count; i++)
                                buyMe.Add(notOwned[i]);
                        break;
                    default:
                        if (sum == s.num - 1)
                            for (int i = 0; i < notOwned.Count; i++)
                                buyMe.Add(notOwned[i]);
                        break;
                }
            }
            return buyMe.ToArray();
        }

        //returns a list of properties that can be developed
        public static int[] canDevelop()
        {
            List<int> properties = new List<int>();
            List<int> canDevelop = new List<int>();
            foreach (Property p in myProperties)
                properties.Add(p.position);

            foreach (StaticData.subDivision s in StaticData.Monopolies)
            {
                int sum = 0;
                string type = s.type;
                for (int i = 0; i < s.num; i++)
                    if (properties.Contains(s.positions[i]))
                        sum++;

                if (sum == s.num)
                    foreach (int p in s.positions)
                    {
                        canDevelop.Add(p);
                        //Console.Write(p + " ");
                    }

            }
            //Console.WriteLine();
            return canDevelop.ToArray();
        }

        //returns a list of properties that are individually owned
        public static int[] prefferedMortgage()
        {
            List<int> properties = new List<int>();
            List<int> singleOwned = new List<int>();
            foreach (Property p in myProperties)
                properties.Add(p.position);

            int sum = 0;
            foreach (StaticData.subDivision s in StaticData.Monopolies)
            {
                for (int i = 0; i < s.num; i++)
                    if (properties.Contains(i))
                        sum++;

                if (sum == 1)
                    foreach (int pos in s.positions)
                        if (properties.Contains(pos) && !(isMortgaged(pos)))
                            singleOwned.Add(pos);
            }
            return singleOwned.ToArray();
        }

        //returns a list of currently mortgaged properties
        public static int[] mortgagedProperties()
        {
            List<int> mortgaged = new List<int>();
            foreach (Property p in myProperties)
                if (p.mortgaged)
                    mortgaged.Add(p.position);
            return mortgaged.ToArray();
        }

        //sets a property to a mortgaged state
        public static void mortgage(int position)
        {
            int index = searchProperties(position);
            Property p = myProperties[index];
            p.mortgaged = true ;
            myProperties[index] = p;
        }

        //sets a ppreviously mortgaged property to un-mortgaged
        public static void unMortgage(int position)
        {
            int index = searchProperties(position);
            Property p = myProperties[index];
            p.mortgaged = false;
            myProperties[index] = p;
        }

        public static bool isMortgaged(int position)
        {
            int[] mortgaged = mortgagedProperties();
            for (int i = 0; i < mortgaged.Length; i++)
                if (mortgaged[i] == position)
                    return true;
            return false;
        }

        private static int searchProperties(int position)
        {
            for (int i = 0; i < myProperties.Count; i++)
            {
                if (myProperties[i].position == position)
                    return i;
            }
            return -1;
        }
    }
}
