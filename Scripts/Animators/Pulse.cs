using UnityEngine;
using UnityEngine.Assertions;
using System;

namespace UIBehaviourKit.Animators {

    public sealed class Pulse : ISimpleAnimator {

        private AnimationCurve curveIn;
        private AnimationCurve curveOut;
        private float timeIn;
        private float timeOut;
        private float animationScale;
        private bool looped;

        private float currentTime;

        public Pulse(AnimationCurve curveIn, AnimationCurve curveOut, bool looped = false, float animationScale = 1.0f) {
            Assert.IsNotNull(curveIn, "curveIn can't be null");
            Assert.IsNotNull(curveOut, "curveOut can't be null");
            Assert.IsTrue(animationScale != 0, "animationScale can't be zero");
            this.curveIn = curveIn;
            this.curveOut = curveOut;
            this.timeIn = Helpers.GetAnimationTime(curveIn);
            this.timeOut = Helpers.GetAnimationTime(curveOut);
            this.animationScale = animationScale;
            this.looped = looped;
        }

        public Pulse(AnimationCurve curveInOut, bool looped = false, float animationScale = 1.0f) {
            Assert.IsNull(curveInOut, "curveInOut can't be null");
            Assert.IsTrue(animationScale != 0, "animationScale can't be zero");
            this.curveIn = curveInOut;
            this.curveOut = Helpers.Invert(curveInOut);
            this.timeIn = this.timeOut = Helpers.GetAnimationTime(curveInOut);
            this.animationScale = animationScale;
            this.looped = looped;
        }

        public void Update(float deltaTime) {
            currentTime = Helpers.EvalTime(currentTime, timeIn + timeOut, deltaTime, animationScale, looped);
        }

        public void Reset() {
            currentTime = 0;
        }

        public void Apply(ISimpleAnimated animated) {
            float value = 0;
            if (currentTime <= timeIn) {
                value = curveIn.Evaluate(currentTime);
            } else {
                value = curveOut.Evaluate(currentTime - timeIn);
            }
            animated.Apply(value);
        }

    }

}