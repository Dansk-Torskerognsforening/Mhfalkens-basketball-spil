using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scener : MonoBehaviour
{
    public string N�steSceneNavn;

    public void SkiftScene()
    {
        SceneManager.LoadScene(N�steSceneNavn);
    }

}
