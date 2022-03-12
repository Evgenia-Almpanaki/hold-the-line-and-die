using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static float initialSpeed = 5f;
    private const float MAX_INITIAL_SPEED = 15f;
    private const float INITIAL_SPEED_INCREASE_RATE = 1.1f;
    private GameManager gameManager;
    private float speed;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        speed = initialSpeed;
        UpdateInitialSpeed();
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    /// <summary>
    /// Increases the initial speed up to a limit.
    /// </summary>
    public void UpdateInitialSpeed()
    {
        initialSpeed = Mathf.Clamp(initialSpeed * INITIAL_SPEED_INCREASE_RATE, 0, MAX_INITIAL_SPEED);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            gameManager.ChangeHealth(-50);
            gameManager.PlayClip(GameManager.ClipType.ENEMY_COLLISION);
        }
        Destroy(this.gameObject);
    }

}
