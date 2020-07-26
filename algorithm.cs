using Algorithms.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.TOH
{
    public class TOHAlgorithm
    {
        protected Rod FirstRod;
        protected Rod SecondRod;
        protected Rod ThirdRod;
        public int NumberOfDisks { get; set; }
        public int MoveCount { get; set; }
        protected List<StepResult> Steps = new List<StepResult>();

        public TOHAlgorithm(int numberOfDisks = 3)
        {
            NumberOfDisks = numberOfDisks;

            Stack<int> firstRod = new Stack<int>();

            for (int i = numberOfDisks; i >= 1; --i)
                firstRod.Push(i);

            FirstRod = new Rod(0, firstRod);
            SecondRod = new Rod(1, new Stack<int>());
            ThirdRod = new Rod(2, new Stack<int>());
        }

        public virtual StepResult[] Solve()
        {
            Move(NumberOfDisks);
            return
                Steps.ToArray();
        }

        protected virtual void Move(int disks, Rod rodA, Rod rodB, Rod rodC)
        {
            if (disks == 1)
            {
                LogMove(disks, rodA.Index, rodB.Index);
                return;
            }

            Move(disks - 1, rodA, rodC, rodB);
            LogMove(disks, rodA.Index, rodB.Index);
            Move(disks - 1, rodC, rodB, rodA);
        }

        protected virtual void Move(int disks)
        {
            Move(disks, FirstRod, ThirdRod, SecondRod);
        }

        protected virtual void LogMove(int disk, int sourceIndex, int destinationIndex)
        {
            ++MoveCount;
            if (sourceIndex == 0)
            {
                FirstRod.Disks.Pop();

                if (destinationIndex == 1)
                    SecondRod.Disks.Push(disk);
                else
                    ThirdRod.Disks.Push(disk);
            }
            else if (sourceIndex == 1)
            {
                SecondRod.Disks.Pop();

                if (destinationIndex == 2)
                    ThirdRod.Disks.Push(disk);
                else
                    FirstRod.Disks.Push(disk);
            }
            else
            {
                ThirdRod.Disks.Pop();

                if (destinationIndex == 0)
                    FirstRod.Disks.Push(disk);
                else
                    SecondRod.Disks.Push(disk);
            }

            string source = sourceIndex == 0 ? "First Rod" : sourceIndex == 1 ? "Second Rod" : "Third Rod";
            string destination = destinationIndex == 0 ? "First Rod" : destinationIndex == 1 ? "Second Rod" : "Third Rod";
            string step = string.Format("Step #:{3} Moved Disk# {0} from the {1} to the {2}.", disk, source, destination,
                MoveCount);

            Steps.Add(new StepResult(step, FirstRod.Disks, SecondRod.Disks, ThirdRod.Disks));
        }
    }
}
