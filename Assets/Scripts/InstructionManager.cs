using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown(InputNames.North))
        {
            Debug.Log("grewgr");
            NextInstruction();
        }
    }


    [Tooltip("All possible instructions")]
    public Instruction[] allInstructions;

    [Tooltip("The number of active and future instructions to be displayed on screen at once")]
    [Range(1, 5)]
    public int numInstructionsInQueue = 4;

    [Tooltip("Position of active instruction in the UI")]
    public Vector2 activeInstructionPosition;

    private const string InstructionManagerName = "Instruction Manager";
    private const string InstructionName = "Instruction #";
    private const string UpdateInstructionsMethodName = "UpdateInstructions";

    private static InstructionManager instance;
    private Instruction[] activeInstructions;

    /// <summary>
    /// Gets the singleton instance of the GameManager
    /// </summary>
    public static InstructionManager Instance
    {
        get
        {
            if (!instance)
            {
                var gameManagerGameObject = GameObjectFactory.GetOrAddGameObject(InstructionManagerName);
                instance = gameManagerGameObject.GetOrAddComponent<InstructionManager>();
            }
            return instance;
        }
    }

    void Awake()
    {
        foreach (InstructionManager instructionManager in FindObjectsOfType<InstructionManager>())
        {
            if (instructionManager != this)
            {
                Destroy(instructionManager.gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        if (allInstructions.Length == 0)
        {
            Debug.LogError("At least one instruction must be added to the list of All Instructions!");
        }
        activeInstructions = new Instruction[numInstructionsInQueue];
    }

    void Start()
    {
        InitializeInstructions();
    }

    /// <summary>
    /// Gets the array of Active Instructions in the order they are to be accomplished
    /// </summary>
    public Instruction[] GetActiveInstructions()
    {
        return activeInstructions;
    }

    /// <summary>
    /// Gets the current instruction to be completed
    /// </summary>
    public Instruction GetNextInstruction()
    {
        return activeInstructions[0];
    }

    /// <summary>
    /// Iterates through the instructions and generates a new random instruction
    /// </summary>
    public void NextInstruction()
    {
        Destroy(activeInstructions[0].gameObject);
        for (int i = 0; i < activeInstructions.Length - 1; i++)
        {
            activeInstructions[i] = activeInstructions[i + 1];
        }
        activeInstructions[activeInstructions.Length - 1] = GetRandomInstruction();
        var instructionBar = FindObjectOfType<InstructionBar>();
        instructionBar.SendMessage(UpdateInstructionsMethodName);
    }

    private Instruction GetRandomInstruction()
    {
        var instruction = Instantiate(allInstructions[Random.Range(0, allInstructions.Length)]);
        instruction.transform.SetParent(transform);
        return instruction;
    }

    private void InitializeInstructions()
    {
        for (int i = 0; i < activeInstructions.Length; i++)
        {
            activeInstructions[i] = GetRandomInstruction();
        }
    }
}
