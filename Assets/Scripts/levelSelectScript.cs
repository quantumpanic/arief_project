using UnityEngine;
using System.Collections;

public class levelSelectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LevelSelection()
    {
        Application.LoadLevel("Level_Select");
    }

    public void OpenEasy()
    {
        Application.LoadLevel("Easy");
    }

    public void OpenNormal()
    {
        Application.LoadLevel("Norm");
    }

    public void OpenHard()
    {
        Application.LoadLevel("Hard");
    }
}
