using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Intcode.Wires
{
    public class WirePanel
    {
        private List<V2> panel;


        public WirePanel(Wire wire1, Wire wire2)
        {
            panel = new List<V2>();
            Fill(wire1);
            Fill(wire2);
        }

        public V2 FindClosestIntersection()
        {
            return panel.GroupBy(v => v)
                .Where(g => g.Count() > 1)
                .Select(v => v.Key)
                .OrderBy(i => i.Magnitude)
                .First();
        }

        void Fill(Wire wire)
        {
            V2 offset = new V2();
            foreach (var v in wire.Directions)
            {
                for (int i = 0; i < v.Magnitude; i++)
                {
                    offset += v.Normalized;
                    panel.Add(offset);
                }
            }
        }
    }
}