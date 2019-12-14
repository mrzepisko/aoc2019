using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Input
    {
        private Queue<int> queue;
        
        public Input()
        {
            queue = new Queue<int>();
        }

        public static Input Initialize()
        {
            return new Input();
        }

        public void Query(int value)
        {
            queue.Enqueue(value);
        }

        public int Read()
        {
            return queue.Dequeue();
        }
    }
}