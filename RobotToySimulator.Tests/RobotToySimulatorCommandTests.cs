using System;
using RobotToySimulator.Library;
using Xunit;

namespace RobotToySimulator.Tests
{
    public class RobotToySimulatorCommandTests
    {
        [Theory]
        [InlineData(0, 0, (int)CardinalDirection.North, 0, 0, (int)CardinalDirection.North)]
        [InlineData(4, 3, (int)CardinalDirection.South, 4, 3, (int)CardinalDirection.South)]
        [InlineData(6, 3, (int)CardinalDirection.South, 0, 0, (int)CardinalDirection.North)]
        public void PlaceCommand(int inputX, int inputY, int inputDirection, int expectedX, int expectedY,
            int expectedDirection)
        {
            var robot = new Robot();
            var simulator = new RobotSimulatorCommand();

            simulator.Place(robot, new Position()
            {
                XAxis = inputX,
                YAxis = inputY,
                CardinalDirection = (CardinalDirection)inputDirection
            });

            var positionStatus = simulator.Report(robot);

            Assert.True(positionStatus.CurrentPosition.XAxis == expectedX
                        && positionStatus.CurrentPosition.YAxis == expectedY
                        && positionStatus.CurrentPosition.CardinalDirection == (CardinalDirection)expectedDirection
            );
        }


        [Theory]
        [InlineData(0,0, (int)CardinalDirection.North, 0, 1, (int)CardinalDirection.North)]
        [InlineData(0,0, (int)CardinalDirection.South, 0, 0, (int)CardinalDirection.South)]
        [InlineData(6,1, (int)CardinalDirection.South, 0, 1, (int)CardinalDirection.North)]
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

            var positionStatus = simulator.Report(robot);

            Assert.True(positionStatus.CurrentPosition.XAxis == expectedX
                        && positionStatus.CurrentPosition.YAxis == expectedY
                        && positionStatus.CurrentPosition.CardinalDirection == (CardinalDirection)expectedDirection
            );

        }

        [Theory]
        [InlineData(0, 0, (int)CardinalDirection.North, 0, 0, (int)CardinalDirection.West)]
        [InlineData(0, 0, (int)CardinalDirection.South, 0, 0, (int)CardinalDirection.East)]
        [InlineData(0, 0, (int)CardinalDirection.East, 0, 0, (int)CardinalDirection.North)]
        [InlineData(0, 0, (int)CardinalDirection.West, 0, 0, (int)CardinalDirection.South)]
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

            var positionStatus = simulator.Report(robot);

            Assert.True(positionStatus.CurrentPosition.XAxis == expectedX
                       && positionStatus.CurrentPosition.YAxis == expectedY
                       && positionStatus.CurrentPosition.CardinalDirection == (CardinalDirection)expectedDirection
           );

        }

        [Theory]
        [InlineData(1, 3, (int)CardinalDirection.North, 1, 3, (int)CardinalDirection.East)]
        [InlineData(1, 3, (int)CardinalDirection.South, 1, 3, (int)CardinalDirection.West)]
        [InlineData(1, 3, (int)CardinalDirection.East, 1, 3, (int)CardinalDirection.South)]
        [InlineData(1, 3, (int)CardinalDirection.West, 1, 3, (int)CardinalDirection.North)]
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

            var positionStatus = simulator.Report(robot);

            Assert.True(positionStatus.CurrentPosition.XAxis == expectedX
                      && positionStatus.CurrentPosition.YAxis == expectedY
                      && positionStatus.CurrentPosition.CardinalDirection == (CardinalDirection)expectedDirection
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

            var positionStatus = simulator.Report(robot);

            Assert.True(positionStatus.CurrentPosition.XAxis == 3
                        && positionStatus.CurrentPosition.YAxis == 3
                        && positionStatus.CurrentPosition.CardinalDirection == CardinalDirection.North
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
