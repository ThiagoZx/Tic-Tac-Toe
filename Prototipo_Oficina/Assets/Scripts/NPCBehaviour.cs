using UnityEngine;
using System.Collections;

public class NPCBehaviour : MonoBehaviour {

	public Texture2D cursor;
	public GUIText[] textBox;
	public GameObject[] scripts;
	public string[] text;
	private bool isTalking;
  
	void OnMouseOver(){
		Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
		if (Input.GetMouseButtonUp (0)) {
			chatIn();
		}
	}

	private void chatIn(){
		for (int i = 0; i < scripts.Length; i++) {
			if(scripts[i].tag == "Door"){
				scripts[i].GetComponent<DoorBehaviour>().enabled = false;
			} else if(scripts[i].tag == "Player"){
				scripts[i].GetComponent<Player_Mov>().enabled = false;
			}
		}

		isTalking = true;
		chat ();

	}

	private void chat(){
		for (int i = 0; i < textBox.Length; i++) {
			textBox[i].text = text[i];
		}
	}

	private void clearChat(){
		for (int i = 0; i < textBox.Length; i++) {
			textBox[i].text = null;
		}
	}

	private void chatOut(){

		clearChat ();

		for (int i = 0; i < scripts.Length; i++) {
			if(scripts[i].tag == "Player"){
				scripts[i].GetComponent<Player_Mov>().enabled = true;
			} else if(scripts[i].tag == "Door"){
				scripts[i].GetComponent<DoorBehaviour>().enabled = true;
			}
		}
	}
	
	void OnMouseExit(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

	void Update(){
		if(isTalking && Input.GetMouseButton (0)){
			chatOut();
			isTalking = false;
		}
	}
}