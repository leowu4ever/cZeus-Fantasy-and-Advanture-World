using UnityEngine;
using System.Collections;

public class LevelWindowScript : MonoBehaviour {

    public GameObject hero;
    public GameObject bird;
    public GameObject dialogLabel;
    public GameObject bubbleLeft;
    public GameObject bubbleRight;

    public static GameObject birdGameObject;
    public static GameObject heroGameObject;
    public static GameObject bubbleLeftGameObject;
    public static GameObject bubbleRightGameObject;


    void Start () {
        transform.localScale = new Vector3 (0f, 0f, 0f);
        //hero.GetComponent<Animator>().CrossFade("Talk", 0f);
        dialogLabel.GetComponent<MeshRenderer>().sortingLayerName = hero.GetComponent<SpriteRenderer>().sortingLayerName;
        dialogLabel.GetComponent<TextMesh>().fontSize = 1024;
        birdGameObject = bird;
        heroGameObject = hero;
        bubbleLeftGameObject = bubbleLeft;
        bubbleRightGameObject = bubbleRight;
    }
	
	void Update () {
	
	}
    public static void BirdTalkingOn()
    {
        birdGameObject.GetComponent<Animator>().CrossFade("BirdMoving", 0f);
    }
    public static void BirdTalkingOff()
    {
        birdGameObject.GetComponent<Animator>().CrossFade("Idle", 0f);
    }
    public static void HeroTalkingOn()
    {
        heroGameObject.GetComponent<Animator>().CrossFade("Talk", 0f);
    }
    public static void HeroTalkingOff()
    {
        heroGameObject.GetComponent<Animator>().CrossFade("Idle", 0f);
    }
    public static void BubbleLeftOn()
    {
        bubbleLeftGameObject.SetActive(true);
    }
    public static void BubbleLeftOff()
    {
        bubbleLeftGameObject.SetActive(false);
    }
    public static void BubbleRightOn()
    {
        bubbleRightGameObject.SetActive(true);
    }
    public static void BubbleRightOff()
    {
        bubbleRightGameObject.SetActive(false);
    }
}
