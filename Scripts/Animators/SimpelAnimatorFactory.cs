using UnityEngine;

namespace UIBehaviourKit.Animators {

    public abstract class SimpleAnimatorFactory : ScriptableObject, ISimpleAnimatorFactory {
        public abstract ISimpleAnimator CreateSimpleAnimator();
    }
}