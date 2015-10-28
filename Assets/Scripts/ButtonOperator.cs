using UnityEngine;
using System.Collections;

public class ButtonOperator : MonoBehaviour
{
	public void LoadLvMapScene ()
	{
		Application.LoadLevel (1);
	}
    public void LoadSettingScene()
    {
        Application.LoadLevel(2);
    }
    public void LoadShopScene ()
	{
		Application.LoadLevel (3);
	}

	
    public void LvMapSceneBackToMainScene()
    {
        Application.LoadLevel(0);
    }
    public void SettingSceneBackToMainScene()
    {
        Application.LoadLevel(0);
    }
    public void ShopSceneBackToMainScene()
    {
        Application.LoadLevel(0);
    }
    public void InGameSceneBackToLvMapScene()
    {
        Application.LoadLevel(1);
    }

}
