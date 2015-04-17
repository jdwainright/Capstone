using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {


	//declare and initialize variables
	[SerializeField] Transform character;
	private Vector3 moveTemp;
	[SerializeField] float speed=45f;
	[SerializeField] float xDifference;
	[SerializeField] float yDifference;
	[SerializeField] float movementThreshold = 45f;
	 

	// Update is called once per frame
	void Update () {
		if (character.transform.position.x > transform.position.x) {
			xDifference = character.transform.position.x - transform.position.x;
		} else {
			xDifference = transform.position.x - character.transform.position.x;
		}

		if (character.transform.position.y > transform.position.y) {
			yDifference = character.transform.position.y - transform.position.y;
		} else {
			yDifference = transform.position.y - character.transform.position.y;

		}
		if (xDifference >= movementThreshold  || yDifference >= movementThreshold) {
			moveTemp = character.transform.position;
			moveTemp.z = -10;

			transform.position = Vector3.MoveTowards(transform.position, moveTemp, speed * Time.deltaTime);
		}
	}
}