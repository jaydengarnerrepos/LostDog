using UnityEngine;

class DogReturnedHomeTrigger : MonoBehaviour
{
    public GameEvent returnedHomeEvent;
    public Collider targetCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other != targetCollider) return;
        returnedHomeEvent.Raise();
    }
}