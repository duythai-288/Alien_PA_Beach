
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PathTool))]
public class PathToolEditor : Editor
{
    PathTool editor;

    // GlobalDisplaySettings globalDisplaySettings;
    // private Dictionary<GlobalDisplaySettings.HandleType, Handles.CapFunction> capFunctions;
    
    List<Vector3> points => editor.points;

    int draggingHandleIndex;
    int handleIndexToDisplayAsTransform;
    //int mouseOverHandleIndex;

    // private PathHandle.HandleColours splineAnchorColours;
    float handleSize => editor.anchorHandleSize;
    
    public void OnEnable()
    {
        editor = target as PathTool;
        LoadDisplaySettings();
        UpdateGlobalDisplaySettings();

    }

    public void OnSceneGUI()
    {
        if (!editor.editView) return;
        EventType eventType = Event.current.type;

        using (var check = new EditorGUI.ChangeCheckScope())
        {
            //handlesStartCol = Handles.color;

            DrawVertexPathSceneEditor();

            // Don't allow clicking over empty space to deselect the object
            if (eventType == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(0);
            }

            if (check.changed)
            {
                EditorApplication.QueuePlayerLoopUpdate();
            }
        }
    }

    void DrawVertexPathSceneEditor()
    {

        Handles.color = Color.green;
        
        int triangleLength = editor.points.Count;
        Vector3 a, b;
        for (int i = 0; i < triangleLength; i++)
        {
            // a = MathUtility.TransformPoint(points[i], editor.transform, PathSpace.xyz);
            if(i + 1 == triangleLength)
            {
                
                if (editor.isLoop)
                {
                    // b = MathUtility.TransformPoint(points[0], editor.transform, PathSpace.xyz);
                    // Handles.DrawLine(a, b);
                }
            }
            else
            {
                // b = MathUtility.TransformPoint(points[i + 1], editor.transform, PathSpace.xyz);
                // Handles.DrawLine(a, b);
            }
            
            
                
        }
        int vertexLength = points.Count;
        for (int i = 0; i < vertexLength; i++)
        {
            DrawHandle(i);
        }
    }

    void DrawHandle(int index)
    {
        // Vector3 handlePosition = MathUtility.TransformPoint(points[index], editor.transform, PathSpace.xyz);

        bool isInteractive = true;
        bool doTransformHandle = index == handleIndexToDisplayAsTransform;

        // PathHandle.HandleColours handleColours = splineAnchorColours;
        // if (index == handleIndexToDisplayAsTransform)
        // {
        //     handleColours.defaultColour = globalDisplaySettings.anchorSelected;
        // }
        // var cap = capFunctions[GlobalDisplaySettings.HandleType.Sphere];
        // PathHandle.HandleInputType handleInputType;
        // handlePosition = PathHandle.DrawHandle(handlePosition,
        //                                        PathSpace.xyz,
        //                                        isInteractive,
        //                                        handleSize,
        //                                        cap,
        //                                        handleColours,
        //                                        out handleInputType,
        //                                        index);
        //
        // if (doTransformHandle)
        // {
        //     // Show normals rotate tool 
        //
        //     handlePosition = Handles.DoPositionHandle(handlePosition, Quaternion.identity);
        // }

        // switch (handleInputType)
        // {
        //     case PathHandle.HandleInputType.LMBDrag:
        //         draggingHandleIndex = index;
        //         handleIndexToDisplayAsTransform = -1;
        //         Repaint();
        //         break;
        //     case PathHandle.HandleInputType.LMBRelease:
        //         draggingHandleIndex = -1;
        //         handleIndexToDisplayAsTransform = -1;
        //         Repaint();
        //         break;
        //     case PathHandle.HandleInputType.LMBClick:
        //         draggingHandleIndex = -1;
        //         if (Event.current.shift)
        //         {
        //             handleIndexToDisplayAsTransform = -1; // disable move tool if new point added
        //         }
        //         else
        //         {
        //             if (handleIndexToDisplayAsTransform == index)
        //             {
        //                 handleIndexToDisplayAsTransform = -1; // disable move tool if clicking on point under move tool
        //             }
        //             else
        //             {
        //                 handleIndexToDisplayAsTransform = index;
        //             }
        //         }
        //         Repaint();
        //         break;
        //     case PathHandle.HandleInputType.LMBPress:
        //         if (handleIndexToDisplayAsTransform != index)
        //         {
        //             handleIndexToDisplayAsTransform = -1;
        //             Repaint();
        //         }
        //         break;
        // }

        // Vector3 localHandlePosition = MathUtility.InverseTransformPoint(handlePosition, editor.transform, PathSpace.xyz);

        // if (points[index] != localHandlePosition)
        // {
        //     Undo.RecordObject(editor, "Move point");
        //     
        //     editor.UpdatePoint(index, localHandlePosition);
        //     
        // }
    }

    void LoadDisplaySettings()
    {
        // globalDisplaySettings = GlobalDisplaySettings.Load();
        // capFunctions = new Dictionary<GlobalDisplaySettings.HandleType, Handles.CapFunction>();
        // capFunctions.Add(GlobalDisplaySettings.HandleType.Circle, Handles.CylinderHandleCap);
        // capFunctions.Add(GlobalDisplaySettings.HandleType.Sphere, Handles.SphereHandleCap);
        // capFunctions.Add(GlobalDisplaySettings.HandleType.Square, Handles.CubeHandleCap);

    }

    void UpdateGlobalDisplaySettings()
    {
        // var gds = globalDisplaySettings;
        // splineAnchorColours = new PathHandle.HandleColours(gds.anchor, gds.anchorHighlighted, gds.anchorSelected, gds.handleDisabled);

    }
}
