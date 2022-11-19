using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject[] ResultElements;
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] Basketball ballScript;
    [SerializeField] float TotalTime = 60;
    private float TimeLeft;
    private bool IsStopped = false;
    
    public void Reset()
    {
        TimeLeft = TotalTime;
        IsStopped = false;
        ToggleResultsUI(false);
    }
    void Start()
    {
        Reset();
    }
    void ToggleResultsUI(bool OnOff)
    {
        ballScript.enabled = !OnOff; // ballScript skal sl� FRA n�r UI-elementer sl�et TIL, og skal sl�es TIL n�r UI-elementer sl�es FRA.
        foreach (var obj in ResultElements)
        {
            obj.SetActive(OnOff);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsStopped)
        {
            if (TimeLeft < 0)
            {
                TimeText.text = "IKKE MERE TID!";
                IsStopped = true;
                ToggleResultsUI(true);
            }
            else
            {
                TimeText.text = "Tid tilbage: " + TimeLeft + "s";
                TimeLeft -= Time.deltaTime;
            }
        }
    }
}
