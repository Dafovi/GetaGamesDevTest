using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(GameManager)), CanEditMultipleObjects]
public class GameManagerEditor : Editor{
   public override void OnInspectorGUI(){
       base.OnInspectorGUI();
       GUILayout.Label ("\nDelete all PlayerPrefs config");
       if(GUILayout.Button("Reset statistics")){
           PlayerPrefs.DeleteAll();
           GameManager.instance.GetVariables();
       }
   }
}
