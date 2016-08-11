using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class quizPanelScript : MonoBehaviour
{
	public GameObject mainPanel;
	
	void Awake()
	{
		// get values from quiz manager
		
	}
	
	quizPopupManager popupManager;
	public Text questionText;
	public Text optionTextA;
	public Text optionTextB;
	public Text optionTextC;
	public Text optionTextD;
	
    // Use this for initialization
    void Start()
    {
		popupManager = quizPopupManager.Instance;
		ApplyText();
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	void ApplyText()
	{
		questionText.text = popupManager.questionText;
		optionTextA.text = popupManager.optionTextA;
		optionTextB.text = popupManager.optionTextB;
		optionTextC.text = popupManager.optionTextC;
		optionTextD.text = popupManager.optionTextD;
	}
	
	public void GiveAnswer(Button button)
	{
		string answerTxt = button.GetComponentInChildren<Text>().text;
		QueryAnswer(answerTxt);
	}
	
	void QueryAnswer(string answer)
	{
		if (popupManager.correctAnswer == answer)
		{
			CorrectAnswer();
		}
		else
		{
			WrongAnswer();
		}
	}
	
	void CorrectAnswer()
	{
		popupManager.activeKey.GiveKey(popupManager.activePlayer);
		ClosePanel();
	}
	
	void WrongAnswer()
	{
		CountdownTimer.Instance.timer = 0;
		ClosePanel();
	}
	
	void ClosePanel()
	{
		Destroy(transform.parent.gameObject);
	}
	
	void OnDestroy()
	{
		CharacterMovement.Instance.isQuizzed = false;
	}
}
