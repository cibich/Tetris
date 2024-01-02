using Dan.Main;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Autorizer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _owowSound;
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TextMeshProUGUI _notice;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Toggle _hardModeToggle;
    private int _minLenghtName = 3;
    private int _maxLenghtName = 12;

    private void Awake()
    {
        _startGameButton.gameObject.SetActive(false);
    }

    public void Verification()
    {
        _name.text = Regex.Replace(_name.text, @"[\u0400-\u04FF]+", string.Empty);

        if (_name.text.Length < _minLenghtName)
        {
            _startGameButton.gameObject.SetActive(false);
        }
        else if (_name.text.Length > _maxLenghtName)
        {
            string name = "";
            for (int i = 0; i < _maxLenghtName; i++)
            {
                name += _name.text[i];
            }
            _name.text = name;
        }
        else
        {
            _startGameButton.gameObject.SetActive(true);
            GameInfo.Username = _name.text;
        }
    }

    public void CheckActivatedHardMode()
    {
        GameInfo.IsHardMode = _hardModeToggle.isOn;
        if (_hardModeToggle.isOn)
            _audioSource.PlayOneShot(_owowSound, 0.4f);
    }

    public void IsCheckSimilitaryName()
    {
        LeaderboardCreator.GetPersonalEntry(Constants.DB_KEY, dbProgress =>
        {
            if (dbProgress.Score == 0)
            {
                LeaderboardCreator.UploadNewEntry(Constants.DB_KEY, _name.text, 0, users =>
                {
                    if (users == false)
                        NoticeMessage("Nickname is taken");
                    else
                        _loader.StartGame();
                });
            }
            else
            {
                LeaderboardCreator.UploadNewEntry(Constants.DB_KEY, _name.text, dbProgress.Score, dbProgress.Extra, users =>
            {
                if (users == false)
                    NoticeMessage("Nickname is taken");
                else
                    _loader.StartGame();
            });
            }
        });
    }

    public void ClearField()
    {
        _name.text = string.Empty;
        NoticeMessage(string.Empty);
    }

    private void NoticeMessage(string message)
    {
        _notice.text = message;
    }
}
