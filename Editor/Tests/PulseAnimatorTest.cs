using NUnit.Framework;
using NSubstitute;
using UnityEngine;

namespace UIBehaviourKit.Animators.Test {

    [TestFixture]
    public class PulseAnimatorTest {

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
            LoopTests(1.0f);
        }

        [Test]
        public void ScaleLoop() {
            LoopTests(2.0f);
        }

        private void NoLoopTests(float scale) {
            DoTest(0, 0, false, scale);
            DoTest(1 / scale, 0.5f, false, scale);
            DoTest(2 / scale, 1.0f, false, scale);
            DoTest(2.5f / scale, 0.5f, false, scale);
            DoTest(3.0f / scale, 0, false, scale);
            DoTest(44.0f / scale, 0, false, scale);
        }

        private void LoopTests(float scale) {
            DoTest(0, 0, true, scale);
            DoTest(1.0f / scale, 0.5f, true, scale);
            DoTest(2.0f / scale, 1.0f, true, scale);
            DoTest(2.5f / scale, 0.5f, true, scale);
            DoTest(3.0f / scale, 0, true, scale);
            DoTest(4.0f / scale, 0.5f, true, scale);
            DoTest(5.0f / scale, 1.0f, true, scale);
            DoTest(5.5f / scale, 0.5f, true, scale);
            DoTest(6.0f / scale, 0, true, scale);
        }

        private void DoTest(float time, float expected, bool looped = false, float scale = 1.0f) {
            var pulse = CreatePulse(looped, scale);
            pulse.Update(time);
            var animated = Substitute.For<ISimpleAnimated>();
            pulse.Apply(animated);
            animated.Received().Apply(expected);
        }

        private Pulse CreatePulse(bool looped = false, float scale = 1.0f) {
            var curve1 = new AnimationCurve(new Keyframe(0, 0), new Keyframe(2, 1));
            var curve2 = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));
            return new Pulse(curve1, curve2, looped, scale);
        }


    }

}