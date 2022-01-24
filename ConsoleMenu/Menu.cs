using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleMenu
{
    class Menu
    {
        public bool shouldRun = false;
        private string latestInput = "NONE";
        private int latestInputInt = -1;
        private int upperIntLimit = 20; //exclusive

        private List<Character> playerAvatars = new List<Character>();
        private List<Character> enemies = new List<Character>();

        //Run the program until told to stop
        public void Run()
        {
            //On start-up, ensure existence of post_it.txt
            EnsurePostIt();

            //Greet the user
            Console.WriteLine("Hello and welcome!");

            //Run core loop
            while (shouldRun)
            {
                TakeMenuInput();
            }
        }

        private void WriteMenu()
        {
            Console.WriteLine("---");
            Console.WriteLine("Please select an option from below by entering the corresponding number in the menu");
            Console.WriteLine("0 - Close Aplication");
            Console.WriteLine("1 - Print 'Hello World!'");
            Console.WriteLine("2 - Have your name and age repeated to you");
            Console.WriteLine("3 - Colorful text toggle");
            Console.WriteLine("4 - Print todays date");
            Console.WriteLine("5 - Compare two numbers");
            Console.WriteLine("6 - Play the guessing game");
            Console.WriteLine("7 - Replace the post-it note");
            Console.WriteLine("8 - Read the post-it note");
            Console.WriteLine("9 - Get the square root, power to 2, and power to 10 of a number");
            Console.WriteLine("10 - Check the multiplication table");
            Console.WriteLine("11 - Watch a bunch of numbers get sorted");
            Console.WriteLine("12 - Is this a palindrome?");
            Console.WriteLine("13 - What numbers are between these two?");
            Console.WriteLine("14 - Seperate odd and even numbers");
            Console.WriteLine("15 - Return the sum of a bunch of numbers");
            Console.WriteLine("16 - Generate a payer avatar and an enemy");
            Console.WriteLine("17 - Print all player avatars created this session");
            Console.WriteLine("18 - Print all enemies created this session");
            Console.WriteLine("19 - Clean up the console");

            Console.WriteLine();

        }

        private void TakeMenuInput()
        {
            while (shouldRun)
            {
               //Write available options
                WriteMenu();

                //Take input from user
                latestInput = Console.ReadLine();

                //Only accept integears
                //If integear is accepted run associated function then reset the int
                bool _isParsable = Int32.TryParse(latestInput, out latestInputInt);
                if (_isParsable)
                {
                    if (latestInputInt >= 0 && latestInputInt < upperIntLimit)
                    {
                        RunSelectedCommand(latestInputInt);
                        latestInputInt = -1; //After running the command, enter illeagal input as to not accidentally repeat inputs
                    }
                    else
                    {
                        Console.WriteLine("Input not valid, please eneter a number between 0 and " + (upperIntLimit-1));
                    }
                }
                else
                {
                    Console.WriteLine("Input not valid, please eneter a number between 0 and " + (upperIntLimit - 1));
                }
            }

        }

        private void RunSelectedCommand(int index)
        {
            Console.WriteLine("---");
            if (latestInputInt == 0) CloseApplication();//Exit application
            if (latestInputInt == 1) PrintHelloWorld();//Print Hello World
            if (latestInputInt == 2) RepeatNameAndAge();//Take name and age input, print it
            if (latestInputInt == 3) ToggleTextColor();//Toggle text colors
            if (latestInputInt == 4) PrintTodaysDate();//Print Todays date
            if (latestInputInt == 5) CompareTwoNumbers();//Take two numbers and print the larger
            if (latestInputInt == 6) PlayTheGuessingGame();//Generate a random number, have the palyer guess and give clues about smaller/larger
            if (latestInputInt == 7) WriteLineInPostIt();//Take a line from user and save it in post_it.txt
            if (latestInputInt == 8) PrintPostItNote();//Print the contents of post_it.txt
            if (latestInputInt == 9) PrintMathPowers();//Print the square root, power to 2, and power to 10 of a number.
            if (latestInputInt == 10) PrintMultiplicationTable();//Print the Multiplication tables 1 -10.
            if (latestInputInt == 11) SortGeneratedNumber();//Generate and sort 10 random numbers
            if (latestInputInt == 12) CheckPalindromeism();//Check if the input is a palindrome
            if (latestInputInt == 13) PrintNumbersBetween();//Take two numbers and print all integears between them
            if (latestInputInt == 14) SeperateOddsAndEvens();//Take a series of inputs and then seperate them by odd and even numbers
            if (latestInputInt == 15) PrintSumOfInputs();//Take a series of inputs and then seperate them by odd and even numbers
            if (latestInputInt == 16) GenerateAvatarAndEnemey();//Ask for name for a avatar and name of an enemy.
            if (latestInputInt == 17) PrintAllAvatars();//Print all avatars created this session
            if (latestInputInt == 18) PrintAllEnemies();//Print all enemies created this session
            if (latestInputInt == 19) ClearConsole();//Clear all text from the console
        }

        private void EnsurePostIt()
        {
            //If there is no post_it.txt, generate one with contents "Remember the eggs"
            if (File.Exists("post_it.txt") == false)
            {
                File.WriteAllText("post_it.txt", "Remember the eggs");
            }
        } //Used for functionality 6 and 7

        private void CloseApplication()
        {
            shouldRun = false;
        }

        private void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        private void RepeatNameAndAge()
        {
            Console.WriteLine("Please enter your first name, last name, and age (positive whole number). Have them be seperated by a space");
            Console.WriteLine("Example: Jane Doe 47 \n");


            bool _inputVerified = false;
            string[] _user_input;
            string _firstName = "NONE";
            string _lastName = "NONE"; ;
            int _age = -1;

            //Keep asking for user input until it's verified
            while (_inputVerified == false)
            {
                _user_input = Console.ReadLine().Split();
                int _verificationCounter = 0; //Requires 3 checks


                //Check for 3 inputs
                //The third one being a whole number
                //A postivie, whole number
                if (_user_input.Length == 3) 
                {
                    _verificationCounter++; 

                    if (Int32.TryParse(_user_input[2], out _age)) _verificationCounter++;
                    if (_age > 0) _verificationCounter++;

                }
               
                //All verification passed?
                if (_verificationCounter == 3)
                {
                    _inputVerified = true;
                    _firstName = _user_input[0];
                    _lastName = _user_input[1];
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine("Please enter your first name, last name, and age (positive whole number). Have them be seperated by a space");
                    Console.WriteLine("Example: Jane Doe 47 \n");

                    _inputVerified = false;
                    _verificationCounter = 0;
                    _age = -1;
                }
            }

            //Repeat input back
            Console.WriteLine();
            Console.WriteLine("Hello! Nice to meet you " +_firstName + " " + _lastName + ", age " + _age.ToString());

        }

        private void ToggleTextColor()
        {
            //Check if the foreground color is white
            //If not change it to white, otherwise randomize a new color

            if (Console.ForegroundColor != ConsoleColor.Gray)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Console color is now reset to normal");
            }
            else
            {
                Console.WriteLine("Randomizing console color...");

                int _rand = 7; //Default color is indexed at 7 in the enum ConsoleColor
                while (_rand == 7)
                {
                    _rand = new Random().Next(1, 15); //Randomize a ConsoleColor index, excluding black (0), and white(15)
                }

                //Apply and write the new color
                Console.ForegroundColor = (ConsoleColor)_rand; // Get color by index
                Console.Write("The selected color is " + ((ConsoleColor)_rand).ToString() + "! \n");
            }
        }

        private void PrintTodaysDate()
        {
            //Print todays date
            //NOTE: Seems to grab predetermined system settings for formatting specifics
            Console.WriteLine("The date today is " + DateTime.Today.ToString("d"));
        }

        private void CompareTwoNumbers()
        {
            //Ask for two intergers
            //Error check,
            //Print the larger, alternativly if let the user know they are of equal size

            bool _correctInputRecieved = false;
            float _inputA = 0;
            float _inputB = 0;

            //Run until 2 correctly formated value have been entered.
            while (_correctInputRecieved == false)
            {

                //Print instructions and take input
                Console.WriteLine("Please enter two numbers seperated by a space");
                Console.WriteLine("Decimals are denoted with a comma (,)");
                Console.WriteLine("Minimum value of: " + float.MinValue.ToString() + ", max value of: " + float.MaxValue.ToString()) ;
                string[] _userInput = Console.ReadLine().Split();


                //Validate input, require 2 correctly formated numbers
                int _correctInputAmount = 0;

                if (_userInput.Length != 2)
                {
                    Console.WriteLine("Error: 2 numbers not entered");
                    continue;
                }

                //Attempt to parse as floats, allowing for decimal numbers
                if(float.TryParse(_userInput[0], out _inputA))
                {
                    _correctInputAmount++;
                }
                if (float.TryParse(_userInput[1], out _inputB))
                {
                    _correctInputAmount++;
                }


                if (_correctInputAmount >= 2) 
                {
                    _correctInputRecieved = true; 
                }
                else
                {
                    Console.WriteLine("Incorrect input format.");
                }
            }

            Console.WriteLine();

            //Compare and print results
            if (_inputA == _inputB)
            {
                Console.WriteLine(_inputA.ToString() + " is equal in size to " + _inputB.ToString());
            }
            else if (_inputA > _inputB)
            {
                Console.WriteLine(_inputA.ToString() + " is larger than " + _inputB.ToString());
            }
            else
            {
                Console.WriteLine(_inputB.ToString() + " is larger than " + _inputA.ToString());
            }

        }

        private void PlayTheGuessingGame()
        {
            //Generate a random number between 1 and 100
            //Take inputs from the palyer
            //Respond "Larger, smaller, correct"

            Console.WriteLine("I'm thinking of a whole number between 1 and 100, try to guess it! (or enter 0 to give up) \n");

            int _correctNumber = new Random().Next(1, 101); //min inclusive, max exclusive

            //Debug
            /*Console.WriteLine();
             Console.WriteLine("DEBUG::_correctNumber: " + _correctNumber);
             Console.WriteLine();*/

            bool _keepPlaying = true;
            while (_keepPlaying)
            {

                //Read and validate input
                string _guessStr = Console.ReadLine();
                float _guess = -1;
                if(float.TryParse(_guessStr, out _guess) == false) //If failed input, inform player
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("I'm thinking of a whole number, try to guess it (or give up by entering 0) \n");
                    continue;
                }

                //If player entered 0, end game.
                if (_guess == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("You gave up, number was " + _correctNumber.ToString());
                    _keepPlaying = false;
                    Console.WriteLine("Game over! \n");
                    break;
                }

                //Player guessed correct, end game.
                if (_guess == _correctNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("That's right! The number was " + _correctNumber.ToString());
                    _keepPlaying = false;

                    ConsoleColor _previousColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green; //Inform the player of vitory with a green colored text
                    Console.WriteLine("You won! \n");
                    Console.ForegroundColor = _previousColor; //Return text to previous color
                    break;
                }

                //Give clue if the guess was too large or too small.
                if (_guess > _correctNumber)
                {
                    Console.WriteLine("The number I'm thinking of is smaller, try again!");
                }
                if (_guess < _correctNumber)
                {
                    Console.WriteLine("The number I'm thinking of is larger, try again!");
                }

            }

        }

        private void WriteLineInPostIt()
        {
            //take line, write line
            Console.WriteLine("Write a line of text to be added to update the post it note with \n");
            string _lineToSave = Console.ReadLine();

            File.WriteAllText("post_it.txt", _lineToSave);

            Console.WriteLine("Post-it updated!");
        }

        private void PrintPostItNote()
        {
            //Ensure existence of post_it.txt and then read it's contents
            EnsurePostIt();

            Console.WriteLine("The post it says: ");
            string _postItContents = File.ReadAllText("post_it.txt");
            Console.WriteLine(_postItContents + " \n");

        }

        private void PrintMathPowers()
        {
            Console.WriteLine("Enter a postive number, decimal or whole.");
            Console.WriteLine("Decimals are denoted with commas (,) \n");

            //Validate input
            bool _validatedInput = false;
            double _input = -1;

            while (_validatedInput == false)
            {
                string _inputStr = Console.ReadLine();
                if(double.TryParse(_inputStr, out _input))
                {
                    //Ensure number is not negative
                    if (_input > 0)
                    {

                        //If the power to 10 or 2 is too big, inform user
                        if (Math.Pow(_input, 2) > double.MaxValue || Math.Pow(_input, 10) > double.MaxValue)
                        {
                            Console.WriteLine("Your number is too big, it would break the code if powered up. \n");
                        }
                        else //Otherwise proceed
                        {
                            _validatedInput = true;
                        }

                    }
                    else
                    {
                        PrinteMathPowersErrorPrint();
                    }
                }
                else
                {
                    PrinteMathPowersErrorPrint();
                }
            }

            //Do the math
            double _sqr = Math.Pow(_input, 0.5);
            double _pow2 = Math.Pow(_input, 2);
            double _pow10 = Math.Pow(_input, 10);

            //Print the results
            Console.WriteLine("\n The square root of " + _input.ToString() + " is " + _sqr.ToString());
            Console.WriteLine("\n " + _input.ToString() + " to the power of 2 is " + _pow2.ToString());
            Console.WriteLine("\n " + _input.ToString() + " to the power of 10 is " + _pow10.ToString());
            Console.WriteLine();

        }
        private void PrinteMathPowersErrorPrint()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input!");
            Console.WriteLine("Enter a postive number, decimal or whole.");
            Console.WriteLine("Decimals are denoted with commas (,) \n");
        }

        private void PrintMultiplicationTable()
        {
            //Print the multiplication tables
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    string _printSection = "";
                    if (j != 1) _printSection = "\t"; //add indention to all but first sections
                    _printSection += Convert.ToString(j.ToString() + "*" + i.ToString() + "=" + (i * j).ToString());
                    Console.Write(_printSection);
                }
                Console.WriteLine();
            }
        }

        private void SortGeneratedNumber()
        {
            //Generate the determined amount of numbers
            //Then give the user the option to see a bogosort, with a warning
            //Verify their option
            //Run selected sorting method.

            int _numbersToGenerate = 10;
            bool _verifiedInput = false;
            bool _runBogo = false;

            Console.WriteLine("Generating " + _numbersToGenerate.ToString() + " numbers between 1 and 100...");
            int[] _unorderedNumbers = new int[_numbersToGenerate];
            int[] _numbersToOrder = new int[_numbersToGenerate];

            //Generate and print random numbers           
            Random _rand = new Random();
            for (int i = 0; i < _numbersToGenerate; i++)
            {
                _unorderedNumbers[i] = _rand.Next(1, 101);
            }
            _unorderedNumbers.CopyTo(_numbersToOrder, 0);

            Console.WriteLine("Numbers generated: \n");
            PrintIntArray(_unorderedNumbers);

            //Ask for sorting preference
            Console.WriteLine();
            Console.WriteLine("Do you want to see a bogosort?");
            Console.WriteLine("WARNING! This can take quite some time \n If you prefer to be much quicker I suggest the bubble sort.");
            Console.WriteLine("Bogosort? Y/N \n");

            //Verify Y/N input
            while (_verifiedInput == false)
            {
                string _userInput = Console.ReadLine();
                _userInput = _userInput.ToUpper();
                if (_userInput[0] == 'Y' || _userInput[0] == 'N') 
                {
                    _verifiedInput = true;
                    if (_userInput[0] == 'Y')
                    {
                        _runBogo = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine("Bogosort? (Y)es or (N)o");
                    Console.WriteLine("If not, you will be shown a bubble sort instead. \n");
                }
            }

            //Run the selected sorting method
            if (_runBogo)
            {
                BogoSort(_numbersToOrder);
            }
            else
            {
                BubbleSort(_numbersToOrder);
            }


        }
 
        private void PrintIntArray(int[] arrayToPrint) //Used to shorthand print arrays for more fun sorting experience
        {
            //Write the contents of the array on a single line, elements seperated by lines
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                Console.Write(arrayToPrint[i].ToString() + " ");
            }
            Console.WriteLine();
        }

        private void BogoSort(int[] arrayToSort)
        {

            Console.Write("Bogosorting...");

            //Randomize the list, check if it's sorted
            //Repeat until sorted

            bool sorted = false;
            Random rand = new Random();
            int numberofItterations = 0;

            while (sorted == false)
            {
                numberofItterations++;

                //Each element is moved at least once
                for (int i = 0; i < arrayToSort.Length; i++)
                {
                    int newPos = rand.Next(0, arrayToSort.Length);
                    int temp = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[newPos];
                    arrayToSort[newPos] = temp;
                }

                //Print current itteration number and state of list
                Console.Write("Itteration " + numberofItterations.ToString() + ": ");
                PrintIntArray(arrayToSort);

                //Check if it's sorted
                for (int i = 0; i < arrayToSort.Length -1; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i+1])
                    {
                        sorted = false;
                        break;
                    }
                    else
                    {
                        sorted = true;
                    }
                }

                //If the list is sorted let the user know
                if (sorted)
                {
                    Console.WriteLine("The list is sorted!");
                    Console.WriteLine("It took " + numberofItterations.ToString() + " itterations! \n");
                }

            }


        }
        private void BubbleSort(int[] arrayToSort)
        {
            //While the array is not sorted, go through and check two numbers at the time, putting the higher one at the larger index
            //If *any* change was made during an itteration, it will need at least one more to control the array is sorted.
            //If no changes were made the array is sorted and the loop can be exited

            int numberOfItterations = 0;
            bool sorted = false;

            Console.WriteLine();
            Console.WriteLine("Bubble sorting...");

            while (sorted == false)
            {
                sorted = true; //will be changed if not correct
                numberOfItterations++;

                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    //Make the larger number be higher in the list
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        int temp = arrayToSort[i + 1];
                        arrayToSort[i + 1] = arrayToSort[i];
                        arrayToSort[i] = temp;

                        //if no changes were made during a full scann of the list, it's sorted
                        sorted = false;

                        //Print Changes
                        Console.Write("Itteration " + numberOfItterations.ToString() + ": ");
                        PrintIntArray(arrayToSort);
                    }
                }

            }
            Console.WriteLine("Sort completed!");
            Console.WriteLine("Number of itterations: " + numberOfItterations.ToString() + ", the last one didn't make any changes " + " \n");

        }

        private void CheckPalindromeism()
        {
            Console.WriteLine("Please enter a string of text and I'll tell you if it's a palindrome \n");

            //Take user input
            string _userInput = Console.ReadLine();

            //Reverse user input into new string (strings are just char arrays to copy it into one of those and then reverse it)
            char[] _charArray = _userInput.ToCharArray();
            Array.Reverse(_charArray);
            string _reversedInput = new string(_charArray);

            //Compare strings
            if (_userInput.Equals(_reversedInput))
            {
                Console.WriteLine();
                Console.WriteLine(_reversedInput + " IS a palindrome! \n");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(_userInput + " IS NOT a palindrome! \n");
            }
        }

        private void PrintNumbersBetween()
        {
            //Take input
            //Verify input
            //Sort input
            //Print all in-betweens

            Console.WriteLine("Please enter two numbers, seperated by a space");
            Console.WriteLine("Decimals are entered using a comma (,)");
            Console.WriteLine("The max value allowed is " + float.MaxValue.ToString() + " the minimum value allowed is " + float.MinValue.ToString());
            Console.WriteLine();

            bool _inputVerified = false;
            string[] _userInput;
            float _inputA = 0;
            float _inputB = 0;

            //Verify input
            while (_inputVerified == false)
            {
                _userInput = Console.ReadLine().Split();

                if (_userInput.Length == 2)
                {
                    if (float.TryParse(_userInput[0], out _inputA) && float.TryParse(_userInput[1], out _inputB))
                    {
                        _inputVerified = true;

                        //Input is verified, ensure A is larger than B
                        bool _AisLarger = _inputA > _inputB;
                        if (!_AisLarger) //if not, flip them
                        {
                            float _temp = _inputA;
                            _inputA = _inputB;
                            _inputB = _temp;
                        }
                    }
                }

                //Inform user input was not allowed
                if (_inputVerified == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine("Please enter two numbers, seperated by a space");
                    Console.WriteLine("Decimals are entered using a comma (,)");
                    Console.WriteLine("The max value allowed is " + float.MaxValue.ToString() + " the minimum value allowed is " + float.MinValue.ToString());
                    Console.WriteLine();
                }
            }

            //Round up the lower number, round down the higher
            //Print everythgin between them
            Console.WriteLine("All whole numbers between " + _inputB.ToString() + " and " + _inputA.ToString() + " are: " + " \n") ;
            for (double i = Math.Ceiling(_inputB); i <= Math.Floor(_inputA); i++)
            {
                if (i == _inputB || i == _inputA) continue; //exclude the numbers input by the user
                Console.Write(i.ToString() + " ");
            }
            Console.WriteLine();
        }

        private void SeperateOddsAndEvens()
        {
            Console.WriteLine("Please enter a series of whole numbers seperated by spaces");
            Console.WriteLine("Please stay within boundries Minimum value of: " + int.MinValue.ToString() + ", max value of: " + int.MaxValue.ToString());
            Console.WriteLine();


            string[] _userInput;
            bool _inputVerified = false;
            int[] _allInputInts = new int[0]; //Requires initialization for use outside of while loop, size gets overrriden each attempt at parsing user inputs
            List<int> _oddInts = new List<int>();
            List<int> _evenInts = new List<int>();

            //Verify user input
            while (_inputVerified == false)
            {
                _userInput = Console.ReadLine().Split();
                _allInputInts = new int[_userInput.Length];

                for (int i = 0; i < _userInput.Length; i++)
                {

                    //If any input element fails to parse, interrupt verification attempt and request new input
                    //If all input parses correctly, while loop will be exited
                    if (Int32.TryParse(_userInput[i], out _allInputInts[i]) == false)
                    {
                        _inputVerified = false;
                        Console.WriteLine("Please enter a series of whole numbers seperated by spaces");
                        Console.WriteLine("Please stay within boundries Minimum value of: " + int.MinValue.ToString() + ", max value of: " + int.MaxValue.ToString());
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        _inputVerified = true;
                    }
                }
            }

            //Check for remainder after division of 2, if none then the number is even, otherwise it's odd
            for (int i = 0; i < _allInputInts.Length; i++)
            {
                if (_allInputInts[i] % 2 == 0)
                {
                    _evenInts.Add(_allInputInts[i]);
                }
                else
                {
                    _oddInts.Add(_allInputInts[i]);
                }
            }

            //Print the seperated lists
            Console.WriteLine();
            Console.Write("Odd numbers entered: ");
            for (int i = 0; i < _oddInts.Count(); i++)
            {
                Console.Write(_oddInts[i].ToString() + " ");
            }

            Console.WriteLine();
            Console.Write("Even numbers entered: ");
            for (int i = 0; i < _evenInts.Count(); i++)
            {
                Console.Write(_evenInts[i].ToString() + " ");
            }
            Console.WriteLine();
        }

        private void PrintSumOfInputs()
        {
            //Ask for numerical inputs
            //Verify data
            //sum and print

            //NOTE: no check for exceeding float max value

            Console.WriteLine("Please enter a series of numbers seperated by spaces");
            Console.WriteLine("Decimals are denoted with commas (,)");
            Console.WriteLine();

            string[] _userInput;
            bool _inputVerified = false;
            float[] _allInputFloats = new float[0]; //Requires initialization for use outside of while loop, size gets overrriden each attempt at parsing user inputs
            float _sum = 0;

            //Verify user input
            while (_inputVerified == false)
            {
                _userInput = Console.ReadLine().Split();
                _allInputFloats = new float[_userInput.Length];

                for (int i = 0; i < _userInput.Length; i++)
                {
                    //If any input element fails to parse, interrupt verification attempt and request new input
                    //If all input parses correctly, while loop will be exited
                    if (float.TryParse(_userInput[i], out _allInputFloats[i]) == false)
                    {
                        _inputVerified = false;
                        Console.WriteLine("Please enter a series of numbers seperated by spaces");
                        Console.WriteLine("Decimals are denoted with commas (,)");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        _inputVerified = true;
                    }
                }
            }

            //Add all elements
            foreach (float number in _allInputFloats)
            {
                _sum += number;
            }

            //Print the sum
            Console.WriteLine("The sum of all numbers intered is " + _sum.ToString());
            Console.WriteLine();

        }

        private void GenerateAvatarAndEnemey()
        {
            //Ask first for a name for the palyer avatar, then for the name of an enemy
            //Roll 3d6 for health, strength, and luck respectivly
            //Print the characters and their stats
            //Save them in their respective lists

            Random rand = new Random();
            int _hp = 0;
            int _str = 0;
            int _lck = 0;


            Console.WriteLine();
            Console.WriteLine("Please enter a name for your character:");
            string avatarName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Now please enter a name for an enemy character:");
            string enemyName = Console.ReadLine();

            
            for (int i = 0; i < 3; i++)
            {
                _hp += rand.Next(1, 7);
                _str += rand.Next(1, 7);
                _lck += rand.Next(1, 7);
            }
            Character playerAvatar = new Character(avatarName, _hp, _str, _lck);
            playerAvatars.Add(playerAvatar);

            Console.WriteLine();
            Console.WriteLine("Character created! Introducing: ");
            playerAvatar.PrintCharacterInfo();

            //Reset to repurpose for enemy (should be function call)
            _hp = 0;
            _str = 0;
            _lck = 0;

            for (int i = 0; i < 3; i++)
            {
                _hp += rand.Next(1, 7);
                _str += rand.Next(1, 7);
                _lck += rand.Next(1, 7);
            }
            Character enemyCharacter = new Character(enemyName, _hp, _str, _lck);
            enemies.Add(enemyCharacter);

            Console.WriteLine();
            Console.WriteLine("Enemy created! Introducing: ");
            enemyCharacter.PrintCharacterInfo();
        }

        private void PrintAllAvatars()
        {
            if (playerAvatars.Count == 0)
            {
                Console.WriteLine("No players created yet!");
                return;
            }

            Console.WriteLine("Here are all the characters you have made this session: ");
            foreach (Character c in playerAvatars)
            {
                c.PrintCharacterInfo();
            }
        }

        private void PrintAllEnemies()
        {
            if (enemies.Count == 0)
            {
                Console.WriteLine("No enemies created yet!");
                return;
            }

            Console.WriteLine("Here are all the enemies you have made this session: ");
            foreach (Character e in enemies)
            {
                e.PrintCharacterInfo();
            }
        }

        private void ClearConsole()
        {
            Console.Clear();
        }
    }
}
