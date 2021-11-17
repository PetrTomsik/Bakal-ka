using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCurrent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Zmackl jsi tlacitko");
    }
    public void printText()
    {
        Debug.Log("Zmackl jsi tlacitko");
    }
    public Texture2D cursorHacek;
    public Texture2D cursorCarka;
    public void ChangeCursorHacek()
    {
        Cursor.SetCursor(cursorHacek, Vector2.zero,CursorMode.ForceSoftware); ;
        Debug.Log("Zmenil se kurzor na hacek");
    }
    public void ChangeCursorCarka()
    {
        Cursor.SetCursor(cursorCarka, Vector2.zero, CursorMode.ForceSoftware); ;
        Debug.Log("Zmenil se kurzor na hacek");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse_position = Input.mousePosition.normalized;
        float x = mouse_position.x;
        float y = mouse_position.y;
        Debug.Log("x " +x+ " y "+y);

    }
}
