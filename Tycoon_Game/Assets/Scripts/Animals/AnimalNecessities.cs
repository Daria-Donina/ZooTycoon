using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalNecessities : MonoBehaviour
{
    [SerializeField]//надо убрать потом
    private int welfare;

    [SerializeField]
    private float lifetime;

    [SerializeField]//надо убрать потом
    private int age;

    [SerializeField]//надо убрать потом
    private float yearsLeft;

    [SerializeField]//надо убрать потом
    private int food;

    [SerializeField]//надо убрать потом
    private int water;

    [SerializeField]//надо убрать потом
    private int inhabitancy;

    [SerializeField]//надо убрать потом
    private int entertainment;

    private int foodPart;
    private int waterPart;
    private int entertainmentPart;
    private int inhabitancyPart;

    // Start is called before the first frame update
    void Start()
    {
        age = 0;
        yearsLeft = lifetime - age;
        food = 100;
        water = 100;
        inhabitancy = 0;
        entertainment = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //-1 раз в секунду
        yearsLeft -= 1 * Time.deltaTime;
        age = (int)(lifetime - yearsLeft);
        if (yearsLeft <= 0)
        {
            Debug.Log("Zero");
        }
    }

    private void FixedUpdate()
    {
        CalculateWelfare();
    }

    //Вычисляет welfare животного.
    private void CalculateWelfare()
    {
        //Считаем вклад food в welfare.
        if (food > 50)
        {
            foodPart = 25;
        }
        else
        {
            foodPart = food / 50 * 25;
        }

        //Считаем вклад water в welfare.
        if (water > 50)
        {
            waterPart = 25;
        }
        else
        {
            waterPart = water / 50 * 25;
        }

        //Считаем вклад entertainment в welfare.
        if (entertainment > 50)
        {
            entertainmentPart = 25;
        }
        else
        {
            entertainmentPart = entertainment / 50 * 25;
        }

        inhabitancyPart = inhabitancy / 100 * 25;

        welfare = foodPart + waterPart + entertainmentPart + inhabitancyPart;
    }
}
