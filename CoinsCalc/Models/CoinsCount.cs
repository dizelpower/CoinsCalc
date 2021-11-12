namespace CoinsCalc
{

    /// <summary>
    /// coins db struct.
    /// </summary>
    public class CoinsCount
    {
        public int CoinsCount_1cnt { get; internal set; }
        public int CoinsCount_2cnt { get; internal set; }
        public int CoinsCount_5cnt { get; internal set; }
        public int CoinsCount_10cnt { get; internal set; }
        public int CoinsCount_20cnt { get; internal set; }
        public int CoinsCount_50cnt { get; internal set; }
        public decimal TotalAmount { get; internal set; }
    }
}
