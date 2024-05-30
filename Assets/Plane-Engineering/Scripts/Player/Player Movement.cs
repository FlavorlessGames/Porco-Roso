using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private float _walkSpeed = 5.0f;
    [SerializeField]
    private float _lookSpeed = 5.0f;
    [SerializeField]
    private float _lookLimitX = 100.0f;
    [SerializeField]
    private float _height = 1.5f;
    [SerializeField]
    private float _fallSpeed = 3f;
    [SerializeField]
    private bool _stopped = false;
    [SerializeField] 
    private GameObject _camera;
    private Camera _cam;
    private float _rotationX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _cam = _camera.GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_stopped) return;
        move();
        look();
        fall();
    }

    private void fall()
    {
        if (grounded()) return;
        _controller.Move(-transform.up * _fallSpeed * Time.deltaTime);
    }

    private bool grounded()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return transform.position.y - hit.point.y < _height;
        }
        return true;
    }

    private void move()
    {
        Vector3 direction = getMovementDirection();
        if (!(direction.magnitude > 0))
        {
            return;
        }
        Vector3 relativeDirection = transform.TransformDirection(direction);
        _controller.Move(relativeDirection * _walkSpeed * Time.deltaTime);
    }

    private void look()
    {
        if (_stopped)
        {
            return;
        }
        _rotationX += -Input.GetAxis("Mouse Y") * _lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -_lookLimitX, _lookLimitX);
        Quaternion xDirection = Quaternion.Euler(_rotationX, 0, 0);
        Quaternion yDirection = Quaternion.Euler(0, Input.GetAxis("Mouse X") * _lookSpeed, 0);
        lookX(xDirection);
        lookY(yDirection);
    }

    private Vector3 getMovementDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        return direction;
    }

    private void lookX( Quaternion direction)
    {
        _camera.transform.localRotation = direction;
    }

    private void lookY(Quaternion direction)
    {
        transform.rotation *= direction;
    }
}
