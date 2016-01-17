using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class InstructionAnimator : MonoBehaviour
{
    [Range(0, 1)]
    public float chanceToBeAwesome = 0.5f;
    public AudioSource soundeffect;
    public GameObject target;
    public GameObject target2;
    private Animator animator;
    private Core core;

    private const string animationIntegerName = "Action";

    private AudioSource superPlayer;
    public AudioClip[] superSounds;

    void Awake()
    {
        animator = GetComponent<Animator>();
        core = FindObjectOfType<Core>();
        superPlayer = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        //animator.SetInteger(animationIntegerName, GetInstructionNumber());
        target.SetActive(false);
        target2.SetActive(false);
    }



    /// <summary>
    /// Updates the instruction's animation in the center of the screen
    /// </summary>w
    public void UpdateAnimation(Action action)
    {

        //animator.SetTrigger("" + (int)action);
        soundeffect.pitch = Random.Range(0.75f, 1.0f);
        //if (!soundeffect.isPlaying)
        //{
        soundeffect.Play();
        //}
        int x = Random.Range(0, 2);
        if (Random.Range(0.0f, 1.0f) <= chanceToBeAwesome && !superPlayer.isPlaying)
        {
            superPlayer.clip = superSounds[Random.Range(0, superSounds.Length)];

            superPlayer.Play();
        }
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
                break;
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
