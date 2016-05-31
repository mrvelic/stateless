using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stateless
{
    public partial class StateMachine<TState, TTrigger>
    {
        internal abstract class TriggerBehaviour
        {
            readonly TTrigger _trigger;
            readonly Func<object[], TTrigger, bool> _guard;
            readonly string _guardDescription;

            protected TriggerBehaviour(TTrigger trigger, Func<object[], TTrigger, bool> guard, string guardDescription)
            {
                _trigger = trigger;
                _guard = guard;
                _guardDescription = Enforce.ArgumentNotNull(guardDescription, nameof(guardDescription));
            }

            public TTrigger Trigger { get { return _trigger; } }
            internal Func<object[], TTrigger, bool> Guard { get { return _guard; } }
            internal string GuardDescription{ get { return _guardDescription ; } }

            public virtual bool IsGuardConditionMet(TTrigger trigger, params object[] args)
            {
                return _guard(args, trigger);
            }

            public abstract bool ResultsInTransitionFrom(TState source, object[] args, out TState destination);
        }
    }
}
