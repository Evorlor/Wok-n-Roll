using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

	private static Control instance = null;
	public bool EnableAdditionalKeysChecking = true;

	public float NorthVolatileTime = 0.05f;
    public float NorthTriggerTime = 0.0f;

	public float NortheastVolatileTime = 0.05f;
	public float NortheastTriggerTime = 0.0f;

	public float EastVolatileTime = 0.05f;
	public float EastTriggerTime = 0.0f;

	public float SoutheastVolatileTime = 0.05f;
	public float SoutheastTriggerTime = 0.0f;

	public float SouthVolatileTime = 0.05f;
	public float SouthTriggerTime = 0.0f;

	public float SouthwestVolatileTime = 0.05f;
	public float SouthwestTriggerTime = 0.0f;

	public float WestVolatileTime = 0.05f;
	public float WestTriggerTime = 0.0f;

	public float NorthwestVolatileTime = 0.05f;
	public float NorthwestTriggerTime = 0.0f;

	public float JumpVolatileTime = 0f;
	public float JumpTriggerTime = 0.1f;



	public static Control GetInstance()
	{
		return instance;
	}

	private class InputNames
	{
		public const string North = "North";
		public const string Northeast = "Northeast";
		public const string East = "East";
		public const string Southeast = "Southeast";
		public const string South = "South";
		public const string Southwest = "Southwest";
		public const string West = "West";
		public const string Northwest = "Northwest";
		public const string Jump = "Jump";
	}

	private class InputNode
	{
		public InputNode(float timeDuration, float triggerPressDuration = 0.0f, bool reversed = false)
		{
			TimeDuration = timeDuration;
			Reversed = reversed;
			TriggerPressDuration = triggerPressDuration;
        }

		public float TriggerPressDuration;
		public float TimeDuration;


		public float InputPressDuration;
		public float LastUpdateTime;
		public bool Pressed;
		public bool Reversed;
	}

	private Dictionary<Action, InputNode> Inputs;

	private string inputConvert(Action input)
	{
		switch (input)
		{
			case Action.North:
				return InputNames.North;
            case Action.Northeast:
				return InputNames.Northeast;
            case Action.East:
				return InputNames.East;
            case Action.Southeast:
				return InputNames.Southeast;
			case Action.South:
				return InputNames.South;
			case Action.Southwest:
				return InputNames.Southwest;
			case Action.West:
				return InputNames.West;
			case Action.Northwest:
				return InputNames.Northwest;
			case Action.Jump:
				return InputNames.Jump;
			default:
				return string.Empty;
		} 
	}

	private bool checkInput(Action key)
	{
		bool pressed = Input.GetButton(inputConvert(key));

		if (!EnableAdditionalKeysChecking)
		{
			return pressed;
        }

		Action addtionalChecking1 = key;
		Action addtionalChecking2 = key;

		switch (key)
		{
			case Action.North:
				addtionalChecking1 = Action.Northeast;
				addtionalChecking2 = Action.Northwest;
				break;
            case Action.Northeast:
				addtionalChecking1 = Action.North;
				addtionalChecking2 = Action.East;
				break;
            case Action.East:
				addtionalChecking1 = Action.Northeast;
				addtionalChecking2 = Action.Southeast;
				break;
            case Action.Southeast:
				addtionalChecking1 = Action.South;
				addtionalChecking2 = Action.East;
                break;
            case Action.South:
				addtionalChecking1 = Action.Southwest;
				addtionalChecking2 = Action.Southeast;
				break;
            case Action.Southwest:
				addtionalChecking1 = Action.West;
				addtionalChecking2 = Action.South;
				break;
            case Action.West:
				addtionalChecking1 = Action.Northwest;
				addtionalChecking2 = Action.Southwest;
				break;
            case Action.Northwest:
				addtionalChecking1 = Action.North;
				addtionalChecking2 = Action.West;
				break;
            default:
				break;
		}

		bool pressed1 = Input.GetButton(inputConvert(addtionalChecking1));
		bool pressed2 = Input.GetButton(inputConvert(addtionalChecking2));


		return (pressed || pressed1 || pressed2);
    }

	void Start () {
		instance = this;

		Inputs = new Dictionary<Action, InputNode>()
		{
			{Action.North, new InputNode(NorthVolatileTime, NorthTriggerTime)},
			{Action.Northeast, new InputNode(NortheastVolatileTime, NortheastTriggerTime) },
			{Action.East, new InputNode(EastVolatileTime, EastTriggerTime) },
			{Action.Southeast, new InputNode(SoutheastVolatileTime, SoutheastTriggerTime) },
			{Action.South, new InputNode(SouthVolatileTime, SouthTriggerTime) },
			{Action.Southwest, new InputNode(SouthwestVolatileTime, SouthwestTriggerTime) },
			{Action.West, new InputNode(WestVolatileTime, WestTriggerTime) },
			{Action.Northwest, new InputNode(NorthwestVolatileTime, NorthwestTriggerTime) },
			{Action.Jump, new InputNode(JumpVolatileTime, JumpTriggerTime, true) },
		};
	}


	void FixedUpdate () {

		// Check button status
		List<Action> keys = new List<Action>(Inputs.Keys);
		foreach (Action key in keys)
		{
			InputNode inputNode = Inputs[key];
			if (!inputNode.Pressed) {
				if (checkInput(key) ^ inputNode.Reversed)
				{
					// Check time
					if (inputNode.InputPressDuration > inputNode.TriggerPressDuration)
					{
						inputNode.InputPressDuration = 0.0f;
						inputNode.LastUpdateTime = Time.fixedTime;
						inputNode.Pressed = true;
					} else
					{
						inputNode.InputPressDuration += Time.deltaTime;
					}
				} else
				{
					inputNode.InputPressDuration = 0.0f;
				}
			} else if(inputNode.Pressed && inputNode.TimeDuration >= 0.0f)
			{
				// Volatile 
				if (inputNode.TimeDuration < Time.fixedTime - inputNode.LastUpdateTime)
				{
					inputNode.InputPressDuration = 0.0f;
					inputNode.LastUpdateTime = Time.fixedTime;
					inputNode.Pressed = false;
				}
			}
		}
	}

	public bool GetInput(Action input)
	{
		return Inputs[input].Pressed;
	}
}
