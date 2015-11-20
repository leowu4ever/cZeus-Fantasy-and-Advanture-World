using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    public void LoadMainScene()
    {
        Application.LoadLevel(0);
    }
    public void LoadSettingScene ()
	{
		Application.LoadLevel (1);
	}
	public void LoadTutorialScene ()
	{
		Application.LoadLevel (2);
	}
    public void LoadShopScene()
    {
        Application.LoadLevel(3);
    }
    public void LoadWorldMapScene()
    {
        Application.LoadLevel(4);
    }
    public void LoadChapterOneScene()
    {
		Application.LoadLevel (5);
	}
	public void LoadTutorialPage1Scene()
	{
		Application.LoadLevel (14);
	}
	public void LoadTutorialPage2Scene()
	{
		Application.LoadLevel (15);
	}
	public void LoadTutorialPage3Scene()
	{
		Application.LoadLevel (16);
	}
	public void LoadTutorialPage4Scene()
	{
		Application.LoadLevel (17);
	}
	public void LoadTutorialPage5Scene()
	{
		Application.LoadLevel (18);
	}
	public void LoadTutorialPage6Scene()
	{
		Application.LoadLevel (19);
	}
}
