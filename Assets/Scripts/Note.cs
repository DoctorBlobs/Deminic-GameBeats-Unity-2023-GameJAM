using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{

    public float BPM;
    float noteSpeed;
    public float scrollMultiplier;
    public float travelDistance;
    public float startYPos;
    float spawnTime;
    float endTime;
    public bool moveHasStarted;
    public float errorMargin;
    float timeSinceStartup;

    // Start is called before the first frame update
    void Start()
    {
        // spawnTime = 2f;
        startYPos = 4f;
        travelDistance = startYPos + 3.5f;
        transform.position = new Vector3(0f, startYPos, 0f);
        scrollMultiplier = 2;
        noteSpeed = BPM/60f;
        endTime = travelDistance / (noteSpeed * 2);
        timeSinceStartup = 0f;
        errorMargin = 0.15f;
    }   

    void Move()
    {
        transform.position -= Vector3.up * (noteSpeed * Time.deltaTime * scrollMultiplier);      
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        hitNote();
        timeSinceStartup += Time.deltaTime;
    }

    void hitNote()
    {
        if ((timeSinceStartup >= endTime - errorMargin) && (timeSinceStartup <= endTime + errorMargin))
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameObject.Destroy(gameObject);
            }
        }
        else if (!(timeSinceStartup <= endTime + errorMargin))
        {
            GameObject.Destroy(gameObject);
        }
    }
}

