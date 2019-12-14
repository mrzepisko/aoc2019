using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public abstract class Command
    {
        private readonly int opCode;
        private readonly int[] parameters;
        
        private int paramCount => parameters.Length;
        
        public int OpCode => opCode;
        public int Size => paramCount + 1;
        
        protected Command(string definition)
        {
            parameters = new int[definition.Length - 2];
            opCode = int.Parse(definition.Substring(definition.Length - 2, 2));
            for (int i = 0; i < paramCount; i++)
            {
                parameters[i] = definition[definition.Length - 2 - i] - '0';
            }
        }

        protected int ReadValue(Context ctx, int paramId)
        {
            int paramValue = ctx.ReadParam(paramId + 1);
            return parameters[paramId] == 0 ? ctx.ReadMemory(paramValue) : paramValue;
        }

        protected void WriteValue(Context ctx, int paramId, int value)
        {
            if (parameters[paramId] == 1) throw new AccessViolationException();
            int paramValue = ctx.ReadParam(paramId + 1);
            ctx.WriteMemory(paramValue, value);
        }
        
        public bool Execute(Context context)
        {
            return context.ReadParam(0) != opCode || Process(context);
        }
        
        protected abstract bool Process(Context ctx);
    }
}