using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public float BPM;
    public float musicLength;
    public GameObject note;
    bool[,] noteSlots = {{true, false, false, false, true}, {true, false, false, false, true}};
    int currentBeat;
    float lastUpdate;

    // Start is called before the first frame update
    void Start()
    {
        BPM = 100;
    }
        // if (Time.realtimeSinceStartup > spawnTime) // TODO move into music handler something

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastUpdate >= BPM / 60)
        {
            currentBeat ++;
            if (noteSlots[0, currentBeat] == true)
            {
                Instantiate(note, new Vector3(1f, 4f, 0f), Quaternion.identity);
            }
            if (noteSlots[1, currentBeat] == true)
            {
                Instantiate(note, new Vector3(3f, 4f, 0f), Quaternion.identity);
            }

        lastUpdate = Time.time;
        }
    }
}
