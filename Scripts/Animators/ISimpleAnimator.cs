namespace UIBehaviourKit.Animators {

    public interface ISimpleAnimator : IAnimator {
        void Apply(ISimpleAnimated animated);
    }
}