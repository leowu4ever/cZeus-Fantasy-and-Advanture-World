using UnityEngine;
using System.Collections;

public class TestGameObject : MonoBehaviour {

	public GameObject obje;
	GameObject obj=null;
	// Use this for initialization
	void Start () {
		obj = GameObject.FindGameObjectWithTag("sound");
		if (obj==null) {
			obj = (GameObject)Instantiate(obje);
		}   
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
