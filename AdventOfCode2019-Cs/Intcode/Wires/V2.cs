using System;

namespace AdventOfCode2019.Intcode.Wires
{
    public struct V2
    {
        public int x, y;
        public V2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Magnitude => Math.Abs(x) + Math.Abs(y);
        public V2 Normalized => new V2(Math.Sign(x), Math.Sign(y));
        
        public static V2 Parse(string input)
        {
            char dir = input[0];
            int magnitude = int.Parse(input.Substring(1, input.Length - 1));
            int x = (dir == 'U' || dir == 'D') ? 0 : (dir == 'R' ? magnitude : -magnitude);
            int y = (dir == 'R' || dir == 'L') ? 0 : (dir == 'U' ? magnitude : -magnitude);
            return new V2(x, y);
        }
            
        public static V2 operator +(V2 v1, V2 v2)
        {
            return new V2(v1.x + v2.x, v1.y + v2.y);
        }

        public static V2 operator -(V2 v1, V2 v2)
        {
            return new V2(v1.x - v2.x, v1.y - v2.y);
        }

        public override string ToString()
        {
            return $"({x} : {y})";
        }

        public bool Equals(V2 other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            return obj is V2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }
    }
}