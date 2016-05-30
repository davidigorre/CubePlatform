using UnityEngine;

public class PlayerAxisMovement : MonoBehaviour {
	
	public float speed=10f;
	public Camera cam;
	float SlowSpeedP=5f;
	float NormalSpeedP=10f;
	Vector3 movement;
	Rigidbody playerRigidBody;
	LayerMask floorMask;
	Animator anim;

	void Start(){ // una vez que se inicializa todo	
		
	}
	
	void Awake(){ // se llama antes de nada sincroniza todos al principio
		
		playerRigidBody = GetComponent<Rigidbody> ();
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		
	}
	
	void FixedUpdate(){
		//Leer las teclas
		float h =Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		// Mover jugador
		Move (h,v);
		// Calcular rotacion
		Turning ();
		// Llamar a las animaciones
		Animating (h,v);
		
	}
	
	void Move(float h, float v){
		//pasamos el movimiento de 2D a 3D
		movement.Set (h, 0f, v);
		
		//calculamos el movimiento
		movement = movement * speed * Time.deltaTime;
		
		playerRigidBody.MovePosition (transform.position + movement);
	}
	
	void Turning(){
		//camera.main es la camara principal
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		RaycastHit floorHit;
		bool hit = Physics.Raycast (camRay,out floorHit, 2000f, floorMask);
		if (hit) { //si a chocado movemos el giro
			//floorHit.point es else punto del suelo donde esta el raton y transform.position es el jugador
			//La resta es el vector en esa direccion
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y=0f;
			//cantidad de rotacion que necesitamos
			Quaternion rotation = Quaternion.LookRotation(playerToMouse);
			//rotacion
			playerRigidBody.MoveRotation(rotation);
		}
		
	}
	
	void Animating(float h, float v){
		
		bool walking;
		if (h != 0 || v != 0) {
			walking = true;
		} else {
			walking = false;
		}
		anim.SetBool ("IsWalking", walking);
	}
	
	// mas lento durante 5 segundos cuando te toca un zomBear
	public void SlowSpeed(){
		speed = SlowSpeedP;
	}
	
	public void NormalSpeed(){
		speed = NormalSpeedP;
	}

	
	void Jump(){
//		Vector3 = transform.TransformDirection (Vector3.up);

	}
}
