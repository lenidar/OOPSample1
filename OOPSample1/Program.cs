using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> history = new List<string>();
            int numA = 0;
            int numB = 0;
            int ope = 0;
            int answer = 0;
            string uInput = "";
            string fInput = "";
            bool opeLastAdd = false;

            while(true)
            {
                Console.Clear();
                if(history.Count > 0)
                {
                    foreach (string h in history)
                        Console.Write(h + " ");
                    Console.WriteLine("\n" + answer);
                }
                Console.Write("Please input either a number or operation : ");
                uInput = Console.ReadLine();
                fInput = filterInput(uInput);
                if(isNum(fInput))
                {
                    if (!opeLastAdd)
                        ope = 0;

                    if (ope <= 0)
                    {
                        history.Clear();
                        answer = 0;
                        numA = convToNum(fInput);
                        history.Add(numA + "");
                    }
                    else
                    {
                        numB = convToNum(fInput);
                        history.Add(numB + "");
                        answer = performOperation(numA, numB, ope);
                        numA = answer;
                        numB = 0;
                    }
                    opeLastAdd = false;
                }
                else
                {
                    ope = convToOperation(fInput);
                    if(ope == -1)
                    {
                        Console.WriteLine("Not a valid operation, please try again!");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (history.Count == 0)
                            history.Add(0 + "");
                        switch (ope)
                        {
                            case 1:
                                if (opeLastAdd)
                                    history[history.Count - 1] = "+";
                                else
                                    history.Add("+");
                                break;
                            case 2:
                                if (opeLastAdd)
                                    history[history.Count - 1] = "-";
                                else
                                    history.Add("-");
                                break;
                            case 3:
                                if (opeLastAdd)
                                    history[history.Count - 1] = "*";
                                else
                                    history.Add("*");
                                break;
                            case 4:
                                if (opeLastAdd)
                                    history[history.Count - 1] = "/";
                                else
                                    history.Add("/");
                                break;
                            case 5:
                                if (opeLastAdd)
                                    history[history.Count - 1] = "=";
                                else
                                    history.Add("=");
                                break;
                        }

                        opeLastAdd = true;
                    }
                }
            }
        }

        /// <summary>
        /// This methods splits the string and only gets the first element
        /// </summary>
        /// <param name="uInput">the raw input string</param>
        /// <returns>the first element of the string</returns>
        static string filterInput(string uInput)
        {
            //string[] temp = uInput.Split(' ');
            return uInput.Split(' ')[0];
            //return temp[0];
        }

        /// <summary>
        /// Checks if the filtered input is a number
        /// </summary>
        /// <param name="fInput">filtered input</param>
        /// <returns>true if input is a number</returns>
        static bool isNum(string fInput)
        {
            return int.TryParse(fInput, out int num);
        }

        /// <summary>
        /// Converts a string into a number
        /// </summary>
        /// <param name="num">the number in string form</param>
        /// <returns>returns the int value for that string</returns>
        static int convToNum(string num)
        {
            return int.Parse(num);
        }

        /// <summary>
        /// Converts a string operation into the fixed numerical counterpart
        /// for the operation
        /// example: method will return 1 if the "+" is input to it.
        /// </summary>
        /// <param name="ope">the string operation</param>
        /// <returns>number counterpart to the operation</returns>
        static int convToOperation(string ope)
        {
            int opeVal = 0;

            switch(ope)
            {
                case "+":
                    opeVal = 1;
                    break;
                case "-":
                    opeVal = 2;
                    break;
                case "*":
                    opeVal = 3;
                    break;
                case "/":
                    opeVal = 4;
                    break;
                case "=":
                    opeVal = 5;
                    break;
                default:
                    opeVal = -1;
                    break;
            }

            return opeVal;
        }

        /// <summary>
        /// performs the operation and returns the answer
        /// </summary>
        /// <param name="numA">the first number</param>
        /// <param name="numB">the second number</param>
        /// <param name="ope">the operation</param>
        /// <returns>the answer</returns>
        static int performOperation(int numA, int numB, int ope)
        {
            int ans = numA;

            switch(ope)
            {
                case 1:
                    ans += numB;
                    break;
                case 2:
                    ans -= numB;
                    break;
                case 3:
                    ans *= numB;
                    break;
                case 4:
                    ans /= numB;
                    break;
            }

            return ans;
        }
    }
}
