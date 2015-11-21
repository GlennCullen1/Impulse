using UnityEngine;
using System.Collections;

public class DestroyWhenOutOfRendererView : MonoBehaviour 
{
	private MeshRenderer renderer;

	private bool pastCountdown = false;

	private void Start () 
	{
		renderer = GetComponent<MeshRenderer>();
		StartCoroutine ( Wait(2) );
	}
	
	private void Update () 
	{
		if( !renderer.isVisible && pastCountdown )
		{
			Destroy (this.gameObject);
		}
	}

	private IEnumerator Wait(float f)
	{
		yield return new WaitForSeconds(f);
		pastCountdown = true;
	}
}
