namespace RobotToySimulator.Library
{
    public interface ISimulatorCommand
    {
        void Place(Robot robot, Position position);
        void Move(Robot robot);
        void Left(Robot robot);
        void Right(Robot robot);
        PositionStatus Report(Robot robot);
    }
}