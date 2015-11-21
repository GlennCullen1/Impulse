using UnityEngine;
using System.Collections;

public class BarScript : MonoBehaviour {

	[SerializeField] private Heartbeat heartbeat;
	[SerializeField] private int maxBPM;
	[SerializeField] private int minBPM;
	[SerializeField] private GameObject heart;
	[SerializeField] private int difference;
	[SerializeField] private float scale;
	[SerializeField] private float maxXpos;
	[SerializeField] private Vector3 newPos;
	// Use this for initialization
	void Start () {

		difference = maxBPM - minBPM;
		maxXpos = this.GetComponent<RectTransform> ().rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		scale = (heartbeat.BPM-60)/difference;
		scale = Mathf.Clamp (scale, 0, 1);
		newPos.Set (0, 0, 0);
		newPos.x = (maxXpos * scale) -maxXpos/2;
		newPos = this.GetComponent<RectTransform> ().TransformPoint (newPos);
		heart.GetComponent<RectTransform> ().position = newPos;
	}
}
