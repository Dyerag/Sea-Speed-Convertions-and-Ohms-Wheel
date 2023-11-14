namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //This method is false, so as to make the do-while loop repeat. If option 3 is picked, the loop is exited and the program closes
            var quit = false;

            //The loop that contains the program. Made in conjunction with the switch inside, to handle what happens if an input, that doesn't do anything is made.
            //Exiting one of the calculators in the switch. or defaulting, brings you back here. The loop is repeated, until the third option is selected
            do
            {
                //clears the window, so the text wont repeatedly be written onscreen row after row, as well as after returning from a calculator
                Console.Clear();
                //This is just some text about how to operate the menu
                Console.WriteLine("Hvad vil du gerne beregne?\n");
                Console.WriteLine("1 for at convertere mellem knob og kilometer\n2 for at beregne Watt, volt, ampere og ohms\n3 for at lukke programmet");

                /*The switch is in charge of userinput. It takes said input, and either returns a default if none of the options cover it.
                 * Or brings the user to either the Knot and km/h calculator, or the Ohms calculator. It can change the bool that controls the loop*/
                switch (Console.ReadKey(true).Key)
                {
                    //Case 1 bringes the user to the knot and km/h calculator menu
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Menu.Sea();
                        break;

                    //Case 2 brings the user to the Ohm calculator menu
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Menu.Öhm();
                        break;

                    //Case 3 changes the bool that controls the loop to true, thereby allowing the program to leave the loop and close
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        quit = true;
                        break;

                    //Incase one of the above inputs weren't choosen, default will be run. In this case, it only tells the user, they have to pick one of the aformentioned options
                    default:
                        Console.WriteLine("\nDer er ingen hemelige input. Kun de tre du ser på skærmen :)");
                        Thread.Sleep(3000);
                        break;
                }
                //when quit is false (which is its initial value) the loop continues
            } while (quit == false);
        }
    }
}