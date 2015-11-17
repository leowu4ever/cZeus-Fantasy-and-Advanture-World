using UnityEngine;
using System.Collections;

public class BoardPressedHandler : MonoBehaviour
{

	private GameObject currentPressedBoard;

	/*
	 * It shoots a laser and determine which board is selected
	 * 
	 * Can only one board gets selected each time 
	 * 
	 * Also need to store the reference of selected board
	 */

	void Update ()
	{ 	
		if (Input.GetMouseButtonDown (0)) {

			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) {

				// -------------------- Test board press --------------------
				GameObject pressedContent = hit.transform.gameObject;
				ContentScript pressedContentScript = pressedContent.GetComponent<ContentScript> ();
				Debug.Log (hit.transform.name + " : " + pressedContentScript.content + " Answer : " + pressedContentScript.answer);
				Debug.Log (hit.transform.parent.name);
			

				GameObject pressedBoard = hit.transform.parent.gameObject;
				if (currentPressedBoard == null) {
					currentPressedBoard = pressedBoard;
				}

				// TO-DO 
				if (pressedBoard == currentPressedBoard) {
					BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> ();
					if (!pressedBoardScript.isPressed) {
						pressedBoardScript.switchToPressedBoardBg ();
					} else {
						pressedBoardScript.switchToNormalBoardBg ();
					}
				} else {
					currentPressedBoard = pressedBoard;
				}


			} 
		}
	}
}
