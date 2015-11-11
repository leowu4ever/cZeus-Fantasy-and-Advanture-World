using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour
{

	public Sprite[] normalAndPressedBoardSprites;
	public bool isPressed = false;

	public void switchToNormalBoardBg ()
	{
		isPressed = false;
		GetComponent<SpriteRenderer> ().sprite = normalAndPressedBoardSprites [0];
	}

	public void switchToPressedBoardBg ()
	{
		isPressed = true;
		GetComponent<SpriteRenderer> ().sprite = normalAndPressedBoardSprites [1];
	}
}
