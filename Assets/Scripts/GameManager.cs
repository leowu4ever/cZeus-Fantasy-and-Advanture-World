using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		if (GameObject.FindGameObjectsWithTag ("Board") != null) {
			Debug.Log (GameObject.FindGameObjectsWithTag ("Board").Length);
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
