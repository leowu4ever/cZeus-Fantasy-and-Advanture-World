using UnityEngine;
using System.Collections;

public class ChapterMapManager : MonoBehaviour {

    public GameObject[] levels;
    public GameObject camera;
    public GameObject hero;
    public GameObject levelWindow;
    public static bool isFocused;

    private float heroSpeed = 1f;
    private int latestLevel;
    private int curLevel;
   
	void Start () {
	   InitLevels ();
       InitHero ();
        ///set state of hero animation
        hero.GetComponent<Animator>().CrossFade("Walk", 0f);
    }
	
	void Update () {
	   if (Input.GetMouseButtonDown (0)) {
            RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);			
            if (hit.collider != null) {
                if (hit.transform.tag == "Node") {
                    GameObject selectedLevelNode = hit.transform.gameObject;
                    LevelScript selectedlevelScript = selectedLevelNode.GetComponent<LevelScript> ();
                    if (!selectedlevelScript.isLocked) {
                        // focus on the selected node
                        camera.transform.position = new Vector3 (selectedLevelNode.transform.position.x, selectedLevelNode.transform.position.y, camera.transform.position.z);  
                        isFocused = true;
                        // bring the levelwindow in front of the camera
                        levelWindow.transform.position = selectedLevelNode.transform.position;
                        levelWindow.SetActive (true); 
                    }
                }
                if (hit.transform.tag == "Level Window Cancel Button") {
                    isFocused = false;
                    levelWindow.SetActive (false); 
                }
            }
        }
	}
    
    // Always put the hero on the latest level and only move it when the player process to next level 
    void InitHero () {
        hero.transform.position = levels[curLevel].transform.position;    
        camera.transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y, camera.transform.position.z);
    }
    
    void InitLevels ()  {
        SetLevelStateTo (levels[0].name, false);  // the fisrt level is always open
        for (int a = 0; a < levels.Length; a++) {
          levels[a].GetComponent<LevelScript> ().isLocked = GetLevelStateFor (levels[a].name);
          levels[a].GetComponent<LevelScript> ().levelId = a + 1;
        }
        curLevel = latestLevel;
    }
 
    bool GetLevelStateFor (string levelName) {
        if (PlayerPrefs.GetInt (levelName) == 0) {
            return true;
        } else {
            return false;
        } 
    }
    // true - 0 - locked 
    // false - 1 - unlocked
    void SetLevelStateTo (string levelName, bool lockerState) {
        if (lockerState) {
            PlayerPrefs.SetInt (levelName, 0);
        } else {
            PlayerPrefs.SetInt (levelName, 1);
        }
    }
    
    void MoveHeroToNextLevelNode () {
        // go to next node
        Transform[] ptsToNxtLv = levels[curLevel].GetComponent<LevelScript> ().ptsToNxtLv;
        for (int a = 0; a < ptsToNxtLv.Length; a++) {
            LeanTween.move (hero, ptsToNxtLv[a].position, 1/heroSpeed);
        }
        LeanTween.move (hero, levels[latestLevel].transform.position, 1/heroSpeed);
        // get the animator component and parameter and set it to true
    }
}