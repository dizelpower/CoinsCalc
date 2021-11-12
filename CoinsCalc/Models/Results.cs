namespace CoinsCalc
{
    /// <summary>
    /// Results after coins add operation 
    /// </summary>
    class Results
    {
        public CoinsCount CoinsCount { get; internal set; }
        public string TextMessage { get; internal set; }
        public bool Error { get; internal set; }
    }
}
