using UnityEngine;
using System.Collections;

public class LevelWindowScript : MonoBehaviour {

    public GameObject hero;
    public GameObject bird;
    public GameObject dialogLabel;
    
	void Start () {
        transform.localScale = new Vector3 (0f, 0f, 0f);
        hero.GetComponent<Animator>().CrossFade("Talk", 0f);
        dialogLabel.GetComponent<MeshRenderer>().sortingLayerName = hero.GetComponent<SpriteRenderer>().sortingLayerName;
        dialogLabel.GetComponent<TextMesh>().fontSize = 1024;
	}
	
	void Update () {
	
	}
}
