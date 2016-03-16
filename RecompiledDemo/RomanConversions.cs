using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecompiledDemo
{
    public class RomanConversions
    {
        private List<string> RomanList = new List<string>();

        private List<char> NumeralList = new List<char>();

        private int remainder;

        private int romans2Add;

        private int decConvertTotal;

        public RomanConversions()
        {
        }

        public void ConvertFromRome(string UserInput)
        {
            int referenceCharacter = this.NumeralList.Count<char>();
            for (int i = 1; i < referenceCharacter - 1; i++)
            {
                char characterAtCount = this.NumeralList.ElementAt<char>(i);
                char characterAfterCount = this.NumeralList.ElementAt<char>(i + 1);
                char characterBeforeCount = this.NumeralList.ElementAt<char>(i - 1);
                if (i != 1)
                {
                    if (characterAtCount == characterBeforeCount)
                    {
                        this.decConvertTotal = this.decConvertTotal + this.RomeConverter(characterAtCount);
                    }
                    else if ((characterAtCount == characterBeforeCount ? false : characterAtCount != characterAfterCount))
                    {
                        if (this.RomeConverter(characterAfterCount) <= this.RomeConverter(characterAtCount))
                        {
                            this.decConvertTotal = this.decConvertTotal + this.RomeConverter(characterAtCount);
                        }
                        else
                        {
                            this.decConvertTotal = this.decConvertTotal + (this.RomeConverter(characterAfterCount) - this.RomeConverter(characterAtCount));
                            i++;
                        }
                    }
                }
                else if (characterAtCount == characterAfterCount)
                {
                    this.decConvertTotal = this.decConvertTotal + this.RomeConverter(characterAtCount);
                }
                else if (i + 2 == referenceCharacter)
                {
                    this.decConvertTotal = this.decConvertTotal + this.RomeConverter(characterAtCount);
                }
                else if (characterAtCount != characterAfterCount)
                {
                    if (this.RomeConverter(characterAfterCount) <= this.RomeConverter(characterAtCount))
                    {
                        this.decConvertTotal = this.decConvertTotal + this.RomeConverter(characterAtCount);
                    }
                    else
                    {
                        this.decConvertTotal = this.decConvertTotal + (this.RomeConverter(characterAfterCount) - this.RomeConverter(characterAtCount));
                        i++;
                    }
                }
            }
            Console.WriteLine(string.Concat(new object[] { "The Roman Numeral ", UserInput, " is equal to a decimal value of ", this.decConvertTotal }));
            this.NumeralList.Clear();
            this.MainBuild();
        }

        public void ListConverter()
        {
            Console.WriteLine(string.Join("", this.RomanList));
            this.MainBuild();
        }

        public string ListCreator(string UserInput)
        {
            int LengthOfUserInput = UserInput.Count<char>();
            string userInputUpperCase = UserInput.ToUpper();
            this.NumeralList.Add('P');
            for (int i = 0; i <= LengthOfUserInput - 1; i++)
            {
                this.NumeralList.Add(userInputUpperCase.ElementAt<char>(i));
            }
            this.NumeralList.Add('P');
            return userInputUpperCase;
        }

        public void MainBuild()
        {
            Console.WriteLine("Would you like to check a 1) Roman Numeral or 2) a regular Integer?");
            int RomanOrDecimalChoice = int.Parse(Console.ReadLine());
            if (RomanOrDecimalChoice == 2)
            {
                Console.WriteLine("Please input your Number.");
                int num1 = int.Parse(Console.ReadLine());
                this.decConvertTotal = 0;
                this.SwitchtoStart(num1);
            }
            else if (RomanOrDecimalChoice == 1)
            {
                Console.WriteLine("Please input your Number.");
                string userInput = Console.ReadLine();
                this.decConvertTotal = 0;
                this.ConvertFromRome(this.ListCreator(userInput));
            }
        }

        public void RomanAssigner(int Num2Convert, int Divisor, int SecondaryDivisor, string Letter2Add, string SecondaryOpp)
        {
            if (Num2Convert < Divisor)
            {
                this.RomanList.Add(SecondaryOpp);
                this.RomanList.Add(Letter2Add);
                this.remainder = Num2Convert % SecondaryDivisor;
                this.SwitchtoStart(this.remainder);
            }
            else if (Num2Convert >= Divisor)
            {
                this.romans2Add = Num2Convert / Divisor;
                this.remainder = Num2Convert % Divisor;
                for (int i = 0; i < this.romans2Add; i++)
                {
                    this.RomanList.Add(Letter2Add);
                }
                this.SwitchtoStart(this.remainder);
            }
        }

        public int RomeConverter(char RomeDig)
        {
            int decimalNumber;
            char romeDig = RomeDig;
            if (romeDig > 'D')
            {
                switch (romeDig)
                {
                    case 'I':
                        {
                            decimalNumber = 1;
                            break;
                        }
                    case 'J':
                    case 'K':
                        {
                            decimalNumber = 0;
                            return decimalNumber;
                        }
                    case 'L':
                        {
                            decimalNumber = 50;
                            break;
                        }
                    case 'M':
                        {
                            decimalNumber = 1000;
                            break;
                        }
                    default:
                        {
                            if (romeDig == 'V')
                            {
                                decimalNumber = 5;
                                break;
                            }
                            else if (romeDig == 'X')
                            {
                                decimalNumber = 10;
                                break;
                            }
                            else
                            {
                                decimalNumber = 0;
                                return decimalNumber;
                            }
                        }
                }
            }
            else if (romeDig == 'C')
            {
                decimalNumber = 100;
            }
            else
            {
                if (romeDig != 'D')
                {
                    decimalNumber = 0;
                    return decimalNumber;
                }
                decimalNumber = 500;
            }
            return decimalNumber;
        }

        public void SwitchtoStart(int Num2Convert)
        {
            if (Num2Convert >= 900)
            {
                this.RomanAssigner(Num2Convert, 1000, 900, "M", "C");
            }
            else if (Num2Convert >= 400)
            {
                this.RomanAssigner(Num2Convert, 500, 400, "D", "C");
            }
            else if (Num2Convert >= 90)
            {
                this.RomanAssigner(Num2Convert, 100, 90, "C", "X");
            }
            else if (Num2Convert >= 40)
            {
                this.RomanAssigner(Num2Convert, 50, 40, "L", "X");
            }
            else if (Num2Convert >= 9)
            {
                this.RomanAssigner(Num2Convert, 10, 9, "X", "I");
            }
            else if (Num2Convert >= 4)
            {
                this.RomanAssigner(Num2Convert, 5, 4, "V", "I");
            }
            else if (Num2Convert < 1)
            {
                this.ListConverter();
                this.RomanList.Clear();
            }
            else
            {
                this.RomanAssigner(Num2Convert, 1, 0, "I", "I");
            }
        }
    }
}