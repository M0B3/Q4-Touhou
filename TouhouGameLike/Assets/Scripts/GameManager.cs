using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Time To win")]
    [SerializeField] private float _maxTimeToWin;

    [Header("Assignables")]
    [SerializeField] private TextMeshProUGUI _timerText;

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
            Time.timeScale = 0.0f;
        }
    }
}
