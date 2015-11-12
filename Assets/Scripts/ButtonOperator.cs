using UnityEngine;
using System.Collections;

public class ButtonOperator : MonoBehaviour
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
    public void LoadWorldMapScene()
    {
        Application.LoadLevel(4);
    }

    public void WorldMapMapSceneBackToMainScene()
	{
		Application.LoadLevel (0);
	}
	public void SettingSceneBackToMainScene ()
	{
		Application.LoadLevel (0);
	}
    public void TutorialSceneBackToMainScene()
    {
        Application.LoadLevel(0);
    }
    public void ShopSceneBackToWorldMapMapScene()
	{
		Application.LoadLevel (4);
	}
	public void ChapterMapSceneBackToWorldMapScene ()
	{
		Application.LoadLevel (4);
	}
    public void InGameSceneBackToChapterScene()
    {
        Application.LoadLevel(5);
    }

}
