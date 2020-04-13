using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ConsoleGuessNumberQuadax
{
    class Program
    {
        static void Main(string[] args)
        {
            string stUserAnswer = "";
            string stAnswer = "";
            bool bStartMsg = true;
            int nTryAgain = 1;
            string stOutputLine3 = "";
            int nAnswer = 0;
            Random r = new Random();
            stAnswer = r.Next(1, 6).ToString();
            stAnswer += r.Next(1, 6).ToString();
            stAnswer += r.Next(1, 6).ToString();
            stAnswer += r.Next(1, 6).ToString();

            for (; ; )
            {
                    if (bStartMsg)
                    {
                        Console.Write("Enter a number between 1 and 6 for each of four consecutive integers. (Note 1111 and 6666 are acceptable guesses, but, for example, 1777 or 5999 is not acceptable.)\r\n\r\n. (The answer is generated randomly when the program first starts. Then, you have 10 guesses. Type end to end the program.)\r\n\r\n"); 
                        bStartMsg = false;
                    }
                    
                    if (nTryAgain > 1)
                    {
                        if (stAnswer != stUserAnswer && stUserAnswer.Length  == 4)
                            Console.Write("You guessed wrong. Below are the results. Enter another number. This try was try# {0}. After 10 tries, another random number will be generated and you will have 10 new tries. Type end to end the program.\r\n" + stUserAnswer + "\r\n" + stOutputLine3 + "\r\n\r\n", (nTryAgain - 1).ToString());
                        else if (stAnswer != stUserAnswer && stUserAnswer.Length != 4)
                        {
                             Console.Write("The number you entered was not four digits. Enter another number. This try was try# {0}. After 10 tries, another random number will be generated and you will have 10 new tries. Type end to end the program.\r\n" + stUserAnswer + "\r\n" + stOutputLine3 + "\r\n\r\n", (nTryAgain - 1).ToString());
                        }



                    }

                    if (nTryAgain == 11)
                    {
                    Console.WriteLine("The answer was {0}. You can try again by entering a four digit number, or to end the program, enter end.", stAnswer);
                    
                    nTryAgain = 1;
                    stAnswer = r.Next(1, 6).ToString();
                    stAnswer += r.Next(1, 6).ToString();
                    stAnswer += r.Next(1, 6).ToString();
                    stAnswer += r.Next(1, 6).ToString();

                    }
                    stUserAnswer = Console.ReadLine();

                    if (stUserAnswer == "end")
                        return;

                    if (stUserAnswer.Length == 4)
                    {
                        if (stAnswer == stUserAnswer)
                        {
                            Console.Write("Good job. You got the correct answer: {0}. Type end to end the program. Not typing end, but a four integer number, will start the program again.\r\n\r\n", stAnswer);
                                nTryAgain = 1;
                            stAnswer = r.Next(1, 6).ToString();
                            stAnswer += r.Next(1, 6).ToString();
                            stAnswer += r.Next(1, 6).ToString();
                            stAnswer += r.Next(1, 6).ToString();

                        }
                        else
                        {
                            char[] chUA = new char[stUserAnswer.Length];
                            char[] chA = new char[nAnswer.ToString().Length];
                            chA = stAnswer.ToCharArray();
                            chUA = stUserAnswer.ToCharArray();
                            stOutputLine3 = "";
                            for (int i = 0; i < stUserAnswer.Length; i++)
                                stOutputLine3 += GetOutputLine(chUA[i], chA[i], ref stAnswer);
                           
                        }


                    }
                    
                nTryAgain += 1;                

                

                
            }
        
        }
        static string GetOutputLine(char chUA, char chA, ref string stA)
        {
            string stReturn = "";
            if (chUA == chA)
            {

                stReturn = "+";
            }
            else if (stA.IndexOf(chUA.ToString()) > -1)
            {
                stReturn = "-";
            }
            else
                stReturn = " ";

            return stReturn;
        }

    }
}
