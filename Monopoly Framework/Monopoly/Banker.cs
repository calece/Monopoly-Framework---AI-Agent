using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_Framework
{
    class Banker
    {

        List<Game_Tile> board = new List<Game_Tile>();
        List<Player> tileOwners = new List<Player>();
        List<Player> players = new List<Player>();
        List<int> playersJail = new List<int>();
        public bool displayWins = true;
        List<Game_Tile> playersCurrentTile = new List<Game_Tile>();
        List<int> playersMoney = new List<int>();
        List<bool> deadPlayers = new List<bool>();
        List<int> playerWins = new List<int>();
        Random r;
        int numHouses = 32;
        int numHotels = 12;
        int numPlayers = 0;
        int turns = -1;
        bool gameOver = false;
        int timeOut = 1;
        int numGames;
        public Banker(List<Player> _players,int _numGames, bool _displayWins,Random _r,int _timeOut)
        {
            timeOut = _timeOut;
            r = _r;
            numGames = _numGames;

            players = _players;
                
            displayWins = _displayWins;
            for (int i = 0; i < players.Count; i++)
            {
                players[i].index = i;
                players[i].banker = this;
                playerWins.Add(0);
            }
            initGame();
        }
        public List<int> getWins()
        {
            return new List<int>(playerWins);
        }
        private void initGame()
        {

            turns = -1;
            gameOver = false;



            board = new List<Game_Tile>();
            tileOwners = new List<Player>();
            playersJail = new List<int>();
            playersCurrentTile = new List<Game_Tile>();
            playersMoney = new List<int>();
            deadPlayers = new List<bool>();
            

            numPlayers = 0;
            populateBoard();
            for (int i = 0; i < players.Count; i++)
            {
                playersMoney.Add(1500);
                playersJail.Add(0);
                deadPlayers.Add(false);
                playersCurrentTile.Add(board[0]);
                numPlayers++;
            }
            for (int i = 0; i < board.Count; i++)
            {
                tileOwners.Add(null);
            }
            nextTurn();
        
        }
        private void populateBoard()
        {
            Game_Tile tile = new Game_Tile(this, board.Count, "none", "Start", 0, 0, new int[] { 0 }, false);
            board.Add(tile);
            List<int> associatedProperties = new List<int>();
            associatedProperties.Add(3);
            tile = new Game_Tile(this, board.Count, "purple", "Mediterranean Avenue", 60, 50, new int[] { 2, 10, 30, 90, 160, 250 }, true,associatedProperties);
            board.Add(tile);

            tile = new Game_Tile(this, board.Count, "none", "Community Chest", 0, 0, new int[] { 0 }, false);
            board.Add(tile);
            associatedProperties.Clear();
            associatedProperties.Add(1);

            tile = new Game_Tile(this, board.Count, "purple", "Baltic Avenue", 60, 50, new int[] { 4, 20, 60, 180, 320, 450 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Income Tax", 0, 0, new int[] { 0 }, false);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "rail", "Reading Railroad", 200, 0, new int[] { 25, 50, 100, 200 }, true, false, true);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(8);
            associatedProperties.Add(9);
            tile = new Game_Tile(this, board.Count, "light blue", "Oriental Avenue", 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Chance", 0, 0, new int[] { 0 }, false);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(6);
            associatedProperties.Add(9);
            tile = new Game_Tile(this, board.Count, "light blue", "Vermont Avenue", 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }, true, associatedProperties);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(6);
            associatedProperties.Add(8);
            tile = new Game_Tile(this, board.Count, "light blue", "Connecticut Avenue", 120, 60, new int[] { 8, 40, 100, 300, 450, 600 }, true, associatedProperties);
            board.Add(tile);


            tile = new Game_Tile(this, board.Count, "none", "Jail", 0, 0, new int[] { 0 }, false);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(13);
            associatedProperties.Add(14);
            tile = new Game_Tile(this, board.Count, "pink", "St. Charles Place", 140, 100, new int[] { 10, 50, 150, 450, 625, 750 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Electric Company", 150, 0, new int[] { 0 }, true, true, false);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(11);
            associatedProperties.Add(14);
            tile = new Game_Tile(this, board.Count, "pink", "States Avenue", 140, 100, new int[] { 10, 50, 150, 450, 625, 750 }, true, associatedProperties);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(11);
            associatedProperties.Add(13);
            tile = new Game_Tile(this, board.Count, "pink", "Virginia Avenue", 160, 100, new int[] { 12, 60, 180, 500, 700, 900 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "rail", "Pennsylvania Railroad", 200, 0, new int[] { 25, 50, 100, 200 }, true, false, true);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(19);
            associatedProperties.Add(18);
            tile = new Game_Tile(this, board.Count, "orange", "St. James Place", 180, 100, new int[] { 14, 70, 200, 550, 750, 950 }, true, associatedProperties);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(16);
            associatedProperties.Add(19);
            tile = new Game_Tile(this, board.Count, "orange", "Tennessee Avenue", 180, 100, new int[] { 14, 70, 200, 550, 750, 950 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Community Chest", 0, 0, new int[] { 0 }, false);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(18);
            associatedProperties.Add(16);
            tile = new Game_Tile(this, board.Count, "orange", "New York Avenue", 200, 100, new int[] { 16, 80, 220, 600, 800, 1000 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Free Parking", 0, 0, new int[] { 0 }, false);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(23);
            associatedProperties.Add(24);
            tile = new Game_Tile(this, board.Count, "red", "Kentucky Avenue", 220, 150, new int[] { 18, 90, 250, 700, 875, 1050 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Chance", 0, 0, new int[] { 0 }, false);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(21);
            associatedProperties.Add(24);
            tile = new Game_Tile(this, board.Count, "red", "Indiana Avenue", 220, 150, new int[] { 18, 90, 250, 700, 875, 1050 }, true, associatedProperties);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(23);
            associatedProperties.Add(21);
            tile = new Game_Tile(this, board.Count, "red", "Illinois Avenue", 240, 150, new int[] { 20, 100, 300, 750, 925, 1100 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "rail", "B & O Railroad", 200, 0, new int[] { 25, 50, 100, 200 }, true, false, true);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(27);
            associatedProperties.Add(29);
            tile = new Game_Tile(this, board.Count, "yellow", "Atlantic Avenue", 260, 150, new int[] { 22, 110, 330, 800, 975, 1150 }, true, associatedProperties);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(26);
            associatedProperties.Add(29);
            tile = new Game_Tile(this, board.Count, "yellow", "Ventnor Avenue", 260, 150, new int[] { 22, 110, 330, 800, 975, 1150 }, true, associatedProperties);
            board.Add(tile);

            tile = new Game_Tile(this, board.Count, "none", "Water Works", 150, 0, new int[] { 0 }, true, true, false);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(27);
            associatedProperties.Add(26);
            tile = new Game_Tile(this, board.Count, "yellow", "Marvin Gardens", 280, 150, new int[] { 24, 120, 360, 850, 1025, 1200 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Goto Jail", 0, 0, new int[] { 0 }, false);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(32);
            associatedProperties.Add(34);
            tile = new Game_Tile(this, board.Count, "green", "Pacific Avenue", 300, 200, new int[] { 26, 130, 390, 900, 1100, 1275 }, true, associatedProperties);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(31);
            associatedProperties.Add(34);
            tile = new Game_Tile(this, board.Count, "green", "North Carolina Avenue", 300, 200, new int[] { 26, 130, 390, 900, 1100, 1275 }, true, associatedProperties);
            board.Add(tile);

            tile = new Game_Tile(this, board.Count, "none", "Community Chest", 0, 0, new int[] { 0 }, false);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(32);
            associatedProperties.Add(31);
            tile = new Game_Tile(this, board.Count, "green", "Pennsylvania Avenue", 320, 200, new int[] { 28, 150, 450, 1000, 1200, 1400 }, true, associatedProperties);
            board.Add(tile);

            tile = new Game_Tile(this, board.Count, "rail", "Short Line Railroad", 200, 0, new int[] { 25, 50, 100, 200 }, true, false, true);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Chance", 0, 0, new int[] { 0 }, false);
            board.Add(tile);


            associatedProperties.Clear();
            associatedProperties.Add(39);
            tile = new Game_Tile(this, board.Count, "blue", "Park Place", 350, 200, new int[] { 35, 175, 500, 1100, 1300, 1500 }, true, associatedProperties);
            board.Add(tile);
            tile = new Game_Tile(this, board.Count, "none", "Free Parking", 0, 0, new int[] { 0 }, false);
            board.Add(tile);

            associatedProperties.Clear();
            associatedProperties.Add(37);
            tile = new Game_Tile(this, board.Count, "blue", "Boardwalk", 400, 200, new int[] { 50, 200, 600, 1400, 1700, 2000 }, true, associatedProperties);
            board.Add(tile);

        }
        /// <summary>
        /// Lets  players check how much money they have
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Cash on hand</returns>
        public int balanceInquiry(Player p)
        {
            return playersMoney[p.index];
        }
        /// <summary>
        /// Lets players check how many houses/hotels are on their current tile
        /// </summary>
        /// <param name="p"></param>
        /// <returns>5 = 4 houses + hotel, >4 = houses</returns>
        public int checkCurrentTilesAssets(Player p)
        {
            return playersCurrentTile[p.index].assets;
        }
        /// <summary>
        /// Returns the current tile a player is on.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Returns a readonly game tile for informational purposes</returns>
        public Game_Tile_Safe getCurrentTile(Player p)
        {
            return new Game_Tile_Safe(playersCurrentTile[p.index]);
        }
        /// <summary>
        /// Lets players attempt to buy a property
        /// </summary>
        /// <param name="p"></param>
        /// <returns>true if purchase is successful, false otherwise</returns>
        public bool buyProperty(Player p)
        {
            Game_Tile t = playersCurrentTile[p.index];
            if (tileOwners[t.index] == null && playersMoney[p.index] >= t.price && t.canBuy)
            {
                payPlayer(p, -t.price);
                tileOwners[t.index] = p;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Allows players check to see if they can buy a property
        /// </summary>
        /// <param name="p">Player Callee</param>
        /// <returns></returns>
        public bool canBuy(Player p)
        {
            Game_Tile t = playersCurrentTile[p.index];
            if (tileOwners[t.index] == null && playersMoney[p.index] >= t.price && t.canBuy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Allows players to checkup on what properties they own
        /// </summary>
        /// <param name="p"></param>
        /// <returns>A list of read only safe properties</returns>
        public List<Game_Tile_Safe> getPropertiesOwned(Player p)
        {
            List<Game_Tile_Safe> list = new List<Game_Tile_Safe>();
            for (int i = 0; i < tileOwners.Count; i++)
            {
                if (tileOwners[i] == p)
                {
                    list.Add(new Game_Tile_Safe(board[i]));
                }
            }
            return list;
        }
        /// <summary>
        /// Allows players to trade a property they own.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="t">Property to trade</param>
        public void tradeProperty(Player p, Game_Tile_Safe t)
        {
            if (p == tileOwners[t.index])
            {
                List<int> playerTraders = new List<int>();
                List<int> moneyOffers = new List<int>();
                List<List<Game_Tile_Safe>> propertyOffers = new List<List<Game_Tile_Safe>>();
                if (tileOwners[t.index] == p)
                {
                    for (int i = 0; i < players.Count; i++)
                    {
                        if (players[i] != p && deadPlayers[i] != true)
                        {
                            playerTraders.Add(i);
                            propertyOffers.Add(players[i].TradeProperty(t));
                            moneyOffers.Add(players[i].TradeMoney(t));
                        }
                    }
                }
                else
                {
                    return;
                }
                //GOTTA CHECK THOSE OFFERS TO MAKE SURE THEY ARE VALID 
                for (int i = 0; i < playerTraders.Count; i++)
                {
                    //check moneys
                    if (playersMoney[playerTraders[i]] < moneyOffers[i])
                    {
                        moneyOffers[i] = -1;
                    }
                    //check properties
                    for (int j = 0; j < propertyOffers[i].Count; j++)
                    {
                        if (tileOwners[propertyOffers[i][j].index] != players[playerTraders[i]])
                        {
                            propertyOffers[i].RemoveAt(j);
                        }
                    }
                }
                int playerNumber=-1;
                int moneyORproperty = -1;
                p.receiveOffer(new List<int>(playerTraders), new List<int>(moneyOffers), new List<List<Game_Tile_Safe>>(propertyOffers), out playerNumber, out moneyORproperty);
                if (playerNumber != -1 && moneyORproperty != -1)
                {
                    if (moneyORproperty == 0) //If the player accepted the money
                    {
                        if (playersMoney[playerNumber] >= moneyOffers[playerNumber])
                        {
                            payPlayer(p, moneyOffers[playerNumber]);
                            payPlayer(players[playerNumber], -moneyOffers[playerNumber]);
                            tileOwners[t.index] = players[playerNumber];
                        }
                    }
                    if (moneyORproperty == 1) //If the player accepted the property
                    {
                        tileOwners[t.index] = players[playerNumber];
                        for (int i = 0; i < propertyOffers[playerNumber].Count; i++)
                        {
                            tileOwners[propertyOffers[playerNumber][i].index] = p;
                        }
                    }
                }

            }
        }
        /// <summary>
        /// Allows players to request a readonly version of a tile for information purposes
        /// </summary>
        /// <param name="ID">Tile Number on board, EX: Start = 0, Boardwalk = 39</param>
        /// <returns></returns>
        public Game_Tile_Safe getPropertyInfo(int ID)
        {
            try
            {
                return new Game_Tile_Safe(board[ID]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        /// <summary>
        /// Lets players attempt to add houses/hotels onto their properties
        /// </summary>
        /// <param name="p">Player Callee</param>t
        /// <param name="tile">Tile that the player wishes to upgrade</param>
        /// <returns></returns>
        public bool buyAssets(Player p, Game_Tile_Safe tile)
        {
            Game_Tile_Safe t = new Game_Tile_Safe(board[tile.index]);

            if (t.associatedProperties.Count != 0)
            {
                for (int i = 0; i < t.associatedProperties.Count; i++)
                {
                    if (tileOwners[t.associatedProperties[i]] != p)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            
            if (tileOwners[t.index] == p && playersMoney[p.index] >= t.assetPrice && t.assets < 5)
            {
                //check to make sure other properties dont differ by more than 1 
                for (int i = 0; i < board[t.index].associatedProperties.Count; i++)
                {
                    if (Math.Abs(board[t.index].assets - board[board[t.index].associatedProperties[i]].assets) > 1)
                    {
                        return false;
                    }
                }
                
                if (t.assets == 4)
                {
                    if (numHotels == 0)
                    {
                        return false;
                    }
                    numHouses += 4;
                    numHotels -= 1;
                }
                else
                {
                    if (numHouses == 0)
                    {
                        return false;
                    }
                    numHouses--;
                }
                payPlayer(p, -t.assetPrice);
                if (t.assets < 5)
                {
                 board[t.index].assets++;
                 return true;
                }
                
            }
                return false;
            
        }
        /// <summary>
        /// Gives players a int array of other active player numbers
        /// </summary>
        /// <param name="callee">Player Callee</param>
        /// <returns>Other active players represented by int array</returns>
        public int[] getPlayerList(Player callee)
        {
            int[] otherplayers = new int[numPlayers - 1];
            if (deadPlayers[callee.index] == true)
            {
                return otherplayers;
            }
            int x = 0;
            for (int i = 0; i < deadPlayers.Count; i++)
            {
                if (i != callee.index && deadPlayers[i] != true)
                {
                    otherplayers[x] = i;
                    x++;
                }
            }
            return otherplayers;
        }
        /// <summary>
        /// Allows players to lookup what other players own on the board
        /// </summary>
        /// <param name="playerNumber">Player number to lookup</param>
        /// <returns>String of property names owned by player</returns>
        public List<Game_Tile_Safe> getPlayerPropertyInfo(int playerNumber)
        {
            List<Game_Tile_Safe> propertiesOwned = new List<Game_Tile_Safe>();
            for (int i = 0; i < tileOwners.Count; i++)
            {
                if (tileOwners[i] != null && tileOwners[i].index == playerNumber)
                {
                    propertiesOwned.Add(new Game_Tile_Safe(board[i]));
                }
            }
            return propertiesOwned;
        }
        /// <summary>
        /// Lets players check how much money another player has
        /// </summary>
        /// <param name="playerNumber">Player number to lookup</param>
        /// <returns>Cash on hand</returns>
        public int playerMoneyLookup(int playerNumber)
        {
            return playersMoney[playerNumber];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="propertyNumber"></param>
        /// <returns></returns>
        public bool mortgageProperty(Player player,int propertyNumber)
        {
            if (propertyNumber > 0 && propertyNumber <= board.Count)
            {
                if (player == tileOwners[propertyNumber] && board[propertyNumber].mortgaged==false)
                {
                    for (int i = 0; i < board[propertyNumber].assets; i++)
                    {
                        sellAssets(player, propertyNumber);
                    }
                    payPlayer(player, board[propertyNumber].price / 2);
                    board[propertyNumber].mortgaged = true;
                    return true;
                }
            }
            return false;
        }

        public bool unmortageProperty(Player player, int propertyNumber)
        {
            if (board[propertyNumber].mortgaged && playersMoney[player.index]>board[propertyNumber].price*.1+board[propertyNumber].price/2)
            {
                int price = (board[propertyNumber].price / 10 + board[propertyNumber].price/2);
                payPlayer(player, -price);
                board[propertyNumber].mortgaged = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool sellAssets(Player player, int propertyNumber)
        {
            if (propertyNumber > 0 && propertyNumber <= board.Count && board[propertyNumber].assets>0 && player == tileOwners[propertyNumber])
            {
                if (board[propertyNumber].assets > 0)
                {
                    if (board[propertyNumber].assets == 5)
                    {
                        if (numHouses >= 4)
                        {
                            numHotels++;
                            numHouses -= 4;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        numHouses++;
                    }
                    
                    payPlayer(player, board[propertyNumber].assetPrice / 2);
                    board[propertyNumber].assets--;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ////BANKER LOGIC
        /// </summary>
        private void nextTurn()
        {
            if (numPlayers <= 0)
            {
                GameOver();
            }
            turns++;
            if (deadPlayers[turns % deadPlayers.Count] == true)
            {
                if (!gameOver)
                {
                    nextTurn();
                }
            }
            else
            {
                if (turns != 0)
                {
                    movePlayer(players[turns % players.Count]);
                }
                else
                {
                    movePlayer(players[turns]);
                }
            }
            if (!gameOver)
            {
                nextTurn();
            }
        }
        private void movePlayer(Player p)
        {
            int die1 = r.Next(6)+1;
           
            int die2 = r.Next(6)+1;
            
            bool doubles = false;
            bool jailed = false;
            if (die1 == die2)
            {
                doubles = true;
            }
            int die = die1+die2;
            if (playersJail[p.index]>0)
            {
                jailed = true;
                bool bail = p.PayBail(playersJail[p.index]);
                if (bail)
                {
                    payPlayer(p, -50);
                    jailed = false;
                }
                else
                {
                    playersJail[p.index]--;
                }
                if (doubles && jailed)
                {
                    doubles = false;
                    jailed = false;
                }
            }
            if (!jailed)
            {
                playersCurrentTile[p.index] = board[(playersCurrentTile[p.index].index+die) % board.Count];
                bool skip = false;
                int multiplier = 1;
                if (die + p.index > board.Count)
                {
                    payPlayer(p, 200);
                }
                switch (playersCurrentTile[p.index].name)
                {
                    case "Jail":

                        break;
                    case "Start":

                        break;
                    case "Goto Jail":
                        playersCurrentTile[p.index] = board[10];
                        playersJail[p.index] = 3;
                        break;
                    case "Free Parking":

                        break;
                    case "Income Tax":
                        payPlayer(p, -200);
                        //the new regular Monopoly US version games only have the $200 Income Tax, excluding the 10% option
                        break;
                    case "Chance":
                        int chance = r.Next(16);
                        switch (chance)
                        {
                            case 0:
                                //Advance to Go (Collect $200) 
                                playersCurrentTile[p.index] = board[0];
                                payPlayer(p, 200);
                                break;
                            case 1:
                                //Advance to Illinois Ave. - If you pass Go, collect $200
                                if (playersCurrentTile[p.index].index > 24)
                                {
                                    payPlayer(p, 200);
                                }
                                playersCurrentTile[p.index] = board[24];
                                break;
                            case 2:
                                //Advance to St. Charles Place – If you pass Go, collect $200
                                if (playersCurrentTile[p.index].index > 11)
                                {
                                    payPlayer(p, 200);
                                }
                                playersCurrentTile[p.index] = board[11];
                                break;
                            case 3:
                                //Advance token to nearest Utility. If unowned, you may buy it from the Bank. If owned, throw dice and pay owner a total ten times the amount thrown.
                                switch (playersCurrentTile[p.index].index)
                                {
                                    case 7:
                                    case 36:
                                        playersCurrentTile[p.index] = board[12];
                                        if (tileOwners[12] != null && tileOwners[12] != p)
                                        {
                                            payPlayer(p, -die * 10);
                                            payPlayer(tileOwners[12], die * 10);
                                        }
                                        break;
                                    case 22:
                                        playersCurrentTile[p.index] = board[28];
                                        if (tileOwners[12] != null && tileOwners[28] != p)
                                        {
                                            payPlayer(p, -die * 10);
                                            payPlayer(tileOwners[28], die * 10);
                                        }
                                        break;
                                }
                                skip = true;
                                break;
                            case 4:
                                //Advance token to the nearest Railroad and pay owner twice the rental to which he/she {he} is otherwise entitled. If Railroad is unowned, you may buy it from the Bank.
                                switch (playersCurrentTile[p.index].index)
                                {
                                    case 7:
                                        playersCurrentTile[p.index] = board[5];
                                        if (tileOwners[5] != null && tileOwners[5] != p)
                                        {
                                            multiplier = 2;
                                        }
                                        break;
                                    case 22:
                                        playersCurrentTile[p.index] = board[25];
                                        if (tileOwners[25] != null && tileOwners[25] != p)
                                        {
                                            multiplier = 2;
                                        }
                                        break;
                                    case 36:
                                        playersCurrentTile[p.index] = board[35];
                                        if (tileOwners[35] != null && tileOwners[35] != p)
                                        {
                                            multiplier = 2;
                                        }
                                        break;
                                }
                                break;
                            case 5:
                                //GET OUT OF JAIL FREE 
                                //WILL NOT BE IMPLEMENTED, NOTHING HAPPENS
                                break;
                            case 6:
                                //Go Back 3 Spaces
                                playersCurrentTile[p.index] = board[playersCurrentTile[p.index].index - 3];
                                break;
                            case 7:
                                //Go to Jail
                                playersCurrentTile[p.index] = board[10];
                                playersJail[p.index] = 3;
                                break;
                            case 8:
                                //Make general repairs on all your property
                                //– For each house pay $25 – For each hotel $100
                                for (int i = 0; i < tileOwners.Count; i++)
                                {
                                    if (tileOwners[i] == p)
                                    {
                                        if (board[i].assets < 5)
                                        {
                                            payPlayer(p, -board[i].assets * 25);
                                        }
                                        else
                                        {
                                            payPlayer(p, -200);
                                        }

                                    }
                                }
                                break;
                            case 9:
                                //Take a trip to Reading Railroad {Take a ride on the Reading} – If you pass Go, collect $200 
                                if (playersCurrentTile[p.index].index > 5)
                                {
                                    payPlayer(p, 200);
                                }
                                playersCurrentTile[p.index] = board[5];
                                break;
                            case 10:
                                //Take a walk on the Boardwalk – Advance token to Boardwalk
                                playersCurrentTile[p.index] = board[39];
                                break;
                        }
                        break;
                }
                if (tileOwners[playersCurrentTile[p.index].index] != null && tileOwners[playersCurrentTile[p.index].index] != p && playersCurrentTile[p.index].canBuy)
                {
                    if (playersCurrentTile[p.index].railroad)
                    {
                        Player rrOwner = tileOwners[playersCurrentTile[p.index].index];
                        int railsOwned = -1;
                        int pay = 25;
                        railsOwned += (tileOwners[5] == rrOwner) ? 1 : 0;
                        railsOwned += (tileOwners[15] == rrOwner) ? 1 : 0;
                        railsOwned += (tileOwners[25] == rrOwner) ? 1 : 0;
                        railsOwned += (tileOwners[35] == rrOwner) ? 1 : 0;
                        for (int i = 0; i < railsOwned; i++)
                        {
                            pay *= 2;
                        }
                        payPlayer(p, -pay);
                        payPlayer(rrOwner, pay);
                    }
                    else if (playersCurrentTile[p.index].utility)
                    {
                        Player utOwner = tileOwners[playersCurrentTile[p.index].index];
                        int utOwned = 0;
                        int pay = 0;
                        utOwned += (tileOwners[12] == utOwner) ? 1 : 0;
                        utOwned += (tileOwners[28] == utOwner) ? 1 : 0;
                        switch (utOwned)
                        {
                            case 1:
                                pay = 4 * die;
                                break;
                            case 2:
                                pay = 10 * die;
                                break;
                        }
                        payPlayer(p, -pay);
                        payPlayer(utOwner, pay);
                    }
                    else
                    {
                        payPlayer(p, -playersCurrentTile[p.index].rents[playersCurrentTile[p.index].assets]);
                        payPlayer(tileOwners[die % tileOwners.Count], playersCurrentTile[p.index].rents[playersCurrentTile[p.index].assets]);
                    }
                }
            }

                p.MyTurn();
         
            if (doubles)
            {
                movePlayer(p);
            }
        }

        private void payPlayer(Player p, int payment)
        {
            for (int i = 0; i < players.Count; i++)
            {
                {
                    if (players[i] == p)
                    {
                        playersMoney[i] += payment;
                        checkFunds(i);
                    }
                }
            }
        }

        private void checkFunds(int index)
        {
            if (playersMoney[index] < 0)
            {
                for (int i = 0; i < board.Count; i++)
                {
                    if (board[i].mortgaged == false && players[index]==tileOwners[i])
                    {
                        playersMoney[index] += board[i].price / 2;
                        board[i].mortgaged = true;
                        if (playersMoney[index] >= 0)
                        {
                            return;
                        }
                    }
                }
                killPlayer(index);
            }
        }
        private void killPlayer(int index)
        {
            if (!deadPlayers[index])
            {
                deadPlayers[index] = true;
                numPlayers--;
                for (int i = 0; i < tileOwners.Count; i++)
                {
                    if (players[index] == tileOwners[i])
                    {
                        tileOwners[i] = null;
                    }
                }
                    if (numPlayers == 1)
                    {
                        GameOver();
                    }
            }
        }
        private void GameOver()
        {
            gameOver = true;
            for (int i = 0; i < deadPlayers.Count; i++)
            {

                if (deadPlayers[i] == false)
                {
                    if (displayWins)
                    {
                        Console.WriteLine(players[i].getName() + " won!\nMoney:" + playersMoney[i] + "\nProperties:");
                        for (int j = 0; j < tileOwners.Count; j++)
                        {
                            if (players[i] == tileOwners[j])
                            {
                                Console.WriteLine("-" + board[j].name);
                            }
                        }
                        Console.WriteLine("\n");
                    }
                    playerWins[i]++;
                }
                else
                {
                    if (displayWins)
                    {
                        Console.WriteLine(players[i].getName() + " lost!\nMoney:" + playersMoney[i] + "\nProperties:");
                        for (int j = 0; j < tileOwners.Count; j++)
                        {
                            if (players[i] == tileOwners[j])
                            {
                                Console.WriteLine("-" + board[j].name);
                            }
                        }
                        Console.WriteLine("\n");
                    }
                }
            }

            numGames--;
            if (numGames > 0)
            {
                initGame();
            }
        }
    }
}
