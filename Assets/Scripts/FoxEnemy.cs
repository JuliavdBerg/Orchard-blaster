using UnityEngine;

public class FoxEnemy : MonoBehaviour
{
    [SerializeField] private float foxSpeed = 5f;
    private bool movingRight = true;

    void Update()
    {
        float moveDirection = movingRight ? 1 : -1;
        transform.Translate(Vector3.right * moveDirection * foxSpeed * Time.deltaTime);

        if (transform.position.x >= 7.4f && movingRight)
        {
            movingRight = false;
            FlipSprite();
        }
        else if (transform.position.x <= -7.41f && !movingRight)
        {
            movingRight = true;
            FlipSprite();
        }
    }
    void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("apple bullet"))
        {
            Debug.Log("fox hit");
            Destroy(gameObject);
        }
    }
}
