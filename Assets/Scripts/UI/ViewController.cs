using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    [SerializeField] private FigureSpawner _spawner;
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _userText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Image _currentFigure;
    [SerializeField] private Image _nextFigure;
    [SerializeField] private GameObject[] _uiElements;
    [SerializeField] private Button _quitButton;

    public void ScoreUpdate(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void ChangeCurrentFigureSprite(Figure figure)
    {
        _currentFigure.sprite = figure.Sprite;
        _currentFigure.color= figure.Color;
    }


    private void OnEnable()
    {
        GameManager.OnGameOver += ActivateUiElements;
        Grid.OnCollision += ChangeNextFigureSprite;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= ActivateUiElements;
        Grid.OnCollision -= ChangeNextFigureSprite;
    }

    private void Start()
    {
        foreach (var item in _uiElements)
        {
            item.SetActive(false);
        }

        ChangeNextFigureSprite();
        _userText.text = GameInfo.Username;
    }

    private void FixedUpdate()
    {
        _timerText.text = DataExtension.FormatTime(_timer.Time);
    }

    private void ChangeNextFigureSprite()
    {
        _nextFigure.sprite = _spawner.GetSpriteNextFigure().Sprite;
        _nextFigure.color = _spawner.GetSpriteNextFigure().Color;
    }

    private void ActivateUiElements()
    {
        foreach (var item in _uiElements)
        {
            item.SetActive(true);
        }
        _quitButton.gameObject.SetActive(false);
    }
}
