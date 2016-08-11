using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour 
{
	public GUIText winLoseText;

	//Inisialisasi
	void Start () 
	{
		winLoseText.text = "";
	}

    //Update dipanggil sekali per frame
    void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		//Jika batu melintasi garis finish, menampilkan teks Anda Menang !
		if(other.tag == "boulder")
		{
			winLoseText.text = "Anda Menang!";
            Invoke("NextLevel", 3);
		}
	}

	public void NextLevel()
	{
        if (Application.loadedLevelName == "Easy")
        {
            Application.LoadLevel("Norm");
        }

        else if (Application.loadedLevelName == "Norm")
        {
            Application.LoadLevel("Hard");
        }
	}

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
