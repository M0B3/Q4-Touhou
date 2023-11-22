using UnityEngine;
using UnityEngine.Rendering;

public class BulletScript : MonoBehaviour
{
    private void OnEnable()
    {
        transform.GetComponent<Rigidbody2D>().WakeUp();
        Invoke("HideBullet", 2f);
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
