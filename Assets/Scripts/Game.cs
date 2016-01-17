using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public Text scoreText;
	public Text timerText;
	private Canvas canvas;

	private float startTime;
	// Use this for initialization
	void Start () {
		canvas = FindObjectOfType<Canvas>();
		startTime = 100.0f;
}

	// Update is called once per frame
	void Update()
	{
		// TODO: Update the score
		//Core.GetInstance().Score;

		if (startTime > 0)
		{
			startTime -= Time.deltaTime;
		}
		else
		{
			// Game over
		}

		int minutes = (int)(startTime / 60.0f);
		int seconds = (int)(startTime % 60.0f);

		if (seconds < 10)
			timerText.text = minutes + ":0" + seconds;
		else
			timerText.text = minutes + ":" + seconds;
	}
}
