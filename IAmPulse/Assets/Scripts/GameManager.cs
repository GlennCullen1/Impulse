using UnityEngine;
using System.Collections;

enum EGameState
{
	isPlaying,
	isFinished
}

public class GameManager : MonoBehaviour
{
	private PlayerController playerController;
	private Heartbeat heartbeat;

	private EGameState gameState = EGameState.isPlaying;

	// Singleton
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("[GameManager]", typeof(GameManager)).GetComponent<GameManager>();
			}
			return instance;
		}
	}

	private void Start()
	{
		if(instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}else instance = this;

		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		heartbeat = playerController.GetComponent<Heartbeat>();
	}

	private void Update()
	{
		if(gameState == EGameState.isFinished)
		{
			Destroy(playerController);
			Destroy(heartbeat);
			//TODO: ShowGameOverCanvas
		}
	}

	public void TriggerGameOver()
	{
		gameState = EGameState.isFinished;
		Debug.Log("GameOver");
	}
}
