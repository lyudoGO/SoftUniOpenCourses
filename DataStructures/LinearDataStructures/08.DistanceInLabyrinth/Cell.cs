namespace _08.DistanceInLabyrinth
{
    public struct Cell
    {
        public int Value;
        public int Row;
        public int Col;

        public Cell(int row, int col, int value)
        {
            this.Value = value;
            this.Row = row;
            this.Col = col;
        }
    }
}
