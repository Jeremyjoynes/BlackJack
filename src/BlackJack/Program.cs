using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlackJack
{
    public class Program
    {
        static Random Random = new Random();
        public static void Main(string[] args)
        {
            Console.Title = "My BlackJack App";
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            ////make card array
            //int[] Cards = new int[52];

            //var cards = new ArrayList();
            
            
            //for (var i = 0; i < Cards.Length; i++)
            //{
            //    Cards[i] = i;
            //    cards.Add(i);
            // //   Console.WriteLine(Cards[i]);
            //}

            //// roll random number between 0-52

            //var x = RandomNumber();
            //Console.WriteLine(x);
            ////test random number generator
            //// random number generator now works -- Had to make static Random Random = new Random
            //on line 11 otherwise was making multiple random's that would generate the same number

            //for (int a = 0; a < 10; a++)
            //{
            //    int rt = RandomNumber();
            //    Console.WriteLine(rt);
            //}




            /// Game Play

            var playerhand = 0;
            var dealerhand = 0;



            Console.WriteLine("Would you like to play Black Jack? Press Y to continue");

            string play = Console.ReadLine();
            play.ToUpper();
            //play.Substring(0, 1); 
         
            while (play == "Y")
            {

                int Ccard1 = RandomNumber();
                int Ccard2 = RandomNumber();
                int card1 = RandomNumber();
                int card2 = RandomNumber();

                playerhand = card1 + card2;
                dealerhand = Ccard1 + Ccard2;
                Console.WriteLine("The dealer has {0}, {1}, for a total of {2}", Ccard1, Ccard2, dealerhand);
                Console.WriteLine("You have {0}, {1} for a total of {2}", card1, card2, playerhand);

                Console.WriteLine("Press S to stay anything else to hit");
                var playerChoice = Console.ReadLine();
               // playerChoice.Substring(0, 1);
                playerChoice.ToUpper();

                if (playerChoice == "S")
                {
                    if (playerhand > dealerhand && dealerhand <= 21)
                    {
                        // dealer hits to try and win

                        while (dealerhand < playerhand && dealerhand <= 21)
                        {
                            int Ccard3 = RandomNumber();
                            dealerhand += Ccard3;
                            Console.WriteLine("The dealer is delt {0} total is {1}", Ccard3, dealerhand);
 

                        } //end computers loop

                    }
                } // ends stay
                else
                {
                    do
                    {
                        int card3 = RandomNumber();
                        playerhand += card3;
                        Console.WriteLine("You are delt {0}, your new total is {1}", card3, playerhand);
                        if (playerhand >= 21)
                        {
                            break;
                        }
                        Console.WriteLine("Press S to stay or anything else to hit!");
                        playerChoice = Console.ReadLine();
                        // playerChoice.Substring(0, 1);
                        playerChoice.ToUpper();
                        if (playerChoice == "S")
                        {
                            break;
                        }

                    } while (playerhand <= 21);

                }

                //player chose to hit

              



                    if (playerhand > 21)
                    {
                        Console.WriteLine("Bust You Lose");
                        play = playAgain();

                        if (play == "N")
                        {
                            break;
                        }

                     }

                if (playerhand == 21)
                {
                    Console.WriteLine("Winner Winner Chicken Dinner you WIN!");
                    play = playAgain();

                    if (play == "N")
                    {
                        break;
                    }
                }

                // logic for the dealer
                if (dealerhand > 21)
                {
                    Console.WriteLine("You Win");
                    play = playAgain();

                    if (play == "N")
                    {
                        break;
                    }
                }
                if (dealerhand > playerhand && dealerhand <= 21)
                {
                    Console.WriteLine("You Lose");
                    play = playAgain();

                    if (play == "N")
                    {
                        break;
                    }
                }

            } // end while



            Console.ReadKey();
        } // end main

        public static int RandomNumber()
        {

            var x = Random.Next(0, 51);
            //4 aces
            if (x == 0 || x == 1 || x == 10 || x == 11)
            {
                Console.WriteLine("Do you want the value to be 1 or 11");
                x = Convert.ToInt32(Console.ReadLine());
            }
            // 4 kings
            else if (x == 20 || x == 21 || x == 30 || x == 31)
            {
                x = 10;
            }
            // 4 queens
            else if (x == 40 || x == 41 || x == 50 || x == 51)
            {
                x = 10;
            }

            //4 jacks
            else if (x == 2 || x == 3 || x == 4 || x == 5)
            {
                x = 10;
            }
            // 4 2's
            else if (x == 6 || x == 7 || x == 8 || x == 9)
            {
                x = 2;
            }
            //4 3's
            else if (x == 13 || x == 12 || x == 14 || x == 15)
            {
                x = 3;
            }
            //4 4's
            else if (x == 19 || x == 18 || x == 17 || x == 16)
            {
                x = 4;
            }
            //4 5's
            else if (x == 22 || x == 23 || x == 24 || x == 26)
            {
                x = 5;
            }
            //4 6's
            else if (x == 29 || x == 28 || x == 27 || x == 25)
            {
                x = 6;
            }
            //4 7s
            else if (x == 32 || x == 34 || x == 35 || x == 33)
            {
                x = 7;
            }
            //4'8s
            else if (x == 39 || x == 38 || x == 37 || x == 36)
            {
                x = 8;
            }
            //4 9s
            else if (x == 42 || x == 43 || x == 44 || x == 45)
            {
                x = 9;
            }
            // 4 10s
            else if (x == 46 || x == 47 || x == 48 || x == 49)
            {
                x = 10;
            }

            return x;
              
        }

        public static string playAgain()
        {
            Console.WriteLine("Would you like to play again?");
            var play = Console.ReadLine();
            //play.Substring(0, 1);
            play.ToUpper();
            return play;
        }

        //public static int playerturn()
        //{
        //    int playHand = 0;
        //    int card1 = 0;
        //    int card2 = 0;
        //    card1 = RandomNumber();
        //    card2 = RandomNumber();
        //    playHand = card1 + card2;
        //    Console.WriteLine("You were delt {0} and {1} for a total of {2}", card1, card2, playHand);
            
        //    Console.WriteLine("Press S to stay anything else to hit.");
        //    var playerChoice = Console.ReadLine();
        //    playerChoice.Substring(0, 1);
        //    playerChoice.ToUpper();


        //    if (playerChoice == "S")
        //    {
        //        return playHand;
        //    }

        //    else if (playHand <= 21)
        //    {
        //        card1 = RandomNumber();
        //        Console.WriteLine("You were delt {0} your total is {1}",card1, playHand);
        //    }
        //    return playHand;
           
            
        //}//end playerturn

    }
}
