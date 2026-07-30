using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int highestUnlockedLevel = 1;

    public int supporters = 0;

    public List<LevelSaveData> levels = new();
}