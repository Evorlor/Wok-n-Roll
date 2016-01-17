using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class InstructionAnimator : MonoBehaviour
{
    public AudioSource soundeffect;
    public GameObject target;
    public GameObject target2;
    private Animator animator;
    private Core core;

    private const string animationIntegerName = "Action";

    void Awake()
    {
        animator = GetComponent<Animator>();
        core = FindObjectOfType<Core>();
    }

    void Start()
    {
        //animator.SetInteger(animationIntegerName, GetInstructionNumber());
    }

    

    /// <summary>
    /// Updates the instruction's animation in the center of the screen
    /// </summary>w
    public void UpdateAnimation(Action action)
    {

        //animator.SetTrigger("" + (int)action);
        soundeffect.pitch = Random.Range(0.75f, 1.0f);
        //if (!soundeffect.isPlaying)
        {
            soundeffect.Play();
        }
        int x = Random.Range(0, 2);
        switch (x)
        {
            case 0:

                Debug.Log(x);
                target.SetActive(true);
                target2.SetActive(false);
                core.AddPoints(25);
                break;

            case 1:
                target.SetActive(false);
                target2.SetActive(true);
                core.AddPoints(50);
                Debug.Log(x);
                break;
            //case 3:
            //    target.SetActive(false);
            //    target2.SetActive(true);
            //    Debug.Log(x);
            //    break;
            //case 4:
            //    target.SetActive(false);
            //    target2.SetActive(true);
            //    Debug.Log(x);
            //    break;
            default: //print();
                target.SetActive(false);
                target2.SetActive(true);
                Debug.Log(x);

                break;
        }



        animator.SetTrigger("" + (int)action);

        //animator.SetInteger(animationIntegerName, GetInstructionNumber());
    }

    private int GetInstructionNumber()
    {
        var currentInstruction = InstructionManager.Instance.GetCurrentInstruction();
        if (currentInstruction)
        {
            return (int)currentInstruction.action;
        }
        return -1;
    }
}
