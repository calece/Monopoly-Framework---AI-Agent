using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Static;

namespace Monopoly_Framework
{
    class jeffBotExp : Player
    {
        const int ASSET_RESERVE = 1500;   //An arbitrary minimum money reserve to prevent bankruptcy
                                        //this will want to become a dynamic value, probably controlled
                                        //by projected income and loss
        const int BUY_RESERVE = 0;      //use this to determine if a property should be mortgaged to prevent bankruptcy
        const int MORTGAGE_RESERVE = 200; //try to mortgage a property if below this value
        const int STAY_IN_JAIL = 400;     //stay in jail until the player game has gone through this many rounds
        const int TRADE_RESERVE = 0;    
        int turnCount = 0;
        int assetCount = 0;

        public struct opponent
        {
            public List<Game_Tile_Safe> tilesOwned;
            public int funds;
        }

        public jeffBotExp(string _name)
            : base(_name)
        {
            StaticData.initialize();
            PropertyHelper.initialize();
            //Console.WriteLine("---------------------");
        }

        private bool bail = false;
        public override bool PayBail(int turnsRemaining)
        {
            if (bail)
            {
                bail = false;
                return true;
            }
            return false;
        }

        public override int TradeMoney(Game_Tile_Safe t)
        {
            return 1;
        }


        override public void MyTurn()
        {

            
            turnCount++;
            int[] playerList = banker.getPlayerList(this);
            int myMoney = banker.balanceInquiry(this);
            //if (banker.inJail(this) && turnCount > STAY_IN_JAIL)
            //{
            //    bail = true;
            //}
            
            List<opponent> opponents = new List<opponent>();
            foreach (int p in playerList)
            {
                opponent t = new opponent();
                t.tilesOwned = banker.getPlayerPropertyInfo(p);
                t.funds = banker.playerMoneyLookup(p);
                
                opponents.Add(t);
            }
            
            List<Game_Tile_Safe> myProperties = banker.getPropertiesOwned(this);
            int assetsAtThisTile = banker.checkCurrentTilesAssets(this);
            int position = banker.getCurrentTile(this).index;
            int assetPrices = banker.getCurrentTile(this).assetPrice;

            //try to mortgage first if money is below the reserve threshold

            if (myMoney < MORTGAGE_RESERVE)
            {
                int[] preferredMortgage = PropertyHelper.prefferedMortgage();
                if (preferredMortgage.Length > 0)
                {
                    banker.mortgageProperty(this, preferredMortgage[0]);
                    PropertyHelper.mortgage(preferredMortgage[0]);
                    myMoney = banker.balanceInquiry(this);
                    //Console.WriteLine(myMoney);
                }
            }
            else //unmortgage a property if we're above the threshold
            {
                int[] mortgagedProperties = PropertyHelper.mortgagedProperties();
                for (int i = 0; i < mortgagedProperties.Length; i++)
                {
                    int index = mortgagedProperties[i];
                    int UMPrice = banker.getPropertyInfo(index).price + (int)((double)banker.getPropertyInfo(index).price * 0.1);
                    if (myMoney + MORTGAGE_RESERVE > UMPrice)
                    {
                        banker.unmortageProperty(this, index);
                        PropertyHelper.unMortgage(index);
                        myMoney = banker.balanceInquiry(this);
                    }
                }
            }

            //then try to buy

            if (banker.canBuy(this) && myMoney > BUY_RESERVE)
            {
                banker.buyProperty(this);
                PropertyHelper.buyProperty(position);
                myMoney = banker.balanceInquiry(this);
            }

            //then attempt to develop if we have monopoly(s)

            int[] canDevelop = PropertyHelper.canDevelop();
            foreach (int p in canDevelop)
            {
                int pos = p;
                int price = banker.getPropertyInfo(p).assetPrice;
                if ((myMoney + ASSET_RESERVE) > price)
                {
                    if (PropertyHelper.buyAsset(pos, 1)) { }
                   
                    else
                        continue;

                    if (banker.buyAssets(this, banker.getPropertyInfo(pos)))
                    {  /*Console.WriteLine(banker.getPropertyInfo(pos).name);*/}
                }
            }     
        }

        struct predictNode
        {
            int position;
            int rollValue;
            bool buyProperty;
            //
        }
        

        private void genProbabilities(Player me, Player op1, Player op2, Player op3, Banker banker)
        {
            List<Game_Tile_Safe> predictBoard = new List<Game_Tile_Safe>();
            Queue<predictNode> nodeTree = new Queue<predictNode>();

        }
    }
}
