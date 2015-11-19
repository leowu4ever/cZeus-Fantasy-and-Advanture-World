using UnityEngine;
using System.Collections;

public class BoardPressedHandler : MonoBehaviour
{
	private GameObject currentPressedBoard;
    public static GameObject currentPressedContent;

	void Update ()
	{
        if (!GameManager.isGameover)
        {
       	    if (Input.GetMouseButtonDown (0))
            {

			    RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {

                    // -------------------- Test board press --------------------
                    GameObject pressedBoard = hit.transform.parent.gameObject;
                    GameObject pressedContent = hit.transform.gameObject;

                    ContentScript pressedContentScript = pressedContent.GetComponent<ContentScript>();
                    //Debug.Log (hit.transform.name + " : " + pressedContentScript.content + " Answer : " + pressedContentScript.answer);
                    //Debug.Log (hit.transform.parent.name);
                    if (currentPressedBoard == null && !pressedContent.GetComponent<ContentScript>().isAnswered)
                    {
                        Debug.Log("Init Cur");
                        currentPressedBoard = pressedBoard;
                        currentPressedContent = pressedContent;
                        SwitchToPressedBoardBg(pressedBoard);
                    }

                    else if (currentPressedBoard == pressedBoard && !pressedContent.GetComponent<ContentScript>().isAnswered)
                    {
                        if (pressedBoard.GetComponent<BoardScript>().isPressed)
                        {
                            if (currentPressedContent.tag != pressedContent.tag)
                            {
                                Debug.Log("Same Board, diff content");
                                currentPressedContent = pressedContent;
                            }
                            else
                            {
                                // pressed bg
                                Debug.Log("Same Board, same content");
                                ToggleBoardBg(pressedBoard);
                            }
                        }
                        else
                        {
                            ToggleBoardBg(pressedBoard);
                        }
                    }

                    else if (currentPressedBoard != pressedBoard && !pressedContent.GetComponent<ContentScript>().isAnswered)
                    {
                        Debug.Log("Diff board");
                        BoardScript currentPressedBoardScript = currentPressedBoard.GetComponent<BoardScript>();
                        currentPressedBoardScript.switchToNormalBoardBg();
                        ToggleBoardBg(pressedBoard);
                        currentPressedBoard = pressedBoard;
                        currentPressedContent = pressedContent;
                    }
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

    void SwitchToPressedBoardBg (GameObject pressedBoard)
    {
        TurnOnInputMode();
        BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript>();
        pressedBoardScript.switchToPressedBoardBg();
    }

    void SwitchToNormalBoardBg(GameObject pressedBoard)
    {
        TurnOffInputMode();
        BoardScript pressedBoardScript = pressedBoard.GetComponent<BoardScript>();
        pressedBoardScript.switchToNormalBoardBg();
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
