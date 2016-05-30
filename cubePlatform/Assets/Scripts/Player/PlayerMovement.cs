using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	float walkSpeed = 20f;
	float runSpeed = 50f;
	float jump = 800f;
	public float DownForce = 3000f;
	bool isIdle;
	public bool isDead;
	public float giroForza;
	public float instantiateTime;
	public float playerSpeed;
	public float playerJumpSpeed;
	public float idleTime;

	public AudioClip audioInit;
	public AudioClip audioWalk;
	public AudioClip audioDead;
	public AudioClip audioIdle;
	private AudioSource source;

	Vector3 playerInitPos;
	Vector3 movement;
	Rigidbody playerRigidBody;
	Animator PlayerAnim;


	void Start() {
		playerInitPos = transform.position;
		instantiateTime = 2f;
		source.PlayOneShot(audioInit);
 		isIdleTimed();
	}

	void Awake(){
		gameObject.AddComponent<AudioSource>();
		giroForza = 10f;
		playerRigidBody = GetComponentInChildren<Rigidbody> ();
		PlayerAnim = transform.GetComponentInChildren<Animator> ();
		source = GetComponent<AudioSource>();
		playerSpeed = walkSpeed;
//		jumpSeg = 1.2f;
		//giroForza = 5f;
		isIdle = true;
	}

	void FixedUpdate(){
		if (!isDead) {
			//Leer las teclas
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");
			// Mover jugador);

			if(Input.GetKeyDown(KeyCode.Space)){
				// Mirar si pisa suelo
				if(IsGrounded()){
					Jump ();
				}
			}

			if (!IsGrounded()) {
				PlayerAnim.SetBool ("isJump", false);
				isIdleTimed ();
			}

			if (h == 0 && v == 0 && IsGrounded()) {
				PlayerAnim.SetBool ("isWalk", false);
				isIdleTimed ();
			} else {
				if (v != 0 || h != 0) {
					PlayerAnim.SetBool ("isWalk", true);
					if(source.isPlaying){
						source.clip = audioWalk;
						source.Play();
					}
				}
				QuitIdleState ();
				Move (h, v);
			}
				
			if (!IsGrounded()) {
				playerRigidBody.AddForce(Vector3.down * DownForce); //pegado al suelo
			}


//			Vector3 fwd1 = transform.TransformDirection (45f,-135f,0f);
//			Debug.DrawRay(playerRigidBody.transform.position, fwd1 * 0.00553f, Color.red);
//			Vector3 fwd2 = transform.TransformDirection (-45f,-135f,0f);
//			Debug.DrawRay(playerRigidBody.transform.position, fwd2 * 0.00553f, Color.green);
//			Vector3 fwd = transform.TransformDirection (Vector3.down);
//			Debug.DrawRay(playerRigidBody.transform.position, fwd * 0.8f, Color.cyan);


		}
	}

	void Move(float h, float v){

		if (IsCuesta ()) {
			playerSpeed = runSpeed;
		} else {
			playerSpeed = walkSpeed;
		}

		if (v < 0) {
			//transform.Translate (Vector3.left * playerSpeed * Time.deltaTime);
			Vector3 back = transform.TransformDirection(Vector3.left);
			playerRigidBody.AddForce(back*playerSpeed, ForceMode.Impulse);
		}

		if (v > 0) {
			Vector3 forward = transform.TransformDirection(Vector3.right);
			playerRigidBody.AddForce(forward*playerSpeed, ForceMode.Impulse);
		}


		//rota a la direccion que va
		if (h < 0) {
			transform.Rotate (0, -giroForza, 0);
		}
		if (h > 0) {
			transform.Rotate (0, giroForza, 0);
		}

	}

	bool IsGrounded(){
		Vector3 fwd = transform.TransformDirection (Vector3.down);
		Vector3 fwd1 = transform.TransformDirection (45f,-135f,0f);
		Vector3 fwd2 = transform.TransformDirection (-45f,-135f,0f);
		return(Physics.Raycast (transform.position, fwd, 0.8f) || Physics.Raycast (transform.position, fwd1, 0.8f) || Physics.Raycast (transform.position, fwd2, 0.8f));
	}

	bool IsCuesta(){
		Vector3 fwd1 = transform.TransformDirection (45f,-135f,0f);
		Vector3 fwd2 = transform.TransformDirection (-45f,-135f,0f);
		return(Physics.Raycast (transform.position, fwd1,  0.73f) || Physics.Raycast (transform.position, fwd2,  0.73f));
	}

	void Jump(){
		PlayerAnim.SetBool ("isJump", true);
		QuitIdleState ();
		//playerRigidBody.velocity = new Vector3(0, jump, 0);
		Vector3 up = transform.TransformDirection(Vector3.up);
		playerRigidBody.AddForce(up * jump , ForceMode.Impulse);
		//Vector3 up = transform.TransformDirection(Vector3.up);
		//playerRigidBody.AddForce(up*playerJumpSpeed, ForceMode.Impulse);
	}

	void OnCollisionStay(Collision cos){
		if (cos.gameObject.tag == "Platform") {
			transform.parent = cos.transform;
			return;
		}
		transform.parent = null;
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Platform"){
			transform.parent = col.transform;
			return;
		}
		transform.parent = null;		
	}
	
	void OnTriggerExit(Collider col){
		transform.parent = null;		
	}

	void IdleState(){
		if (isIdle) {
			PlayerAnim.SetBool ("isIdle", true);
//			source.loop = true;
			/*if(source.isPlaying){
				source.loop = true;
				source.clip = audioIdle;
				source.Play();
			}*/
		}
	}

	void isIdleTimed() {
		if (!isIdle) {
			isIdle = true;
			Invoke ("IdleState", idleTime);
		}
	}

	void QuitIdleState(){
		isIdle = false;
//		source.loop = false;
//		source.Stop();
		PlayerAnim.SetBool ("isIdle", false);
	}

	public void IsDead(bool hasTimer){
		source.clip = audioDead;
		source.Play ();
		isDead = true;
		PlayerAnim.SetBool ("isDead", true);
		if (hasTimer) {
			Invoke("InstantiateIt", instantiateTime);
			Destroy (gameObject, instantiateTime);
		}else{
			Invoke("InstantiateIt", 0);
			Destroy(gameObject);
		}
	}

	void InstantiateIt(){
		Instantiate (Resources.Load ("Prefabs/Player/PlayerFab"), playerInitPos, Quaternion.identity);
		isDead = false;
	}
}