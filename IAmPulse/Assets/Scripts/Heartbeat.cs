using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Beat {
	public float timeSinceBeat;
	public Beat() 
	{
		timeSinceBeat = 0;
	}

	public void addTime(float deltaTime)
	{
		timeSinceBeat += deltaTime;
	}
}

public class Heartbeat : MonoBehaviour 
{
	[SerializeField] private List<Beat> pastBeats;
	[SerializeField] private KeyCode beatKey = KeyCode.Return;
	[SerializeField] private float SampleTime = 5.0f;
	[SerializeField] private float bpm = 0; public float BPM {get{ return bpm;}}

	private void Start () 
	{
		pastBeats = new List<Beat>();
		pastBeats.Add(new Beat());
	}
	
	private void Update () 
	{
		if(bpm < 200)
		{
			if(Input.GetKeyDown(beatKey))
			{
				pastBeats.Add(new Beat());
			}
			List<Beat> tempBeats = new List<Beat>();
			if (pastBeats.Count > 0) 
			{
				foreach (Beat beat in pastBeats) 
				{
					beat.addTime (Time.deltaTime);
					if (beat.timeSinceBeat > SampleTime) 
					{
						tempBeats.Add(beat);
					}
				}
				foreach (Beat beat in tempBeats) 
				{
					pastBeats.Remove(beat);
				}
				tempBeats.Clear();
			}
			bpm = pastBeats.Count * 12;
		}
	}
}
