using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public Text scoreText;
	public Text timerText;
	private Canvas canvas;

	public float StartTime = 100.0f;
	// Use this for initialization
	void Start () {
		canvas = FindObjectOfType<Canvas>();
	}

	// Update is called once per frame
	void Update()
	{
		// TODO: Update the score
		scoreText.text = Core.GetInstance().Score.ToString();

		if (StartTime > 0)
		{
			StartTime -= Time.deltaTime;
		}
		else
		{
			// Game over
		}

		int minutes = (int)(StartTime / 60.0f);
		int seconds = (int)(StartTime % 60.0f);

		if (seconds < 10)
			timerText.text = minutes + ":0" + seconds;
		else
			timerText.text = minutes + ":" + seconds;
	}
}
