using System;


namespace RollADice_14873
{
    class Program
    {
        
        static int RollDice()
        {
            Random randomDiceVal = new Random();
            Console.Beep();            
            return randomDiceVal.Next(1, 7);

        }

        static void Main(string[] args)
        {
            //The winning mark = 100
            int Winning_mark = 100;

            //Welcome Message
            Console.WriteLine("---------------------WELCOME TO ROLL THE DICE-----------------------------\n");

            Console.WriteLine("Press Enter to proceed to the game\n");
            Console.ReadKey();
            Console.WriteLine("---------------------------------------------------------------------------------------------\n");

            //Printing the Rules and Regualations of the game
            Console.WriteLine("!!RULES AND REGULATIONS!!\n\n");

            Console.WriteLine(
                "Number of Players: 02 \n\n" +
                "Number of Dices: 02 per player\n\n" +
                "Winning Score: 100 \n\n\n" +
                " - If at least one player is not present, then the game terminates.\n\n" +
                " - Each player will get a chance to roll two dices at the same time.\n\n" +
                " - Each player should enter their names for Player 1 and Player 2 positions respectively.\n\n"+
                "The player 1 will start the game by rolling the 2 dice.\n\n" +
                " - If the two dice values are different, the score is updated with the sum of the dice values and the player 2 " +
                "gets the chance to roll the dice.\n\n" +
                " - If the two dice values are equal and 1, the score is reduced to 0 and the player 2 gets the chance to roll the dice.\n\n" +
                " - If the two dice values are equal but the value is not 1, the score is updated with the sum of the dice values and the"+
                "player 1 gets another chance to roll the dice.\n\n"+
                "The same set of conditions will apply for the player 2 during his turn.\n\n"+
                "The process above repeats until one of the players reaches/passes the Winning score 100.\n\n");
            Console.WriteLine("---------------------------------------------------------------------------------------------\n");
            Console.WriteLine("!!!!!!!Go through the Rules and Regulations of the game before proceeding!!!!!!!\n");
            Console.WriteLine("GOOD LUCK WITH THE GAME!\n");
            Console.WriteLine("Press Enter to proceed to the game\n");
            Console.ReadKey();

            //Printing the enter name message and collecting the inputs
            Console.WriteLine("Enter the name of Player 1:");
            string A = Console.ReadLine();
            Console.WriteLine("Enter the name of Player 2:");
            string B = Console.ReadLine();


            //If atleast one name is left empty, the program was made to exit
            if (A == "" || B == "")
            {
                Console.WriteLine("Cannot Proceed to game. Two players required to proceed to the game.");
                Environment.Exit(0);

            }

            //Creating two player objects from the Player class
            Player player1 = new Player(A);
            Player player2 = new Player(B);

            Console.WriteLine("Press Enter to proceed to the game\n");
            Console.ReadKey();

            

            while (player1.score<Winning_mark && player2.score < Winning_mark)
            {
                while (player1.score < Winning_mark && player2.score < Winning_mark)
                {
                    Console.WriteLine(player1.GetName() + "\'s turn. Click Enter key to roll.\n");
                    Console.ReadKey();
                    player1.dice_value1 = RollDice();
                    player1.dice_value2 = RollDice();
                    player1.score += player1.dice_value1 + player1.dice_value2;

                    if (player1.dice_value2 == 1 && player1.dice_value1 == 1)
                    {
                        player1.score = 0;
                        Console.WriteLine(player1.Message1());
                        Console.WriteLine(player1.Message2());
                        break;//Chance to the next player

                    }
                    else if (player1.dice_value1 == player1.dice_value2 && player1.dice_value1 != 1)
                    {

                        Console.WriteLine(player1.Message1());
                        Console.WriteLine(player1.Message2());
                        continue;

                    }
                    else
                    {
                        Console.WriteLine(player1.Message1());
                        Console.WriteLine(player1.Message2());
                        break;//Chance to the next player
                    }
                }

                while (player1.score < Winning_mark && player2.score < Winning_mark)
                {
                    Console.WriteLine(player2.GetName() + "\'s turn. Click Enter key to roll.\n");
                    Console.ReadKey();
                    player2.dice_value1 = RollDice();
                    player2.dice_value2 = RollDice();
                    player2.score += player2.dice_value1 + player2.dice_value2;

                    if (player2.dice_value1 == 1 && player2.dice_value2 == 1)
                    {
                        player2.score = 0;
                        Console.WriteLine(player2.Message1());
                        Console.WriteLine(player2.Message2());
                        break;//Chance to the next player

                    }
                    else if (player2.dice_value1 == player2.dice_value2 && player2.dice_value1 != 1)
                    {

                        Console.WriteLine(player2.Message1());
                        Console.WriteLine(player2.Message2());
                        continue;

                    }
                    else
                    {

                        Console.WriteLine(player2.Message1());
                        Console.WriteLine(player2.Message2());
                        break;//Chance to the next player
                    }
                }
            }
                


            //Printing the Winner of the game
            if (player2.score >= player1.score && player2.score >= 100)
            {
                Console.WriteLine("GAME OVER!");
                Console.WriteLine("Final SCORE OF: " + player2.GetName() + " " + player2.score);
                Console.WriteLine(player2.GetName() + " WINS THE GAME!");


            }
            else if (player1.score == player2.score && player2.score >= 100)
            {
                Console.WriteLine("GAME IS DRAW");


            }
            else if ((player1.score >= player2.score && player1.score >= 100))
            {
                Console.WriteLine("GAME OVER!");
                Console.WriteLine("Final SCORE OF: " + player1.GetName() + " " + player1.score);
                Console.WriteLine(player1.GetName() + " WINS THE GAME!");
            }
            
        }
    }




    class Player
    {
        public string player_name;
        public int dice_value1;
        public int dice_value2;
        public int score = 0;
        public Player(string name)
        {
            this.player_name = name;
        }
        public string GetName()
        {
            return player_name;
        }
        public string Message1()
        {
            string str = this.player_name + " rolled: " + this.dice_value1 + " and " + this.dice_value2;
            return str;
        }
        public string Message2()
        {
            string str = this.player_name + "\'s SCORE: " + this.score +"\n\n";
            return str;
        }

    }

    
}


