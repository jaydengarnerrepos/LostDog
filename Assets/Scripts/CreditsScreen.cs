using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

class CreditsScreen : MonoBehaviour
{
    public SpriteRenderer renderer;

    private IEnumerator Start()
    {
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);
        renderer.DOFade(1f, 1f);
        yield return new WaitForSeconds(4f);
        renderer.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Title");
    }
}