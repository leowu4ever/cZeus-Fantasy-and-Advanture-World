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


		Debug.Log ("start init");
		CSVParser.Packet rawData = CSVParser.ParseCSV.generateData ("6");
		List<string> displayContent = rawData.DisplayData;
		if (displayContent.Count == contentSpriteArray.Length) {
			Debug.Log ("size matched");

			// assign board content according to CSV input 
			for (int a = 0; a < contentSpriteArray.Length; a++) {
				contentSpriteArray [a].GetComponent<ContentScript> ().content = displayContent [a];
			}

		}
	
	}


	void Update ()
	{
	
	}
}