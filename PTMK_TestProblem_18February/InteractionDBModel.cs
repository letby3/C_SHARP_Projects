using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PTMK_TestProblem_18February.Models;


namespace PTMK_TestProblem_18February
{
    public interface IInteractionDB 
    {
        /*
         * There are 3-4 surnames from each letter of the alphabet.
         * All full names will generate are unique.
         * There is a slight overlap with the fact that the names do not correspond to the gender.
         * Also, the surname comes first in the Russian way
        */                       
        void MakeTable();

        void WriteTable(string fullName, DateTime dateBirth, char gender);

        void OutUniquePosition();

        void AutoWrite();

        float GetСriterionFM();

        float GetСriterionFMFast();
    }

    internal class InteractionDB : IInteractionDB
    {
        
        public InteractionDB() { }

        public void AutoWrite()
        {
            LittleFullNameData fullNameGenerate = new();
            using (UsersDbContext db = new())
            {
                
                Random genRand = new();
                DateTime startDate = new(1960, 1, 1);
                char[] genderChoose = { 'F', 'M'};
                Users newUser;                
                for (int i = 0; i < 1000000; i++)
                {
                    newUser = new Users
                    {
                        fullName = fullNameGenerate.SurnameData[i / 10000] + fullNameGenerate.Names[(i / 100) % 100] + fullNameGenerate.LastNames[i % 100],
                        dateBirth = startDate.AddDays(genRand.Next((DateTime.Today - startDate).Days)),
                        gender = genderChoose[genRand.Next(0, 2)]
                    };                    
                    
                    db.users.Add(newUser);                        
                }                
                db.SaveChanges();

            }
        }

        public float GetСriterionFM()
        {
            using (UsersDbContext db = new UsersDbContext())
            {                
                DateTime startTime = DateTime.Now;

                var userswithF = db.users.Where(p => p.gender == 'M' && p.fullName.StartsWith("F"));
                double totalTime = ((DateTime.Now - startTime).TotalMicroseconds) / 1000.0;
                
                foreach (var person in userswithF)
                    Console.WriteLine($"{person.fullName} {person.dateBirth} {person.gender}");
                Console.WriteLine($"{totalTime} milisec");
            }
            return 0.0f;
        }

        /// <summary>
        /// After applying the method, you need to restore the database by running method 4
        /// </summary>
        /// <returns></returns>
        public float GetСriterionFMFast()
        {
            using (UsersDbContext db = new UsersDbContext())
            {                
                _ = db.users.Where(p => p.gender != 'M').Where(p => p.fullName.StartsWith("F") == false).ExecuteDelete();
                DateTime startTime = DateTime.Now;               
                var userswithF = db.users.Where(p => p.gender == 'M' && p.fullName.StartsWith("F"));
                double totalTime = ((DateTime.Now - startTime).TotalMicroseconds) / 1000.0;

                foreach (var person in userswithF)
                    Console.WriteLine($"{person.fullName} {person.dateBirth} {person.gender}");
                Console.WriteLine($"{totalTime} milisec");
            }
            return 0.0f;
        }

        public void MakeTable()
        {
            using (UsersDbContext db = new UsersDbContext())
            {
                Console.WriteLine("The table has been created");
            }
        }

        public void OutUniquePosition()
        {
            using (UsersDbContext db = new UsersDbContext())
            {
                Console.WriteLine("All unique positions: ");
                Console.WriteLine("Full Name\tDate of birth\tGender\tAge");
                foreach (Users i in db.users.ToArray())
                {
                    Console.WriteLine($"{i.fullName}\t\t{i.dateBirth.ToShortDateString()}\t{i.gender}\t{(int)(DateTime.Now - i.dateBirth).TotalDays/365}");
                }
            }
        }

        public void WriteTable(string fullName, DateTime dateBirth, char gender)
        {
            using (UsersDbContext db = new UsersDbContext())
            {                
                if (db.users.Find(fullName, dateBirth) == null)
                {
                    db.users.Add(new Users { fullName = fullName, dateBirth = dateBirth, gender = gender });
                    db.SaveChanges();
                }
                Console.WriteLine("Entry added");
            }
        }
    }
}
