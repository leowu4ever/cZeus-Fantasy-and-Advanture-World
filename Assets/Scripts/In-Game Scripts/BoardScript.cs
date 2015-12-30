using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour
{
	public bool isPressed = false;
	public GameObject plusIcon, multiplyIcon, additionContent, productContent;

	void Update ()
	{
		UpdateMathIcon();
	}

    void UpdateMathIcon () {
        if (plusIcon != null) {
			if (additionContent.GetComponent<ContentScript> ().content != "") {
				plusIcon.SetActive (true);
			} else {
				plusIcon.SetActive (false);
			} 
			if (productContent.GetComponent<ContentScript> ().content != "") {
				multiplyIcon.SetActive (true);
			} else {
				multiplyIcon.SetActive (false);
			} 
		}
    }
    
	public void SwitchToNormalBoardBg ()
	{
		isPressed = false;
        if(!BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().isAnswered)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            LeanTween.scale (gameObject, new Vector3 (1f, 1f, 1f), 0.15f).setEase (LeanTweenType.linear);
            InputNumberBarHandler.wrongAnswerCountFrame = -1;
        }    
	}

	public void SwitchToPressedBoardBg ()
	{
		isPressed = true;
        LeanTween.scale (gameObject, new Vector3 (0.9f, 0.9f, 0.9f), 0.15f).setEase (LeanTweenType.linear);
        GetComponent<SpriteRenderer>().color = new Color(77 / 255f, 184 / 255f, 1f, 1f);
	}
}
