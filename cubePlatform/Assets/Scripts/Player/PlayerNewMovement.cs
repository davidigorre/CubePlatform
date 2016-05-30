using UnityEngine;

public class PlayerNewMovement : MonoBehaviour
{

	float walkSpeed=10f;
	float jump=5f;
	public float jumpMoveVelocity= 2f;
	public bool isJumping;
	public float jumpSeg;
	public float giroForza;
	//float jumpSpeedShift=30f;
	float runSpeed=20f;
	public float playerSpeed;
	public float playerJumpSpeed;

	Vector3 movement;
	Rigidbody playerRigidBody;

	void Awake(){ // se llama antes de nada sincroniza todos al principio
		playerRigidBody = GetComponentInChildren<Rigidbody> ();
		playerSpeed = walkSpeed;
		playerJumpSpeed = jump;
		isJumping = true;
		jumpSeg = 1.2f;
		giroForza = 5f;
	}

	void FixedUpdate(){

		/*if (Input.GetKey (KeyCode.LeftShift)) {
			playerJumpSpeed = jumpSpeedShift;
			playerSpeed = runSpeed;
		} else {
			playerSpeed = walkSpeed;
			playerJumpSpeed = jumpSpeed;
		}*/


		//Leer las teclas
		float h =Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		// Mover jugador


		if(Input.GetKeyDown(KeyCode.Space)){
			// Mirar si pisa suelo
			if(isJumping == true){
				Jump ();
				Invoke ("Jumping", jumpSeg);
				isJumping = false;
			}
		}
		Move (h,v);
	}

	void Move(float h, float v){
		//Mirar si esta saltando y moverlo mas lento.
		if(isJumping == false){
			playerSpeed = jumpMoveVelocity;
		}else{
			playerSpeed = walkSpeed;
		}

		/*//pasamos el movimiento de 2D a 3D
		movement.Set (0f, 0f, v);
		//calculamos el movimiento
		movement = movement * playerSpeed * Time.deltaTime;
		//movement.Set (h * jumpSpeed, v, 0f);
		playerRigidBody.MovePosition(transform.position + movement);*/

		if (v < 0) {
			transform.Translate (Vector3.back * playerSpeed * Time.deltaTime);
		}
		if (v > 0) {
			transform.Translate (Vector3.forward * playerSpeed * Time.deltaTime);
		}

		//rota a la direccion que va
		if (h < 0) {
			transform.Rotate (0, -giroForza, 0);
			/*Quaternion rotation = Quaternion.LookRotation (new Vector3(giroForza, 0f, 0f));
			//rotacion
			playerRigidBody.MoveRotation(rotation);*/
		}
		if (h > 0) {
			transform.Rotate (0, giroForza, 0);
			/*Quaternion rotation = Quaternion.LookRotation (new Vector3(giroForza, 0f, 0f));
			//rotacion
			playerRigidBody.MoveRotation(rotation);*/
		}


	}

	void Jumping(){
		/*Vector3 fwd = transform.TransformDirection (-Vector3.up);
		return(!Physics.Raycast (transform.position, fwd, 0.78f));*/
		isJumping = true;
	}

	void Jump(){
		/*Vector3 up = transform.TransformDirection(Vector3.up);
		playerRigidBody.AddForce(up*playerJumpSpeed, ForceMode.Impulse);*/
		playerRigidBody.velocity = new Vector3(0, jump, 0);
		/*Vector3 up = transform.TransformDirection(Vector3.up);
		transform.Translate (up * playerJumpSpeed);*/
	}
}