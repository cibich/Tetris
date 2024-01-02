using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Image _loadImage;
    [SerializeField] private Text _loadText;

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        _loadImage.gameObject.SetActive(true);
        float timer = 0;

        while (timer < 0.99f)
        {
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
            _loadImage.fillAmount = timer;
            _loadText.text = string.Format("{0:0}%", timer*100f);
        }
        SceneManager.LoadScene(1);
    }
}
