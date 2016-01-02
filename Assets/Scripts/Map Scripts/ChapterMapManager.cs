using UnityEngine;
using System.Collections;

public class ChapterMapManager : MonoBehaviour {

    public GameObject[] levels;
    public GameObject camera;
    public GameObject hero;
    public GameObject levelWindow;
    public GameObject dialogLabel;
    public GameObject skipButton;
    public GameObject playButton;
    public static bool isFocused;
    public static int latestLevel;
    public static int curLevel;

    private LevelScript selectedlevelScript;
    private bool isTyping = false;
    private bool isTypingBusy=false;
    private float letterPause = 0.2f;
    private int dialogIndex = 0;
    private float heroSpeed = 1f;
    
   
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
                    selectedlevelScript = selectedLevelNode.GetComponent<LevelScript> ();
                    if (!selectedlevelScript.isLocked) {
                        curLevel = selectedlevelScript.levelId - 1;
                        // focus on the selected node
                        camera.transform.position = new Vector3 (selectedLevelNode.transform.position.x, selectedLevelNode.transform.position.y, camera.transform.position.z);
                        isFocused = true;
                        // bring the levelwindow in front of the camera
                        levelWindow.transform.position = selectedLevelNode.transform.position;
                        LeanTween.scale (levelWindow, new Vector3 (1f, 1f, 1f), 0.5f).setEase (LeanTweenType.easeInOutBack);
                        isTyping = true;
                        playButton.SetActive(true);
                        skipButton.SetActive(false);
                    }
                }
                 
                if (hit.transform.tag == "Level Window Cancel Button") {
                    isFocused = false;
                    LeanTween.scale (levelWindow, new Vector3 (0f, 0f, 0f), 0.5f).setEase (LeanTweenType.easeInOutBack);
                    clearDialog();
                }
                
                if (hit.transform.tag == "Level Window Play Button") {
                    isFocused = false;
                    Application.LoadLevel (levels[curLevel].GetComponent<LevelScript>().levelSceneId);
                    if (levels.GetUpperBound(0)> curLevel)
                    {
                        PlayerPrefs.SetString("NEXTLEVELNAME", levels[curLevel + 1].name);
                    }
                    clearDialog();
                }
                if (hit.transform.tag == "Level Window Skip Button")
                {
                    letterPause = 0.0f;
                }
            }
        }
        DialogType();
    }

    void InitLevels ()  { // 1. unlock lv1 2. init the rest levels 3. 
        if (!GetLevelStateOf (levels[0].name)) {
          SetLevelStateTo (levels[0].name, false);  // the fisrt level is always open
        }
        for (int a = 0; a < levels.Length; a++) {
          LevelScript ls = levels[a].GetComponent<LevelScript> ();
          ls.isLocked = GetLevelStateOf (levels[a].name);
          ls.levelId = a + 1;   // assign the level Id 
          if (!ls.isLocked) {
              latestLevel = a;
          }
        }
        curLevel = latestLevel;
    }
    
    // Always put the hero on the latest level and only move it when the player process to next level 
    void InitHero () {
        hero.transform.position = new Vector3 (levels[latestLevel].transform.position.x + 0.5f, levels[latestLevel].transform.position.y + 0.5f, levels[latestLevel].transform.position.z);  
        camera.transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y, camera.transform.position.z);
    }
 
    public static bool GetLevelStateOf (string levelName) {
        if (PlayerPrefs.GetInt (levelName) == 0) {
            return true;
        } else {
            return false;
        } 
    }
    
    // true - 0 - locked 
    // false - 1 - unlocked
    public static void SetLevelStateTo (string levelName, bool lockerState) {
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

    void DialogType()
    {
        if (isTyping  && selectedlevelScript.dialogs.Length !=0)
        {
            if(!isTypingBusy)
            {
                playButton.SetActive(false);
                skipButton.SetActive(true);
                clearDialog();
                CharactersHandler();
                StartCoroutine(TypeText(selectedlevelScript.dialogs[dialogIndex]));
                isTypingBusy = true;
                dialogIndex++;
                if (dialogIndex==selectedlevelScript.dialogs.Length)
                {
                    isTyping = false;
                    dialogIndex = 0;
                } 
            }
        } 
        else
        {
            isTyping = false;
            if (!isTypingBusy)
            {
                LevelWindowScript.BirdTalkingOff();
                LevelWindowScript.HeroTalkingOff();
                playButton.SetActive(true);
                skipButton.SetActive(false);
            }
        }
    }
    IEnumerator TypeText(string message)
    {
        int charCount = 0;
        foreach (char letter in message.ToCharArray())
        {
            if(charCount ==10)
            {
                dialogLabel.GetComponent<TextMesh>().text += "\n";
                charCount = 0;
            }
            dialogLabel.GetComponent<TextMesh>().text += letter;
            charCount++;
            yield return new WaitForSeconds(letterPause);
        }
        DoLastTyping();
    }
    void DoLastTyping()
    {
        isTypingBusy = false;
        letterPause = 0.2f;
    }
    void clearDialog()
    {
        dialogLabel.GetComponent<TextMesh>().text = "";
    }
    void CharactersHandler()
    {
        if(dialogIndex%2==0)
        {
            LevelWindowScript.BirdTalkingOn();
            LevelWindowScript.HeroTalkingOff();
            LevelWindowScript.BubbleRightOn();
            LevelWindowScript.BubbleLeftOff();
        }
        else
        {
            LevelWindowScript.BirdTalkingOff();
            LevelWindowScript.HeroTalkingOn();
            LevelWindowScript.BubbleLeftOn();
            LevelWindowScript.BubbleRightOff();
        }
    } 
}