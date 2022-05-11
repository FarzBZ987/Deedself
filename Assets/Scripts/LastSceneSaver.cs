using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneSaver : MonoBehaviour
{
    private void Awake()
    {
        GameData.instance.lastSceneUpdate();
    }
}
