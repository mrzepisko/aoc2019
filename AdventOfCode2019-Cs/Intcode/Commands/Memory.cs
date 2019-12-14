using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Memory
    {
        private readonly int[] value;
        private Memory(int[] value)
        {
            this.value = new int[value.Length];
            Array.Copy(value, this.value, value.Length);
        }

        public int this[int addr]
        {
            get => value[addr];
            set => this.value[addr] = value;
        }
        
        public Memory(int memsize)
        {
            value = new int[memsize];
        }

        public static Memory Load(int[] data)
        {
            return new Memory(data);
        }
    }
}