using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Clone_Handler_Script : MonoBehaviour
{
    [SerializeField]
    int MaxCloneCount = 2;
    [SerializeField]
    private GameObject DefaultClonePrefab;
    [SerializeField]
    PlayerScript playerScript;
    bool PlayCloneMovement = false;

    void Start()
    {
        //Add in the objects that should move as well
    }

    void FixedUpdate()
    {
        if (PlayCloneMovement)
        {
            ProcessCloneMovement();
        }
    }

    List<TotalTransform> ListOfCloneTransforms = new List<TotalTransform>(); //Setup the list
    List<GameObject> ListOfCloneObjects = new List<GameObject>(); //Setup the list

    public void AddNewClone(TotalTransform totalTransform)
    {
        if (ListOfCloneObjects.Count < MaxCloneCount) //Check if the max number of clones is currently reached.
        {
            //Spawn a new clone and add it to the List
            ListOfCloneObjects.Add(Instantiate(DefaultClonePrefab, totalTransform.GetCurrentPositionToPlay(), totalTransform.GetCurrentRotationToPlay()));
            //Add the TotalTransform object to the list
            ListOfCloneTransforms.Add(totalTransform);
        } 
        else
        {
            //Potentially implement the overwriting of clones in here
            //Would involve deleting the first position, moving 2->1 3->2 etc. and then adding to the end
        }
        PlayCloneMovement = true;
    }

    public void ProcessCloneMovement()
    {
        for (int x = 0; x < ListOfCloneObjects.Count; x++) // Loop through the Clone Objects
        {
            if (ListOfCloneTransforms[x].CanPlay) // Check if we've reached the end of the playback list
            {
                ListOfCloneObjects[x].transform.position = ListOfCloneTransforms[x].GetCurrentPositionToPlay(); //Update Position
                ListOfCloneObjects[x].transform.rotation = ListOfCloneTransforms[x].GetCurrentRotationToPlay(); //Update Rotation
                ListOfCloneTransforms[x].IncrementFrameCount(); // Increment the playback Framecount
            } 
        }
    }
}
