using UnityEngine;
using System.Collections;
using System;

public class Core : MonoBehaviour {

	private IRecipe mRecipe;
	private bool started = true;

	public float TimeToSkip = -1.0f;
	private float timeDuration = 0.0f;

	public float ScoreValue = 10.0f;
	private float Score = 0.0f;

	// Use this for initialization
	void Start () {
		// TODO: Testing
		mRecipe = new RandomRecipe(1000);
    }

	// Update is called once per frame
	void Update () {
		if (started && mRecipe != null)
		{
			Action action = mRecipe.CurrentStep();
			if (TimeToSkip >= 0.0f)
			{
				timeDuration += Time.deltaTime;
				if (timeDuration >= TimeToSkip)
				{
					started = nextStep();
                    return;
				}
            }

			Debug.Log(action);

			if (Control.GetInstance().GetInput(action))
			{
				Score += ScoreValue;
                started = nextStep();

				Debug.Log(Score);
			}
		}
	}

	public bool IsStarted()
	{
		return started;
    }

	private bool nextStep()
	{
		bool valid = true;
		try
		{
			mRecipe.NextStep();
		}
		catch (InvalidOperationException)
		{
			valid = false;
		}
		return valid;
	}

	private bool preStep()
	{
		bool valid = true;
		try
		{
			mRecipe.PreStep();
		}
		catch (InvalidOperationException)
		{
			valid = false;
		}
		return valid;
	}

	public void SetRecipe(IRecipe recipe)
	{
		mRecipe = recipe;
    }

	public void StartCooking()
	{
		started = true;
    }
}
