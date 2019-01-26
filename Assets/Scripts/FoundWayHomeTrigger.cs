using UnityEngine;

class FoundWayHomeTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent returnedGameEvent;
    [SerializeField] private Collider targetCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other != targetCollider) return;
        returnedGameEvent.Raise();
        Debug.Log("RETURNED HOME.");
    }
}