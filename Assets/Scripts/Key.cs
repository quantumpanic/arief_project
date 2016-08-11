using UnityEngine;
using System.Collections;

public enum KeyColor
{
	Red,
	Blue,
	Yellow,
	Purple,
	Green
}

public class Key : MonoBehaviour {

    public KeyColor color;
	public int quizTag;
	bool hasQuiz;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider col)
	{
		if (hasQuiz) return;
		if (col.gameObject.tag == "Player") {
			playerScript player = col.gameObject.GetComponent<playerScript>();
			QuizPlayer(quizTag, player);
		}
	}
	
	public void GiveKey(playerScript plyr)
	{
        // kasih kunci ke player
        plyr.keys.Add(color);
		Destroy(gameObject); // hapus objek kunci
	}
	
	public void QuizPlayer(int num, playerScript player)
	{
		quizPopupManager.Instance.ShowMainPanel(this, player, quizTag);
		CharacterMovement.Instance.isQuizzed = true;
		hasQuiz = true;
	}
}
