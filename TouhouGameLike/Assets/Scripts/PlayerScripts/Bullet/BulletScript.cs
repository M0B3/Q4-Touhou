using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Bullet settings")]
    [SerializeField] private float _timeBeforeDestroy;

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody2D>().WakeUp();
        Invoke("HideBullet", _timeBeforeDestroy);
    }
    private void OnDisable()
    {
        transform.GetComponent<Rigidbody2D>().Sleep();
        CancelInvoke();
    }

    private void HideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            PlayerLifeDamages enemyLife = collision.GetComponent<PlayerLifeDamages>();
            enemyLife.TakeDamage(1);

            gameObject.SetActive(false);
        }

        if (collision.CompareTag("GameController"))
        {
            gameObject.SetActive(false);
        }
    }
}
