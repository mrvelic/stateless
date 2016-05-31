using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Stateless.Tests
{
    [TestFixture]
    public class TriggerBehaviourFixture
    {
        [Test]
        public void ExposesCorrectUnderlyingTrigger()
        {
            var transtioning = new StateMachine<State, Trigger>.TransitioningTriggerBehaviour(
                Trigger.X, State.C, (a, t) => true);

            Assert.AreEqual(Trigger.X, transtioning.Trigger);
        }

        [Test]
        public void WhenGuardConditionFalse_IsGuardConditionMetIsFalse()
        {
            var transtioning = new StateMachine<State, Trigger>.TransitioningTriggerBehaviour(
                Trigger.X, State.C, (a, t) => false);

            Assert.IsFalse(transtioning.IsGuardConditionMet(Trigger.X));
        }

        [Test]
        public void WhenGuardConditionTrue_IsGuardConditionMetIsTrue()
        {
            var transtioning = new StateMachine<State, Trigger>.TransitioningTriggerBehaviour(
                Trigger.X, State.C, (a, t) => true);

            Assert.IsTrue(transtioning.IsGuardConditionMet(Trigger.X));
        }
    }
}
