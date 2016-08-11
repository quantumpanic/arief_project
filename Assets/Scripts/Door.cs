using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door : MonoBehaviour {

	public bool isOpen;
    public KeyColor color;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerStay(Collider col)
	{
		if (isOpen)
			return;
		if (col.gameObject.tag == "Player") {
			// cek ada kunci
			playerScript player = col.gameObject.GetComponent<playerScript>();
			if (player.keys.Contains(color))
			{
				print("open");
				// buka pintu
				OpenDoor();
			}
		}
	}

	public void OpenDoor()
	{
		// buka dan main animasi
		isOpen = true;
		gameObject.GetComponent<Animator> ().SetBool ("opened", true);
	}
}