using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameClient
{
    class serverResponce
    {
        private Contestant contestant = new Contestant();
        public String joinserver()
        {
            return "JOIN#";
        }
        public int serverJoinReply(String reply)
        {
            switch (reply)
            {
                case "PLAYERS_FULL#": Console.WriteLine("Players full"); return 1;
                case "ALREADY_ADDED#": Console.WriteLine("Already added"); return 2;
                case "GAME_ALREADY_STARTED#": Console.WriteLine("Game already started"); return 3;
                default: return 0;
            }

        }

        public void acceptance(String acceptanceText)
        {
            
            Console.WriteLine(acceptanceText);
            if (acceptanceText != "")
            {
                acceptanceText = acceptanceText.Remove(acceptanceText.Length - 1);
                char[] charArray = { ':' , ';' , ',' };
                String[] tokens = acceptanceText.Split(charArray);
                contestant.playerName = tokens[1];
                contestant.playerLocationX = int.Parse(tokens[2]);
                contestant.playerLocationY = int.Parse(tokens[3]);
                contestant.Direction = int.Parse(tokens[4]);
                Console.WriteLine(contestant.ToString());
            }
            else
            {
                Console.WriteLine("Error in message received..");
                
            }
            Thread.Sleep(5000);
            
        }
        /*
        public int initiation(String initialtionText)
        {
            if (initialtionText.EndsWith("#"))
            {
                initialtionText = initialtionText.Remove(initialtionText.Length - 1);
                char[] charArray = { ':' };
                String[] tokens = initialtionText.Split(charArray);

                if (tokens[1].Substring(1, 1).Equals(Contestant.playerNumber.ToString()))
                {
                    char[] resCharArray = { ';' };
                    String[] brickWalls = tokens[2].Split(resCharArray);
                }
                else
                {
                    Console.WriteLine("There is an error with the initiation String player mismatch");
                }
            }
            else
            {
                Console.WriteLine("There is an error with the initiation String");
                return 0;
            }
            return 1;
        }*/
    }
}
