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
		currentHeight = 1;
	}
	
	// Update is called once per frame

	void LateUpdate () {

		distance = player.transform.position.y - 0.5F;
		maxDistance = updateMaxDistance (maxDistance, distance);

		Vector3 temp = new Vector3 (0f, player.transform.position.y, 0f);
		//temp = player.transform.position;

		maxHeight = getMaxHeight (temp, maxHeight);
		temp = maxHeight;
		
		transform.localScale = maxHeight + initialScale + 2*temp;


		//transform.localScale.y = findScale (1, maxDistance);

		/*
		currentHeight = transform.localScale;

		Vector3 temp = new Vector3 (initialPos.x, initialPos.y, initialPos.x);
		temp = initialPos - temp;
	
		Vector3 adjust = new Vector3 (initialPos.x, temp.y, initialPos.z);
		transform.position = adjust;
		*/
	}

	/*
	float findScale(float increase, float number){
		return ((number + increase) / number);
	}
	*/


	float updateMaxDistance(float maxDistance, float distance){
		if (distance > maxDistance) {
			maxDistance = distance;
		}
		return maxDistance;
	}

	Vector3 getMaxHeight(Vector3 compare, Vector3 max){
		if (compare.y > max.y) {
			return compare;
		}
		return max;
	}
}
