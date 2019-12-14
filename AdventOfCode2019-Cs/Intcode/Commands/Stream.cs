using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Stream
    {
        private Queue<int> queue;
        
        public Stream()
        {
            queue = new Queue<int>();
        }

        public static Stream Initialize()
        {
            return new Stream();
        }

        public void Write(int value)
        {
            Console.WriteLine($@"W: {value}");
            queue.Enqueue(value);
        }

        public int Read()
        {
            var value = queue.Dequeue();
            Console.WriteLine($@"R: {value}");
            return value;
        }
    }
}