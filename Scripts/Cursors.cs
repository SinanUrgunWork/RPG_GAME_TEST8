using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    public GameObject CursorObject;
    public Sprite CursorBasic;
    public Sprite CursorHand;
    public Image CursorImage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CursorObject.transform.position = Input.mousePosition;
        if (Input.GetMouseButton(1))
        {
            CursorImage.sprite = CursorHand;
        }
        if (Input.GetMouseButtonUp(1))
        {
            CursorImage.sprite = CursorBasic;
        }
    }
}
