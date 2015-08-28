using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	void Update(){
		if (Input.GetMouseButtonDown (0)) {

			Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.up, 0.0023f);
			print(hit.transform.gameObject.tag.ToString());

			switch (hit.transform.gameObject.tag) {
				
			case "Item":
				hit.transform.gameObject.GetComponent<ItemBehaviour>().changePlace(hit.transform.gameObject);
				break;

			case "Floor":
				GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
				break;

			case "Door":
				print("Zup");
				if(!hit.transform.gameObject.GetComponent<DoorBehaviour>().DoorOpen){
					hit.transform.gameObject.GetComponent<DoorBehaviour>().DoorOpen = true;
					//Criar funçao que muda a imagem da porta para aberta e faz um simpatico som dela abrindo.
				} else {
					GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().moveAllowed = true;
				}
					
				break;
			}
		}
	}
}
