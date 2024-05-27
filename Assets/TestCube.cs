using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    public Material a;
    public Material b;
    private bool _materialA = false;
    // Start is called before the first frame update
    void Start()
    {
        Interactable interactable = GetComponent<Interactable>();
        interactable.InteractEvent += changeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeColor()
    {
        GetComponent<Renderer>().material = _materialA ? a : b;
        _materialA = !_materialA;
    }
}
