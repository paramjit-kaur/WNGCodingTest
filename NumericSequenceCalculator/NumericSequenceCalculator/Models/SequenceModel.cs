using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Models
{
    public class SequenceModel
    {
        public int Number { get; set; }

        public List<int> AllNumberSequence { get; set; }

        public List<int> OddNumberSequence { get; set; }

        public List<int> EvenNumberSequence { get; set; }

        public List<int> FibonacciNumberSequence { get; set; }

    }
}