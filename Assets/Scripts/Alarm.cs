using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private IntruderDetector _intruderDetector;

    private Coroutine _currentFade;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _fadeSpeed = 0.2f;

    private void Awake()
    {
        _sound.volume = 0f;
    }

    private void OnEnable()
    {
        _intruderDetector.OnDetected += Play;
        _intruderDetector.OnLost += Stop;
    }

    private void OnDisable()
    {
        _intruderDetector.OnDetected -= Play;
        _intruderDetector.OnLost -= Stop;
    }

    private void Play()
    {
        if (_currentFade != null)
        {
            StopCoroutine(_currentFade);
        }

        if (_sound.isPlaying == false)
        {
            _sound.Play();
        }

        _currentFade = StartCoroutine(Fade(_maxVolume));
    }

    private void Stop()
    {
        if (_currentFade != null)
        {
            StopCoroutine(_currentFade);
        }

        _currentFade = StartCoroutine(Fade(_minVolume));
    }

    private IEnumerator Fade(float targetVolume)
    {
        while (Mathf.Approximately(_sound.volume, targetVolume) == false)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, targetVolume, _fadeSpeed * Time.deltaTime);
            yield return null;
        }

        if (Mathf.Approximately(targetVolume, _minVolume))
        {
            _sound.Stop();
        }
    }

}
