using UnityEngine;
using System.Collections;

public class LevelWindowScript : MonoBehaviour {

    public GameObject hero;
    public GameObject bird;
    
	void Start () {
        transform.localScale = new Vector3 (0f, 0f, 0f);
        hero.GetComponent<Animator>().CrossFade("Talk", 0f);
	}
	
	void Update () {
	
	}
}
