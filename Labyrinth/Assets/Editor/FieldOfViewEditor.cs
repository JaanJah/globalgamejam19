using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor
{
    //void OnScreenGUI()
    //{
    //    FieldOfView fov = (FieldOfView)target;
    //    Handles.color = Color.white;
    //    Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
    //    Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
    //    Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

    //    Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
    //    Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

    //}
    void OnSceneGUI() {
        FieldOfView fow = (FieldOfView)target; Handles.color = Color.white;
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);
        Handles.DrawWireArc(fow.transform.position, Vector3.up, viewAngleA, fow.viewAngle, fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);
    }
}
