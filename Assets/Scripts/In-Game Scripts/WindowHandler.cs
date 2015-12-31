using UnityEngine;
using System.Collections;

public class WindowHandler : MonoBehaviour
{
	public GameObject inputNumberBar;
    //for level 1-5
    public GameObject[] MysterList;
    public GameObject[] mysterAnswerChoice;
    
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
        if (GameManager.puzzleLv=="1"|| GameManager.puzzleLv == "2"|| GameManager.puzzleLv == "3"|| GameManager.puzzleLv == "4"|| GameManager.puzzleLv == "5")
        {
            SelectedInputNumberToDisplay();
        }
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
                for (int j = 0; j < MysterList.Length; j++)
                {
                    if (BoardPressedHandler.curPressedBoard == MysterList[j])
                    {
                        for (int n = (mysterAnswerChoice.Length / MysterList.Length) * j; n < (mysterAnswerChoice.Length / MysterList.Length) * j + mysterAnswerChoice.Length / MysterList.Length; n++)
                        {
                            if (i == int.Parse(mysterAnswerChoice[n].transform.GetChild(0).GetComponent<ContentScript>().content))
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
}
