using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Framework
{
    class Game_Tile_Safe
    {
        public readonly string name;
        public readonly int price;
        public readonly int[] rents;
        public readonly int assets;
        public readonly int assetPrice;
        public readonly bool mortgaged = false;
        public readonly bool utility = false;
        public readonly bool railroad = false;

        public readonly int index;
        public readonly string color;
        public readonly List<int> associatedProperties = new List<int>();
        public Game_Tile_Safe(Game_Tile t)
        {
            name = t.name;
            price = t.price;
            rents = t.rents;
            assets = t.assets;
            assetPrice = t.assetPrice;
            mortgaged = t.mortgaged;
            utility = t.utility;
            railroad = t.railroad;
            color = t.color;
            index = t.index;
            associatedProperties = t.associatedProperties;
        }
    }
    class Game_Tile
    {
        public Banker banker;
        public readonly string name;
        public readonly int price;
        public readonly int[] rents;
        public int assets=0;
        public readonly int assetPrice;
        public readonly int index;
        public bool canBuy;
        private Player owner = null;
        public bool mortgaged = false;
        public bool utility = false;
        public bool railroad = false;
        public string color;
        public List<int> associatedProperties = new List<int>();
        public Game_Tile(Banker _banker, int _index, string _color, string _name, int _price,int _assetPrice, int[] _rent, bool _canBuy)
        {
            assetPrice = _assetPrice;
            color = _color;
            banker = _banker;
            name = _name;
            price = _price;
            rents = _rent;
            canBuy = _canBuy;
            index = _index;
        }
        public Game_Tile(Banker _banker, int _index, string _color, string _name, int _price,int _assetPrice, int[] _rent, bool _canBuy, bool _utility, bool _railroad)
        {
            assetPrice = _assetPrice;
            color = _color;
            banker = _banker;
            name = _name;
            price = _price;
            rents = _rent;
            canBuy = _canBuy;
            utility = _utility;
            railroad = _railroad;
            index = _index;
        }
        public Game_Tile(Banker _banker, int _index, string _color, string _name, int _price,int _assetPrice, int[] _rent, bool _canBuy, List<int> _associatedProperties)
        {
            assetPrice = _assetPrice;
            color = _color;
            index = _index;
            banker = _banker;
            name = _name;
            price = _price;
            rents = _rent;
            canBuy = _canBuy;
            for (int i = 0; i < _associatedProperties.Count; i++)
            {
                associatedProperties.Add(_associatedProperties[i]);
            }
        }
    }
}
