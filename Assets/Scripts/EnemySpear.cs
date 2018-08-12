using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpear : MonoBehaviour {

	public float xVal ;
	public float xVel ;

	// Use this for initialization
	void Start () {
		xVel = 0.1f;
		xVal = GameObject.Find("enemySpearPosition").transform.position.x;
		Destroy(GameObject.Find("enemySpear(Clone)"),1f);
	}
	
	// Update is called once per frame
	void Update () {
		
		xVal -= xVel;
		transform.position = new Vector3 (xVal,transform.position.y,0);
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		if(col.gameObject.tag == "Player"){
			print("deve destruir a lança");
			Destroy(GameObject.Find("enemySpear(Clone)"),0.3f);
		}		
		
		if(col.gameObject.tag == "spear"){
			Destroy(GameObject.Find("enemySpear(Clone)"));
			Destroy(GameObject.Find("playerSpear(Clone)"));
		}
		
	}
}
