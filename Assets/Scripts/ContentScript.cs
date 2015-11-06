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
		InitContentSprite ();
	}

	void InitContentSprite ()
	{		
		SetContentSpriteTo (int.Parse (content));
	}

	void SetContentSpriteTo (int num)
	{
		gameObject.GetComponent<SpriteRenderer> ().sprite = contentSprites [num];
	}
}
