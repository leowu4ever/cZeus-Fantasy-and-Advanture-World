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
		Application.LoadLevel (3);
	}
	public void LoadTutorialScene ()
	{
		Application.LoadLevel (2);
	}
	public void LoadShopScene ()
	{
		Application.LoadLevel (3);
	}
	public void LoadWorldMapScene ()
	{
		Application.LoadLevel (2);
	}
	public void LoadChapterOneScene ()
	{
		Application.LoadLevel (3);
	}
    
    public void RestartScene () {
         Application.LoadLevel (Application.loadedLevelName);
    }
}
