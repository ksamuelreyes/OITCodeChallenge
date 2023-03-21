using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OITCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bContinueOuter = true;
            bool bContinueInner = true;

            Dictionary<char, int> RomanDict = new Dictionary<char, int>();
            RomanDict.Add('I', 1);
            RomanDict.Add('V', 5);
            RomanDict.Add('X', 10);
            RomanDict.Add('L', 50);
            RomanDict.Add('C', 100);
            RomanDict.Add('D', 500);
            RomanDict.Add('M', 1000);


            while (bContinueOuter)
            {
                while (bContinueInner)
                {
                    Console.WriteLine("Welcome to the number converter. Please type an option:");

                    Console.WriteLine("1. Roman to Decimal");
                    Console.WriteLine("2. Decimal to Roman");
                    string typeChoice = Console.ReadLine();

                    Int32.TryParse(typeChoice, out int numChoice);


                    if (numChoice == 1)
                    {

                        RomantoDecimal(RomanDict);
                        bContinueInner = false;
                    }
                    else if (numChoice == 2)
                    {
                        DecimaltoRoman();
                        bContinueInner = false;
                    }
                    else
                    {
                        Console.WriteLine("Try Again");
                    }

                }
                Console.WriteLine("Convert Another? (y/n)");
                string continueString = Console.ReadLine();
                bContinueOuter = (continueString == "y");
                bContinueInner = (continueString == "y");
            }

        }
        static void RomantoDecimal(Dictionary<char,int> RomanDict)
        {
            Console.WriteLine("Please insert a Roman Numeral to Convert");
            string romanString = Console.ReadLine();
            int sum = 0;

            for (int i = 1; i < (romanString.Length); i++)
            {

                if (RomanDict[romanString[i - 1]] < RomanDict[romanString[i]])
                {
                    sum -= RomanDict[romanString[i - 1]];
                }
                else
                {
                    sum += RomanDict[romanString[i - 1]];
                }

                if (i == romanString.Length - 1)
                {
                    sum += RomanDict[romanString[i]];
                }
            }
            Console.WriteLine(sum);

        }
        static void DecimaltoRoman()
        {
            Console.WriteLine("Please insert a decimal to convert to Roman Numeral");
            string stringInput = Console.ReadLine();
            Int32.TryParse(stringInput, out int decInput);


            string romanOutput = "";

            if ((decInput < 4000) && (decInput >= 1000))
            {
                int thouCount = decInput / 1000;
                string temp = new string('M', thouCount);
                romanOutput += temp;

                 decInput %= 1000;   
            }

            if (decInput >= 900)
            {
                romanOutput += "CM";

                decInput %= 900;
            }

            if (decInput >= 500)
            {
                romanOutput += "D";

                decInput %= 500;
            }

            if (decInput >= 400)
            {
                romanOutput += "CD";
                decInput %= 400;
            }

            if(decInput >= 100)
            {
                int hundCount = decInput / 100;
                string temp = new string('C', hundCount);
                romanOutput += temp;
                decInput %= 100;
            }

            if(decInput >= 90)
            {
                romanOutput += "XC";
                decInput %= 90;
            }

            if(decInput >= 50)
            {
                romanOutput += "L";
                decInput %= 50;
            }

            if (decInput >= 40)
            {
                romanOutput += "CD";
                decInput %= 40;
            }
            
            if (decInput >= 10)
            {
                int tenCount = decInput / 10;
                string temp = new string('X', tenCount);
                romanOutput += temp;
                decInput %= 10;
            }

            if (decInput >= 9)
            {
                romanOutput += "IX";
                decInput %= 9;
            }

            if (decInput >= 5)
            {
                romanOutput += "V";
                decInput %= 5;
            }

            if (decInput >= 4)
            {
                romanOutput += "IV";
                decInput %= 4;
            }

            if (decInput >= 1)
            {
                int onesCount = decInput / 1;
                string temp = new string('I', onesCount);
                romanOutput += temp;
            }
            Console.WriteLine(romanOutput);
        }

    }
}
