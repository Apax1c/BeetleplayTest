using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        Interacted();
    }

    public void Interacted()
    {
        UIBehaviour.Instance.LevelLose();
    }
}