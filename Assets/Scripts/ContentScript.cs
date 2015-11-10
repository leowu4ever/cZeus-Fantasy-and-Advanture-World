﻿using UnityEngine;
using System;

using System.Collections;

public class ContentScript : MonoBehaviour
{
	public string content = "0";
	public bool isAnswered = false;
	public GameObject numberPrefab;

	void Start ()
	{	
		char[] contentCharArray = content.ToCharArray ();

		if (contentCharArray.Length == 1) {
			GameObject contentSprite = Instantiate (numberPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
			contentSprite.transform.parent = gameObject.transform;
			contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentCharArray [0].ToString ()));
		}

		if (contentCharArray.Length > 1) {
			for (int a = 0; a < contentCharArray.Length; a++) {
				GameObject contentSprite = Instantiate (numberPrefab, new Vector3 (transform.position.x + a * 0.15f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
				contentSprite.transform.parent = gameObject.transform;
				contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentCharArray [a].ToString ()));
			}
		}


	}

}