using UnityEngine;
using System.Collections;

public class WindowHandler : MonoBehaviour
{
	public GameObject inputNumberBar;
    //for level 1-5
    public GameObject[] mysteryList;
    public GameObject[] mysteryAnswerChoice;
    public GameObject hintButton;

    void Update ()
	{
		if (GameManager.isInputing) {

            if (!GameManager.IsTutorial()) {
                if (GameManager.IsAnyHintLeft() && BoardPressedHandler.curPressedContent.tag == "Mystery Number Content") {
                    hintButton.SetActive (true);
                } else {
                    hintButton.SetActive (false);
                }
            }
            
			ActivateInputNumberBar ();
			Debug.Log ("isInputing");
		} else {
			DeactivateInputNumberBar ();
			Debug.Log ("not isInputing");
		}
	}
    
	void ActivateInputNumberBar ()
	{
		inputNumberBar.SetActive (true);
        ActiveInputNumberForAll();
        if (GameManager.IsTutorial ())
        {
             DisplaySelectionsOnInputNumBar();
        }
        DisableInputNumberForWrongAnswer();
        
    }
    
	void DeactivateInputNumberBar ()
	{
		inputNumberBar.SetActive (false);
	}
    
    void  DisplaySelectionsOnInputNumBar()
    {
        if (BoardPressedHandler.curPressedContent.tag == "Mystery Number Content")
        {
            
            for (int i = 1; i < inputNumberBar.transform.childCount; i++)
            {
                inputNumberBar.transform.GetChild(i).gameObject.SetActive(false);
                for (int j = 0; j < mysteryList.Length; j++)
                {
                    if (BoardPressedHandler.curPressedBoard == mysteryList[j])
                    {
                        for (int n = (mysteryAnswerChoice.Length / mysteryList.Length) * j; n < (mysteryAnswerChoice.Length / mysteryList.Length) * j + mysteryAnswerChoice.Length / mysteryList.Length; n++)
                        {
                            if (i == int.Parse(mysteryAnswerChoice[n].transform.GetChild(0).GetComponent<ContentScript>().content))
                            {
                                inputNumberBar.transform.GetChild(i).gameObject.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
        else
        {    
            for (int i = 1; i < inputNumberBar.transform.childCount; i++)
            {
                inputNumberBar.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    
    void DisableInputNumberForWrongAnswer()
    {
        if (BoardPressedHandler.curPressedContent.tag == "Mystery Number Content")
        {
            DisableZeroForMysteryBoard ();
            for (int i = 1; i < inputNumberBar.transform.childCount; i++)
            {
                for(int j=0; j< BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().wrongAnswer.Count;j++)
                {
                    if (i == int.Parse(BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().wrongAnswer[j]))
                    {
                        inputNumberBar.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    
    void DisableZeroForMysteryBoard () {
        inputNumberBar.transform.GetChild(inputNumberBar.transform.childCount-1).gameObject.SetActive(false);
    }
    
    void ActiveInputNumberForAll()
    {
        for (int i = 1; i < inputNumberBar.transform.childCount; i++)
        {
            inputNumberBar.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
