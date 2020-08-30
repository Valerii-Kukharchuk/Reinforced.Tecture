﻿using System.IO;
using Reinforced.Tecture.Commands;

namespace Reinforced.Tecture.Tracing.Commands.Cycles
{
    [CommandCode("ITR")]
    public class Iteration : CommandBase, ITracingOnly
    {
        internal Iteration() { }

        public override void Describe(TextWriter tw)
        {
            if (string.IsNullOrEmpty(Annotation))
            {
                tw.Write("--- Cycle iteration ---");
            }
            else
            {
                tw.Write($"--- {Annotation} ---");
            }
        }

        /// <summary>
        /// Clones command for tracing purposes
        /// </summary>
        /// <returns>Command clone</returns>
        protected override CommandBase DeepCloneForTracing()
        {
            return new Iteration();
        }
    }
}