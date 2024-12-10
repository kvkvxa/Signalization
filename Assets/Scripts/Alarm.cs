using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private float _fadeSpeed = 0.2f;

    private void Awake()
    {
        _sound.volume = 0f;
    }

    private void OnTriggerEnter(Collider intruder)
    {
        StopAllCoroutines();

        StartCoroutine(FadeIn());
    }

    private void OnTriggerExit(Collider intruder)
    {
        StopAllCoroutines();

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        _sound.Play();

        while (_sound.volume < 1f)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, 1f, _fadeSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        while (_sound.volume > 0f)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, 0, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        _sound.Stop();
    }
}
