using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	[SerializeField] private float invincibilityTime = 5;

	private PlayerController playerController;
	private Heartbeat heartbeat;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		heartbeat = playerController.GetComponent<Heartbeat>();
	}

	private void Update()
	{
		if( Time.time > invincibilityTime && (heartbeat.BPM > 200 || heartbeat.BPM <= 0) )
		{
			Debug.Log("GameOver");
			Destroy(playerController);
			Destroy(heartbeat);
		}
	}
}
