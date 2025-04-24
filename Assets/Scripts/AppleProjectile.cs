using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    private float destroyTimer = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        destroyTimer += Time.deltaTime;
        if (destroyTimer > 1.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}