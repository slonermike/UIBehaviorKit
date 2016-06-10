using NUnit.Framework;
using NSubstitute;
using UnityEngine;

namespace UIBehaviourKit.Animators.Test {

    [TestFixture]
    public class LinearAnimatorTest {
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1.0f, 1.0f));
        private ISimpleAnimated animated;
        private Linear animator;

        [SetUp]
        public void SetUp() {
            animated = Substitute.For<ISimpleAnimated>();
            animator = new Linear(curve);
        }

        [Test]
        public void ZeroOnStart() {
            animator.Apply(animated);
            animated.Received().Apply(0);
        }

        [Test]
        public void HalfAtHalfTime() {
            animator.Update(0.5f);
            animator.Apply(animated);
            animated.Received().Apply(0.5f);
        }

        [Test]
        public void OneAtEnd() {
            animator.Update(1.0f);
            animator.Apply(animated);
            animated.Received().Apply(1.0f);
        }

        [Test]
        public void DontGoOutside() {
            animator.Update(1.1f);
            animator.Apply(animated);
            animated.Received().Apply(1.0f);
        }

        [Test]
        public void Reset() {
            animator.Update(1.1f);
            animator.Reset();
            animator.Apply(animated);
            animated.Received().Apply(0);
        }

        [Test]
        public void Loop() {
            animator = new Linear(new AnimationCurve(new Keyframe(0, 0), new Keyframe(2, 1)), true);
            animator.Update(3.0f);
            animator.Apply(animated);
            animated.Received().Apply(0.5f);
        }
    }
}