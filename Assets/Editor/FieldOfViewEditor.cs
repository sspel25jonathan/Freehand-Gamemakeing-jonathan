using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
   public void OnScreenGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.cyan;
        Handles.DrawWireArc(fov.transform.position, Vector3.up,Vector3.forward, 360, fov.radius);
    }
}
