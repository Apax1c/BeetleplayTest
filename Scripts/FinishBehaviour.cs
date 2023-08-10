using UnityEngine;

public class FinishBehaviour : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        Interacted();
    }

    public void Interacted()
    {
        UIBehaviour.Instance.LevelWin();
    }
}
