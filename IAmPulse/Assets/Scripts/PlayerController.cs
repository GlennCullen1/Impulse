using UnityEngine;
using UnityEngine.UI;
using System.Collections;

enum EPlayerState
{
	isRunning,
	isJumping,
	isDucking,
	isSwitchingLane
}

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour 
{
	[SerializeField] private float invincibilityTime = 5;

	[SerializeField] private float jumpLimit = 0;
	[SerializeField] private float duckLimit = 0;

	[SerializeField] private float jumpForce = 0;

	[SerializeField] private Transform[] lanes;

	[SerializeField] private Text text;

	private float startTime;

	private GameObject gameOverUI;

	private int currentLaneIndex = 1; // Middle Lane
	
	private EPlayerState playerState = EPlayerState.isRunning;

	private Heartbeat heartbeat = null;
	private Transform myTransform = null;
	private Rigidbody myRigidbody = null;

	private bool isShrinking = true;

	float startPoint = 0;

	private void Start()
	{
		heartbeat = GetComponent<Heartbeat>();
		myRigidbody = GetComponent<Rigidbody>();
		myTransform = GetComponent<Transform>();

		gameOverUI = GameObject.FindGameObjectWithTag("GameOverMenu");
		gameOverUI.SetActive(false);

		startTime = Time.time;

		startPoint = transform.position.z;
	}

	private void Update()
	{
		if( Time.time > startTime + invincibilityTime && (heartbeat.BPM > 200 || heartbeat.BPM <= 60) )
		{
			TriggerGameOver();
		}

		myRigidbody.velocity = new Vector3( 0, myRigidbody.velocity.y, heartbeat.BPM / 10);

		if( playerState == EPlayerState.isRunning )
		{
			if( Input.GetKeyDown(KeyCode.UpArrow) && heartbeat.BPM > jumpLimit )
			{
				playerState = EPlayerState.isJumping;
				myRigidbody.AddForce( Vector3.up * jumpForce );
				// Play Jump Animation
				StartCoroutine(WaitForTime(1));
				return;
			}

			if( Input.GetKeyDown(KeyCode.DownArrow) && heartbeat.BPM < duckLimit )
			{
				playerState = EPlayerState.isDucking;
				// Play Duck Animation
				StartCoroutine(WaitForTime(1));
				isShrinking = true;
				return;
			}

			if( Input.GetKeyDown(KeyCode.LeftArrow) )
			{
				if(currentLaneIndex == 0)
				{
					return;
				}

				playerState = EPlayerState.isSwitchingLane;
				currentLaneIndex--;
				StartCoroutine(WaitForTime(0.8f));
				return;
			}

			if( Input.GetKeyDown(KeyCode.RightArrow) )
			{
				if(currentLaneIndex == lanes.Length-1)
				{
					return;
				}
				
				playerState = EPlayerState.isSwitchingLane;
				currentLaneIndex++;
				StartCoroutine(WaitForTime(0.8f));
				return;
			}
		}

		if( playerState == EPlayerState.isDucking )
		{
			if(isShrinking)
			{
				myTransform.localScale -= new Vector3(0, Time.deltaTime, 0);
				if(myTransform.localScale.y < 0.5f)
					isShrinking = false;
			}
			else
			{
				myTransform.localScale += new Vector3(0, Time.deltaTime, 0);
			}
		}

		if( playerState == EPlayerState.isSwitchingLane )
		{
			myTransform.position = Vector3.Lerp( myTransform.position, new Vector3(lanes[currentLaneIndex].position.x, myTransform.position.y, myTransform.position.z), Time.deltaTime * 4 );
		}
	}

	private void OnCollisionEnter(Collision obj)
	{
		// Hits Anything But The Platform
		if(!obj.gameObject.CompareTag("Platform") && Time.time > startTime + invincibilityTime)
		{
			text.text = "Ran: " +  (transform.position.z - startPoint)  + " Meters!"; 
			TriggerGameOver();
		}
	}

	/// <summary>
	/// Waits for time, then resets playerState back to Running
	/// </summary>
	private IEnumerator WaitForTime(float timeToWait)
	{
		yield return new WaitForSeconds(timeToWait);

		playerState = EPlayerState.isRunning;
	}

	private void TriggerGameOver()
	{
		Destroy(this.gameObject);
		Destroy(heartbeat);
		gameOverUI.SetActive(true);
	}
}
