using UnityEngine;
using UnityEngine.UI;

public class InstructionBar : MonoBehaviour
{
    [Tooltip("All possible instructions")]
    public Instruction[] allInstructions;

    [Tooltip("The number of active and future instructions to be displayed on screen at once")]
    [Range(1, 5)]
    public int numInstructionsOnScreen = 4;

    [Tooltip("Position of active instruction in the UI")]
    public Vector2 activeInstructionPosition;

    private const string InstructionName = "Instruction #";
    private readonly Vector2 InstructionOffset = new Vector2(0, 125.0f);

    private Instruction[] activeInstructions;
    private Canvas canvas;

    void Awake()
    {
        if (allInstructions.Length == 0)
        {
            Debug.LogError("At least one instruction must be added to the list of All Instructions!");
        }
        activeInstructions = new Instruction[numInstructionsOnScreen];
        canvas = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        CreateInstructionBar();
        UpdateInstructionSet();
    }

    /// <summary>
    /// Iterates through the instructions and updates the active instruction while adding a new random one at the tail
    /// </summary>
    public void NextInstruction()
    {
        Destroy(activeInstructions[0].gameObject);
        for (int i = 0; i < activeInstructions.Length - 1; i++)
        {
            activeInstructions[i] = activeInstructions[i + 1];
            activeInstructions[i].transform.position = (Vector2)activeInstructions[i].transform.position - InstructionOffset;
        }
        activeInstructions[activeInstructions.Length - 1] = GetRandomInstruction();
        activeInstructions[activeInstructions.Length - 1].transform.SetParent(canvas.transform);
        activeInstructions[activeInstructions.Length - 1].transform.position = activeInstructionPosition + InstructionOffset * (activeInstructions.Length - 1);
    }

    private Instruction GetRandomInstruction()
    {
        return Instantiate(allInstructions[Random.Range(0, allInstructions.Length)]);
    }

    private void CreateInstructionBar()
    {
        for (int i = 0; i < activeInstructions.Length; i++)
        {
            activeInstructions[i] = GetRandomInstruction();
            activeInstructions[i].transform.position = activeInstructionPosition + InstructionOffset * i;
            activeInstructions[i].transform.SetParent(canvas.transform);
        }
    }

    private void UpdateInstructionSet()
    {
        //var images = canvas.GetComponentsInChildren<Image>();
        //foreach (var image in images)
        //{
        //    if (image.name.StartsWith(InstructionName))
        //    {
        //        image.sprite = GetRandomInstruction().sprite;
        //    }
        //}
    }
}
