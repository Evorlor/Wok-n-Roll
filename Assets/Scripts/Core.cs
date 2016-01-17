using UnityEngine;
using System.Collections;
using System;

public class Core : MonoBehaviour {

	private bool EnableShackingStyle = false;
	private int ShackingTimes = 2;
	private int currentShackingTime = 0;

	private bool debounced = false;

	private IRecipe mRecipe;
	private bool started = true;

	public float TimeToSkip = -1.0f;
	private float timeDuration = 0.0f;

	private float ScoreValue = 0.1f;
	private float Score = 0.0f;

	// Use this for initialization
	void Start () {
		// TODO: Testing
		mRecipe = new RandomRecipe();
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
				if (action == Action.Jump)
				{
					for (int i = (int)Action.BEGIN + 1; i < (int)Action.SIZE; i++)
					{
						if (i == (int)Action.Jump)
							continue;
						if (Control.GetInstance().GetInput((Action)i))
							return;
					}

					Score += ScoreValue;
					started = nextStep();
				}
				else
				{
					if (debounced || !EnableShackingStyle) {
						debounced = false;
						currentShackingTime++;
						if ((currentShackingTime >= ShackingTimes) || !EnableShackingStyle)
						{
							currentShackingTime = 0;
							Score += ScoreValue;
							started = nextStep();
							Debug.Log(Score);
						}
					}
				}
			} else
			{
				debounced = true;
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
