using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ContentScript : MonoBehaviour
{
	public string content, answer;
	public bool isAnswered;
	public GameObject numberPrefab;
    public static float xShift = 0.1f;
    public static float xDisplacement = 0.07f;
    public List<string> wrongAnswer;

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
            InitNumberSpriteFor (content);
        }
	}

	void InitNumberSpriteFor (string content)
	{
        char[] contentCharArray = content.ToCharArray ();
		if (contentCharArray.Length == 1) {
			GameObject contentSprite = Instantiate (numberPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
			contentSprite.transform.parent = gameObject.transform;
			contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentCharArray [0].ToString ()));
		}

		if (contentCharArray.Length > 1) {
			for (int a = 0; a < contentCharArray.Length; a++) {
				GameObject contentSprite = Instantiate (numberPrefab, new Vector3 (transform.position.x - xShift + a * (xShift + xDisplacement), transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
				contentSprite.transform.parent = gameObject.transform;
				contentSprite.GetComponent<NumberSpriteScript> ().SetSpriteTo (int.Parse (contentCharArray [a].ToString ()));
			}
		}
	}

}
