using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using GoogleVR.GVRDemo;

public class GazeInputModule : GvrBasePointer
{
    public override float MaxPointerDistance
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public override void GetPointerRadius(out float enterRadius, out float exitRadius)
    {
        throw new System.NotImplementedException();
    }

    public override void OnPointerClickDown()
    {
        throw new System.NotImplementedException();
    }

    public override void OnPointerClickUp()
    {
        throw new System.NotImplementedException();
    }

    public override void OnPointerEnter(RaycastResult raycastResult, bool isInteractive)
    {
        throw new System.NotImplementedException();
    }

    public override void OnPointerExit(GameObject previousObject)
    {
        throw new System.NotImplementedException();
    }

    public override void OnPointerHover(RaycastResult raycastResultResult, bool isInteractive)
    {
        throw new System.NotImplementedException();
    }
}
