using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    private SpriteRenderer theSR;
    private RectTransform imgRectTransform;
    private Vector3 mouseWorldPosition;
    public bool activated;
    public Sprite defaultImage;
    public Sprite pressedImage;

    // the keytopress here is to activate the zone, different from the one in EnemyAttack.cs
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        imgRectTransform = GetComponent<RectTransform>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        Debug.Log(mouseWorldPosition);


        // changes sprite when pressed
        if (RectTransformUtility.RectangleContainsScreenPoint(imgRectTransform, mouseWorldPosition))
        {
            activated = true;
            theSR.sprite = pressedImage;
        }

        if(!RectTransformUtility.RectangleContainsScreenPoint(imgRectTransform, mouseWorldPosition))
        {
            activated = false;
            theSR.sprite = defaultImage;
        }
    }
}
