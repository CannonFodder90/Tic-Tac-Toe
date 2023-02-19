using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
    //game board arrays, two for edge and middle rows
    static string[] endRows = { "  --", "---", "---", "---", "---", "---", "--" };
    static string[] midRows = { "  + ", "---", " + ", "---", " + ", "---", " +" };
    //playspace arrays, empty values in 1,3, and 5 for data storage during play
    static string[] playRow1 = { "1 |  ", " ", "  |  ", " ", "  |  ", " ", "  |" };
    static string[] playRow2 = { "2 |  ", " ", "  |  ", " ", "  |  ", " ", "  |" };
    static string[] playRow3 = { "3 |  ", " ", "  |  ", " ", "  |  ", " ", "  |" };
    //alpha labeling for entry by player and identification
    static string[] topRowAlpha = { "    ", " A ", "   ", " B ", "   ", " C ", "  ", };
    //Variable to control player or computer turn
    static bool playerTurn = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Would you like to play Tic-Tac-Toe?");
            top:
            string playGame = Console.ReadLine();
            string playGameLwr = playGame.ToLower().Trim();
            if (playGameLwr == "yes")
            {
                GameBoard();
            }
            else if (playGameLwr == "no")
            {
                Console.WriteLine("Ok, have a nice day.");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("I do not understand.");
                Console.WriteLine("\nWould you like to play Tic-Tac-Toe?");
                goto top;
            }
        }
        static void GameBoard()
        {
        Board:
            //Write arrays to write gameboard to Console
            Console.WriteLine("\n");
            Array.ForEach(topRowAlpha, Console.Write);
            Console.Write("\n");
            Array.ForEach(endRows, Console.Write);
            Console.Write("\n");
            Array.ForEach(playRow1, Console.Write);
            Console.Write("\n");
            Array.ForEach(midRows, Console.Write);
            Console.Write("\n");
            Array.ForEach(playRow2, Console.Write);
            Console.Write("\n");
            Array.ForEach(midRows, Console.Write);
            Console.Write("\n");
            Array.ForEach(playRow3, Console.Write);
            Console.Write("\n");
            Array.ForEach(endRows, Console.Write);


            //Victory conditions for player, resets board if replay
            bool playerVictory = PlayerVictoryCheck();
            if (playerVictory == true)
            {                
                Console.WriteLine("\nLooks like you won! Good job!");
                WinReplayTop:
                Console.WriteLine("Would you like to play again?");
                string playerWinReplayRaw = Console.ReadLine();
                string playerWinReplay = playerWinReplayRaw.ToLower().Trim();
                if (playerWinReplay == "yes")
                {
                    playRow1[1] = " ";
                    playRow1[3] = " ";
                    playRow1[5] = " ";
                    playRow2[1] = " ";
                    playRow2[3] = " ";
                    playRow2[5] = " ";
                    playRow3[1] = " ";
                    playRow3[3] = " ";
                    playRow3[5] = " ";
                    playerTurn = false;
                    Console.WriteLine("Ok, let me start this time.");
                    goto Board;
                }
                else if (playerWinReplay == "no")
                {
                    Console.WriteLine("Thanks for playing!");
                    Console.WriteLine("\nPress any key to exit");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That input doesn't make sense");
                    goto WinReplayTop;
                }
            }
            else //no victory, continue playing
            { }


            //Victory conditions for computer, resets board if replay
            bool computorVictory = ComputerVictoryCheck();
            if (computorVictory == true)
            {
                Console.WriteLine("\nLooks like I won! Better luck next time!");
                LoseReplayTop:
                Console.WriteLine("Would you like to play again?");
                string playerLoseReplayRaw = Console.ReadLine();
                string playerLoseReplay = playerLoseReplayRaw.ToLower().Trim();
                if (playerLoseReplay == "yes")
                {
                    playRow1[1] = " ";
                    playRow1[3] = " ";
                    playRow1[5] = " ";
                    playRow2[1] = " ";
                    playRow2[3] = " ";
                    playRow2[5] = " ";
                    playRow3[1] = " ";
                    playRow3[3] = " ";
                    playRow3[5] = " ";
                    playerTurn = true;
                    Console.WriteLine("Ok, you can start.");
                    goto Board;
                }
                else if (playerLoseReplay == "no")
                {
                    Console.WriteLine("Thanks for playing!");
                    Console.WriteLine("\nPress any key to exit");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That input doesn't make sense");
                    goto LoseReplayTop;
                }

            }
            else { }//keep playing


            //Draw conditions, reset if replay
            bool gameDrawEnd = GameDrawCheck();
            if (gameDrawEnd == true)
            {
                Console.WriteLine("\nLooks like there are no winners.");
                DrawReplayTop:
                Console.WriteLine("Would you like to play again?");
                string DrawReplayRaw = Console.ReadLine();
                string DrawReplay = DrawReplayRaw.ToLower().Trim();
                if (DrawReplay == "yes")
                {
                    playRow1[1] = " ";
                    playRow1[3] = " ";
                    playRow1[5] = " ";
                    playRow2[1] = " ";
                    playRow2[3] = " ";
                    playRow2[5] = " ";
                    playRow3[1] = " ";
                    playRow3[3] = " ";
                    playRow3[5] = " ";
                    playerTurn = true;
                    Console.WriteLine("Ok, you can start.");
                    goto Board;
                }
                else if (DrawReplay == "no")
                {
                    Console.WriteLine("Thanks for playing!");
                    Console.WriteLine("\nPress any key to exit");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That input doesn't make sense");
                    goto DrawReplayTop;
                }    
            }
            else { }//keep playing


            if (playerTurn == true)
            {//Prompt user for move
                Console.WriteLine("\nYou are \"X,\" please choose a move.");
            choose:
                Console.WriteLine("Play by choosing a square, ex; A1");
                //take user input & convert to upper & trim it
                string moveRaw = Console.ReadLine();
                string move = moveRaw.ToUpper().Trim();

                //send variable to choice check to confirm valid option
                string playerChoice = PlayerChoiceCheck(move);
                //Return from choice check with new variable and insert into array if not occupied
                //player turn        
                if (playerChoice == null)
                {
                    goto choose;
                }
                else if (playerChoice == "A1")
                {
                    if (playRow1[1] == " ")
                    {
                        playRow1[1] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "A2")
                {
                    if (playRow2[1] == " ")
                    {
                        playRow2[1] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "A3")
                {
                    if (playRow3[1] == " ")
                    {
                        playRow3[1] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "B1")
                {
                    if (playRow1[3] == " ")
                    {
                        playRow1[3] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "B2")
                {
                    if (playRow2[3] == " ")
                    {
                        playRow2[3] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "B3")
                {
                    if (playRow3[3] == " ")
                    {
                        playRow3[3] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "C1")
                {
                    if (playRow1[5] == " ")
                    {
                        playRow1[5] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "C2")
                {
                    if (playRow2[5] == " ")
                    {
                        playRow2[5] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else if (playerChoice == "C3")
                {
                    if (playRow3[5] == " ")
                    {
                        playRow3[5] = "X";
                        playerTurn = false;
                        goto Board;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken, please choose another.");
                        goto choose;
                    }
                }
                else
                {
                    Console.WriteLine("Something has gone wrong...");
                    Console.WriteLine(playRow1[1]);
                    Console.ReadLine();
                }
            }
            else if (playerTurn == false)
            {   //computer turn
                if (playRow2[3] == " ")
                {
                    playRow2[3] = "O";
                    Console.WriteLine("\nI choose B2!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow1[1] == " ")
                {
                    playRow1[1] = "O";
                    Console.WriteLine("\nI choose A1!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow1[3] == " ")
                {
                    playRow1[3] = "O";
                    Console.WriteLine("\nI choose B1!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow1[5] == " ")
                {
                    playRow1[5] = "O";
                    Console.WriteLine("\nI choose C1!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow2[1] == " ")
                {
                    playRow2[1] = "O";
                    Console.WriteLine("\nI choose A2!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow2[5] == " ")
                {
                    playRow2[5] = "O";
                    Console.WriteLine("\nI choose C2!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow3[1] == " ")
                {
                    playRow3[1] = "O";
                    Console.WriteLine("\nI choose A3!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow3[3] == " ")
                {
                    playRow3[3] = "O";
                    Console.WriteLine("\nI choose B3!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else if (playRow3[5] == " ")
                {
                    playRow3[5] = "O";
                    Console.WriteLine("\nI choose C3!");
                    Console.WriteLine("\n");
                    playerTurn = true;
                    goto Board;
                }
                else
                {
                    Console.WriteLine("Oh something went WAY wrong here, LOL");
                    Console.ReadLine();
                }
            }
            else
            {   //this should only happen if all squares are filled with no winner.
                Console.WriteLine("Oh something went WAY wrong here, LOL");
                Console.ReadLine();
            }
        }

        static string PlayerChoiceCheck(string move)
        {   //check to make sure only valid moves are entered
            if (move == "A1" || move == "A2" || move == "A3" || move == "B1" || move == "B2" || move == "B3" || move == "C1" || move == "C2" || move == "C3")
            {
                string playerChoice = move;
                return playerChoice;
            }
            else
            {
                Console.WriteLine(move + " is not a valid iput. Please try again.");
                Console.WriteLine("\n");
                string playerChoice = null;
                return playerChoice;
            }
        }

        static bool PlayerVictoryCheck()
        {   //Player victory condition check
            if (playRow1[1] == "X" && playRow1[3] == "X" && playRow1[5] == "X")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow2[1] == "X" && playRow2[3] == "X" && playRow2[5] == "X")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow3[1] == "X" && playRow3[3] == "X" && playRow3[5] == "X")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[1] == "X" && playRow2[1] == "X" && playRow3[1] == "X")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[3] == "X" && playRow2[3] == "X" && playRow3[3] == "X")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[5] == "X" && playRow2[5] == "X" && playRow3[5] == "X")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[1] == "X" && playRow2[3] == "X" && playRow3[5] == "X")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow3[1] == "X" && playRow2[3] == "X" && playRow1[5] == "X")
            {
                bool victory = true;
                return victory;
            }
            else
            {
                bool victory = false;
                return victory;
            }
        }
        static bool ComputerVictoryCheck()
        {//computer victory condition check
            if (playRow1[1] == "O" && playRow1[3] == "O" && playRow1[5] == "O")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow2[1] == "O" && playRow2[3] == "O" && playRow2[5] == "O")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow3[1] == "O" && playRow3[3] == "O" && playRow3[5] == "O")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[1] == "O" && playRow2[1] == "O" && playRow3[1] == "O")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[3] == "O" && playRow2[3] == "O" && playRow3[3] == "O")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[5] == "O" && playRow2[5] == "O" && playRow3[5] == "O")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow1[1] == "O" && playRow2[3] == "O" && playRow3[5] == "O")
            {
                bool victory = true;
                return victory;
            }
            else if (playRow3[1] == "O" && playRow2[3] == "O" && playRow1[5] == "O")
            {
                bool victory = true;
                return victory;
            }
            else
            {
                bool victory = false;
                return victory;
            }
        }
        static bool GameDrawCheck()
        {
            if (playRow1[1].Contains("O") || playRow1[1].Contains("X"))
            {
                if (playRow1[3].Contains("O") || playRow1[3].Contains("X"))
                {
                    if (playRow1[5].Contains("O") || playRow1[3].Contains("X"))
                    {
                        if (playRow2[1].Contains("O") || playRow2[1].Contains("X"))
                        {
                            if (playRow2[3].Contains("O") || playRow2[3].Contains("X"))
                            {
                                if (playRow2[5].Contains("O") || playRow2[5].Contains("X"))
                                {
                                    if (playRow3[1].Contains("O") || playRow3[1].Contains("X"))
                                    {
                                        if (playRow3[3].Contains("O") || playRow3[3].Contains("X"))
                                        {
                                            if (playRow3[5].Contains("O") || playRow3[5].Contains("X"))
                                            {
                                                bool drawGameEnd = true;
                                                return drawGameEnd;
                                            }
                                            else
                                            {   bool drawGameEnd = false;                                                
                                                return drawGameEnd;
                                            }  
                                        }
                                        else 
                                        {   bool drawGameEnd = false;
                                            return drawGameEnd;
                                        }
                                    }
                                    else
                                    {
                                        bool drawGameEnd = false;
                                        return drawGameEnd;
                                    }
                                }
                                else
                                {
                                    bool drawGameEnd = false;
                                    return drawGameEnd;
                                }
                            }
                            else
                            {
                                bool drawGameEnd = false;
                                return drawGameEnd;
                            }
                        }
                        else
                        {
                            bool drawGameEnd = false;
                            return drawGameEnd;
                        }
                    }
                    else
                    {
                        bool drawGameEnd = false;
                        return drawGameEnd;
                    }
                }
                else
                {
                    bool drawGameEnd = false;
                    return drawGameEnd;
                }
            }
            else
            {
                bool drawGameEnd = false;
                return drawGameEnd;
            }
        }
    }
}
