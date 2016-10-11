using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.Models
{
    public class Sequence : ISequence
    {
        public int IdentifyNumber(int number)
        {
            return Math.Sign(number);
        }
      
    }
    public interface ISequence
    {
        int IdentifyNumber(int number);       
    }
}