using UnityEngine;
using System.Collections;

public class BoardPressedHandler : MonoBehaviour
{
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
				GameObject pressedContent = hit.transform.gameObject;
				ContentScript pressedContentScript = pressedContent.GetComponent<ContentScript> ();
				GameObject pressedBoard = hit.transform.parent.gameObject;
				BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> ();

				Debug.Log (hit.transform.name + " : " + pressedContentScript.content + " Answer : " + pressedContentScript.answer);
				Debug.Log (hit.transform.parent.name);
				if (!pressedBoardScript.isPressed) {
					pressedBoardScript.switchToPressedBoardBg ();
				} else {
					pressedBoardScript.switchToNormalBoardBg ();
				}
			} 
		}
	}
}
