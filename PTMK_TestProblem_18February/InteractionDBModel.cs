using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTMK_TestProblem_18February
{
    public interface IInteractionDB 
    {
        void MakeTable();

        void WriteTable(string fullName, DateTime dateBirth, char gender);

        void OutUniquePosition();

        void AutoWrite();

        float GetСriterionFM();
    }

    internal class InteractionDB : IInteractionDB
    {
        public InteractionDB()
        {

        }

        public void AutoWrite()
        {
            throw new NotImplementedException();
        }

        public float GetСriterionFM()
        {
            throw new NotImplementedException();
        }

        public void MakeTable()
        {
            throw new NotImplementedException();
        }

        public void OutUniquePosition()
        {
            throw new NotImplementedException();
        }

        public void WriteTable(string fullName, DateTime dateBirth, char gender)
        {
            throw new NotImplementedException();
        }
    }
}
