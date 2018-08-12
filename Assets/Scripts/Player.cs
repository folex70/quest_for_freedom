using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float speed;
	protected Vector2 direction;
	public Rigidbody2D rb;
	public Transform GroundCheck;
	public bool Grounded;
	public float JumpForce;
	public GameObject spearPrefab;
	public GameObject spearPosition;
	
	AudioSource audio;
	public AudioClip  hitSound;
	public AudioClip  AttackSound;
	
	// Use this for initialization
	void Start () {
		speed = 4f;
		JumpForce = 50f;
		rb = GetComponent<Rigidbody2D>();
		audio = GetComponent<AudioSource>();
	}
	
	void FixedUpdate(){
		Grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.02f);
	}
	
	// Update is called once per frame
	void Update () {
		
		direction = Vector2.zero;
		
		if (Input.GetKey(KeyCode.A)){
			direction += Vector2.left;
		}
		
		if (Input.GetKey(KeyCode.D)){
			direction += Vector2.right;
		}
		
		if (Input.GetKey(KeyCode.Space) && Grounded==true){
			rb.AddForce(Vector2.up * JumpForce);
		}
		
		if(Input.GetButtonDown("Fire1")){
			//attack
			audio.PlayOneShot(AttackSound, 0.7F);
			Instantiate(spearPrefab, new Vector3(spearPosition.transform.position.x,spearPosition.transform.position.y,0), Quaternion.identity);
		}
		
		transform.Translate(direction*speed*Time.deltaTime);
		
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "spike"){
			print("colidiu com espinho");
			GameObject.Destroy(GameObject.Find("Player"));
		}
		
		if(col.gameObject.tag == "spear"){
			print("hit");
			audio.PlayOneShot(hitSound, 0.7F);
			rb.AddForce(Vector2.left * 1000f);
		}
		
	}
}
