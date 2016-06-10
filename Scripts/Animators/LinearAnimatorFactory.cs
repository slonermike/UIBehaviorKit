using UnityEngine;

namespace UIBehaviourKit.Animators {

    [CreateAssetMenu(menuName="UIBehaviourKit/Linear Animation", fileName="ui_linear_animation.asset")]
    public sealed class LinearAnimatorFactory : SimpleAnimatorFactory {
        [SerializeField]
        private AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1.0f, 0));
        [SerializeField]
        private float animationScale = 1.0f;
        [SerializeField]
        private bool looped = false;

        public override ISimpleAnimator CreateSimpleAnimator()
        {
            return new Linear(curve, looped, animationScale);
        }
    }
}
