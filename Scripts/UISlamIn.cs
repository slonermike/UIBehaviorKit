/************************************************************
 * 
 *                      UI Slam-In
 *                 2016 Slonersoft Games
 * 
 * Place this on a UI element such as Image or Text and you
 * can call "Slam" on it to have the text slam into place.
 * 
 ************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISlamIn : MonoBehaviour {

	[Tooltip("Determines how slam animates in.")]
	public AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

	[Tooltip("How big should it slam in? (1.0 for no size change)")]
	public float slamSize = 2.0f;

	[Tooltip("Time (sec) for the slam to take.")]
	public float slamTime = 1.0f;

	[Tooltip("True to slam upon enable, false to wait for script intervention.")]
	public bool slamImmediately = false;

	float progressPct = 0.0f;
	MaskableGraphic graphic;
	RectTransform rectTransform;
	Vector3 baseScale;

	// Use this for initialization
	void Start () {
		graphic = GetComponent<MaskableGraphic> ();
		rectTransform = GetComponent<RectTransform> ();
		baseScale = rectTransform.localScale;
		Slam (slamTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (progressPct < 1.0f) {
			progressPct = Mathf.Clamp01(progressPct + (Time.deltaTime / slamTime));

			float adjustedPct = curve.Evaluate (progressPct);

			rectTransform.localScale = baseScale * Mathf.Lerp (slamSize, 1f, adjustedPct);

			if (graphic != null) {
				graphic.color = new Color (graphic.color.r, graphic.color.g, graphic.color.b, adjustedPct);
			}
		}
	}

	// Slam the UI text into place.
	//
	// time (optional): how long should the slam take?  Omit to use value set in the inspector.
	public void Slam(float time = -1f)
	{
		if (time > 0f)
			slamTime = time;
		
		progressPct = 0.0f;

		// Might not be initialized yet.
		if (graphic != null) {
			graphic.color = new Color (graphic.color.r, graphic.color.g, graphic.color.b, 0.0f);
		}
	}
}
