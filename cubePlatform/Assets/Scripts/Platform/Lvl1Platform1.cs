using UnityEngine;
using System.Collections;

public class Lvl1Platform1 : MonoBehaviour {

	Vector3 initialTrans;
	public GameObject plt1;
	public int trampaTime;
	public bool isDebug;


	void Awake () {
		initialTrans = plt1.transform.position;
	}

	void Update(){
		if(isDebug) {
			Invoke("MovePlatformPos", 0);
			Invoke("ReturnPlatformPos", trampaTime);
			isDebug = false;
		}
	}

	void OnTriggerEnter(Collider other){
		Invoke ("MovePlatformPos", 0);
	}

	void MovePlatformPos() {
		if (plt1.transform.position.y == initialTrans.y) {
			Vector3 tmp = plt1.transform.position;
			tmp.y = plt1.transform.position.y - 1f;
		
			plt1.transform.position = tmp;
//			Invoke ("ReturnPlatformPos", trampaTime);
		}
	}

	void ReturnPlatformPos(){
		plt1.transform.position = initialTrans;
	}

}
