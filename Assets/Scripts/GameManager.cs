using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{   
	public string puzzleLevel;
    public int numOfAnswers;
	public GameObject[] contentSpriteArray;
	public GameObject scoreWindow, gameoverWindow;

	public static bool isInputing, isGameover;
	public static int errorCount, numOfAnswered;
    	
	public const int MAX_ERROR_NUMBER = 5;
	public const int GAME_DURATION = 10;

	void Start ()
	{
		InitGame ();
		InitGameboard ();
	}

	void Update ()
	{
		if (!isGameover) {  
            if (numOfAnswered == numOfAnswers) {    // game win
                StopCurGame();
				scoreWindow.SetActive (true);  
            } else if (errorCount > MAX_ERROR_NUMBER || InGameTimer.isTimerFinish) {   // game over 1. reach max error 2. time up
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
		InGameTimer.StartTimer ();
	}

	void InitGameboard ()
	{
		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData (puzzleLevel);   
		List<string> contentList = rawData.displayData;
		List<string> answerList = rawData.answerData;
		SetnumOfAnswersFor (puzzleLevel, rawData.rowSize, rawData.columnSize);            
        AssignContentAndAnswer (contentList, answerList);
	}
    
    void AssignContentAndAnswer (List<string> contentList, List<string> answerList) {
         for (int a = 0; a < contentSpriteArray.Length; a++) {
            string content = contentList [a];
            string answer = answerList [a];
            contentSpriteArray [a].GetComponent<ContentScript> ().content = content;       
            contentSpriteArray [a].GetComponent<ContentScript> ().answer = answer;   
            // mystery answered
            if (content != "0" && answer != "0") {
                contentSpriteArray [a].GetComponent<ContentScript> ().isAnswered = true;
                IncrenumOfAnsweredByOne ();
            } 
            // pair/square not answered
            if (content == "0" && answer == "0") {
                contentSpriteArray [a].GetComponent<ContentScript> ().content = ""; // special handle in case you next input becomes '0' + 1/n
            }  
		}
    }

	void SetnumOfAnswersFor (string puzzleLevel, int rowSize, int columnSize)
	{
		if (puzzleLevel == "1" || puzzleLevel == "2") {
			numOfAnswers = 2;
		} else if (puzzleLevel == "3") {
			numOfAnswers = 3;
		} else if (puzzleLevel == "4" || puzzleLevel == "5") {
			numOfAnswers = 4;
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

	public static void IncrenumOfAnsweredByOne ()
	{
		numOfAnswered++;
	}
}