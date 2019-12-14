using System;
using System.Collections;
using System.Linq;
using AdventOfCode2019.Intcode.Commands;

namespace AdventOfCode2019.Intcode
{
    public class InteropProgram
    {
        public InteropProgram(string source)
        {
            this.source = source.Split(',')
                .Select(long.Parse)
                .ToArray();
        }

        private readonly long[] source;

        public Context Prepare()
        {
            return Context.Initialize(source);
        }
    }
}