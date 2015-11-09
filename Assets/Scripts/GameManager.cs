using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public GameObject[] contentSpriteArray;
	private int boardCount;
	// Use this for initialization
	void Start ()
	{	

		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData ("6");	// How to pass a parameter 
		List<string> displayContentList = rawData.displayData;
		List<string> answerContentList = rawData.answerData;

		// ---------------------- Test ------------------------
		string displayContentInARow = "";
		for (int a = 0; a < displayContentList.Count; a++) {
			displayContentInARow = displayContentInARow + " " + displayContentList [a];
		}
		Debug.Log (rawData.rowSize + "x" + rawData.columnSize + " Puzzle: " + rawData.index + " size of " + displayContentList.Count);
		Debug.Log (displayContentInARow);
		// ---------------------- Test ------------------------

		if (displayContentList.Count == contentSpriteArray.Length) {	// size check
			for (int a = 0; a < contentSpriteArray.Length; a++) {
				//Debug.Log ("assign" + displayContent [a]);
				contentSpriteArray [a].GetComponent<ContentScript> ().content = displayContentList [a];		// assign content
			}
		}
	}
}