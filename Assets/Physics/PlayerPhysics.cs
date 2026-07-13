using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float force = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}