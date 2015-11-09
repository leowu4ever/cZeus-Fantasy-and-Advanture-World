using UnityEngine;
using System.Collections;

public class NumberSpriteScript : MonoBehaviour
{

	public Sprite[] spriteArray;

	public void SetSpriteTo (int num)
	{
		gameObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [num];
	}

}
