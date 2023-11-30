using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float _enemySpeed;
    private Vector2 _moveDirection, _moveLeft, _moveRight;

    [Header("Bullet Settings")]
    [SerializeField] private GameObject _eBulletPrefab;
    [SerializeField] private int _eMaxBulletsPerLevel;
    [SerializeField] private List<GameObject> _eBulletsList = new List<GameObject>();
    [SerializeField] private float _eTimeBetweenShoot;
    [SerializeField] private float _eBulletSpeed;
    [SerializeField] private float _positiveAngle, _negativeAngle;

    private float timer = 0, currentTimer = 2;

    private float _spiralAngle = 90f;
    private float _currentDirectionBulletAngle = 5;

    [SerializeField]
    private bool _isSpiral = true, _isExplosion = false;

    private void Start()
    {
        //Set bullet
        for (int i = 0; i < _eMaxBulletsPerLevel; i++)
        {
            GameObject bullet = Instantiate(_eBulletPrefab);
            _eBulletsList.Add(bullet);
            _eBulletsList[i].SetActive(false);
        }

        _moveLeft = Vector2.left; _moveRight = Vector2.right;
        _moveDirection = _moveLeft;
    }
    private void Update()
    {
        StartShootCoroutine();
    }
    private void FixedUpdate()
    {
        DoEnemyMove();
    }

    private void DoEnemyMove()
    {
        transform.Translate(_moveDirection * _enemySpeed * Time.deltaTime);

        if (transform.position.x <= -15)
        {
            _moveDirection = _moveRight;
        }
        else if (transform.position.x >= 15)
        {
            _moveDirection = _moveLeft;
        }
    }

    private IEnumerator AutoShoot()
    {
        for (int i = 0; i < _eBulletsList.Count; i++)
        {
            if (!_eBulletsList[i].activeInHierarchy)
            {
                //Set the transform of the bullet on the center ship
                _eBulletsList[i].transform.position = transform.position;
                _eBulletsList[i].transform.rotation = transform.rotation;

                //Get the rigidBody
                Rigidbody2D tempRb2D = _eBulletsList[i].GetComponent<Rigidbody2D>();
                //Active the bullet
                _eBulletsList[i].SetActive(true);

                //Shoot Paterne state machine
                if (_isSpiral)
                {
                    //Move the bullet
                    float bulDirX = transform.position.x + Mathf.Sin((_spiralAngle * Mathf.PI) / 180f);
                    float bulDirY = transform.position.y + Mathf.Cos((_spiralAngle * Mathf.PI) / 180f);

                    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
                    Vector2 bulDirection = (bulMoveVector - transform.position).normalized;

                    tempRb2D.AddForce(bulDirection * _eBulletSpeed, ForceMode2D.Force);

                    //Shoot angle
                    if (_spiralAngle >= 270)
                    {
                        _currentDirectionBulletAngle = _negativeAngle;
                    }
                    else if (_spiralAngle <= 90)
                    {
                        _currentDirectionBulletAngle = _positiveAngle;
                    }

                    _spiralAngle += _currentDirectionBulletAngle;

                }
                else if (_isExplosion)
                {
                    print("do 2nd patern");
                }

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
            currentTimer = _eTimeBetweenShoot;
        }
    }
}
