using UnityEngine;
using System.Collections;

public class BoardPressedHandler : MonoBehaviour
{
	public static GameObject curPressedBoard;
	public static GameObject curPressedContent;

	void Update ()
	{
		if (!GameManager.isGameover) {
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);			
				if (hit.collider != null) {
					// -------------------- Test board press --------------------
					GameObject pressedBoard = hit.transform.parent.gameObject;
					GameObject pressedContent = hit.transform.gameObject;
                    BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> (); 
					ContentScript pressedContentScript = pressedContent.GetComponent<ContentScript> ();
                    
					if (!pressedContentScript.isAnswered) {
						
                        if (curPressedBoard == null && curPressedContent == null) {    // for first press
							//Debug.Log ("Init Cur");    
							SwitchToPressedBoardBg (pressedBoard);
                            UpdatePressedStates (pressedBoard, pressedContent);
                            
						} else if (curPressedBoard == pressedBoard) {
							if (pressedBoardScript.isPressed) {
								if (curPressedContent.name != pressedContent.name) {    // same board diff content = no action
									//Debug.Log ("Same Board, diff content");
                                    UpdatePressedStates (pressedBoard, pressedContent);
								} else {
									//Debug.Log ("Same Board, same content");    // same board same content = switch off
                                    SwitchToNormalBoardBg (pressedBoard);
                                    curPressedBoard = null;
						          	curPressedContent = null;
								}
							} else {
			                    SwitchToPressedBoardBg (pressedBoard);                                
                                UpdatePressedStates (pressedBoard, pressedContent);
							}
                            
						} else if (curPressedBoard != pressedBoard) {
							//Debug.Log ("Diff board");
                            SwitchToNormalBoardBg (curPressedBoard);
                            SwitchToPressedBoardBg (pressedBoard);
                            UpdatePressedStates (pressedBoard, pressedContent);
						}
					}
				}
			}
		}
	}
    
    void UpdatePressedStates (GameObject pressedBoard,  GameObject pressedContent) 
    {
         curPressedBoard = pressedBoard;
		 curPressedContent = pressedContent;
    }
    
	void SwitchToPressedBoardBg (GameObject pressedBoard)
	{
		GameManager.isInputing = true;
		BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> ();
		pressedBoardScript.SwitchToPressedBoardBg ();
	}

	void SwitchToNormalBoardBg (GameObject pressedBoard)
	{
		GameManager.isInputing = false;
		BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript> ();
		pressedBoardScript.SwitchToNormalBoardBg ();
	}
}
