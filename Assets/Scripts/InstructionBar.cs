using UnityEngine;
using UnityEngine.UI;

public class InstructionBar : MonoBehaviour
{
    [Tooltip("Position of active instruction in the UI")]
    public Vector2 activeInstructionPosition;

    private readonly Vector2 InstructionOffset = new Vector2(0, 300.0f);

    private Image[] instructionImages;
    private Canvas canvas;

    void Awake()
    {
        instructionImages = new Image[InstructionManager.Instance.numInstructionsInQueue];
        canvas = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        CreateInstructions();
    }

    /// <summary>
    /// Updates the set of instructions displayed on the Instruction Bar
    /// </summary>
    public void UpdateInstructions()
    {
        if (instructionImages[0] == null)
        {
            return;
        }
        var activeInstructions = InstructionManager.Instance.GetActiveInstructions();
        Destroy(instructionImages[0].gameObject);
        for (int i = 0; i < activeInstructions.Length - 1; i++)
        {
            instructionImages[i] = instructionImages[i + 1];
            instructionImages[i].transform.position = (Vector2)instructionImages[i].transform.position - InstructionOffset;
        }
        var newInstructionImage = new GameObject(activeInstructions[activeInstructions.Length - 1].name).AddComponent<Image>();
        newInstructionImage.sprite = activeInstructions[activeInstructions.Length - 1].sprite;
        newInstructionImage.transform.position = activeInstructionPosition + InstructionOffset * (activeInstructions.Length - 1);
        newInstructionImage.transform.SetParent(canvas.transform);
        instructionImages[activeInstructions.Length - 1] = newInstructionImage;
    }

    private void CreateInstructions()
    {
        var activeInstructions = InstructionManager.Instance.GetActiveInstructions();
        for (int i = 0; i < activeInstructions.Length; i++)
        {
            var instructionImage = new GameObject(activeInstructions[i].name).AddComponent<Image>();
            instructionImage.transform.localScale *= 2;
            instructionImage.sprite = activeInstructions[i].sprite;
            instructionImage.transform.position = activeInstructionPosition + InstructionOffset * i;
            instructionImage.transform.SetParent(canvas.transform);
            instructionImages[i] = instructionImage;
        }
    }
}