using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalsRecalculator : MonoBehaviour
{
    void Awake()
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        meshFilter.mesh.RecalculateNormals();
    }
   
}
