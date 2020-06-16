using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsManager : MonoBehaviour
{
    public static int step;
   
    public int GetStep()
    {
        return step;
    }

    public void SetStep(int currentStep)
    {
        step = currentStep;
    }
}
