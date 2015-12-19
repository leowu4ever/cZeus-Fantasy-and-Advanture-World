using UnityEngine;
using System.Collections;

public class TestAudio : MonoBehaviour {

	private static TestAudio instance = null;

	public static TestAudio Instance
	{
		get
		{ 
			return instance;
		}
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
		
		DontDestroyOnLoad(this.gameObject);
	}

}
