#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneChanger))]
public class SceneChangerEditor : Editor
{
    private SceneChanger sceneChanger;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        sceneChanger = (SceneChanger)target;
        sceneChanger.isNewGame = EditorGUILayout.Toggle("New game?", sceneChanger.isNewGame);
        if (!sceneChanger.isNewGame)
        {
            sceneChanger.isContinue = EditorGUILayout.Toggle("Continue?", sceneChanger.isContinue);
            if (!sceneChanger.isContinue)
            {
                sceneChanger.part = EditorGUILayout.IntField("Level Part", sceneChanger.part);
                sceneChanger.level = EditorGUILayout.IntField("Level Number", sceneChanger.level);
            }
            
        }
    }
    
}
#endif