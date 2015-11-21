using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fade : MonoBehaviour {

	public string level;

	public Image fadeImage;

	bool fadeIn;
	bool fadeOut;

	// Use this for initialization
	void Start () {
		fadeImage = GetComponent<Image>();

		StartCoroutine(routine());
		//fadeOut = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeIn)
		{
			Color fadeColor = fadeImage.color;
			fadeColor.a += Time.deltaTime;;
			fadeImage.color = fadeColor;
			
			if(fadeColor.a >= 255)
				fadeIn = false;
		}

		if(fadeOut)
		{
			Color fadeColor = fadeImage.color;
			fadeColor.a -= Time.deltaTime;
			fadeImage.color = fadeColor;
			
			if(fadeColor.a <= 0)
				fadeOut = false;
		}
	}

	public void FadeIn()
	{
		fadeIn = true;
	}

	public void FadeOut()
	{
		fadeOut = true;
	}

	private IEnumerator routine()
	{
		FadeOut ();

		yield return new WaitForSeconds(7);

		FadeIn();

		yield return new WaitForSeconds(2);

		Application.LoadLevel(level);
	}
}
