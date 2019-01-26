using System.Collections;
using UnityEngine;

class CameraFollow : MonoBehaviour
{
    public Camera gameCamera;
    public GameEvent leavingHomeState, returningHomeState;
    public Transform car, dog;
    private Transform currentTarget;
    public Vector2 cameraOffset;
    public float zoomSpeed = 5f;

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
        gameCamera.transform.position = new Vector3(currentTarget.position.x + cameraOffset.x,
            currentTarget.position.y + cameraOffset.y,
            gameCamera.transform.position.z);
    }

    private void OnLeavingHome()
    {
        currentTarget = car;
    }

    private void OnReturningHome()
    {
        currentTarget = dog;
        StartCoroutine(ZoomingInOnDog());
    }

    private IEnumerator ZoomingInOnDog()
    {
        while (gameCamera.fieldOfView > 60)
        {
            gameCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            yield return null;
        }
    }
}