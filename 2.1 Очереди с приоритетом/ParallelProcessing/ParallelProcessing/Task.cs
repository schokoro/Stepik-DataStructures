namespace ParallelProcessing
{
    public struct Task
    {
        private int time;
        private int core;
        public int Time
        {
            get { return time; }
            set { time = value; }
        }

        public int Core
        {
            get { return core; }
            set { core = value; }
        }
        public Task(int val1, int val2)
        {
            time = val1;
            core = val2;
        }
        public static bool operator >(Task val1, Task val2)
        {
            if (val1.time > val2.time)
                return true;
            else return false;
        }

        public static bool operator <(Task val1, Task val2)
        {
            if (val1.time < val2.time)
                return true;
            else return false;
        }
    }
}
