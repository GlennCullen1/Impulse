using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpawnBlip : MonoBehaviour {
	[SerializeField] GameObject blipPrefab;
	[SerializeField] GameObject spawnPoint;
	[SerializeField] GameObject endPoint;
	List<GameObject> activeBlips;
	// Use this for initialization
	void Start () {
		activeBlips = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Return))
			{
				GameObject blip = (GameObject)Instantiate(blipPrefab,spawnPoint.GetComponent<RectTransform>().position, Quaternion.identity);
				blip.GetComponent<RectTransform>().parent = this.GetComponent<RectTransform>().parent;
				activeBlips.Add(blip);
			}
		List<GameObject> tempBeats = new List<GameObject>();
		foreach (GameObject blip in activeBlips) {

			blip.GetComponent<RectTransform>().position = Vector3.MoveTowards(blip.GetComponent<RectTransform>().position, endPoint.GetComponent<RectTransform>().position, 10);
			if (blip.GetComponent<RectTransform>().position ==  endPoint.GetComponent<RectTransform>().position)
			{
				tempBeats.Add(blip);
			}
		

		}
		foreach (GameObject beat in tempBeats) {
			activeBlips.Remove(beat);
		}
		tempBeats.Clear();
	}
	}

