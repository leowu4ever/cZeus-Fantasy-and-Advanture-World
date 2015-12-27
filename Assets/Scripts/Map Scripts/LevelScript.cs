using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {
    public int levelId;
    public int levelSceneId;
    public bool isLocked;
    public int stars;
    public GameObject levelBase;
    public GameObject locker;
    public string[] dialogs;
    
    void Start () {
        if (isLocked) {
            locker.SetActive (true);
        }
         else {
            levelBase.SetActive (true);
         }
    }
}
