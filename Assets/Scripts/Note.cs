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
    float endTime;
    public bool moveHasStarted;
    public float errorMargin;
    float timeSinceStartup;
    public char whichKey;
    public KeyCode keyCode;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        // spawnTime = 2f;
        startYPos = 4f;
        travelDistance = startYPos + 3.7f;
        scrollMultiplier = 2f;
        noteSpeed = BPM/60f;
        endTime = travelDistance / (noteSpeed * 2);
        timeSinceStartup = 0f;
        errorMargin = 0.13f;
        switch (whichKey)
        {
            case 'j':
                keyCode = KeyCode.J; break;
            case 'k':
                keyCode = KeyCode.K; break;
            case 'f':
                keyCode = KeyCode.F; break;
            case 'd':
                keyCode = KeyCode.D; break;
        }
    }   

    void Move()
    {
        transform.position -= Vector3.up * (noteSpeed * Time.deltaTime * scrollMultiplier);      
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        HitNote();
        timeSinceStartup += Time.deltaTime;
    }

    void HitNote()
    {
        if ((timeSinceStartup >= endTime - (2 * errorMargin)) && (timeSinceStartup <= endTime + errorMargin))
        {
            Debug.Log("ddsaf" + timeSinceStartup);
            if (Input.GetKeyDown(keyCode))
            {
                GameObject.Destroy(gameObject);
                score++;
            }
        }
        else if (!(timeSinceStartup <= endTime + 2))
        {
            GameObject.Destroy(gameObject);
            score--;
        }
    }
}

