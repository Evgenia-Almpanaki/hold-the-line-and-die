using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask whatStopsMovement;
    [SerializeField] private Transform movePoint;
    [SerializeField] private float moveStep = 1f;
    [SerializeField] private float speed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        movePoint.parent = null;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, moveStep * Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, moveStep * Input.GetAxisRaw("Vertical"), 0f);
                    gameManager.PlayClip(GameManager.ClipType.LINE_CHANGE);
                    gameManager.ChangeHealth(-10);

                }
            }
        }
    }
}

