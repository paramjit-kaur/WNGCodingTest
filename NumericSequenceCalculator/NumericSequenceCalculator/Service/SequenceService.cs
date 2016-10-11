using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NumericSequenceCalculator.Models;

namespace NumericSequenceCalculator.Service
{
    public class SequenceService : ISequenceService
    {

        ISequence _sequence;


        public SequenceService(ISequence sequence)
        {
            _sequence = sequence;

        }

        /// <summary>
        /// Identify whether number is positive or negative.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>boolean</returns>
        public bool IdentifyNumber(string number)
        {
            int NumberType = _sequence.IdentifyNumber(Convert.ToInt32(number));
            if (NumberType == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Generate all the sequence for the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public SequenceModel GenerateSequences(string number)
        {
            SequenceModel sequenceModel = new SequenceModel();

            return sequenceModel;
        }
    }

    public interface ISequenceService
    {
        SequenceModel GenerateSequences(string number);
        bool IdentifyNumber(string number);
    }
}