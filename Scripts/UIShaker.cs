/************************************************************
 * 
 *                      UI Shaker
 *                 2016 Slonersoft Games
 * 
 * Place this on a UI element and shake it all around by calling
 * Shake on this component.
 * 
 ************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIShaker : MonoBehaviour {

	float maxMagnitude = 0.0f;
	float timeLeft_s = 0.0f;
	float timeTotal_s = 0.0f;

	RectTransform rectTransform;
	Vector3 rootPos;

	// Initialize the component, grabbing initial conditions.
	//
	void Initialize()
	{
		if (rectTransform == null) {
			rectTransform = GetComponent<RectTransform> ();
			rootPos = rectTransform.localPosition;
		}
	}

	// Called every frame.
	//
	void Update () {

		if (rectTransform && timeLeft_s > 0) {
			// Subtract time until it reaches zero, then the shake is done.  Reset the system.
			timeLeft_s -= Time.deltaTime;
			if (timeLeft_s <= 0.0f) {
				timeLeft_s = 0.0f;
				timeTotal_s = 0.0f;
			}

			// Set the local position to the shaken offset.
			rectTransform.localPosition = rootPos + GetOffset ();
		}
	}

	// Generates a random offset based on the current state of the shake.
	//
	Vector3 GetOffset()
	{

		// Default offset is zero -- no shake.
		Vector3 offset = Vector2.zero;

		// If there is a current shake in play.
		if (timeLeft_s > 0f && timeTotal_s > 0f) {

			// Choose a random direction.
			float direction = Random.Range (0.0f, 360.0f);

			// Create a vector (relative to orientation) with a random direction rotated around the forward axis.
			offset = Quaternion.AngleAxis (direction, Vector3.forward) * Vector3.right;

			// Determine the current effective spread (between 0 and maxSpread) and multiply the offset by that.
			offset *= Mathf.Lerp (0.0f, maxMagnitude, timeLeft_s / timeTotal_s);
		}

		return offset;
	}

	// Shake the element!
	//
	// time_s: Time (in seconds) for the shake to take.
	// magnitude: distance (in game units) for the shake to move the camera at its most extreme.
	//
	public void Shake(float time_s, float magnitude)
	{
		Initialize ();
		timeTotal_s = time_s;
		timeLeft_s = time_s;
		maxMagnitude = magnitude;
	}
}