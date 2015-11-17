using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public GameObject[] contentSpriteArray;
	private int boardCount;

	void Start ()
	{	
		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData ("6");	// How to pass a parameter 
		List<string> contentList = rawData.displayData;
		List<string> answerList = rawData.answerData;

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
		if (contentList.Count == contentSpriteArray.Length) {	// size check
			for (int a = 0; a < contentSpriteArray.Length; a++) {
				contentSpriteArray [a].GetComponent<ContentScript> ().content = contentList [a];		// assign content
				contentSpriteArray [a].GetComponent<ContentScript> ().answer = answerList [a];		// assign answer
			}
		}
	}
}