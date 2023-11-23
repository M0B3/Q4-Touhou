using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeDamages : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float _playerMaxLifePerLevel;
    [Space(10)]
    [Header("Assignables")]
    [SerializeField] private Slider _playerLifeSlider;

    private float _playerCurrentLife = 100f;

    private void Start()
    {
        //Set the max life of the player
        _playerCurrentLife = _playerMaxLifePerLevel;

        //Set the ui according to the player life
        _playerLifeSlider.maxValue = _playerMaxLifePerLevel;
    }

    private void Update()
    {
        //Set the ui according to the player life
        _playerLifeSlider.value = _playerCurrentLife;

    }

    public void TakeDamage(float damage)
    {
        _playerCurrentLife -= damage;

        if (_playerCurrentLife <= 0)
        {
            print("Game Over");
        }
    }
}
