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
                // initial press 
                // new press or quit press
                // switch press
                if (currentPressedBoard == null)
                {
                    currentPressedBoard = pressedBoard;
                    ToggleBoardBg(pressedBoard);
                }

                else if (currentPressedBoard == pressedBoard)
                {
                    if (!pressedContent.transform.parent == currentPressedBoard)
                    {
                        ToggleBoardBg(pressedBoard);
                    }
                }

                else if (currentPressedBoard != pressedBoard)
                {
                    BoardScript currentPressedBoardScript = currentPressedBoard.GetComponent<BoardScript>();
                    currentPressedBoardScript.switchToNormalBoardBg();
                    ToggleBoardBg(pressedBoard);
                    currentPressedBoard = pressedBoard;
                }
            } 
		}
	}

    void ToggleBoardBg (GameObject pressedBoard)
    {
        BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript>();
        if (!pressedBoardScript.isPressed)
        {
            TurnOnInputMode();
            pressedBoardScript.switchToPressedBoardBg();
        }
        else
        {
            TurnOffInputMode();
            pressedBoardScript.switchToNormalBoardBg();
        }
    }

    void TurnOnInputMode ()
    {
        GameManager.isInputing = true;
    }

    void TurnOffInputMode()
    {
        GameManager.isInputing = false;
    }
}
