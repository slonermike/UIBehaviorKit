using NUnit.Framework;
using NSubstitute;
using UnityEngine;

namespace UIBehaviourKit.Animators.Test {

    [TestFixture]
    public class LinearAnimatorTest {
        private const float VerySmallValue = 0.00001f;

        [Test]
        public void NoScaleNoLoop() {
            NoLoopTests(1.0f);
        }

        [Test]
        public void ScaleNoLoop() {
            NoLoopTests(2.0f);
        }

        [Test]
        public void NoScaleLoop() {
            LoopTest(1.0f);
        }

        [Test]
        public void ScaleLoop() {
            LoopTest(2.0f);
        }

        private void NoLoopTests(float scale) {
            DoTest(0, 0, scale, false);
            DoTest(1.0f / scale, 0.5f, scale, false);
            DoTest(2.0f / scale, 1.0f, scale, false);
        }

        private void LoopTest(float scale) {
            DoTest(0, 0, scale, true);
            DoTest(1.0f / scale, 0.5f, scale, true);
            DoTest(2.0f / scale - VerySmallValue, 1.0f, scale, true);
            DoTest(3.0f / scale, 0.5f, scale, true);
            DoTest(4.0f / scale - VerySmallValue, 1.0f, scale, true);
        }

        private void DoTest(float time, float expected, float scale, bool looped) {
            ISimpleAnimated animated = Substitute.For<ISimpleAnimated>();
            var animator = CreateLinear(scale, looped);
            animator.Update(time);
            animator.Apply(animated);
            animated.Received().Apply(expected);
        }

        private Linear CreateLinear(float scale, bool looped) {
            var curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(2.0f, 1.0f));
            return new Linear(curve, looped, scale);
        }
    }
}