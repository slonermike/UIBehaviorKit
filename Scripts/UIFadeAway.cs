/************************************************************
 * 
 *                      UI Fade Away
 *                 2016 Slonersoft Games
 * 
 * Place this on a MaskableGraphic such as Image or Text and
 * call Fade to make it fade away and grow.
 * 
 * NOTE: Growth will happen relative to the pivot point of the
 * element.  This means if your pivot is on the top left, it
 * will grow toward the bottom right.
 * 
 ************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIFadeAway : MonoBehaviour {

	[Tooltip("Rate at which to animate.")]
	public AnimationCurve curve = AnimationCurve.Linear (0.0f, 0.0f, 1.0f, 1.0f);

	[Tooltip("Size to fade away to.  1.0 = no change.  2.0 = double size.")]
	public float fadeSize = 2.0f;

	[Tooltip("Time over which to perform the fade.")]
	public float fadeTime = 1.0f;

	[Tooltip("True to fade immediately on load, false to wait for script intervention.")]
	public bool fadeImmediately = true;

    float progressPct = 0.0f;
    MaskableGraphic text;

    Vector3 baseScale;

    // Use this for initialization
    void Start()
    {
        Initialize();
		if (!fadeImmediately) {
			Restore ();
		}
    }

	// Grab initial conditions for the graphic.
	//
    void Initialize()
    {
        if (text == null)
        {
            text = GetComponent<MaskableGraphic>();
            Fade(fadeTime);
            baseScale = text.rectTransform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (progressPct < 1.0f)
        {
            progressPct = Mathf.Clamp01(progressPct + (Time.deltaTime / fadeTime));

            float adjustedPct = curve.Evaluate(progressPct);

            text.rectTransform.localScale = Vector3.Lerp(baseScale, baseScale * fadeSize, adjustedPct);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f - adjustedPct);
        }
    }

	// Fade away.
	//
	// time: time in seconds to perform the fade.
	//
    public void Fade(float time = -1f)
    {
        Initialize();

        if (fadeTime > 0f)
            fadeTime = time;
        else
            fadeTime = 0.5f;

        progressPct = 0.0f;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
    }

	// Restore the graphic to its initial size and full opacity.
	//
    public void Restore()
    {
        Initialize();

        progressPct = 1.0f;
        text.rectTransform.localScale = baseScale;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
    }
}
