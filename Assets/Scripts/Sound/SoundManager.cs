using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _classicMode;
    [SerializeField] private AudioClip _hardMode;
    [SerializeField] private AudioClip _rowFull;
    [SerializeField] private AudioClip _roundOver;

    private bool _isHardMode = false;

    private void OnEnable()
    {
        GameManager.OnGameOver += StopMainTheme;
        Row.OnRowFull += RowFull;
        _isHardMode = GameInfo.IsHardMode;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= StopMainTheme;
        Row.OnRowFull -= RowFull;
    }

    private void RowFull(int obj)
    {
        _audioSource.PlayOneShot(_rowFull, 0.8f);
    }

    private void Start()
    {
        StartCoroutine(PlayTrack());
    }

    IEnumerator PlayTrack()
    {
        if (_isHardMode)
            _audioSource.clip = _hardMode;
        else _audioSource.clip = _classicMode;

        yield return new WaitForSeconds(0.3f);
        _audioSource.Play();


    }

    private void StopMainTheme()
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_roundOver, 0.8f);
    }
}
