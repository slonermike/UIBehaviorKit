using UnityEngine;
using UnityEngine.Assertions;
using System;

namespace UIBehaviourKit.Animators {

    public sealed class Linear : ISimpleAnimator {
        private AnimationCurve animationCurve;
        private float animationScale;
        private float animationTime;
        private bool looped;

        private float currentTime;

        public Linear(AnimationCurve animationCurve, bool looped = false, float animationScale = 1.0f)
        {
            Assert.IsNotNull(animationCurve, "animationCurve is null");
            Assert.IsTrue(animationScale != 0, "animationScale mustn't be zero");
            this.animationCurve = animationCurve;
            this.animationScale = animationScale;
            this.looped = looped;
            this.animationTime = Helpers.GetAnimationTime(animationCurve);
        }

        public void Update(float deltaTime) {
            currentTime += deltaTime * animationScale;
            if (looped) {
                currentTime %= animationTime;
            }
        }

        public void Reset() {
            currentTime = 0;
        }

        public void Apply(ISimpleAnimated fadeAway) {
            fadeAway.Apply(animationCurve.Evaluate(Mathf.Clamp(currentTime, 0, animationTime)));
        }

    }
}