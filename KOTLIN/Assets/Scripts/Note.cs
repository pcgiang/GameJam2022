using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour 
{    
    public KeyCode keyToPress;
    public bool canBePressed;
    double timeInstantiated;
    public float assignedTime;
    private Vector3 character;
    // Start is called before the first frame update
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
        Vector3 m_center = new Vector3(Screen.width/2f, Screen.height/2f - 50,Camera.main.nearClipPlane);

        character = Camera.main.ScreenToWorldPoint(m_center);
        character.z = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 10));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // should make this lerp to the centre of the screen instead, noteDespawnY is basically the centre of the screen
            // transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * SongManager.Instance.noteDespawnY, t);
            transform.position = Vector3.Lerp(transform.position, character,t);
        }
        if (Input.GetKeyDown(keyToPress))
        {
          if(canBePressed)
          {
              gameObject.SetActive(false);
          }
        }
      
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        ZoneController zone = other.gameObject.GetComponent<ZoneController>();
        if (other.tag == "Activator")
        {
            if (zone.activated)
            {
                canBePressed = true;
            }
        } else if (other.tag == "Player")
        {
          // minus hp function can be inserted here perhaps
          gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
        }
    }

        // private Vector3 m_pos;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     Vector3 m_center = new Vector3(Screen.width/2f, Screen.height/2f,Camera.main.nearClipPlane);


    //     m_pos= Camera.main.ScreenToWorldPoint(m_center);
    //     m_pos.z = 0f;

    // }

    // private void Update()
    // {
    //     transform.position = Vector3.Lerp(transform.position, m_pos,0.1f);
    // }
}