using UnityEngine;
using System.Collections;

public class ScenaryManager : MonoBehaviour {

	[SerializeField] private GameObject roadPrefab;
	[SerializeField] private int roadLength;
	private int roadCount;
	[SerializeField] private GameObject[] BarriersPrefabs;
	[SerializeField] private GameObject[] Lanes;
	// Use this for initializationd
	void Start () {
		GameObject road;
		SpawnRoad();
		SpawnRoad();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");

		if(obj == null)
			return;
		if (obj.transform.position.z > this.transform.position.z + (roadLength * (roadCount-1))) {

			SpawnRoad();
		}
	}

	private void SpawnRoad()
	{
		Instantiate(roadPrefab,new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z+(roadLength*roadCount)+roadLength/2), Quaternion.identity);
		roadCount ++;
		for (int cnt = 1; cnt <= roadLength/10; cnt++) {
			int coin = Random.Range(0,2);
			if(coin == 0)
			{
				int laneInt = Random.Range(0,Lanes.Length);
				Instantiate(BarriersPrefabs[Random.Range(0,BarriersPrefabs.Length)],new Vector3(Lanes[laneInt].transform.position.x,this.transform.position.y,this.transform.position.z+(roadLength*(roadCount-1))+cnt*10), Quaternion.identity);
			}

		}
	}
}
