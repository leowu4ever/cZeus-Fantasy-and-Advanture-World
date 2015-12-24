using UnityEngine;
using System;
using System.Collections;

public class ContentScript : MonoBehaviour
{
	public string content, answer;
	public bool isAnswered;
	public GameObject numberPrefab;

    void Awake () {
        content = "0";
        answer = "-1";
        isAnswered = false;
    }
    
	void Start ()
	{	
		InitContent ();
	}

	void InitContent ()
	{      
          if (content != "0" && content != "") { // create number sprite at where mystery not answered and pair/square hidden
            // split content to an array of chars
            CreateNumberSprite (content.ToCharArray ());
        }
	}

	void CreateNumberSprite (char[] contentCharArray)
	{
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
