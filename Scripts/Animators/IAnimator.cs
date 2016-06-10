using UnityEngine.UI;

namespace UIBehaviourKit.Animators {

    public interface IAnimator {
        void Update(float deltaTime);
        void Reset();
    }
}