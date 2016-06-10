using UnityEngine;
using UnityEngine.Assertions;
using System;

namespace UIBehaviourKit.Animators {

    public sealed class Linear : ISimpleAnimator {
        private AnimationCurve animationCurve;
        private float animationTime;
        private bool looped;

        private float currentTime;

        public Linear(float animationTime, AnimationCurve animationCurve, bool looped = false)
        {
            Assert.IsNotNull(animationCurve, "animationCurve is null");
            Assert.IsTrue(animationTime > 0, "fadeTime must be greater or equal zero");
            this.animationCurve = animationCurve;
            this.animationTime = animationTime;
            this.looped = looped;
        }

        public void Update(float deltaTime) {
            currentTime += deltaTime;
        }

        public void Reset() {
            currentTime = 0;
        }

        public void Apply(ISimpleAnimated fadeAway) {
            float delta = 0;
            if (looped) {
                delta = currentTime % animationTime;
            }
            else {
                delta = Mathf.Clamp01(currentTime / animationTime);
            }
            fadeAway.Apply(animationCurve.Evaluate(delta));
        }

    }
}