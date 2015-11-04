using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject[] contentSpriteArray;
	private int boardCount;
	// Use this for initialization
	void Start ()
	{
		GameObject[] boardArray = GameObject.FindGameObjectsWithTag ("Board");					// find gameobject by tag 
		int boardArraySize = boardArray.Length;
		Debug.Log ("There are " + boardArraySize + " boards in the scene");


		int tempCount = 0;
		for (int i = 0; i < boardArraySize; i++) {
			Debug.Log (boardArray [i].name);													// access gameobject name
			tempCount++;
		}

		if (tempCount == boardArraySize) {
			Debug.Log ("Correct!!!");
		}

		// Generate a random gameboard
		GameObject[] boardContentArray = GameObject.FindGameObjectsWithTag ("Board Content");
		int boardContentArraySize = boardContentArray.Length;
		Debug.Log ("There are " + boardContentArraySize + " texts in the scene");
		for (int i = 0; i < boardContentArraySize; i++) {
			Debug.Log (boardContentArray [i].name);													// access gameobject name
			tempCount++;
		}
	}
	
	void Update ()
	{
	
	}
	void InitGameboard ()
	{
		

	}
}