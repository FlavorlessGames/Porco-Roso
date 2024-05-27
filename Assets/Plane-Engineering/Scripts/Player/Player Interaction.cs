using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] 
    private GameObject _camera;
    private Camera _cam;
    private Vector3 _screenCenter;
    private Interactable _current;
    // Start is called before the first frame update
    void Start()
    {
        _cam = _camera.GetComponent<Camera>();
        _screenCenter = new Vector3(Screen.width/2, Screen.height/2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        setInteractable();
        if (Input.GetButtonDown("Interact"))
        {
            interact();
        }
    }

    private void setInteractable()
    {
        Ray ray = _cam.ScreenPointToRay(_screenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null && inRange(interactable))
            {
                interactable.Hover();
                _current = interactable;
                return;
            }
        }
        _current = null;
    }

    private void interact()
    {
        if (_current == null) return;
        _current.Interact();
    }

    private bool inRange(Interactable target)
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        return dist < target.Range;
    }
}
