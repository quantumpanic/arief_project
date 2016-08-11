using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class quizPopupManager : MonoBehaviour
{

    public static quizPopupManager Instance;
    public GameObject mainPanel;

    public Stage stage;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	// semua text untuk pertanyaan dan jawaban
	string[][][] queries = new string[3][][]{
        new string[1][]{
            // easy
            new string[6]{
				// options A,B,C,D
                "Apa warna kunci ini",
                "Merah",
                "Biru",
                "Kuning",
                "Ungu",
				// jawaban benar
                "Merah"}
            },
        new string[3][]{
            // medium
            new string[6]{
                "Setelah mendapatkan kunci berwarna hijau, berapa tikungan untuk membuka pagar hijau?",
                "0",
                "1",
                "2",
                "3",
                "2"},
            new string[6]{
                "Untuk mendapatkan kunci warna merah ini , sebelumnya harus membuka pagar berwarna?",
                "Merah",
                "Hijau",
                "Kuning",
                "Biru",
                "Hijau"},
            new string[6]{
                "Berapakah waktu yang disediakan pada level medium ini?",
                "30 Detik",
                "60 Detik",
                "90 Detik",
                "120 Detik",
                "120 Detik"}
            },
        new string[5][]{
            // hard
            new string[6]{
                "Berapakah waktu yang disediakan pada level hard ini?",
                "1 Menit",
                "3 Menit",
                "5 Menit",
                "7 Menit",
                "5 Menit"},
            new string[6]{
                "Ada berapa tikungan dari pagar merah sampai tempat kunci berwarna kuning?",
                "0",
                "1",
                "2",
                "3",
                "2"},
            new string[6]{
                "Sebelum mendapatkan kunci hijau, terdapat jalan yang berupa...",
                "Tikungan",
                "Pertigaan",
                "Perempatan",
                "Buntu",
                "Perempatan"},
            new string[6]{
                "Berapakah total waktu yang diberikan dari level easy sampai hard?",
                "270",
                "180",
                "420",
                "580",
                "580"},
            new string[6]{
                "Berapa software yang dibutuhkan untuk membuat game ini?",
                "1",
                "2",
                "3",
                "4",
                "3"}
        }
    };
	
	public Key activeKey;
	public playerScript activePlayer;
	
    public void ShowMainPanel(Key key, playerScript plyr, int num = 0)
    {
        switch (stage)
		{
			case Stage.Easy:
			{
				PickQuestion(0,num);
				break;
			}
			case Stage.Medium:
			{
				PickQuestion(1,num);
				break;
			}
			case Stage.Hard:
			{
				PickQuestion(2,num);
				break;
			}
		}
		
		activeKey = key;
		activePlayer = plyr;
        SceneManager.LoadScene("QuizPanel", LoadSceneMode.Additive);
    }
	
	public string questionText;
	public string optionTextA;
	public string optionTextB;
	public string optionTextC;
	public string optionTextD;
	public string correctAnswer;
	
	List<int> usedQuestions = new List<int>();
	
	void PickQuestion(int diff, int num)
	{
		questionText = queries[diff][num][0];
		optionTextA = queries[diff][num][1];
		optionTextB = queries[diff][num][2];
		optionTextC = queries[diff][num][3];
		optionTextD = queries[diff][num][4];
		correctAnswer = queries[diff][num][5];
	}
}

public enum Stage
{
    Easy,
    Medium,
    Hard
}
