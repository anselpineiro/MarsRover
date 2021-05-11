using System;
using System.Text.RegularExpressions;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gridBounds = getGridBounds().Split(" ");

            ExplorationGrid grid = new ExplorationGrid(Int32.Parse(gridBounds[0]), Int32.Parse(gridBounds[1]));

            setPosition(grid);

            performInstructions(grid, getInstructions());

            Console.WriteLine("Rover Position: {0}\r\n", grid.GetRoverPosition());


            setPosition(grid);

            performInstructions(grid, getInstructions());

            Console.WriteLine("Rover Position: {0}", grid.GetRoverPosition());



        }


        private static void performInstructions(ExplorationGrid grid, string instructions)
        {

            bool instructionPerformed = true;

            foreach (Char instruction in instructions)
            {
                instructionPerformed = grid.PerformInstruction((RoverInstruction)Enum.Parse(typeof(RoverInstruction), instruction.ToString()));
                if (!instructionPerformed)
                {
                    Console.WriteLine("Error.  Rover out of bounds.  Aborting instructions.");
                    break;
                }
            }

            
        }

        private static string getGridBounds()
        {
            Console.WriteLine("Enter Grid Bounds in format: X Y");
            String gridBounds = Console.ReadLine().TrimEnd();

            Regex regex = new Regex(@"^[\d ]*$");

            while (!regex.IsMatch(gridBounds) && gridBounds.Split(" ").Length != 2)
            {
                Console.WriteLine("Invalid bounds.  Please enter in the format: X Y");
                gridBounds = Console.ReadLine();
            }

            return gridBounds;
        }

        private static string getInitialPosition()
        {
            String initialPosition;

            bool isValid = false;

            do
            {
                Console.WriteLine("Enter Rover Position in the format: X Y Z");
                String invalidMessage = "Invalid Input!";
                initialPosition = Console.ReadLine().TrimEnd();

                String[] split = initialPosition.Split(" ");

                

                if (split.Length != 3)
                {
                    Console.WriteLine(invalidMessage);
                    continue;
                }

                int intValue = 0;

                if (!Int32.TryParse(split[0], out intValue) || !Int32.TryParse(split[1], out intValue))
                {
                    Console.WriteLine(invalidMessage);
                    continue;
                }



                if (split[2] != "N" && split[2] != "E" && split[2] != "S" && split[2] != "W")
                {
                    Console.WriteLine(invalidMessage);
                    continue;
                }

                isValid = true;

            } while (!isValid);


            return initialPosition;
        }

        private static string getInstructions()
        {
            String instructions;
            bool isValid = true;
            do
            {
                isValid = true;
                Console.WriteLine("Enter instructions without spaces (accepted values L, R, M): ");
                instructions = Console.ReadLine().TrimEnd();


                foreach (Char c in instructions.ToCharArray())
                {
                    if (c != 'L' && c != 'R' && c != 'M')
                    {
                        isValid = false;
                        Console.WriteLine("Invalid Format!");
                        break;
                    }
                }
            } while (!isValid);

            return instructions;
            
        }

        private static void setPosition(ExplorationGrid grid)
        {
            

            bool inBounds = true;

            do
            {
                string[] initialPosition = getInitialPosition().Split(" ");

                inBounds = grid.ConfirmPosition(Int32.Parse(initialPosition[0]), Int32.Parse(initialPosition[1]), char.Parse(initialPosition[2]));

                if (!inBounds)
                    Console.WriteLine("Mars Rover cannot leave the bounds of the map.  Please enter valid position.\r\n");
            } while (!inBounds);
        }
    }
}
