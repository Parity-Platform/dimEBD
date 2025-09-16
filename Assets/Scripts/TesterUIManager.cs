using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketUIManager : MonoBehaviour
{
    public GameObject uiForCableA;
    public GameObject uiForCableB;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        socket.selectEntered.AddListener(OnCableInserted);
        socket.selectExited.AddListener(OnCableRemoved);
    }

    private void OnCableInserted(SelectEnterEventArgs args)
    {
        GameObject insertedObject = args.interactableObject.transform.gameObject;

        // ������ �� ����� � tag
        if (insertedObject.CompareTag("CableA"))
        {
            uiForCableA.SetActive(true);
        }
        else if (insertedObject.CompareTag("CableB"))
        {
            uiForCableB.SetActive(true);
        }
    }

    private void OnCableRemoved(SelectExitEventArgs args)
    {
        // ���� ���� �� ������� ������ ��� �� UI
        uiForCableA.SetActive(false);
        uiForCableB.SetActive(false);
    }
}

