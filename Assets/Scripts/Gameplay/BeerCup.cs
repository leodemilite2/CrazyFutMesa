using UnityEngine;

public class BeerCup : MonoBehaviour
{
    [SerializeField]
    private Sprite emptyCupSprite;

    [SerializeField]
    private GameObject beerAreaPrefab;

    [SerializeField]
    private float minImpact = 3f;

    private CircleCollider2D fullCollider;

    private bool spilled;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        fullCollider = GetComponent<CircleCollider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spilled)
            return;

        if (collision.relativeVelocity.magnitude < minImpact)
            return;

        SpillBeer();
    }

    private void SpillBeer()
    {
        spilled = true;

        spriteRenderer.sprite = emptyCupSprite;

        // O copo deixa de bloquear a passagem
        fullCollider.enabled = false;

        Instantiate(
            beerAreaPrefab,
            transform.position,
            Quaternion.identity
        );
    }
}