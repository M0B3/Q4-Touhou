using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeDamages : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float _playerMaxLifePerLevel;
    [SerializeField] private bool _isPlayer = false;
    [Space(10)]
    [Header("Assignables")]
    [SerializeField] private Slider _playerLifeSlider;
    public GameObject _playerWinMenu;
    [SerializeField] private GameObject _playerLooseMenu;

    private float _playerCurrentLife = 100f;

    [HideInInspector] public bool _loose = false, _win = false;

    private void Start()
    {
        //Set the max life of the player
        _playerCurrentLife = _playerMaxLifePerLevel;

        //Set the ui according to the player life
        _playerLifeSlider.maxValue = _playerMaxLifePerLevel;

        //Close all menu
        if (_isPlayer)
        {
            _playerWinMenu.SetActive(false);
            _playerLooseMenu.SetActive(false);
        }
    }

    private void Update()
    {
        //Set the ui according to the player life
        _playerLifeSlider.value = _playerCurrentLife;

        if (_isPlayer && _win)
        {
            _playerWinMenu.SetActive(true);
        } 
        else if (_isPlayer && _loose)
        {
            _playerLooseMenu?.SetActive(true);
        }

    }

    public void TakeDamage(float damage)
    {
        _playerCurrentLife -= damage;

        if (_playerCurrentLife <= 0 && _isPlayer)
        {
            print("Game Over");
            _loose = true;

            Time.timeScale = 0.0f;
        }
        else if (_playerCurrentLife <= 0 && !_isPlayer)
        {
            print("you Win");

            GameObject player = GameObject.Find("PlayerShip");
            player.GetComponent<PlayerLifeDamages>()._win = true;

            gameObject.SetActive(false);
            Time.timeScale = 0.0f;
        }
    }
}
