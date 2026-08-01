using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerVisual : MonoBehaviour
{
    private void Awake()
    {
        SpriteRenderer renderer =
            GetComponent<SpriteRenderer>();

        TeamData team =
            SaveManager.Instance.GetSelectedTeam();

        if (team != null)
        {
            renderer.sprite = team.previewSprite;
        }
    }
}