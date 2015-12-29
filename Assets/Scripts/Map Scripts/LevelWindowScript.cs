using UnityEngine;
using System.Collections;

public class LevelWindowScript : MonoBehaviour {

    public GameObject hero;
    public GameObject bird;
    
	void Start () {

        hero.GetComponent<Animator>().CrossFade("talk", 0f);
	}
	
	void Update () {
	
	}
}
