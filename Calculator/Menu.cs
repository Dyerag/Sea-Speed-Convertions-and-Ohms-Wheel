using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Menu
    {
        /// <summary>
        /// The method that converts between km/h and knots
        /// </summary>
        public static void Sea()
        {
            //preparing an instance of the class containing all the methods to calculate conversions
            var Travel = new SpeedConversions();
            //The variable that contains the userinput, efter it has been verified to actually be a number
            double input;
            // This variable is the check for what to do after, after doing the calculation. it is used at the end of the do-while loop
            int quit;

            do
            {
                //clears the screen of the startmenu, or prior text from this window from an invalid input
                Console.Clear();
                Console.WriteLine("Hvad vil du gerne konvertere?\n1) Kilometer i timen til knob\n2) Knob til kilomoter i timen");

                //The funktion that checks which conversion the user chose, and grabs the corresponding method
                switch (Console.ReadKey(true).Key)
                {
                    //If the convertion km/h to knot is chosen, this is the switch case that calculates it
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        //Clears the screen before asking for the speed in km/h
                        Console.Clear();
                        Console.WriteLine("Hvor mange km/t kører den?");

                        /* within the conditions of the while loop, the conversion of the user input from string to double is made. If it's successful,
                         * the result is put in the input variable, and trypass returns true, which skips the loop. If the userinput can't be made into a double,
                         * the loop is run, which only contains a writeline that says what was written, was not valid.*/
                        while (!double.TryParse(Console.ReadLine(), out input))
                        {
                            Console.WriteLine("Tal, og kun tal, må og skal inputtes\n");
                        }

                        //Clears the screen, before writing the input and result of the conversion onscreen
                        Console.Clear();
                        Console.WriteLine($"{input} km/t svarer til {Math.Round(Travel.KmHToKnot(input), 2)} knob");
                        break;

                    // the converter for knots to km/h
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        //Clears the screen before asking for the speed in knots
                        Console.Clear();
                        Console.WriteLine("Hvor mange knob sejler den?");

                        /* within the conditions of the while loop, the conversion of the user input from string to double is made. If it's successful,
                         * the result is put in the input variable, and trypass returns true, which skips the loop. If the userinput can't be made into a double,
                         * the loop is run, which only contains a writeline that says what was written, was not valid.*/
                        while (!double.TryParse(Console.ReadLine(), out input))
                        {
                            Console.WriteLine("Tal, og kun tal, må og skal inputtes\n");
                        }

                        //Clears the screen, before writing the input and result of the conversion onscreen
                        Console.Clear();
                        Console.WriteLine($"{input} knob svarer til {Math.Round(Travel.KnotToKmH(input), 2)} km/t");
                        break;

                    // this is what happens when the user inputs an option not in the switchcase.
                    // It writes a message on screen, about how the onscreen options are the only one
                    default:
                        Console.WriteLine("De her er de eneste muligheder");
                        Thread.Sleep(3000);
                        break;
                }

                /* The code her comes after the result of the given conversion is outputtet, but waits a bit before allowing program to continue. 
                 * The user is then prompted to input whether or not they wish to return to the main menu, do use this conversion again, or close the program*/
                Thread.Sleep(2000);
                Console.WriteLine("\n\tTilbage til startmenu\tLav Sø-converteringer igen\tLuk program");
                Console.WriteLine("\t\t[1]\t\t\t[2]\t\t\t[3]");

                // The variable is reset, to make sure  
                quit = 0;

                //This loop contains the process for whether the user wants to return to the first menu, use this calculator again, or close the program
                //would have been easier if i used a do-while instead, but i chose to try and use another loop for the sake of variety
                while (quit == 0)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        // This case allows both loops to be exited, and leads back to the startmenu
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            quit = 2;
                            break;

                        //This case lets the program exit the first loop, and repeat this method again
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            quit = 1;
                            break;

                        //this case just closes the program
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            Environment.Exit(0);
                            break;

                        //Text to be written on screen incase the an input which isn't one of the options here, is chosen
                        /* Note: the condition for the nested loop, in which this switch case is located, is only changed by the first two cases.
                         * The switch will therefore be repeated if default occur*/
                        default:
                            Console.WriteLine("vær sød at vælge en af de tre muligheder");
                            break;
                    }
                }
                //The end the loop containing the main part of the method
            } while (quit == 1);
        }

        /// <summary>
        /// calculates power, voltage, resistance, or current, using two of the other three
        /// </summary>
        public static void Öhm()
        {
            //premade declarations
            double? input1, input2, result = null;
            int CalcMethod = 0, quit;
            IEnergy? resultCalculations = null;
            //The loop that runs the main part of the method
            do
            {
                input1 = null; input2 = null;
                // This loop is to guarantee that the user only inputs one of the four valid input choices
                for (int i = 0; i < 1 || i > 4;)
                {
                    // This text lists the options for what the user would like to calculate
                    Console.Clear();
                    Console.WriteLine("Hvad vil du gerne beregne?\n\n\tWatt\tVolt\tOhm\tAmpere");
                    Console.WriteLine("\t[1]\t[2]\t[3]\t[4]\n");

                    Console.Write("dit valg: ");
                    // This if statement is where userinput is done. If the input doesn't contain only integers, the instantiation of the classobject is not made
                    if (int.TryParse(Console.ReadLine(), out i))
                    {
                        // The variable declared here, will contain the classobject that has the method to calculate whatever energy the user picks
                        // The Class that is instantiated, is picked in the method based on what was input just prior
                        resultCalculations = OhmInstans(i);
                    }
                    // The code in the else statements only purpose, is to notify the user, that their choice most only contain numbers
                    else
                    {
                        Console.WriteLine("Valget skal bestå af kun tal");
                        Thread.Sleep(3000);
                    }
                }

                //tells the User what they have picked, followed by the options to calculate it
                Console.Clear();
                Console.WriteLine($"Så du har valgt at beregne {resultCalculations.Name()}. Hvad vil du bruger til at beregne det?\n");

                Console.WriteLine($"\n{resultCalculations.Options()}\n\t[1]\t\t\t[2]\t\t\t[3]");

                // the Loop that makes sure that whatever the user inputs, is one of the choices
                do
                {
                    //if the input isnt a number, the user will be told that it must be a number
                    if (!int.TryParse(Console.ReadLine(), out CalcMethod))
                        Console.WriteLine("Det må kun være tal\n");
                    // If the input is a number, but not one of the three options, a message saying it has to be one of the three is printed
                    else if (CalcMethod < 1 || CalcMethod > 3)
                        Console.WriteLine("Det kan ikke være andet end de tre her");
                    // The loop is exited once a number within the scope
                } while (CalcMethod < 1 || CalcMethod > 3);

                //takes the entire string of options to calculate the result with, and divides it in an array
                String[] valueNames = resultCalculations.Options().Split(' ', '\t');

                /*This array contains the indexes of valueNames array. specifikly the index of the names of the values used,
                 * so that they can be used to tell the user what they are supposed to input*/
                int[] nameIndex = Index(CalcMethod);

                Console.Clear();
                //block of code for inputting the first value
                for (double temp; input1 == null;)
                {
                    Console.Write($"{valueNames[nameIndex[0]]}: ");
                    // Tries to conjvert the input into a double. If impossible, print that input must be just numbers
                    // If valid, Input will be put in the temp variable made for the loop, as it cannot be directly into input1, since its nullable
                    if (!double.TryParse(Console.ReadLine(), out temp))
                    {
                        Console.WriteLine("Det Skal være tal");
                        Console.ReadKey();
                    }
                    // If input is valid, the temp variable has its contents put in input1
                    else
                        input1 = temp;
                }

                //same applies here, as did the block of code right above
                Console.Clear();
                for (double temp; input2 == null;)
                {
                    Console.Write($"{valueNames[nameIndex[1]]}: ");
                    if (!double.TryParse(Console.ReadLine(), out temp))
                    {
                        Console.WriteLine("Det Skal være tal");
                        Console.ReadKey();
                    }
                    else
                        input2 = temp;
                }

                // This switch uses the userinput made prior when choosing which values to use to calculate the result, to pick the right method
                switch (CalcMethod)
                {
                    case 1:
                        result = resultCalculations.Calc1(input1, input2);
                        break;
                    case 2:
                        result = resultCalculations.Calc2(input1, input2);
                        break;
                    case 3:
                        result = resultCalculations.Calc3(input1, input2);
                        break;
                }

                // This Prints the values that were input, and what the results were
                Console.Clear();
                Console.WriteLine($"{input1} {valueNames[nameIndex[0]]} og {input2} {valueNames[nameIndex[1]]} svarer til {result} {resultCalculations.Name()}.");
                Console.ReadKey(true);

                //options on whether to do this again, return to the startmenu, or close the program
                Console.WriteLine("\n\tTilbage til startmenu\tBeregn Ohms lov igen\tLuk program");
                Console.WriteLine("\t\t[1]\t\t\t[2]\t\t\t[3]");

                // The variable is reset, to make sure  
                quit = 0;

                //This loop contains the process for whether the user wants to return to the first menu, use this calculator again, or close the program
                //would have been easier if i used a do-while instead, but i chose to try and use another loop for the sake of variety
                while (quit == 0)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        // This case allows both loops to be exited, and leads back to the startmenu
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            quit = 2;
                            break;

                        //This case lets the program exit the first loop, and repeat this method again
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            quit = 1;
                            break;

                        //this case just closes the program
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            Environment.Exit(0);
                            break;

                        //Text to be written on screen incase the an input which isn't one of the options here, is chosen
                        /* Note: the condition for the nested loop, in which this switch case is located, is only changed by the first two cases.
                         * The switch will therefore be repeated if default occur*/
                        default:
                            Console.WriteLine("vær sød at vælge en af de tre muligheder");
                            break;
                    }
                }

            } while (quit == 1);
        }

        // Apperantly it's possible to use an interface as a returntype
        /// <summary>
        /// The Method used to initialise the class that i'll be used to calculate the choosen object of Ohms wheel
        /// </summary>
        /// <param name="Choice"></param>
        /// <returns></returns>
        internal static IEnergy OhmInstans(int Choice)
        {
            switch (Choice)
            {
                case 1:
                    return new Power();
                    break;

                case 2:
                    return new Voltage();
                    break;

                case 3:
                    return new Resistance();
                    break;

                case 4:
                    return new Current();
                    break;

                default:
                    Console.WriteLine("Valget må ikke være andet end de fire muligheder på skærmen");
                    Thread.Sleep(4000);
                    return null;
                    break;
            }
        }

        /// <summary>
        /// Used to get the indexes containing the names of the values that are to be input, so they can be printed on screen
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        internal static int[] Index(int i)
        {
            switch (i)
            {
                case 1:
                    int[] arrayslots = { 1, 3 };
                    return arrayslots;
                    break;

                case 2:
                    int[] arrayslots2 = { 5, 7 };
                    return arrayslots2;
                    break;

                case 3:
                    int[] arrayslots3 = { 9, 11 };
                    return arrayslots3;
                    break;

                default:
                    return null;
                    break;
            }
        }
    }
}
