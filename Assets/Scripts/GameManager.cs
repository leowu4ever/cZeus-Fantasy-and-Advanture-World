using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private int boardCount;
	// Use this for initialization
	void Start ()
	{
		GameObject[] boardArray = GameObject.FindGameObjectsWithTag ("Board");					// find gameobject by tag 
		int boardArraySize = boardArray.Length;
		if (GameObject.FindGameObjectsWithTag ("Board") != null) {
			Debug.Log ("There are " + boardArraySize + " in the scene");
		}

		int tempCount = 0;
		for (int i = 0; i < boardArraySize; i++) {
			Debug.Log (boardArray [i].name);													// access gameobject name
			tempCount++;
		}

		if (tempCount == boardArraySize) {
			Debug.Log ("Correct!!!");
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void InitGameboard ()
	{
		

	}
}
