using UnityEngine;
using System;
using System.Collections;

public class ContentScript : MonoBehaviour
{
	public string content = "0";
	public string answer = "-1";
	public bool isAnswered = false;
	public GameObject numberPrefab;

	void Start ()
	{	
		InitContent ();
		InitAnswer ();
	}

	void InitContent ()
	{
	
		char[] contentCharArray = content.ToCharArray ();
		
		if (contentCharArray [0] != '0') {		// hide content 
			isAnswered = true;
			if (contentCharArray.Length == 1) {
				GameObject contentSprite = Instantiate (numberPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
				contentSprite.transform.parent = gameObject.transform;
				contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentCharArray [0].ToString ()));
			}
			
			if (contentCharArray.Length > 1) {
				for (int a = 0; a < contentCharArray.Length; a++) {
					GameObject contentSprite = Instantiate (numberPrefab, new Vector3 (transform.position.x - 0.05f + a * (0.05f + 0.1f), transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
					contentSprite.transform.parent = gameObject.transform;
					contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentCharArray [a].ToString ()));
				}
			}
		}
	}

	void InitAnswer ()
	{
		if (answer == "0") {
			answer = content;		// the answer is set to 0 in the csv files if it is revealed at the start
		}
	}


}
