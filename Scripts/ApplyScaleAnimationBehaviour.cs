using UnityEngine;
using UnityEngine.UI;
using UIBehaviourKit.Animators;

namespace UIBehaviourKit {

    [AddComponentMenu("UIBehaviorKit/Apply scale animation")]
    public sealed class ApplyScaleAnimationBehaviour : ApplySimpleAnimationBehaviour
    {
        [SerializeField]
        private Vector3 from = new Vector3(1.0f, 1.0f, 1.0f);
        [SerializeField]
        private Vector3 to = Vector3.zero;

        protected override void ApplyAnimation(MaskableGraphic target, float delta)
        {
            target.transform.localScale = Vector3.Lerp(from, to, delta); 
        }
    }

}


