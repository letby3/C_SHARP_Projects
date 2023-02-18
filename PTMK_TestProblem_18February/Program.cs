using PTMK_TestProblem_18February.Models;

namespace PTMK_TestProblem_18February
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IInteractionDB interactionDB = new InteractionDB();
            foreach (string i in args) 
            {
                Console.WriteLine(i);
            }
            switch (args[0])
            {
                case "1":
                    interactionDB.MakeTable();
                    break;
                case "2":                   
                    interactionDB.WriteTable(args[1].ToString(), DateTime.Parse(args[2]), char.Parse(args[3]));
                    break;
                case "3":
                    interactionDB.OutUniquePosition();
                    break;
                case "4":
                    interactionDB.AutoWrite();
                    break;
                case "5":
                    interactionDB.GetСriterionFM();
                    break;
                case "6":
                    interactionDB.GetСriterionFMFast();
                    break;
            }
        }
    }
}