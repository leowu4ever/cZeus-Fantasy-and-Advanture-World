using UnityEngine;
using System.Collections;

public class BoardPressedHandler : MonoBehaviour
{
	private GameObject currentPressedBoard;
	public static GameObject currentPressedContent;

	void Update ()
	{
		if (!GameManager.isGameover) {
			if (Input.GetMouseButtonDown (0)) {
	
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				//RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);
			
				if (hit.collider != null) {
					// -------------------- Test board press --------------------
					GameObject pressedBoard = hit.transform.parent.gameObject;
					GameObject pressedContent = hit.transform.gameObject;

					ContentScript pressedContentScript = pressedContent.GetComponent<ContentScript> ();
					//Debug.Log (hit.transform.name + " : " + pressedContentScript.content + " Answer : " + pressedContentScript.answer);
					//Debug.Log (hit.transform.parent.name);
					if (!pressedContent.GetComponent<ContentScript> ().isAnswered) {
						if (currentPressedBoard == null) {
							Debug.Log ("Init Cur");
							currentPressedBoard = pressedBoard;
							currentPressedContent = pressedContent;
							SwitchToPressedBoardBg (pressedBoard);
						} else if (currentPressedBoard == pressedBoard) {
							if (pressedBoard.GetComponent<BoardScript> ().isPressed) {
								if (currentPressedContent.name != pressedContent.name) {
									Debug.Log ("Same Board, diff content");
									currentPressedContent = pressedContent;
								} else {
									// pressed bg
									Debug.Log ("Same Board, same content");
									ToggleBoardBg (pressedBoard);
								}
							} else {
								ToggleBoardBg (pressedBoard);
							}
						} else if (currentPressedBoard != pressedBoard) {
							Debug.Log ("Diff board");
							BoardScript currentPressedBoardScript = currentPressedBoard.GetComponent<BoardScript> ();
							currentPressedBoardScript.SwitchToNormalBoardBg ();
							ToggleBoardBg (pressedBoard);
							currentPressedBoard = pressedBoard;
							currentPressedContent = pressedContent;
						}
					}
				}
			}
		}
	}

	void ToggleBoardBg (GameObject pressedBoard)
	{
		BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> ();
		if (!pressedBoardScript.isPressed) {
			TurnOnInputMode ();
			pressedBoardScript.SwitchToPressedBoardBg ();
		} else {
			TurnOffInputMode ();
			pressedBoardScript.SwitchToNormalBoardBg ();
		}
	}

	void SwitchToPressedBoardBg (GameObject pressedBoard)
	{
		TurnOnInputMode ();
		BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> ();
		pressedBoardScript.SwitchToPressedBoardBg ();
	}

	void SwitchToNormalBoardBg (GameObject pressedBoard)
	{
		TurnOffInputMode ();
		BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> ();
		pressedBoardScript.SwitchToNormalBoardBg ();
	}

	void TurnOnInputMode ()
	{
		GameManager.isInputing = true;
	}

	void TurnOffInputMode ()
	{
		GameManager.isInputing = false;
	}
}
