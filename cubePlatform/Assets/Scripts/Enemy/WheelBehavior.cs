using UnityEngine;
using System.Collections;

public class WheelBehavior : MonoBehaviour {

	public float movementSpeed;
	public float rotateSpeed;
	public bool changeDirection;
	public bool isVertical;

	void Awake () {
	}
	
	void FixedUpdate () {
		Move();
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag != "Player") {
			changeDirection = !changeDirection;
		}
		if(col.transform.tag == "Player" && col.transform.GetComponent<PlayerMovement>().isDead == false) {
			col.transform.GetComponent<PlayerMovement>().IsDead(true);
		}

	}

	void Move() {
		if(isVertical){
			GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,90) * Time.deltaTime * rotateSpeed;
			if(changeDirection) { 
				this.transform.Translate (Vector3.left * Time.deltaTime * movementSpeed, Space.World);
			}else{
				this.transform.Translate (Vector3.right * Time.deltaTime * movementSpeed, Space.World);
			}
		}else{
			GetComponent<Rigidbody>().angularVelocity = new Vector3(90,90,0) * Time.deltaTime * rotateSpeed;
			if(changeDirection) { 
				this.transform.Translate (Vector3.forward * Time.deltaTime * movementSpeed, Space.World);
			}else{
				this.transform.Translate (Vector3.back * Time.deltaTime * movementSpeed, Space.World);
			}
		}
	}
}
