using UnityEngine;
using UnityEngine.Rendering;

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
}
