using UnityEngine;


public class SwitchClickable : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string onState = "TurnOn";
    [SerializeField] string offState = "TurnOff";
    bool isOn;

    void Awake()
    {
        if (!animator) animator = GetComponent<Animator>();
        var simple = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        simple.selectEntered.AddListener(_ => Toggle());
    }

    void Toggle()
    {
        isOn = !isOn;
        animator.Play(isOn ? onState : offState, 0, 0f);
    }
}




