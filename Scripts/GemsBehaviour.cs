using UnityEngine;

public class GemsBehaviour : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter(Collider other)
    {
        Interacted();
        Destroy(this.gameObject);
    }

    public void Interacted()
    {
        UIBehaviour.Instance.AddScore();
    }
}
