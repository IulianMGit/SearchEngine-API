using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data
{
    public class TermWeightAndPositionPair
    {
        public TermWeightAndPositionPair(double weight, int position)
        {
            Weight = weight;
            Position = position;
        }
        public double Weight { get; set; }
        public int Position { get; set; }
    }
}
