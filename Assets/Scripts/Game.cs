using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public Text scoreText;
	public Text timerText;
	private Canvas canvas;
    private GameOver gameOver;

	public float StartTime = 100.0f;
    private float defaultTime = 0;

        void Awake()
    {
        defaultTime = StartTime;
    }
	// Use this for initialization
	void Start () {
		canvas = FindObjectOfType<Canvas>();
        gameOver = FindObjectOfType<GameOver>();
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

		float fractionalPortion = StartTime - (float)System.Math.Truncate(StartTime);
		int mmseconds = (int)(fractionalPortion * 100 % 60.0f);

		string timeStr;
		if (seconds < 10)
			timeStr = minutes + ":0" + seconds;
		else
			timeStr = minutes + ":" + seconds;

		if (mmseconds < 10)
			timeStr += ":0" + mmseconds;
		else
			timeStr += ":" + mmseconds;

        if(minutes <= 0 && seconds <= 0 && mmseconds <= 0)
        {
            minutes = seconds = mmseconds = 0;
            gameOver.SetGameOver(true);
        }

        timerText.text = timeStr;

        bool isJumping = Control.GetInstance().GetInput(Action.North);

      if (gameOver.IsGameOver() && isJumping){
            gameOver.SetGameOver(false);
            gameOver.image.enabled = false;
            StartTime = defaultTime;
            //minutes = 0;
            //seconds = 5;
            //mmseconds = 0;
            Core.GetInstance().Score = 0;
        }
    }
}
