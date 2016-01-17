using UnityEngine;
using System.Collections;
using System;

public class Core : MonoBehaviour {

	private static Core instance;
	public static Core GetInstance()
	{
		return instance;
	}

	private bool EnableShackingStyle = false;
	private int ShackingTimes = 2;
	private int currentShackingTime = 0;

	private bool debounced = false;

	private bool started = true;

	public float TimeToSkip = -1.0f;
	private float timeDuration = 0.0f;

	private int ScoreValue = 1;
	public int Score = 0;

    private float timeDelayed = 0.0f;
    public float TimeToDelay = 0.5f;

	// Use this for initialization
	void Start () {
		instance = this;
    }

	// Update is called once per frame
	void Update () {
		if (started && timeDelayed >= TimeToDelay)
		{
            Action action = InstructionManager.Instance.GetCurrentInstruction().action;
			if (TimeToSkip >= 0.0f)
			{
				timeDuration += Time.deltaTime;
				if (timeDuration >= TimeToSkip)
				{
					started = nextStep();
                    return;
				}
            }
            

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
                            timeDelayed = 0.0f;
                            started = nextStep();
						}
					}
				}
			} else
			{
				debounced = true;
            }
		} else
        {
            timeDelayed += Time.deltaTime;
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
			InstructionManager.Instance.NextInstruction();
		}
		catch (InvalidOperationException)
		{
			valid = false;
		}
		return valid;
	}

	public void StartCooking()
	{
		started = true;
    }
}
