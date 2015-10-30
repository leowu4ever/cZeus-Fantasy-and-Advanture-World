using UnityEngine;
using System.Collections;

public class ButtonOperator : MonoBehaviour
{
	public void LoadLvMapScene ()
	{
		Application.LoadLevel (1);
	}
	public void LoadSettingScene ()
	{
		Application.LoadLevel (2);
	}
	public void LoadTutorialScene ()
	{
		Application.LoadLevel (3);
	}
	
	public void LvMapSceneBackToMainScene ()
	{
		Application.LoadLevel (0);
	}
	public void SettingSceneBackToMainScene ()
	{
		Application.LoadLevel (0);
	}
	public void ShopSceneBackToLvMapScene ()
	{
		Application.LoadLevel (1);
	}
	public void InGameSceneBackToLvMapScene ()
	{
		Application.LoadLevel (1);
	}
	public void TutorialSceneBackToMainScene ()
	{
		Application.LoadLevel (0);
	}
	public void LvMapSceneToShopScene ()
	{
		Application.LoadLevel (5);
	}

}
