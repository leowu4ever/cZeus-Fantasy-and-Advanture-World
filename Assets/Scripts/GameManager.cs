using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject[] contentSpriteArray;
	private int boardCount;
	// Use this for initialization
	void Start ()
	{
		// assign board content according to CSV input 
		for (int a = 0; a < contentSpriteArray.Length; a++) {
			contentSpriteArray [a].GetComponent<ContentScript> ().content = Random.Range (0, 9).ToString ();
		}
	}
	void Update ()
	{
	
	}
}