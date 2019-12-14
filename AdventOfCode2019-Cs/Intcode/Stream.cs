using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Stream
    {
        private Queue<long> queue;
        
        public Stream()
        {
            queue = new Queue<long>();
        }

        public static Stream Initialize()
        {
            return new Stream();
        }

        public void Write(long value)
        {
            Console.WriteLine($@"W: {value}");
            queue.Enqueue(value);
        }

        public long Read()
        {
            var value = queue.Dequeue();
            Console.WriteLine($@"R: {value}");
            return value;
        }
    }
}