using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float _playerMoveSpeed;

    [Header("Bullet Settings")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _maxBulletsPerLevel;
    [SerializeField] private List<GameObject> _bulletsList = new List<GameObject>();
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private float _bulletSpeed;

    private Vector2 _moveDirection;
    private Transform _playerPos;

    private float timer = 0, currentTimer = 2;

    private void Start()
    {
        _playerPos = transform.GetComponent<Transform>();

        for (int i = 0; i < _maxBulletsPerLevel; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            _bulletsList.Add(bullet);
            _bulletsList[i].SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        DoMove();
    }
    private void Update()
    {
        StartShootCoroutine();
    }

    private IEnumerator AutoShoot()
    {
        for (int i = 0; i < _bulletsList.Count; i++)
        {
            if (!_bulletsList[i].activeInHierarchy)
            {
                _bulletsList[i].SetActive(true);

                _bulletsList[i].transform.position = transform.position;
                _bulletsList[i].transform.rotation = transform.rotation;


                Rigidbody2D tempRb2D = _bulletsList[i].GetComponent<Rigidbody2D>();
                tempRb2D.AddForce(tempRb2D.transform.up * _bulletSpeed, ForceMode2D.Force);

                yield return null;
                break;
            }
        }
    }
    private void StartShootCoroutine()
    {
        currentTimer -= Time.deltaTime;

        if (currentTimer < timer)
        {
            StartCoroutine(AutoShoot());
            currentTimer = _timeBetweenShoot;
        }
    }

    private void DoMove()
    {
        _playerPos.Translate(new Vector3(_moveDirection.x, _moveDirection.y, 0) * Time.deltaTime * _playerMoveSpeed);
    }
    //---Inputs---//
    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveDirection = ctx.ReadValue<Vector2>();
    }
    //-----------//
}
