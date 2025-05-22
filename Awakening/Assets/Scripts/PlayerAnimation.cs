using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Vector2 movement;

    void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            Destroy(gameObject); // Destroi instâncias duplicadas
            return;
        }

        DontDestroyOnLoad(gameObject); // Mantém apenas uma instância
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        Vector2 pos = PlayerManager.instance != null ? PlayerManager.instance.playerSpawnPosition : Vector2.zero;

        if (PlayerManager.instance != null && pos != Vector2.zero)
        {
            transform.position = pos;
        }
        else
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
            if (spawnPoint != null)
                transform.position = spawnPoint.transform.position;
        }

        if (PlayerManager.instance != null)
            PlayerManager.instance.playerSpawnPosition = Vector2.zero;
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (movement != Vector2.zero)
        {
            animator.SetBool("isWalking", true);

            if (movement.x > 0)
                animator.Play("moveRight");
            else if (movement.x < 0)
                animator.Play("moveLeft");
            else if (movement.y > 0)
                animator.Play("moveUp");
            else if (movement.y < 0)
                animator.Play("moveDown");
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.Play("Idle");
        }
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)(movement * moveSpeed * Time.fixedDeltaTime);
    }
}
