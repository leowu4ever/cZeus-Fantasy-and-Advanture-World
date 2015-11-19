﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{   
	public GameObject[] contentSpriteArray;
	public static bool isInputing;
	public static bool isGameover;
	public static int errorCount;
	public const int MAX_ERROR_NUMBER = 5;
	public const int GAME_DURATION = 100;
	public static int remainingTime;
	public static int answeredCount;
	public static int totalAnswerNumber;
	public GameObject inputNumberHanlder;

	void OnGUI ()
	{
		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData ("6");    // How to pass a parameter 
		GUI.Label (new Rect (10, 10, 100, 100), rawData.displayData [0]);
	}

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
			if (errorCount > MAX_ERROR_NUMBER) {
				isGameover = true;
				// ask they want to continue or quit 
				Debug.Log ("Game Over");
			}

			if (answeredCount == totalAnswerNumber) {
				isGameover = true;
				Debug.Log ("win");
				// display score window
			}

			if (InGameTimer.isTimerFinish) {
				isGameover = true;
				Debug.Log ("time up");
			}

			if (isInputing) {
				Debug.Log ("isInputing true ");
			} else {
				Debug.Log ("isInputing false ");
			}
		}

	}

	void InitGameboard ()
	{
		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData ("6");    // How to pass a parameter 
		List<string> contentList = rawData.displayData;
		List<string> answerList = rawData.answerData;
		totalAnswerNumber = rawData.columnSize * rawData.rowSize;
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
				if (contentList [a] != "0") {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = contentList [a];       // assign content
					contentSpriteArray [a].GetComponent<ContentScript> ().answer = answerList [a];     // assign answer
				} else {
					contentSpriteArray [a].GetComponent<ContentScript> ().content = "";
				}
			}
		}
	}

	public static void IncreaseErrorCount ()
	{
		errorCount++;
	}
}