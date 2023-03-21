using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Samuel Reyes
// OIT Code Challenge
// Decimal <--> Roman Numeral

namespace OITCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            bool bContinueOuter = true;
            bool bContinueInner = true;

            // This loop allows the user to continue to input numbers or Roman Numerals
            do
            {
                // This loops if the user inputs something other than "1" or "2"
                do
                {
                    // Receive user input and convert to integer
                    Console.WriteLine("Welcome to the number converter. Please type an option:");

                    Console.WriteLine("1. Roman to Decimal");
                    Console.WriteLine("2. Decimal to Roman");
                    string typeChoice = Console.ReadLine();

                    Int32.TryParse(typeChoice, out int numChoice);


                    //Depending on integer, a different method is selected. If none is selected, the user is prompted to try again
                    if (numChoice == 1)
                    {

                        RomantoDecimal();
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
                while (bContinueInner);

                //User is asked if they want to convert again. Then they are either allowed to continue or the app is exited
                Console.WriteLine("Convert Again? (y/n)");
                string continueString = Console.ReadLine();
                bContinueOuter = (continueString == "y");
                bContinueInner = (continueString == "y");
            }
            while (bContinueOuter);

        }
        //Roman --> Decimal
        static void RomantoDecimal()
        {
            // Dictionary is created with corresponding Roman numeral and numeric value
            Dictionary<char, int> RomanDict = new Dictionary<char, int>();
            RomanDict.Add('I', 1);
            RomanDict.Add('V', 5);
            RomanDict.Add('X', 10);
            RomanDict.Add('L', 50);
            RomanDict.Add('C', 100);
            RomanDict.Add('D', 500);
            RomanDict.Add('M', 1000);

            // User is prompted for input
            Console.WriteLine("Please insert a Roman Numeral to Convert");
            string romanString = Console.ReadLine();
            int sum = 0;


            // The program selects the first two characters in the input string. It compares the two values
            for (int i = 1; i < (romanString.Length); i++)
            {
                //If the value of the second is greater than that of the first, the value of the first is subtracted from the total
                if (RomanDict[romanString[i - 1]] < RomanDict[romanString[i]])
                {
                    sum -= RomanDict[romanString[i - 1]];
                }
                // Otherwise, the value of the second character is added to the total
                else
                {
                    sum += RomanDict[romanString[i - 1]];
                }

                // Given how Roman Numerals function, the last character is always counted
                // Here, if the program is looking at the final pair of characters, the last one is added automatically
                if (i == romanString.Length - 1)
                {
                    sum += RomanDict[romanString[i]];
                }
            }
            Console.WriteLine(sum);

        }
        //Decimal --> Roman
        static void DecimaltoRoman()
        {
            // User input
            Console.WriteLine("Please insert a decimal to convert to Roman Numeral (between 1-3999):");
            string stringInput = Console.ReadLine();
            Int32.TryParse(stringInput, out int decInput);


            string romanOutput = "";
            // Here, the code basically goes through every possible value each place value at a time.
            // It then adds the corresponding character to the output string, and uses the Modulo to get a remainder which is then used again
            if ((decInput < 4000) && (decInput >= 1000))
            {
                // For example, if the number is 1000-4000, first the number of thousands is determined
                int thouCount = decInput / 1000;
                //It is then added to the output string
                string temp = new string('M', thouCount);
                romanOutput += temp;

                //Then a remainer is taken to use in the next statement
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
                romanOutput += "XL";
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
