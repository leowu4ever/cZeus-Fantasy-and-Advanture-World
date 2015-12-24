using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{   
	public string puzzleLevel;
	public GameObject[] contentSpriteArray;
	public GameObject scoreWindow;

	public static bool isInputing;
	public static bool isGameover;
	public static int errorCount;	
	public static int remainingTime;
	public static int numOfAnswered;
	public static int numOfAnswers;

	public const int MAX_ERROR_NUMBER = 5;
	public const int GAME_DURATION = 200;

	void Start ()
	{
		InitGame ();
		InitGameboard ();
	}

	void Update ()
	{
		if (!isGameover) {
			remainingTime = InGameTimer.countTime;
			if (errorCount > MAX_ERROR_NUMBER || numOfAnswered == numOfAnswers || InGameTimer.isTimerFinish) {
				InGameTimer.StopTimer ();
				isGameover = true;
				scoreWindow.SetActive (true);
			}
		}
	}

	void InitGame ()
	{
		isGameover = false;
		errorCount = 0;
		numOfAnswered = 0;
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

		// ---------------------- Assign ------------------------
		if (contentList.Count == contentSpriteArray.Length) {   // size check
			for (int a = 0; a < contentSpriteArray.Length; a++) {
				if (contentList [a] == "0" && answerList [a] != "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = contentList [a];       
					contentSpriteArray [a].GetComponent<ContentScript> ().answer = answerList [a];   	   
				} else if (contentList [a] != "0" && answerList [a] != "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = contentList [a];     
					contentSpriteArray [a].GetComponent<ContentScript> ().answer = answerList [a];        
					contentSpriteArray [a].GetComponent<ContentScript> ().isAnswered = true;
					IncrenumOfAnsweredByOne ();
				} else if (contentList [a] == "0" && answerList [a] == "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = "";
				} else if (contentList [a] != "0" && answerList [a] == "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = contentList [a];     
					contentSpriteArray [a].GetComponent<ContentScript> ().answer = answerList [a];    	
				}
			}
		}

//		// ---------------------- Test ------------------------
//		string completeDisplayContentTestString = "";
//		for (int a = 0; a < contentList.Count; a++) {
//			completeDisplayContentTestString = completeDisplayContentTestString + " " + contentList [a];
//		}
//		Debug.Log (rawData.rowSize + "x" + rawData.columnSize + " Puzzle: " + rawData.index + " size of " + contentList.Count);
//		Debug.Log ("content: " + completeDisplayContentTestString);
//		
//		string completeAnswerTestString = "";
//		for (int a = 0; a < answerList.Count; a++) {
//			completeAnswerTestString = completeAnswerTestString + " " + answerList [a];
//		}
//		Debug.Log ("answer: " + completeAnswerTestString);

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

	public static void IncreaseErrorCount ()
	{
		errorCount++;
	}

	public static void IncrenumOfAnsweredByOne ()
	{
		numOfAnswered++;
	}
}