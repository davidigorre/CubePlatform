using UnityEngine;
using System.Collections;

public class Lvl1PushWall : MonoBehaviour {
	
	public float mroPosition;
	public float mroSpeed;
	public float mroDistance;
	public bool moveRight;
	Vector3 initialTrans;
	
	private AudioClip blob;
	private AudioSource source;
	bool activateSound;
	
	void Awake() {
		initialTrans = transform.position;
		source = GetComponent<AudioSource>();
		blob = GetComponent<AudioClip>();
		activateSound = true;
	}

	void FixedUpdate () {
		
		mroPosition = transform.position.z;
		if (moveRight) {
			Invoke("MoveRight",1);
		} else {
			MoveLeft ();
		}
	}
	
	void MoveRight(){
		if ((initialTrans.z - mroDistance) < mroPosition) {
			transform.Translate (Vector3.up * Time.deltaTime * mroSpeed);
			return;
		}
		if(activateSound) {
//			source.PlayOneShot(blob, 5);
			source.Play();
			activateSound = !activateSound;
		}
		moveRight = false;
	}
	
	void MoveLeft(){
		if ((initialTrans.z) > mroPosition) {
			transform.Translate (Vector3.down * Time.deltaTime * mroSpeed);
			return;
		}
		if(!activateSound){
			activateSound = true;
		}
		moveRight = true;
	}	

	void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player") {
			col.transform.GetComponent<PlayerMovement>().IsDead(true);
		}
	}
}
