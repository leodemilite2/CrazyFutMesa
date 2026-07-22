using UnityEngine;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Crazy FutMesa/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Informações da Fase")]
    public int levelNumber;
    public string levelName;

    [Header("Estrelas")]
    public int threeStarShots = 3;
    public int twoStarShots = 5;
    public int oneStarShots = 8;

[Header("Progressão")]
public string nextLevel;
}