using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float Range { get { return _range; } }
    [SerializeField] private float _range = 10f;
    private float _timer = 0f;
    public event GenericHandler InteractEvent;
    public event GenericHandler OnHoverEvent;
    public event GenericHandler EndHoverEvent;
    private bool _current = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_current && _timer <= 0)
        {
            EndHoverEvent?.Invoke();
        }
        else if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
    }

    public void Hover()
    {
        _timer = .1f;
        if (_current) return;
        OnHoverEvent?.Invoke();
    }

    public void Interact()
    {
        InteractEvent?.Invoke();
        Debug.Log(name);
    }

    public delegate void GenericHandler();
}
