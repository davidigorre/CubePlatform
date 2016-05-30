// Plataforma Movil Sobre Lava Lvl Uno 
using UnityEngine;
using System.Collections;

public class Lvl1MobilePlatform : MonoBehaviour {
	public float movementSpeed;
	public bool changeDirection;
	public bool isVertical;

	void FixedUpdate () {
		Move();
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.tag != "Player" && col.name != "Sphere") {
			changeDirection = !changeDirection;
		}
	}

	void Move() {
		if(isVertical){
			GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,90) * Time.deltaTime;
			if(changeDirection) { 
				this.transform.Translate (Vector3.left * Time.deltaTime * movementSpeed, Space.World);
			}else{
				this.transform.Translate (Vector3.right * Time.deltaTime * movementSpeed, Space.World);
			}
		}else{
			GetComponent<Rigidbody>().angularVelocity = new Vector3(90,90,0) * Time.deltaTime;
			if(changeDirection) { 
				this.transform.Translate (Vector3.forward * Time.deltaTime * movementSpeed, Space.World);
			}else{
				this.transform.Translate (Vector3.back * Time.deltaTime * movementSpeed, Space.World);
			}
		}
	}
}

