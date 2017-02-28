using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;     
/* \     /  |                                                  /  |          
$$  \   /$$ |  ______   _______    ______    ______    ______  $$ | __    __ 
$$$  \ /$$$ | /      \ /       \  /      \  /      \  /      \ $$ |/  |  /  |
$$$$  /$$$$ |/$$$$$$  |$$$$$$$  |/$$$$$$  |/$$$$$$  |/$$$$$$  |$$ |$$ |  $$ |
$$ $$ $$/$$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |$$ |  $$ |
$$ |$$$/ $$ |$$ \__$$ |$$ |  $$ |$$ \__$$ |$$ |__$$ |$$ \__$$ |$$ |$$ \__$$ |
$$ | $/  $$ |$$    $$/ $$ |  $$ |$$    $$/ $$    $$/ $$    $$/ $$ |$$    $$ |
$$/      $$/  $$$$$$/  $$/   $$/  $$$$$$/  $$$$$$$/   $$$$$$/  $$/  $$$$$$$ |
                                           $$ |                    /  \__$$ |
                                           $$ |                    $$    $$/ 
                                           $$/                      $$$$$*/
namespace Monopoly_Framework
{
    class LogicCore
    {
        List<Player> pl = new List<Player>();
        public Random r = new Random();

        public LogicCore()
        {
            int numGames = 1000;
            List<int> wins = new List<int>();
            for (int i = 0; i < numGames; i++)
            {
                pl = new List<Player>();
                Cale_Bot myBot = new Cale_Bot("Cale");
                pl.Add(myBot);
                jeffBotExp bot = new jeffBotExp("Jeff");
                pl.Add(bot);
                failBot bot2 = new failBot("stupid 3");
                pl.Add(bot2);
                bot2 = new failBot("stupid 4");
                pl.Add(bot2);
                Banker banker = new Banker(pl, 1, false,r,1);

                for (int j = 0; j < banker.getWins().Count; j++)
                {
                    if (j > wins.Count-1)
                    {
                        wins.Add(banker.getWins()[j]);
                    }
                    else
                    {
                        wins[j] += banker.getWins()[j];
                    }
                }
            }
            for (int i = 0; i < wins.Count; i++)
            {
                Console.WriteLine(pl[i].getName() + " won:" + wins[i]);
            }

        }
    }
}

/*
 * ENJOY THE CODE
 * F22 _ RAPTOR
                                /\
                               /  \
                              ;    ;
                             ;      :
                             :      :
                            :   ..   :
                           _:  /::\  :_
                         ,"   :"  ":   ".
                         |    |\__/|    |
                         |     \__/     |
                         |              |
                         |     .  .     |
                        /   |   ..   |   \
                      ./    :   ..   :    \.
                    ."      :   ..   :      ".
                  ."        :   ..   :        ".
                /"          ::\/..\/::          "\
              /"            :   ..   :            "\
            /~              ;   ..   :              "\
          /"              /.:   ..   :.\              "\
        /"               / |    ..    | \               "\
       |                x  |    ..    |  x                |
       |_               H  |    ..    |  H               _|
         "-._           H  |    ..    |  H           _.-"
             "--..__    "-.|^^^\../^^^|.-"    __..--"
                   _:-"""""|akn ||    |"""""-:_
                .-"       /|/\/\||/\/\|\       "-.
                |        /              \        |
                `-------"                `-------'
*/