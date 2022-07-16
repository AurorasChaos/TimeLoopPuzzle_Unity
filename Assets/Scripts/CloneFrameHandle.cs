using System;
using System.Collections.Generic;
using System.Text;

public class CloneFrameHandle
{
    List<Vector3> localPositions = new List<Vector3>();
    List<Quaternion> localRotations = new List<Quaternion>();
    List<FrameAction> FrameActions = new List<FrameAction>();
    public int CurrentFrameBeingPlayed = 0;
    public bool CanPlay = true;

    public void AddNewTransformation(Transform transform, int ActionNumber)
    {
        localPositions.Add(transform.localPosition);
        localRotations.Add(transform.localRotation);



    }

}

