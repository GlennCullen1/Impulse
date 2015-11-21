using UnityEngine;
using System.Collections;

public class UIFunctions : MonoBehaviour 
{
	public void LoadToLeve(string name)
	{
		Application.LoadLevel(name);
	}

	public void LoadToLevel(int index)
	{
		Application.LoadLevel(index);
	}
}
