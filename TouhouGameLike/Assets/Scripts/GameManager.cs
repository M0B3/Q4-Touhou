using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Time To win")]
    [SerializeField] private float _maxTimeToWin;

    [Header("Assignables")]
    [SerializeField] private TextMeshProUGUI _timerText;

    private bool _isWin = false;
    private bool _antiLag = true;

    private float _currentTimer;

    private void Start()
    {
        _currentTimer = _maxTimeToWin;
    }

    private void Update()
    {
        _currentTimer -= Time.deltaTime;

        int timerToText = (int)_currentTimer;
        _timerText.text = timerToText.ToString();

        if (timerToText == 0)
        {
            GameObject player = GameObject.Find("PlayerShip");
            player.GetComponent<PlayerLifeDamages>()._win = true;
            player.GetComponent<PlayerLifeDamages>()._playerWinMenu.SetActive(true);

            _isWin = true;
        }

        if (_isWin && _antiLag)
        {
            _isWin = false;
            _antiLag = false;
            Time.timeScale = 0.0f;
        }
    }
}
