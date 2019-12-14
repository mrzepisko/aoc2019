using System;
using System.Collections;
using System.Linq;
using AdventOfCode2019.Intcode.Commands;

namespace AdventOfCode2019.Intcode
{
    public class InteropProgram
    {
        public InteropProgram(string source, int extraMemory = 0)
        {
            this.source = source.Split(',')
                .Select(long.Parse)
                .ToArray();
            Array.Resize(ref this.source, source.Length + extraMemory);
        }

        private readonly long[] source;

        public Context Prepare()
        {
            return Context.Initialize(source);
        }
    }
}