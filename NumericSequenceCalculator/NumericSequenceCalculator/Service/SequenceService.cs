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
            try
            {
                int NumberType = _sequence.IdentifyNumber(Convert.ToInt32(number));
                if (NumberType == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Generate all the sequence for the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public SequenceModel GenerateSequences(int number)
        {
            try
            {
                SequenceModel sequenceModel = new SequenceModel();
                sequenceModel.Number = number;
                sequenceModel.AllNumberSequence = _sequence.GetAllNumbers(number).ToList();
                sequenceModel.EvenNumberSequence = _sequence.GetEvenNumbers(number).ToList();
                sequenceModel.OddNumberSequence = _sequence.GetOddNumbers(number).ToList();
                sequenceModel.FibonacciNumberSequence = _sequence.GetFibonacciNumbers(number).ToList();

                return sequenceModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public interface ISequenceService
    {
        SequenceModel GenerateSequences(int number);
        bool IdentifyNumber(string number);
    }
}