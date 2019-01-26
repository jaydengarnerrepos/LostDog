using UnityEngine;

public class CarSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip engine, doorSlam;

    public void SlamDoor()
    {
        audioSource.PlayOneShot(doorSlam);
    }
}