using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeSceneButton : MonoBehaviour
{

    [SerializeField] private string sceneName;

    public void ChangeScene(){
            LevelManager.Instance.LoadScene(sceneName);
    }

}
