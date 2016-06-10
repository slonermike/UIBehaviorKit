using UnityEngine;
using UnityEngine.Assertions;

namespace UIBehaviourKit.Animators {

    static internal class Helpers {
        internal static float GetAnimationTime(AnimationCurve curve) {
            Assert.IsNotNull(curve, "curve can't be null");
            Assert.IsTrue(curve.length > 1, "curve must have at least 2 keyframes");
            return curve.keys[curve.length - 1].time;
        }

        internal static float EvalTime(float currentTime, float animationTime, float deltaTime, float animationScale, bool looped) {
            currentTime += deltaTime * animationScale;
            if (looped) {
                currentTime %= animationTime;
            }
            return Mathf.Clamp(currentTime, 0, animationTime);
        }
    }
}