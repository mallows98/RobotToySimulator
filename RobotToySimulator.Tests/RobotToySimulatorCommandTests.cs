using System;
using Xunit;

namespace RobotToySimulator.Tests
{
    public class RobotToySimulatorCommandTests
    {
        [Theory]
        [InlineData(0,0, (int)CardinalDirection.North, 0, 1, (int)CardinalDirection.North)]
        [InlineData(0,0, (int)CardinalDirection.South, 0, 0, (int)CardinalDirection.South)]
        public void MoveCommand(int inputX, int inputY, int inputDirection, int expectedX, int expectedY, int expectedDirection)
        {
            var robot = new Robot();
            var simulator = new RobotSimulatorCommand();

            simulator.Place(robot, new Position()
            {
                XAxis = inputX,
                YAxis = inputY,
                CardinalDirection = (CardinalDirection) inputDirection
            });

            simulator.Move(robot);

            var currentRobotPosition = simulator.Report(robot);

            Assert.True(currentRobotPosition.XAxis == expectedX
                        && currentRobotPosition.YAxis == expectedY
                        && currentRobotPosition.CardinalDirection == (CardinalDirection)expectedDirection
            );

        }

        





        [Theory]
        [InlineData(0, 0, (int)CardinalDirection.North, 0, 0, (int)CardinalDirection.West)]
        public void LeftCommand(int inputX, int inputY, int inputDirection, int expectedX, int expectedY, int expectedDirection)
        {
            var robot = new Robot();
            var simulator = new RobotSimulatorCommand();

            simulator.Place(robot, new Position()
            {
                XAxis = inputX,
                YAxis = inputY,
                CardinalDirection = (CardinalDirection)inputDirection
            });

            simulator.Left(robot);

            var currentRobotPosition = simulator.Report(robot);

            Assert.True(currentRobotPosition.XAxis == expectedX
                        && currentRobotPosition.YAxis == expectedY
                        && currentRobotPosition.CardinalDirection == (CardinalDirection)expectedDirection
            );

        }

        [Theory]
        [InlineData(1, 3, (int)CardinalDirection.North, 1, 3, (int)CardinalDirection.East)]
        public void RightCommand(int inputX, int inputY, int inputDirection, int expectedX, int expectedY, int expectedDirection)
        {
            var robot = new Robot();
            var simulator = new RobotSimulatorCommand();

            simulator.Place(robot, new Position()
            {
                XAxis = inputX,
                YAxis = inputY,
                CardinalDirection = (CardinalDirection)inputDirection
            });

            simulator.Right(robot);

            var currentRobotPosition = simulator.Report(robot);

            Assert.True(currentRobotPosition.XAxis == expectedX
                        && currentRobotPosition.YAxis == expectedY
                        && currentRobotPosition.CardinalDirection == (CardinalDirection)expectedDirection
            );

        }

        [Fact]
        public void RunMultipleCommands_InputX0Y0East_ReturnX3Y3North()
        {
            var robot = new Robot();
            var simulator = new RobotSimulatorCommand();

            simulator.Place(robot, new Position()
            {
                XAxis = 1,
                YAxis = 2,
                CardinalDirection = CardinalDirection.East
            });

            simulator.Move(robot);
            simulator.Move(robot);
            simulator.Left(robot);
            simulator.Move(robot);

            var currentRobotPosition = simulator.Report(robot);

            Assert.True(currentRobotPosition.XAxis == 3
                        && currentRobotPosition.YAxis == 3
                        && currentRobotPosition.CardinalDirection == CardinalDirection.North
            );

        }

        [Fact]
        public void MoveWithoutPlace_ReturnsArgumentException()
        {
            var robot = new Robot();
            var simulator = new RobotSimulatorCommand();


            Assert.Throws<ArgumentException>(() =>
            {
                simulator.Move(robot);
            });
        }

    }
}
