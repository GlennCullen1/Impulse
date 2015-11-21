using UnityEngine;
using System.Collections;

public class DestroyWhenOutOfRendererView : MonoBehaviour 
{
	private MeshRenderer meshRenderer;

	private bool pastCountdown = false;

	private void Start () 
	{
		meshRenderer = GetComponent<MeshRenderer>();
		StartCoroutine ( Wait(2) );
	}
	
	private void Update () 
	{
		if( !meshRenderer.isVisible && pastCountdown )
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
