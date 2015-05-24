using UnityEngine;
using System.Collections;

public class UpdateWalls : MonoBehaviour {

	Vector3 initialScale;
	Vector3 maxHeight;
	Vector3 temp = new Vector3 (0f, 10f, 0f);
	public GameObject player;
	float distance; 
	float currentHeight;
	float maxDistance = 0;

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame

	void LateUpdate () {

		distance = player.transform.position.y - 0.5F;
		maxDistance = updateMaxDistance (maxDistance, distance);

		maxHeight = getMaxHeight (maxDistance);
		
		transform.localScale = maxHeight + initialScale + 2*temp;

	}


	float updateMaxDistance(float maxDistance, float distance){
		if (distance > maxDistance) {
			maxDistance = distance;
		}
		return maxDistance;
	}

	Vector3 getMaxHeight(float f){
		Vector3 h = new Vector3(0f, f, 0f);
		return h;
	}
}
