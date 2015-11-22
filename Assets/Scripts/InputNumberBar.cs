using UnityEngine;
using System.Collections;
public class InputNumberBar : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("S");
		gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (0, 0, 0);
		LeanTween.scale (gameObject, new Vector3 (1, 1, 1), 0.7f).setEase (LeanTweenType.easeOutBounce).setDelay (0.5f);
	}
}
