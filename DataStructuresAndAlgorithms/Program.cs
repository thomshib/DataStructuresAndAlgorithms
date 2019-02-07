using System;
using System.Threading;
using System.Threading.Tasks;
using DataStructuresAndAlgorithms.Tree;
using DataStructuresAndAlgorithms.Tree.BST;

namespace DataStructuresAndAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {


            Graphs.GraphSampleTest graphTest = new Graphs.GraphSampleTest();

            /*
            BSTreeSample.BinarySearchTreeTest();


            
            BinaryTreeSample tree = new BinaryTreeSample();

            
            var testHashSet = new HashSet();

            
            TestCallCenter();
            
            TestTowerofHanoi();

           

            TestSelectionSort();
            TestInsertionSort();
            TestQuickSort();

            */
            Console.ReadLine();
        }
        
        static void TestSelectionSort()
        {
            Console.WriteLine(" Selection Sort-----------");
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            SelectionSort.Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            SelectionSort.Sort(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }

        static void TestInsertionSort()
        {
            Console.WriteLine("  Insertion Sort-------------");
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            InsertionSort.Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            InsertionSort.Sort(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }

        static void TestQuickSort()
        {
            Console.WriteLine("  Quick Sort-------------");
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            QuickSort.Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            QuickSort.Sort(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }

        static void TestTowerofHanoi()
        {
            Console.WriteLine("  Tower of Hanoi-------------");
            TowersofHanoi.MoveTower(3, "A", "B", "C");

            
        }

        static void TestCallCenter()
        {
            CallCenter center = new CallCenter();
            Parallel.Invoke(
                () => CallersAction(center),
                () => ConsultantAction(center,"Marcin",ConsoleColor.Red),
                 () => ConsultantAction(center, "James", ConsoleColor.Yellow),
                  () => ConsultantAction(center, "Olivia", ConsoleColor.Green)

                                                   );
        }

        private static void ConsultantAction(CallCenter center, string name, ConsoleColor color)
        {
            Random random = new Random();
            while (true)
            {
                IncomingCall call = center.AnswerCall(name);
                if(call != null)
                {
                    Console.ForegroundColor = color;
                    Log($"Call #{call.Id} from {call.ClientId} is answered by { call.Consultant}.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Thread.Sleep(random.Next(1000, 10000));
                    center.End(call);

                    Console.ForegroundColor = color;
                    Log($"Call #{call.Id} from {call.ClientId} is ended by { call.Consultant}."); 
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Thread.Sleep(random.Next(500, 1000));

                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        private static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}]  { text}"); 
}

        private static void CallersAction(CallCenter center)
        {
            Random random = new Random();

            while (true)
            {
                int clientid = random.Next(1, 10000);
                int waitingCount = center.Call(clientid);
                Log($"Incoming call from {clientid}, waiting in the queue: {waitingCount} ");
                Thread.Sleep(random.Next(1000, 5000));
            }
        }
    }
}
