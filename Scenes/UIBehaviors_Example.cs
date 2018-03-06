using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBehaviors_Example : MonoBehaviour {
	
	void Start()
	{
		StartCoroutine (RunFader ());
		StartCoroutine (RunShaker ());
		StartCoroutine (RunSlammer ());
		StartCoroutine (RunGroupFader ());
		StartCoroutine (RunAnimateValue ());
	}

	IEnumerator RunAnimateValue()
	{
		UIValueAnimator anim = GameObject.FindObjectOfType<UIValueAnimator> ();
		anim.SetValue (0);

		while (true) {
			anim.AnimateValue (Random.Range (0, 10) * 750, Random.Range (1.0f, 3.0f));
			yield return new WaitForSeconds (5.0f);
		}
	}

	IEnumerator RunGroupFader()
	{
		UIGroupFader[] list = GameObject.FindObjectsOfType<UIGroupFader>();
		float[] delayList = new float[list.Length];
		for (int i = 0; i < delayList.Length; i++) {
			delayList [i] = list [i].changeDelay;
		}

		while (true) {
			yield return new WaitForSeconds (3.0f);
			for (int i = 0; i < delayList.Length; i++) {
				list [i].Fade (0.0f, 0.25f, delayList [i] * 0.2f);
			}
			yield return new WaitForSeconds (3.0f);
			for (int i = 0; i < delayList.Length; i++) {
				list [i].Fade (1.0f, 0.75f, delayList [i]);
			}
		}
	}


	IEnumerator RunSlammer()
	{
		UISlamIn slammer = GameObject.FindObjectOfType<UISlamIn> ();

		while (true) {
			slammer.slamSize = Random.Range (1.5f, 3.0f);
			slammer.slamTime = Random.Range (0.2f, 1.0f);
			slammer.Slam ();
			yield return new WaitForSeconds (3.0f);
		}
	}

	IEnumerator RunFader()
	{
		UIFadeAway fader = GameObject.FindObjectOfType<UIFadeAway> ();

		while (true) {
			fader.fadeSize = Random.Range (1.5f, 3.0f);
			fader.Fade (Random.Range (1.0f, 3.0f));
			yield return new WaitForSeconds (3.0f);
			fader.Restore ();
			yield return new WaitForSeconds (1.0f);
		}
	}

	IEnumerator RunShaker()
	{
		UIShaker shaker = GameObject.FindObjectOfType<UIShaker> ();

		while (true) {
			shaker.Shake (2.0f, Random.Range(1.0f, 10.0f));
			yield return new WaitForSeconds (3.0f);
		}
	}
}
