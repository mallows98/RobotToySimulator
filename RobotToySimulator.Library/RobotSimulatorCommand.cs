using System;

namespace RobotToySimulator
{
    public class RobotSimulatorCommand : ISimulatorCommand
    {
        public void Left(Robot robot)
        {
            switch (robot.Position.CardinalDirection)
            {
                case CardinalDirection.North:
                    robot.Position.CardinalDirection = CardinalDirection.West;
                    break;
                case CardinalDirection.South:
                    robot.Position.CardinalDirection = CardinalDirection.East;
                    break;
                case CardinalDirection.East:
                    robot.Position.CardinalDirection = CardinalDirection.North;
                    break;
                case CardinalDirection.West:
                    robot.Position.CardinalDirection = CardinalDirection.South;
                    break;
            }
        }

        public void Move(Robot robot)
        {

            var initialPosition = robot.Position;

            switch (robot.Position.CardinalDirection)
            {
                case CardinalDirection.North:
                    robot.Position.YAxis++;
                    break;
                case CardinalDirection.South:
                    robot.Position.YAxis--;
                    break;
                case CardinalDirection.East:
                    robot.Position.XAxis++;
                    break;
                case CardinalDirection.West:
                    robot.Position.XAxis--;
                    break;
            }

        }

        public void Place(Robot robot, Position position)
        {
            robot.Position = position;
        }

        public PositionStatus Report(Robot robot)
        {
            var status = new PositionStatus(robot.Position);
            status.Message = status.IsPositionValid
                ? "Position valid"
                : "Position is out of bounds";
            return status;
        }

        public void Right(Robot robot)
        {
            switch (robot.Position.CardinalDirection)
            {
                case CardinalDirection.North:
                    robot.Position.CardinalDirection = CardinalDirection.East;
                    break;
                case CardinalDirection.South:
                    robot.Position.CardinalDirection = CardinalDirection.West;
                    break;
                case CardinalDirection.East:
                    robot.Position.CardinalDirection = CardinalDirection.South;
                    break;
                case CardinalDirection.West:
                    robot.Position.CardinalDirection = CardinalDirection.North;
                    break;
            }
        }

        
    }
}