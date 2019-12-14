using System;
using System.Collections;
using System.Linq;

namespace AdventOfCode2019.Intcode
{
    public class InteropProgram
    {
        public InteropProgram(string source)
        {
            this.source = source.Split(',')
                .Select(int.Parse)
                .ToArray();
        }

        private readonly int[] source;

        public int[] Source => source;
        
        public int this[int addr] => source[addr];
    }
}