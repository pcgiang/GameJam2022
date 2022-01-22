using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    public KeyCode keyToPress;

    public bool canBePressed;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        } else
        {
            // transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
            Move();

            if (Input.GetKeyDown(keyToPress))
          {
              if(canBePressed)
              {
                  gameObject.SetActive(false);
              }
          }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
        }
    }

    public abstract void Move();
}
