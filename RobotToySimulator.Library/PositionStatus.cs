namespace RobotToySimulator
{
    public class PositionStatus
    {
        public PositionStatus(Position currentPosition)
        {
            CurrentPosition = currentPosition;
        }


        public bool IsPositionValid
        {
            get
            {
                if (CurrentPosition == null)
                {
                    return false;
                }

                return (CurrentPosition.XAxis >= 0 &&
                        CurrentPosition.XAxis <= 5 &&
                        CurrentPosition.YAxis >= 0 &&
                        CurrentPosition.YAxis <= 5);
            }
        }


        public string Message { get; set; }
        public Position CurrentPosition { get; set; }
    }
}