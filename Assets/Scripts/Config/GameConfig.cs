using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "CrazyFutMesa/Game Config")]
public class GameConfig : ScriptableObject
{
    [Header("Player")]

    public float launchForce = 6f;

    public float playerMass = 1f;

    public float playerLinearDamping = 0.6f;

    [Header("Ball")]

    public float ballMass = 0.3f;

    public float ballLinearDamping = 0.4f;

    [Header("Gameplay")]

    public float maxDragDistance = 3f;
}