using UnityEngine;
using UnityEngine.UI;
using UIBehaviourKit.Animators;

namespace UIBehaviourKit {

    [AddComponentMenu("UIBehaviourKit/Apply color animation")]
    public sealed class ApplyColorAnimationBehaviour : ApplySimpleAnimationBehaviour
    {
        [SerializeField]
        private Gradient gradient;

        protected override void ApplyAnimation(MaskableGraphic target, float delta)
        {
            target.color = gradient.Evaluate(delta);
        }
    }

}
