using UnityEngine;

class DogReturningHomeState : MonoBehaviour
{
    public GameEvent returningHome;
    public Transform spawnPoint;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        returningHome.Raised += OnReturningHome;
    }

    private void OnDisable()
    {
        returningHome.Raised -= OnReturningHome;
    }

    private void OnReturningHome()
    {
        gameObject.SetActive(true);
        gameObject.transform.SetPositionAndRotation(
            new Vector3(spawnPoint.position.x, spawnPoint.position.y, gameObject.transform.position.z),
            spawnPoint.rotation);
    }
}