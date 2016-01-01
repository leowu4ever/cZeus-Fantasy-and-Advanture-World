using UnityEngine;
using System.Collections;

public class WindowHandler : MonoBehaviour
{
	public GameObject inputNumberBar;
    //for level 1-5
    public GameObject[] mysteryList;
    public GameObject[] mysteryAnswerChoice;
    
    void Update ()
	{
		if (GameManager.isInputing) {
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
        if (GameManager.puzzleLv=="1"|| GameManager.puzzleLv == "2"|| GameManager.puzzleLv == "3"|| GameManager.puzzleLv == "4"|| GameManager.puzzleLv == "5")
        {
            SelectedInputNumberToDisplay();
        }
        DisableInputNumberForWrongAnswer();
    }
    
	void DeactivateInputNumberBar ()
	{
		inputNumberBar.SetActive (false);
	}
    
    void SelectedInputNumberToDisplay()
    {
        if (BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().tag == "Mystery Number Content")
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
        if (BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().tag == "Mystery Number Content")
        {
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
    void ActiveInputNumberForAll()
    {
        for (int i = 1; i < inputNumberBar.transform.childCount; i++)
        {
            inputNumberBar.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
