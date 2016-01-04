using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
	public void LoadMainScene ()
	{
		Application.LoadLevel (0);
	}
	public void LoadSettingScene ()
	{
		Application.LoadLevel (1);
	}    
   
    public void LoadRecordScene ()
	{
		Application.LoadLevel (2);
	}
    
	public void LoadWorldMapScene ()
	{
		Application.LoadLevel (3);
	}
    
	public void LoadChapterOneScene ()
	{
		Application.LoadLevel (4);
	}	

    public void RestartScene () {
         Application.LoadLevel (Application.loadedLevelName);
    }
}
