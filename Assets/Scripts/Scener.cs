using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scener : MonoBehaviour
{
    public string NæsteSceneNavn;

    public void SkiftScene()
    {
        SceneManager.LoadScene(NæsteSceneNavn);
    }

}
