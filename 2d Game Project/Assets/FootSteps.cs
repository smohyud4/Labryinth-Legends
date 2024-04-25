using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public GameObject footstep;
    void Start()
    {
        footstep.SetActive(false);
    }
   void Update()
    {
        if (T_PlayerControl.isWalking)
            footstep.SetActive(true);
        else
            footstep.SetActive(false);
    }
}
