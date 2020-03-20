namespace RobotToySimulator.Library
{
    public class Position
    {
        public Position()
        {
        }

        public Position(int xAxis, int yAxis, CardinalDirection cardinalDirection)
        {
            XAxis = xAxis;
            YAxis = yAxis;
            CardinalDirection = cardinalDirection;
        }

        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public CardinalDirection CardinalDirection { get; set; }
    }
}