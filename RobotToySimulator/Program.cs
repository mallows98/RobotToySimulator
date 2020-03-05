using System.Text.RegularExpressions;
using RobotToySimulator.Library;

namespace RobotToySimulator.Console
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string commandSelected = null;
            Robot robot = null;
            var simulatorCommand = new RobotSimulatorCommand();
            PositionStatus robotPositionStatus = null;

            do
            {
                try
                {
                    Console.WriteLine("What do you want to do? Please select one of the actions below:");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("C - Create a robot");
                    Console.WriteLine("P - Place the robot on a starting position");
                    Console.WriteLine("M - Move a robot");
                    Console.WriteLine("L - Move the robot 90 degrees to the Left");
                    Console.WriteLine("R - Move the robot 90 degrees to the Right");
                    Console.WriteLine("S - Show the robot's current position");
                    Console.WriteLine("Q - Quit");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Enter command here:");
                    commandSelected = Console.ReadLine();

                    switch (commandSelected.ToUpper())
                    {
                        case "C":
                            robot = new Robot();
                            Console.WriteLine("Robot created.");
                            Console.WriteLine("*******************");
                            break;
                        case "P":
                            Console.WriteLine("Please enter its starting position (x, y, [NORTH|SOUTH|EAST|WEST]):");
                            var input = Console.ReadLine();

                            if (!Regex.IsMatch(input, @"\(\d,\d,(NORTH|SOUTH|EAST|WEST|north|south|east|west)\)"))
                            {
                                Console.WriteLine("Invalid coordinates. Please try again");
                                break;
                            }

                            var inputItems = input.TrimStart('(').TrimEnd(')').Split(',');

                            int.TryParse(inputItems[0], out var xAxis);
                            int.TryParse(inputItems[1], out var yAxis);
                            Enum.TryParse(typeof(CardinalDirection), inputItems[2], true, out var direction);

                            robot.Position = new Position(xAxis, yAxis, (CardinalDirection)direction);
                            robotPositionStatus = new PositionStatus(robot.Position);
                            if (!robotPositionStatus.IsPositionValid)
                            {
                                Console.WriteLine($"{robotPositionStatus.Message}");
                                break;
                            }

                            simulatorCommand.Place(robot, robot.Position);
                            Console.WriteLine("Robot now positioned.");
                            Console.WriteLine("*******************");
                            break;

                        case "M":
                            simulatorCommand.Move(robot);
                            Console.WriteLine("Robot has been moved");
                            Console.WriteLine("*******************");
                            break;

                        case "L":
                            simulatorCommand.Left(robot);
                            Console.WriteLine("Robot has moved to its left.");
                            Console.WriteLine("*******************");
                            break;

                        case "R":
                            simulatorCommand.Right(robot);
                            Console.WriteLine("Robot has moved to its right.");
                            Console.WriteLine("*******************");
                            break;

                        case "S":
                            robotPositionStatus = new PositionStatus(robot.Position);

                            Console.WriteLine($"Robot is placed at ({robotPositionStatus.CurrentPosition.XAxis}," +
                                              $"{robotPositionStatus.CurrentPosition.YAxis}) " +
                                              $"{Enum.GetName(typeof(CardinalDirection), robotPositionStatus.CurrentPosition.CardinalDirection)}");
                            break;
                        default:
                            Console.WriteLine("Invalid selection");
                            Console.WriteLine("*******************");
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (commandSelected is null || commandSelected != "Q" || commandSelected != "q");

            Environment.Exit(0);
        }
    }
}
