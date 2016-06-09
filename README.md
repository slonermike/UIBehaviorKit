# UIBehaviorKit

This library provides visual behaviors for UI elements in the Unity Engine.

This code is freely available to you via the [WTFPL License](https://en.wikipedia.org/wiki/WTFPL)

##Examples
Examples of each are provided in the scene UIBehaviors-Example.unity found in the 'Scenes' folder.

![alt text](http://www.slonersoft.com/images/uibehavior_example.gif "Examples of UIBehaviors in action.")

## Behaviors
### UIFadeAway
Place this on a MaskableGraphic such as Image or Text and call Fade to make it fade away and grow.
NOTE: Growth will happen relative to the pivot point of the element.  This means if your pivot is on the top left, it will grow toward the bottom right.
### UISlamIn
Place this on a UI element such as Image or Text and you can call "Slam" on it to have the text slam into place.
### UIPulse
Place this on a maskable UI element such as Image or Text and it will pulse through the colors laid out in colorPattern.
### UIShaker
Place this on a UI element and shake it all around by calling Shake on this component.
### UIValueAnimator
Place this on a Text element and call AnimateValue to change the value over time, "tallying" the result.
### UIGroupFader
Used to fade an entire group of UI elements together. All children of this object will be affected.
Introduce a delay to create a cascading effect without having to manage coroutines.
