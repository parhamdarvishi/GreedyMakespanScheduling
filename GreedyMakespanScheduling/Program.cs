namespace GreedyMakespanScheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example task durations and machine count
            int[] tasks = { 4, 2, 8, 3, 5, 7, 6 };
            int machineCount = 3;

            // Generate the schedule
            var schedule = GreedyMakespanSchedule(tasks, machineCount);

            // Output the result
            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"Machine {i + 1}: Tasks {string.Join(", ", schedule[i])}, Total Time: {schedule[i].Sum()}");
            }
        }

        static List<List<int>> GreedyMakespanSchedule(int[] tasks, int machineCount)
        {
            // Initialize machines with empty task lists
            var machines = new List<List<int>>(machineCount);
            for (int i = 0; i < machineCount; i++)
            {
                machines.Add(new List<int>());
            }

            // Sort tasks in descending order (greedy choice)
            var sortedTasks = tasks.OrderByDescending(t => t);

            foreach (var task in sortedTasks)
            {
                // Find the machine with the least load
                var leastLoadedMachine = machines.OrderBy(machine => machine.Sum()).First();

                // Assign the current task to the least loaded machine
                leastLoadedMachine.Add(task);
            }

            return machines;
        }
    }
}
