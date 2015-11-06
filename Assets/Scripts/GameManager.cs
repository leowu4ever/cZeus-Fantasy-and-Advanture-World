using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject[] contentSpriteArray;
	private int boardCount;
	// Use this for initialization
	void Start ()
	{
		contentSpriteArray [0].GetComponent<ContentScript> ().content = "4";
			
	}
	
	void Update ()
	{
	
	}
	void InitGameboard ()
	{
		

	}
}