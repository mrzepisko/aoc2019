using System;
using System.Linq;

namespace AdventOfCode2019.Intcode.Wires
{
    public class Wire
    {
        private V2[] corners;
        private V2[] directions;
        private int width, height;

        public int Width => width;
        public int Height => height;
        public V2[] Directions => directions;

        public Wire(string definition)
        {
            directions = definition.Split(',')
                .Select(V2.Parse).ToArray();
            corners = new V2[directions.Length + 1];
            corners[0] = new V2(0, 0);
            for (int i = 1; i < directions.Length; i++)
            {
                corners[i] = corners[i - 1] + directions[i];
                width = Math.Max(Math.Abs(corners[i].x), width);
                height = Math.Max(Math.Abs(corners[i].y), height);
            }
        }
    }
}