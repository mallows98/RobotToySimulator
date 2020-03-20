using System;

namespace RobotToySimulator.Library
{
    public class RobotSimulatorCommand : ISimulatorCommand
    {
        public void Left(Robot robot)
        {
            if (robot == null)
                throw new ArgumentException("Robot does not exist");

            if (robot.Position == null)
                throw new ArgumentException("Robot positioning is not set");

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
            if(robot == null)
                throw new ArgumentException("Robot does not exist");

            if (robot.Position == null)
                throw new ArgumentException("Robot positioning is not set");

            var initialPosition = new Position
            {
                XAxis = robot.Position.XAxis,
                YAxis = robot.Position.YAxis,
                CardinalDirection = robot.Position.CardinalDirection
            };

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

            var positionStatus = new PositionStatus(robot.Position);
            if (!positionStatus.IsPositionValid)
                robot.Position = initialPosition;
        }

        public void Place(Robot robot, Position position)
        {
            if (robot == null)
                throw new ArgumentException("Robot does not exist");

            var positionStatus = new PositionStatus(position);

            robot.Position = (!positionStatus.IsPositionValid)
                ? new Position { CardinalDirection = CardinalDirection.North, XAxis = 0, YAxis = 0} : position;
        }

        public PositionStatus Report(Robot robot)
        {
            if (robot == null)
                throw new ArgumentException("Robot does not exist");

            var status = new PositionStatus(robot.Position);
            status.Message = status.IsPositionValid
                ? "Position valid"
                : "Position is out of bounds or null";
            return status;
        }

        public void Right(Robot robot)
        {
            if (robot == null)
                throw new ArgumentException("Robot does not exist");

            if (robot.Position == null)
                throw new ArgumentException("Robot positioning is not set");

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