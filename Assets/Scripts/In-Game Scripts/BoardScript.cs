using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour
{
	//public Sprite[] normalAndPressedBoardSprites;
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
		GetComponent<SpriteRenderer> ().color =  new Color (1f, 1f, 1f, 1f);
	}

	public void SwitchToPressedBoardBg ()
	{
		isPressed = true;
		GetComponent<SpriteRenderer> ().color = new Color (199/255f, 167/255f, 1f, 1f);

	}
}
