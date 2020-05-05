using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    public static int PeopleCount { get; set; }
    public static int AnimalCount { get; set; }

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
            if (welfare < 10)
            {
                number += 4;
                sum += welfare * 5;
            }
            else if (welfare < 20)
            {
                number += 2;
                sum += welfare * 3;
            }
            else if (welfare < 30)
            {
                number += 1;
                sum += welfare * 2;
            }
            else
            {
                sum += welfare;
            }
        }

        WelfareCoefficient = sum / (number * 100);
    }
}
