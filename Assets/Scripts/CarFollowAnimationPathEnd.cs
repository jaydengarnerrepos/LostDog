using System.Threading;
using UnityEngine;

class CarFollowAnimationPathEnd : MonoBehaviour
{
    [SerializeField] private GameEvent returningGameEvent;

    public void EndCarFollow()
    {
        returningGameEvent.Raise();
        Debug.Log("RETURNING HOME.");
    }
}