using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted): base(name, weighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Must have at least 5 students");
                
            }

            var threshold = Students.Count * 0.2;
            var count = 0;

            foreach(Student Student in Students)
            {
                if(averageGrade >= Student.AverageGrade)
                {
                    count++;
                }
            }

            if(count >= threshold * 5)
            {
                return 'A';
            }else if(count >= threshold * 4)
            {
                return 'B';
            }
            else if (count >= threshold * 3)
            {
                return 'C';
            }
            else if (count >= threshold * 2)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }else
            {
                base.CalculateStatistics();
            }          
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
            
        }
    }
}