using UnityEngine;
using System.Collections;

public class UpdateWalls : MonoBehaviour {

	Vector3 initialPos;
	public GameObject player;
	float distance; 
	float currentHeight;
	float maxDistance = 0;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		currentHeight = 1;
	}
	
	// Update is called once per frame

	void LateUpdate () {

		distance = player.transform.position.y - 0.5F;
		maxDistance = updateMaxDistance (maxDistance, distance);

		transform.localScale = findScale (1, maxDistance);
		currentHeight = transform.localScale;

		Vector3 temp = new Vector3 (initialPos.x, initialPos.y, initialPos.x);
		temp = initialPos - temp;
	
		Vector3 adjust = new Vector3 (initialPos.x, temp.y, initialPos.z);
		transform.position = adjust;
	}

	float findScale(float increase, float number){
		return ((number + increase) / number);
	}

	float updateMaxDistance(float maxDistance, float distance){
		if (distance > maxDistance) {
			maxDistance = distance;
		}
	}
}
