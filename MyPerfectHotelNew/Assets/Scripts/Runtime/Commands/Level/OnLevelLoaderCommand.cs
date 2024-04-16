using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelLoaderCommand
{
     private Transform _levelHolder;

    internal OnLevelLoaderCommand(Transform levelHolder)
    {
        _levelHolder = levelHolder;
    }

    internal void Execute(byte levelIndex)
    {
        Object.Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level {levelIndex}"), _levelHolder,
                true);
    }
}
