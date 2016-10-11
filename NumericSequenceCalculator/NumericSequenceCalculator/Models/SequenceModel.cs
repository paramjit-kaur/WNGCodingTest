using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NumericSequenceCalculator.Models
{
    public class SequenceModel
    {
        [Required(ErrorMessage="A number must be entered.")]
        public int Number { get; set; }

        public List<string> AllNumberSequence { get; set; }

        public List<string> OddNumberSequence { get; set; }

        public List<string> EvenNumberSequence { get; set; }

        public List<string> FibonacciNumberSequence { get; set; }

    }
}