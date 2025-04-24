using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100;
    [SerializeField] public Image healthbar;
    public float playerSpawnX = 6.42f;
    public float playerSpawnY = 1.1256f;
    void Start()
    {
    }
    void Update()
    {
        healthbar.fillAmount = playerHealth / 100f;
    }
    public void TakeDamage(float damageAmount)
    {
        playerHealth -= (int)damageAmount;
    }
    public void playerRespawn()
    {
        gameObject.transform.position = new Vector3(playerSpawnX, playerSpawnY, 0);
    }
}
