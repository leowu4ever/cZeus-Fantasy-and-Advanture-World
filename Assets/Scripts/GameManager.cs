using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{   
	public GameObject[] contentSpriteArray;
	public static bool isInputing;
	public static bool isGameover;
	public static int errorCount;
	public const int MAX_ERROR_NUMBER = 5;
	public const int GAME_DURATION = 113;
	public static int remainingTime;
	public static int answeredCount;
	public static int totalAnswerNumber;
	public GameObject scoreWindow;
	public string puzzleLevel;

	void Awake ()
	{
		remainingTime = GAME_DURATION;
	}

	void Start ()
	{
		InitGameboard ();
		InGameTimer.initTimer (GAME_DURATION);
		InGameTimer.StartTimer ();
	}

	void Update ()
	{
		remainingTime = InGameTimer.countTime;

		if (!isGameover) {
			if (errorCount > MAX_ERROR_NUMBER || answeredCount == totalAnswerNumber || InGameTimer.isTimerFinish) {
				InGameTimer.StopTimer ();
				isGameover = true;
				scoreWindow.SetActive (true);
			}
		}

	}

	void InitGameboard ()
	{
		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData (puzzleLevel);    // How to pass a parameter 
		List<string> contentList = rawData.displayData;
		List<string> answerList = rawData.answerData;
        SetTotalAnswerNumberFor(puzzleLevel, rawData.rowSize, rawData.columnSize);            
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

		// ---------------------- Assign ------------------------
		if (contentList.Count == contentSpriteArray.Length) {   // size check
			for (int a = 0; a < contentSpriteArray.Length; a++) {
				if (contentList [a] == "0" && answerList [a] != "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = contentList [a];       // assign content
					contentSpriteArray [a].GetComponent<ContentScript> ().answer = answerList [a];     // assign answer
				}else if(contentList[a] != "0" && answerList[a] != "0")
                {
                    contentSpriteArray[a].GetComponent<ContentScript>().content = contentList[a];       // assign content
                    contentSpriteArray[a].GetComponent<ContentScript>().answer = answerList[a];         // assign answer
                    contentSpriteArray[a].GetComponent<ContentScript>().isAnswered = true;
                    IncreAnsweredCountByOne();
                }
                else if (contentList [a] == "0" && answerList [a] == "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = "";
				} else if (contentList [a] != "0" && answerList [a] == "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = contentList [a];       // assign content
					contentSpriteArray [a].GetComponent<ContentScript> ().answer = answerList [a];     // assign answer
				}
			}
		}
	}
    void SetTotalAnswerNumberFor(string puzzleLevel,int rowSize,int columnSize)
    {
        totalAnswerNumber = columnSize * rowSize;
        if (puzzleLevel == "1" || puzzleLevel == "2")
        {
            totalAnswerNumber = 2;
        }
        else if (puzzleLevel == "3")
        {
            totalAnswerNumber = 3;
        }
        else if (puzzleLevel == "4"|| puzzleLevel == "5")
        {
            totalAnswerNumber = 4;
        }
    }
    public static void IncreaseErrorCount ()
	{
		errorCount++;
	}

	public static void IncreAnsweredCountByOne ()
	{
		answeredCount++;
	}
}