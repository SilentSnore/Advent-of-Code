using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    class Program
    {
        private const int ListSize = 256; 
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText(@"C:\Users\Naga\Desktop\in.txt");
            string[] lengthSequence = input.Split(',');
            List<int> list = new List<int>(ListSize);

            //fillup
            for (int i = 0; i < ListSize; i++)
            {
                list.Add(i);
            }

            //actual work
            int currentPosition = 0, skip = 0;
            foreach (string s in lengthSequence)
            {
                int length = Int32.Parse(s.Trim());
                list = Swap(list, currentPosition, length);
                currentPosition = JumpNext(currentPosition, length, skip);
                skip++;
            }

            Console.WriteLine("Multiply of first two: " + list[0] * list[1]);

            //part 2
            List<int> lengthList = new List<int>();
            foreach (char c in input.ToCharArray())
            {
                lengthList.Add(c);
            }
            lengthList.Add(17);
            lengthList.Add(31);
            lengthList.Add(73);
            lengthList.Add(47);
            lengthList.Add(23);

            currentPosition = 0;
            skip = 0;
            for (int numOfIterations = 0; numOfIterations < 64; numOfIterations++)
            {
                foreach (int length in lengthList)
                {
                    list = Swap(list, currentPosition, length);
                    currentPosition = JumpNext(currentPosition, length, skip);
                    skip++;
                }
            }

            List<int> blocks = new List<int>();
            IEnumerable<IEnumerable<int>> groups = Chunk(list, 16);
            foreach (IEnumerable<int> @group in groups)
            {
                int neutral = 0;
                foreach (int i in group)
                {
                    neutral = neutral ^ i;
                }
                blocks.Add(neutral);
            }

            foreach (int block in blocks)
            {
                Console.Write(block.ToString("X2"));
            }

            Console.ReadKey();
        }

        private static int NextIndex(int position)
        {
            if (position < ListSize - 1)
                return position + 1;
            return 0;
        }

        private static int PreviousIndex(int position)
        {
            if (position > 0)
                return position - 1;
            return ListSize - 1;
        }
        private static List<int> Swap(List<int> list, int position, int length)
        {
            int numOfSwapsNeeded = length / 2, numOfSwapsMade = 0, startPosition = position, currentPosition = position;
            List<int> newList = new List<int>(list);
            while (numOfSwapsMade < numOfSwapsNeeded)
            {
                int corespondPosition = CorespondIndex(startPosition, currentPosition, length);
                newList[currentPosition] = list[corespondPosition];
                newList[corespondPosition] = list[currentPosition];
                currentPosition = NextIndex(currentPosition);
                numOfSwapsMade++;
            }
            return newList;
        }

        private static int CorespondIndex(int startPosition, int currentPosition, int length)
        {
            int stepsAway = 0, tmpPosition = startPosition;
            while (tmpPosition != currentPosition)
            {
                tmpPosition = NextIndex(tmpPosition);
                stepsAway++;
            }
            int counter = 0, finishPosition = startPosition;
            while (counter < length - 1)
            {
                finishPosition = NextIndex(finishPosition);
                counter++;
            }
            int corespondPosition = finishPosition;
            for (int i = 0; i < stepsAway; i++)
            {
                corespondPosition = PreviousIndex(corespondPosition);
            }
            return corespondPosition;
        }

        private static int JumpNext(int currentPosition, int length, int skip)
        {
            int numOfIterations = 0, distance = length + skip;
            while (numOfIterations < distance)
            {
                currentPosition = NextIndex(currentPosition);
                numOfIterations++;
            }
            return currentPosition;
        }

        /// <summary>
        /// Break a list of items into chunks of a specific size
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
}
