using System;
using CommandLine;

namespace Everything.NET.Verbs
{
    public class VerbBase
    {
        public virtual int Action()
        {
            var attr = this.GetType().GetCustomAttributes(true);

            foreach (var a in attr)
            {
                if (a.GetType() == typeof(VerbAttribute))
                {
                    throw new NotImplementedException($"Verb {(a as VerbAttribute).Name} contains unimplemented Action().");
                }
            }

            throw new NotImplementedException($"Current verb is invalid.");
        }
    }
}
