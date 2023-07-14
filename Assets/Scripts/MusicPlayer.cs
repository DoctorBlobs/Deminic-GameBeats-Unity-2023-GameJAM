using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public float BPM;
    public float musicLength;
    public GameObject jArrow;
    public GameObject kArrow;
    public GameObject fArrow;
    public GameObject dArrow;
    public GameObject audiosource;
    int currentSong;

    readonly bool[,] noteSlots = {{true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false,
 false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false,
 true, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false,
 true, false, false, false, true, false, false, false, true, false, false, false, false, false, false, false}, {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false,
 false, false, false, false, false, false, true, false, false, false, false, false, true, false, false, false,
 false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false,
 false, false, false, true, false, false, false, false, false, false, true, false, true, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, false}, {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false,
 false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, true, false, false, false, false, false, true, false,
 true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,}};

    readonly bool[,] noteSlots2 = {{true, false, false, false, true, false, false, false, true, false, false, false, true, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, true, false, true, false, false, false,
 true, false, false, false, true, false, false, false, true, false, false, false, true, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, true, false, false, false, false, true, false, false, true, false, false, false}, {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, true, false, false, false, true, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, true, false, false, false, true, false,
 false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, true, false, false, true, false, false, false, false, false, false, false, false, false,
 false, false, true, false, false, false, false, true, false, false, false, false, false, false, false, false}, {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, true, false, false, false, true, false, false, false, true, false, false, false, false, false,
 false, false, false, false, false, false, false, true, false, false, false, false, true, false, false, false,
 false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 true, false, false, false, false, false, true, false, false, false, false, false, true, false, false, false,
 false, false, true, false, false, true, false, false, false, true, false, false, true, false, true, false,
 false, false, false, false, false, false, true, false, true, false, false, true, false, false, false, false}, {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false,
 false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, true, false, false, false, true, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false,
 false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, false,
 false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false}};
    int currentBeat;
    float lastUpdate;

    // Start is called before the first frame update
    void Start()
    {
        musicLength = 12 * 16;
        BPM = 100;
        currentBeat = 0;
        currentSong = 0;
    }
    // if (Time.realtimeSinceStartup > spawnTime) // TODO move into music handler something

    // Update is called once per frame
    void Update()
    {
        if (currentBeat >= musicLength - 1)
        {
            currentSong++;
            currentBeat = 0;
            BPM = 115;
        }
        if (Time.time - lastUpdate >= (60 / BPM) / 4.1)
        {
            switch (currentSong)
            {
                case 0:
                if (noteSlots[0, currentBeat] == true)
                {
                    Instantiate(jArrow, new Vector3(1f, 4f, 0f), Quaternion.identity);
                }
                if (noteSlots[1, currentBeat] == true)
                {
                    Instantiate(kArrow, new Vector3(3f, 4f, 0f), Quaternion.identity);
                }
                if (noteSlots[2, currentBeat] == true)
                {
                    Instantiate(fArrow, new Vector3(-1f, 4f, 0f), Quaternion.identity);
                }
                    break;
                case 1:
                if (noteSlots2[0, currentBeat] == true)
                {
                    Instantiate(jArrow, new Vector3(1f, 4f, 0f), Quaternion.identity);
                }
                if (noteSlots2[1, currentBeat] == true)
                {
                    Instantiate(kArrow, new Vector3(3f, 4f, 0f), Quaternion.identity);
                }
                if (noteSlots2[2, currentBeat] == true)
                {
                    Instantiate(fArrow, new Vector3(-1f, 4f, 0f), Quaternion.identity);
                }
                if (noteSlots2[3, currentBeat] == true)
                {
                    Instantiate(dArrow, new Vector3(-3f, 4f, 0f), Quaternion.identity);
                }
                    break;
            }
            currentBeat++;

            lastUpdate = Time.time;
        }
    }
}
