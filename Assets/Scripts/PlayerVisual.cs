using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerVisual : MonoBehaviour
{
    // Tamanho visual desejado do Player.
    // A huracan10 com escala 1 serve como nossa referência.
    [SerializeField]
    private float targetSize = 1f;

    private void Awake()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        TeamData team =
            SaveManager.Instance.GetSelectedTeam();

        if (team != null)
        {
            renderer.sprite = team.previewSprite;

            NormalizeSize(renderer);
        }
    }

    private void NormalizeSize(SpriteRenderer renderer)
    {
        if (renderer.sprite == null)
            return;

        // Descobre o tamanho real da sprite no Unity,
        // considerando o Pixels Per Unit.
        float currentSize = Mathf.Max(
            renderer.sprite.bounds.size.x,
            renderer.sprite.bounds.size.y
        );

        if (currentSize <= 0f)
            return;

        // Calcula quanto precisamos aumentar/diminuir
        // essa sprite para atingir o tamanho padrão.
        float scale = targetSize / currentSize;

        transform.localScale = Vector3.one * scale;
    }
}