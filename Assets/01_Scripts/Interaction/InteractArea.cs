using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    public List<GameObject> interactable = new List<GameObject>();

    private void OnTriggerEnter(Collider intercat)
    {
        for (int i = 0; i < interactable.Count; i++)
        {
            
        }
    }

    private void OnTriggerExit(Collider interact)
    {
        Debug.Log($"{interact.name} Exited");
    }
}
