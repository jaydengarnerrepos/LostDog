using UnityEngine;

class DogSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bark, growl, pant, hop, pee, wimper;

    public void Bark()
    {
        audioSource.PlayOneShot(bark);
    }

    public void Growl()
    {
        audioSource.PlayOneShot(growl);
    }

    public void Pant()
    {
        audioSource.PlayOneShot(pant);
    }

    public void Hop()
    {
        audioSource.PlayOneShot(hop);
    }

    public void Pee()
    {
        audioSource.PlayOneShot(pee);
    }

    public void Wimper()
    {
        audioSource.PlayOneShot(wimper);
    }
}