using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WindowHandler : MonoBehaviour
{
	public GameObject inputNumberBar;
    //for level 1-5
    public GameObject[] mysteryList, mysteryAnswerChoice;
    public GameObject hintButton;
    public Sprite cross;
    private Sprite[] spriteNum = new Sprite[9]; 
    private float inputNumberBarY;
    private bool inputNumberBarShowing;
    
    void Start () {
        if (!GameManager.IsTutorial()) {
            LeanTween.moveX (GameObject.Find("Start Note"), 0, 1f).setEase (LeanTweenType.easeInBounce);
            LeanTween.moveX (GameObject.Find("Start Note"), -6f, 1f ).setEase (LeanTweenType.easeOutExpo).setDelay (2f);
        }
        InitSpriteNum();
        inputNumberBarY = inputNumberBar.transform.position.y;
    }

    void Update ()
	{
        Debug.Log (GameObject.Find ("Tool Bar").transform.position.y);
        if (GameManager.isGameover) {
          LeanTween.moveY (GameObject.Find ("Tool Bar"), 1000, 0.5f).setEase (LeanTweenType.easeOutExpo); 
        }
        
		if (GameManager.isInputing && !inputNumberBarShowing) {
            if (!GameManager.IsTutorial()) {
                if (GameManager.IsAnyHintLeft() && BoardPressedHandler.curPressedContent.tag == "Mystery Number Content" && !BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().isAnswered) {
                    hintButton.SetActive (true);
                } else {
                    hintButton.SetActive (false);
                }
            }
			ActivateInputNumberBar ();

		} else if (!GameManager.isInputing && inputNumberBarShowing) { 
            DeactivateInputNumberBar ();
            if (!GameManager.IsTutorial()) {
                hintButton.SetActive (false);
            }
		} else if (!GameManager.isInputing) {
            DeactivateInputNumberBar ();
            if (!GameManager.IsTutorial()) {
                hintButton.SetActive (false);
            }
        }
	}
    
	void ActivateInputNumberBar ()
	{
		//inputNumberBar.SetActive (true);
        inputNumberBarShowing = true;
        LeanTween.moveY (inputNumberBar, inputNumberBarY, 0.5f).setEase (LeanTweenType.easeOutExpo);
        ActiveInputNumberForAll();
        if (GameManager.IsTutorial ())
        {
             DisplaySelectionsOnInputNumBar();
        }
        DisableInputNumberForWrongSelects();
        
    }
    
	void DeactivateInputNumberBar ()
	{
        inputNumberBarShowing = false;
        LeanTween.moveY (inputNumberBar, -100, 0.5f).setEase (LeanTweenType.easeOutExpo);
		//inputNumberBar.SetActive (false);
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
    
    void DisableInputNumberForWrongSelects()
    {
        if (BoardPressedHandler.curPressedContent.tag == "Mystery Number Content")
        {
            DisableZeroForMysteryBoard ();
            for (int i = 1; i < inputNumberBar.transform.childCount; i++)
            {
                for (int j=0; j< BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().wrongSelects.Count;j++)
                {
                    if (i == int.Parse(BoardPressedHandler.curPressedContent.GetComponent<ContentScript>().wrongSelects[j]))
                    {
                        inputNumberBar.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false; 
                        inputNumberBar.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = cross;
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
            if(i<10)
            {
                inputNumberBar.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                inputNumberBar.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = spriteNum[i - 1];
            }
        }
    }
    void InitSpriteNum()
    {
        for(int i=0;i<spriteNum.Length;i++)
        {
            spriteNum[i] = inputNumberBar.transform.GetChild(i + 1).gameObject.GetComponent<Image>().sprite;
        }
    }
}
