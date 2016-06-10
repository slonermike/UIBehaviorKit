using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UIBehaviourKit.Animators;

namespace UIBehaviourKit {

    public abstract class ApplySimpleAnimationBehaviour : MonoBehaviour, ISimpleAnimated {

        [SerializeField]
        private SimpleAnimatorFactory animation;
        [SerializeField]
        private MaskableGraphic[] targets;

        private ISimpleAnimator animator;

        private void Awake() {
            if (targets == null || targets.Length == 0) {
                var target = GetComponent<MaskableGraphic>();
                Assert.IsNotNull(target, "Can't find suitrable target to apply animator");
                targets = new MaskableGraphic[1];
                targets[0] = target;
            }
            animator = animation.CreateSimpleAnimator();
        }

        private void Update() {
            animator.Update(Time.deltaTime);
            animator.Apply(this);
        }

        public void Apply(float delta) {
            foreach (var it in targets) {
                ApplyAnimation(it, delta);
            }
        }

        protected abstract void ApplyAnimation(MaskableGraphic target, float delta);
    }

}


