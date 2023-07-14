using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{

    public int score;
    public Text _textscore;
    public int goodscore;
    public int badscore;
    public int damage;
    public int Health

    // Update is called once per frame
    void GetPointsBad(bool goodbad)
    {
        if goodbad{
            score = score + goodscore;
        }
        else
        {
            score = score + badscore;
        }
        
    }

    void RemoveHealth() {
        Health = Health - damage;
    }

    void HealthCount() {
        if Health <= 0{
            Debug.log("Ded");
            //put game over here
        }
    }
}
