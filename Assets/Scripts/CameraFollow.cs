using UnityEngine;

class CameraFollow : MonoBehaviour
{
    public Camera gameCamera;
    public GameEvent leavingHomeState, returningHomeState;
    public Transform car, dog;
    private Transform currentTarget;

    private void Awake()
    {
        currentTarget = car;
    }

    private void OnEnable()
    {
        leavingHomeState.Raised += OnLeavingHome;
        returningHomeState.Raised += OnReturningHome;
    }

    private void OnDisable()
    {
        leavingHomeState.Raised -= OnLeavingHome;
        returningHomeState.Raised -= OnReturningHome;
    }

    private void LateUpdate()
    {
        if (currentTarget == null) return;
        gameCamera.transform.position = new Vector3(currentTarget.position.x, currentTarget.position.y,
            gameCamera.transform.position.z);
    }

    private void OnLeavingHome()
    {
        currentTarget = car;
    }

    private void OnReturningHome()
    {
        currentTarget = dog;
    }
}