using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour 
{
	[SerializeField] private Transform target = null;

	private float zOffset = 0;

	private void Start () 
	{
		zOffset = (target.position - transform.position).z;
	}
	
	private void Update () 
	{
		if(target != null)
			transform.position = new Vector3( transform.position.x, transform.position.y, target.position.z - zOffset );
	}
}
