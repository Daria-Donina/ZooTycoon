using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public static int PeopleCount { get; set; } = 0;
    public static int AnimalCount { get; set; } = 0;

    public static int Money { get; set; } = 500;

    public static float WelfareCoefficient { get; set; }

    public static List<float> AnimalWelfares { get; set; } = new List<float>();

    // Update is called once per frame
    void Update() => CalculateWelfareCoefficient();

    private static void CalculateWelfareCoefficient()
    {
        var number = AnimalWelfares.Count;
        float sum = 0;

        foreach (var welfare in AnimalWelfares)
        {
            if (welfare < 10f)
            {
                number += 4;
                sum += welfare * 5f;
            }
            else if (welfare < 20f)
            {
                number += 2;
                sum += welfare * 3f;
            }
            else if (welfare < 30f)
            {
                number += 1;
                sum += welfare * 2f;
            }
            else
            {
                sum += welfare;
            }
        }

        WelfareCoefficient = sum / (number * 100f);
    }
}
