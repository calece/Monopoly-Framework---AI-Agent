using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Framework
{
    abstract class Player
    {
        private string Name = "player";
        public int index;
        public Banker banker;
        public Player(string _name)
        {
            Name = _name;
            
        }
        virtual public void MyTurn()
        {

        }
        public string getName()
        {
            return Name;
        }
        public virtual bool PayBail(int turnsRemaining)
        {
            return false;
        }
        /// <summary>
        /// This method is called if another player would like to trade a property
        /// The property being traded will be passed as a game_tile_safe for informational purposes
        /// </summary>
        /// <param name="t"></param>
        /// <returns>return the ID of a tile owned by the tradee, return -1 if not interested</returns>
        public virtual List<Game_Tile_Safe> TradeProperty(Game_Tile_Safe t)
        {
            List<Game_Tile_Safe> propertOffers = new List<Game_Tile_Safe>();
            return propertOffers ;
        }
        /// <summary>
        /// This method is called if another player would like to trade a property
        /// The property being traded will be passed as a game_tile_safe for informational purposes
        /// </summary>
        /// <param name="t"></param>
        /// <returns>return a valid amount of money, return -1 if not interested</returns>
        public virtual int TradeMoney(Game_Tile_Safe t)
        {
            return -1;
        }
        /// <summary>
        /// This is the method that is called after a player has proposed a trade
        /// It contains the offers from the other players in the forms of list.
        /// </summary>
        /// <param name="players">The player numbers associated with the indexes of the following lists</param>
        /// <param name="moneyOffers">A list of money offers</param>
        /// <param name="propertyOffers">A list of property offers</param>
        /// <param name="playerNumber">this is the player from which you are choosing to accept the offer from</param>
        /// <param name="offer">set offer to 0 if you accept a players money offer, if you select his property offer, than set offer to 1</param>
        public virtual void receiveOffer(List<int> players, List<int> moneyOffers, List<List<Game_Tile_Safe>> propertyOffers, out int playerNumber, out int offer)
        {
            offer = -1;
            playerNumber = -1;
        }
    }
    class failBot : Player
    {
        public failBot(string _name):base(_name)
        {
        }
        override public void MyTurn()
        {
            if (banker.canBuy(this))
            {
                banker.buyProperty(this);
            }

            foreach (Game_Tile_Safe prop in banker.getPropertiesOwned(this))
            {
         
                banker.tradeProperty(this, prop);
            }
        }

        public override void receiveOffer(List<int> players, List<int> moneyOffers, List<List<Game_Tile_Safe>> propertyOffers, out int playerNumber, out int offer)
        {
            playerNumber = -1;
            offer = -1;
        }

        
    }
}
