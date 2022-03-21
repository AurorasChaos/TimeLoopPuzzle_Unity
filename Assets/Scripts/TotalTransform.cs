using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalTransform
{
    List<Vector3> localPositions = new List<Vector3>();
    List<Quaternion> localRotations = new List<Quaternion>();
    public int CurrentFrameBeingPlayed = 0;
    public bool CanPlay = true;

    public void AddNewPosition(Vector3 Transformation)
    {
        //Add new tposition to the list of Positions
        localPositions.Add(Transformation);
    }
    public void AddNewRotation(Quaternion Rotation)
    {
        //Add new rotation to the list of Rotations
        localRotations.Add(Rotation);
    }
    public void IncrementFrameCount()
    {
        //Increment the current Playback Frame Count
        CurrentFrameBeingPlayed++;
        if (CurrentFrameBeingPlayed > GetLengthOfList()) { CanPlay = false; }
    }
    public Vector3 GetCurrentPositionToPlay()
    {
        //Get the position to playback
        return localPositions[CurrentFrameBeingPlayed];
    }
    public Quaternion GetCurrentRotationToPlay()
    {
        //Get the rotation to playback
        return localRotations[CurrentFrameBeingPlayed];
    }

    public int GetLengthOfList()
    {
        //Get the length of the lists enclosed
        return localPositions.Count;
    }
    public void ResetPlayState()
    {
        CurrentFrameBeingPlayed = 0;
        CanPlay = true;
    }
}
