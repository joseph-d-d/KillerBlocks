using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	
	private Vector3 offset;
	
	void Start ()
	{
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
	{
		Vector3 move = new Vector3 (offset.x, player.transform.position.y, offset.z);
		transform.position = move;
	}
}

//Vector3 temp = new Vector3(7.0f,0,0);
//myGameObject.transform.position += temp;