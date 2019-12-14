using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Memory
    {
        private readonly long[] value;
        private Memory(long[] value)
        {
            this.value = new long[value.Length];
            Array.Copy(value, this.value, value.Length);
        }

        public long this[long addr]
        {
            get => value[addr];
            set => this.value[addr] = value;
        }
        
        public Memory(long memsize)
        {
            value = new long[memsize];
        }

        public static Memory Load(long[] data)
        {
            return new Memory(data);
        }
    }
}