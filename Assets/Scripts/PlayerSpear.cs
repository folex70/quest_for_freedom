using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpear : MonoBehaviour {


	public float xVal ;
	public float xVel ;
	public GameObject spearPosition;

	// Use this for initialization
	void Start () {
		xVel = 0.1f;
		xVal = GameObject.Find("spearPosition").transform.position.x;
		Destroy(GameObject.Find("playerSpear(Clone)"),1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		xVal += xVel;
		transform.position = new Vector3 (xVal,transform.position.y,0);
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "Enemy"){
			print("deve destruir a lança");
			Destroy(GameObject.Find("playerSpear(Clone)"),0.3f);
		}else{
			Destroy(GameObject.Find("playerSpear(Clone)"),1f);
		}
		
		if(col.gameObject.tag == "spear"){
			Destroy(GameObject.Find("playerSpear(Clone)"));
			Destroy(GameObject.Find("enemySpear(Clone)"));
		}
		
	}
}
