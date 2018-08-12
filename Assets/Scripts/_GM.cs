using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GM : MonoBehaviour {

	public float time = 59f;
	public float floorTime = 5f;
	public int floorCount = 0;
	public Text timeText;
	public Text gameText;
	public GameObject floor;
	public bool WinGame;
	public bool GameEnded;
	public GameObject Player;
	public GameObject Enemy;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameEnded){
			time -= Time.deltaTime;
			floorTime -= Time.deltaTime;
			timeText.text = "Time: "+Mathf.Round(time);	
		}
		
		
		
		
		if(floorTime < 0){

			if(floorCount == 0){
				GameObject.Destroy(GameObject.Find("Floor"));
				floorCount ++;
			}else{
				GameObject.Destroy(GameObject.Find("Floor ("+floorCount+")"));
				floorCount ++;
			}
			
			floorTime = 3f;
		}
		
		if(time < 0){
			GameOver();
		}
		
		if(!GameEnded){
			Player = GameObject.Find("Player");
			if(Player == null){
				WinGame = false;
				GameOver();	
			}
			
			Enemy = GameObject.Find("Enemy");
			if(Enemy == null){
				WinGame = true;
				GameOver();	
			}
		}
	}
	
	public void GameOver(){
		GameEnded = true;
		if(WinGame){
			gameText.text = "You Win! Thanks for play. This game is a entry for LD#42 made in 24 hours! Game By @folex70.";
		}else{
			gameText.text = "You Loose! Thanks for play. This game is a entry for LD#42 made in 24 hours! Game By @folex70.";
		}
	}
}
