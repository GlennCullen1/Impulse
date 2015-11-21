using UnityEngine;
using UnityEngine.UI;
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

	private GameObject gameOverUI;

	private EGameState gameState = EGameState.isPlaying;

	// Singleton
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
//			if(instance == null)
//			{
//				instance = new GameObject("[GameManager]", typeof(GameManager)).GetComponent<GameManager>();
//			}
			return instance;
		}
	}

	private void Start()
	{
//		if(instance != null && instance != this)
//		{
//			Destroy(this.gameObject);
//		}else instance = this;

		instance = this;

		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		heartbeat = playerController.GetComponent<Heartbeat>();

		gameOverUI = GameObject.FindGameObjectWithTag("GameOverMenu");
		gameOverUI.SetActive(false);

		gameState = EGameState.isPlaying;
	}

	private void Update()
	{
		if(gameState == EGameState.isFinished)
		{
			Destroy(playerController);
			Destroy(heartbeat);
			gameOverUI.SetActive(true);
		}
	}

	public void TriggerGameOver()
	{
		gameState = EGameState.isFinished;
		Debug.Log("GameOver");
	}
}
