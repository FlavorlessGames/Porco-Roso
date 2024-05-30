using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DotCursor : MonoBehaviour
{
    public Texture2D cursorTexture; 
    public Vector2 cursorSize = new Vector2(10, 10); 

    void Start()
    {    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    { 
        float x = (Screen.width - cursorSize.x) / 2;
        float y = (Screen.height - cursorSize.y) / 2;
        GUI.DrawTexture(new Rect(x, y, cursorSize.x, cursorSize.y), cursorTexture);
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}


