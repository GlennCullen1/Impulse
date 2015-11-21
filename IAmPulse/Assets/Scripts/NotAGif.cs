using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NotAGif : MonoBehaviour {

	[SerializeField] private Sprite[] imageReel;
	[SerializeField] private float time;
	private float count;
	private int numOfImages;
	private int activeImage;
	// Use this for initialization
	void Start () {
		numOfImages = imageReel.Length;
		count =  0;
		activeImage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (count >= time) {
			activeImage++;
			if(activeImage>numOfImages-1)
			{
				activeImage = 0;
			}
			this.GetComponent<Image>().sprite = imageReel[activeImage];
		}
	}
}
