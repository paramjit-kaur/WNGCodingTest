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
        /// <returns>true/false</returns>
        public bool IdentifyNumber(string number)
        {
            try
            {
                if (!IsDecimalNumber(number))
                {
                    int NumberType = _sequence.IdentifyNumber(Convert.ToInt32(number));
                    if (NumberType == 1)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Identify whether number is a decimal or whole number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsDecimalNumber(string number)
        {
            if (number.Contains('.'))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Identify whether number is zero or not.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>true/false</returns>
        public bool IsZeroNumber(string number)
        {
            if (!IsDecimalNumber(number))
            {
                if (Convert.ToInt32(number) == 0)
                    return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// Generate all the sequence for the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>model object</returns>
        public SequenceModel GenerateSequences(string number)
        {
            try
            {
                SequenceModel sequenceModel = new SequenceModel();//fill the sequence model object
                sequenceModel.Number =Convert.ToInt32(number);

                if (_sequence.GetAllNumbers(sequenceModel.Number).Count > 0)
                    sequenceModel.AllNumberSequence = _sequence.GetAllNumbers(sequenceModel.Number).ToList();

                if (_sequence.GetEvenNumbers(sequenceModel.Number).Count > 0)
                    sequenceModel.EvenNumberSequence = _sequence.GetEvenNumbers(sequenceModel.Number).ToList();

                if (_sequence.GetOddNumbers(sequenceModel.Number).Count > 0)
                    sequenceModel.OddNumberSequence = _sequence.GetOddNumbers(sequenceModel.Number).ToList();

                if (_sequence.GetFibonacciNumbers(sequenceModel.Number).Count > 0)
                    sequenceModel.FibonacciNumberSequence = _sequence.GetFibonacciNumbers(sequenceModel.Number).ToList();

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
        SequenceModel GenerateSequences(string number);
        bool IdentifyNumber(string number);
        bool IsDecimalNumber(string number);
        bool IsZeroNumber(string number);
    }
}