using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
	public string puzzleLevel;
    public static string puzzleLv;
    public GameObject gameBoard;
	public GameObject[] contentSpriteArray;
	public GameObject scoreWindow, gameoverWindow;

	public static bool isInputing, isGameover;
	public static int errorCount, numOfAnswered;

    public const int MAX_ERROR_NUMBER = 5;
	public const int GAME_DURATION = 1000;

    private int numOfAnswers;
    private bool initFinished;
    
	void Start ()
	{  
        gameBoard.transform.position = new Vector3 (5,1,0);
        puzzleLv = puzzleLevel; // BAD
		InitGame ();
		InitGameboard ();
        initFinished = true; 
	}

	void Update ()
	{
        if (initFinished) {
            initFinished = false;
            LeanTween.moveX (gameBoard, 0, 2f).setEase (LeanTweenType.easeOutBounce);
            InGameTimer.StartTimer ();
        }
		if (!isGameover) {  
            //StartCoroutine(ExecuteAfterTime(1f,chapterScript.chapterSceneId));

            if (numOfAnswered == numOfAnswers) {    // game win

               StopCurGame();
			   scoreWindow.SetActive (true);  
               ChapterMapManager.SetLevelStateTo (PlayerPrefs.GetString("NEXTLEVELNAME"), false);
               // for level map 
               
            } else if (errorCount > MAX_ERROR_NUMBER || InGameTimer.isTimerFinish) {   // game over 1. reach max error 2. time over
               StopCurGame();
               gameoverWindow.SetActive (true);
            }
		}
	}

	void InitGame ()
	{
		errorCount = 0;
		numOfAnswered = 0;
   		isGameover = false;
		isInputing = false;
		InGameTimer.initTimer (GAME_DURATION);

	}

	void InitGameboard ()
	{
		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData (puzzleLevel);   
		List<string> contentList = rawData.displayData;
		List<string> answerList = rawData.answerData;
		SetnumOfAnswersFor (puzzleLevel, rawData.rowSize, rawData.columnSize,rawData.isLShape);            
        AssignContentAndAnswer (contentList, answerList);
        // ---------------------- Test ------------------------
		string completeDisplayContentTestString = "";
		for (int a = 0; a < contentList.Count; a++) {
			completeDisplayContentTestString = completeDisplayContentTestString + " " + contentList [a];
		}
		Debug.Log (rawData.rowSize + "x" + rawData.columnSize + " Puzzle: " + rawData.index + " size of " + contentList.Count);
		Debug.Log ("content: " + completeDisplayContentTestString);

		string completeAnswerTestString = "";
		for (int a = 0; a < answerList.Count; a++) {
			completeAnswerTestString = completeAnswerTestString + " " + answerList [a];
		}
		Debug.Log ("answer: " + completeAnswerTestString);
	}
    
    void AssignContentAndAnswer (List<string> contentList, List<string> answerList) {
         for (int a = 0; a < contentSpriteArray.Length; a++) {
            string content = contentList [a];
            string answer = answerList [a];
            contentSpriteArray [a].GetComponent<ContentScript> ().content = content;       
            contentSpriteArray [a].GetComponent<ContentScript> ().answer = answer;   
            // mystery answered 
            // This does not apply for lv1-5
            if (content != "0" && answer != "0" && contentSpriteArray [a].transform.tag != "Selection") {
                contentSpriteArray [a].GetComponent<ContentScript> ().isAnswered = true;
                IncreNumOfAnsweredByOne ();
            } 
            // pair/square answered
            if(content != "0" && answer == "0") {
                contentSpriteArray [a].GetComponent<ContentScript> ().isAnswered = true;
            }
            // pair/square not answered
            if (content == "0" && answer == "0") {
                contentSpriteArray [a].GetComponent<ContentScript> ().content = ""; // special handle in case you next input becomes '0' + 1/n
            }  
		}
    }

	void SetnumOfAnswersFor (string puzzleLevel, int rowSize, int columnSize,bool isLShape)
	{
		if (puzzleLevel == "1" || puzzleLevel == "2") {
			numOfAnswers = 2;
		} else if (puzzleLevel == "3") {
			numOfAnswers = 3;
		} else if (puzzleLevel == "4" || puzzleLevel == "5") {
			numOfAnswers = 4;
		} else if (isLShape) {
            numOfAnswers = (columnSize * rowSize)-1;
        } else {
			numOfAnswers = columnSize * rowSize;
		}
	}
    
    void StopCurGame () {
        isGameover = true;
        InGameTimer.StopTimer ();
    }
 
	public static void IncreaseErrorCount ()
	{
		errorCount++;
	}

	public static void IncreNumOfAnsweredByOne ()
	{
		numOfAnswered++;
	}
}