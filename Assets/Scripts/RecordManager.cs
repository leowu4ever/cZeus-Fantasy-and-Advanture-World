using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   GameObject.Find ("Content").GetComponent<Text>().text = PlayerPrefs.GetString ("Record");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
