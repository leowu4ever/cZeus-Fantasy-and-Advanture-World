using UnityEngine;
using System;

using System.Collections;

public class ContentScript : MonoBehaviour
{
	public Sprite[] contentSprites;
	public string content = "0";
	public bool isAnswered = false;
	
	void Start ()
	{
		switch (content) {
		case "0":
			break;
		case "1":
			break;
		case "2":
			break;
		case "3":
			break;
		case "4":
			break;
		case "5": 
			break;
		case "6":
			break;
		case "7":
			break;
		case "8":
			break;
		case "9":
			break;
		default :
			Debug.Log ("?");
			break;
		}
		gameObject.GetComponent<SpriteRenderer> ().sprite = contentSprites [0];
	}

	void InitContentSprite ()
	{

	}
	void Update ()
	{
	
	}
}
