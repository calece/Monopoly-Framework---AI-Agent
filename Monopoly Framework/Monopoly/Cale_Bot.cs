using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Framework
{
    class Cale_Bot : Player
    {
        private string name = "Cale";


        public Cale_Bot(string Name):base(Name)
        {
            name = Name;
        }

        public override bool PayBail(int turnsRemaining)
        {
            if (banker.balanceInquiry(this) > 2000 && turnsRemaining == 1)
            {
                return true;
            }
            return false;            
        }

        public override void MyTurn()
        {
          
            //Console.WriteLine("My Balance: ${0}", banker.balanceInquiry(this));
            //Console.WriteLine("My Properties:");
            foreach (Game_Tile_Safe prop in banker.getPropertiesOwned(this))
            {
                Game_Tile_Safe property = banker.getPropertyInfo(prop.index);
                if (banker.buyAssets(this, prop))
                {

                    //Console.WriteLine("Asset purchased on: {0}", property.name);
                }

                //Console.WriteLine("Name: {0}  Color: {1} NumAssets: {2}", property.name, property.color, property.assets);
            }
            //int[] otherPlayers = banker.getPlayerList(this);
            //foreach (int i in otherPlayers)
            //{
            //    Console.WriteLine("Player {0} Balance: {1}", i, banker.playerMoneyLookup(i));
            //    Console.WriteLine("Player {0} Properties:", i);
            //    foreach (Game_Tile_Safe prop in banker.getPlayerPropertyInfo(i))
            //    {
            //        Game_Tile_Safe property = banker.getPropertyInfo(prop.index);
            //        Console.WriteLine("Name: {0}  Color: {1} NumAssets: {2}", property.name, property.color, property.assets);
            //    }
            //}

            


            if (banker.canBuy(this) && banker.balanceInquiry(this) > 200)
            {
                banker.buyProperty(this);
            }




            //Console.ReadLine();
            //banker.tradeProperty(this, this.banker.getPropertyInfo(1));
        }

        public override void receiveOffer(List<int> players, List<int> moneyOffers, List<List<Game_Tile_Safe>> propertyOffers, out int playerNumber, out int offer)
        {
            offer = -1;
            playerNumber = -1;
        }


        public override int TradeMoney(Game_Tile_Safe t)
        {
            return 1;
        }

        public override List<Game_Tile_Safe> TradeProperty(Game_Tile_Safe t)
        {
            List<Game_Tile_Safe> propertOffers = new List<Game_Tile_Safe>();
            return propertOffers;
        }


    }
}
