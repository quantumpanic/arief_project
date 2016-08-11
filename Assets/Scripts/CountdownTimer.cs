using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour 
{
	public float timer;
	public float timerLimit = 30.0f;

	public GUIText timerText;
	private FinishLine finishLine;
	
	public static CountdownTimer Instance;
	
	void Awake()
	{
		if (!Instance)
		{
			Instance = this;
		}
	}

	// Use this for initialization
	void Start () 
	{
		timer = timerLimit;
		SetTimerText ();

		finishLine = GameObject.Find ("FinishLine").GetComponent<FinishLine>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		SetTimerText ();

		if(timer <= 0.0f)
		{
			finishLine.winLoseText.text = "Waktu Habis!!";
            Destroy(GameObject.Find("Boulder"));
			Invoke("Reset", 3);
			timer = timerLimit;
		}
	}

    void Reset()
    {
        finishLine.ResetLevel();
    }

	void SetTimerText()
	{
		timerText.text = "Time Left: " + timer.ToString("f0");
	}
}
