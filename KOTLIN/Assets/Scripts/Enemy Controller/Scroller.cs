using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scroller : MonoBehaviour
{
    public float beatTempo;

    public bool hasStarted;

    public KeyCode keyToPress;

    public bool canBePressed;

    double timeInstantiated;
    public float assignedTime;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        timeInstantiated = SongManager.GetAudioSourceTime();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(keyToPress))
      {
          if(canBePressed)
          {
              gameObject.SetActive(false);
          }
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ZoneController zone = other.gameObject.GetComponent<ZoneController>();
        if (other.tag == "Activator")
        {
            if (zone.activated)
            {
                canBePressed = true;
            }
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
