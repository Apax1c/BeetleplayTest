using UnityEngine;

public class GemsBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject slicedGemPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Interacted();
        Instantiate(slicedGemPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void Interacted()
    {
        UIBehaviour.Instance.AddScore();
    }
}
