namespace RideTheHorse
{
    public class Cell
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public int Value { get; set; }

        public Cell(int row, int column, int value = 0)
        {
            this.Row = row;
            this.Column = column;
            this.Value = value;
        }
    }
}
