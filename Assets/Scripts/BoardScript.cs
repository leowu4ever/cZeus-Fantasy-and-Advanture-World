using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour
{

	public Sprite[] normalAndPressedBoardSprites;
	public bool isPressed = false;

	public void SwitchToNormalBoardBg ()
	{
		isPressed = false;
		GetComponent<SpriteRenderer> ().sprite = normalAndPressedBoardSprites [0];
	}

	public void SwitchToPressedBoardBg ()
	{
		isPressed = true;
		GetComponent<SpriteRenderer> ().sprite = normalAndPressedBoardSprites [1];
	}
}
