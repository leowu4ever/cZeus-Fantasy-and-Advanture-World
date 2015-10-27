using UnityEngine;
using System.Collections;

public class ButtonOperator : MonoBehaviour
{
	public void LoadLvMapScene ()
	{
		Application.LoadLevel (1);
	}

	public void LoadShopScene ()
	{
		Application.LoadLevel (2);
	}

	public void LoadSettingScene ()
	{
		Application.LoadLevel (3);
	}

}
