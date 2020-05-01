﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoving : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private delegate void Moving();

    private Vector3 direction;

    private float waitTime;

    private float timer;

    private Moving[] moving;

    private Animator animator;

    private int randomIndex;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //Массив из методов движения, из которых раз в какой-то период времени 
        //будет выбираться и вызываться случайный.
        moving = new Moving[5];
        moving[0] = GoUp;
        moving[1] = GoDown;
        moving[2] = GoLeft;
        moving[3] = GoRight;
        moving[4] = StandStill;

        //Случайно выбирается направление, куда пойдет человек сначала.
        randomIndex = Random.Range(0, 5);
        moving[randomIndex].Invoke();

        //Случайно выбирается промежуток времени, в течение которого 
        //человек не будет менять направление движения.
        waitTime = Random.Range(1, 6);
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;

        //Проверяем, не прошло ли время waitTime. 
        //Если да, то человек меняет направление движения.
        if (timer > waitTime)
        {
            //Удаляем время waitTime.
            timer -= waitTime;

            //Случайно выбирается направление, куда пойдет человек.
            randomIndex = Random.Range(0, 5);
            moving[randomIndex].Invoke();

            //Случайно выбирается промежуток времени, 
            //в течение которого человек не будет менять направление движения.
            waitTime = Random.Range(1, 6);
        }
    }

    /// <summary>
    /// При столкновении человека с границей дороги (т.е. с землей/травой)
    /// человек останавливается, пока не истечет время waitTime.
    /// Затем меняет направление движения и, если снова произошло столкновение,
    /// человек снова стоит на месте.
    /// Можно подумать, как реализовать это получше.
    /// </summary>
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            randomIndex = 4;
            //randomIndex = Random.Range(0, 5);
            moving[randomIndex].Invoke();
        }
    }

    /// <summary>
    /// Перечисление чисел, каждое из которых соответствует своей анимации по Animation State.
    /// </summary>
    enum CharStates
    {
        goDown = 1,
        goUp = 2,
        goRight = 3,
        goLeft = 4
    }

    /// <summary>
    /// Метод, задающий направление движения человека вверх.
    /// </summary>
    void GoUp()
    {
        //Меняем направление.
        direction = new Vector3(0.0f, 1.0f, 0.0f);

        //Включаем анимацию на случай, если она была выключена в StandStill().
        animator.enabled = true;
        //Переключаем анимацию.
        animator.SetInteger("AnimationState", (int)CharStates.goUp);
    }

    /// <summary>
    /// Задает направление движения человека вниз.
    /// </summary>
    void GoDown()
    {
        //Меняем направление.
        direction = new Vector3(0.0f, -1.0f, 0.0f);

        //Включаем анимацию на случай, если она была выключена в StandStill().
        animator.enabled = true;
        //Переключаем анимацию.
        animator.SetInteger("AnimationState", (int)CharStates.goDown);
    }

    /// <summary>
    /// Задает направление движения человека влево.
    /// </summary>
    void GoLeft()
    {
        //Меняем направление.
        direction = new Vector3(-1.0f, 0.0f, 0.0f);

        //Включаем анимацию на случай, если она была выключена в StandStill().
        animator.enabled = true;
        //Переключаем анимацию.
        animator.SetInteger("AnimationState", (int)CharStates.goLeft);
    }

    /// <summary>
    /// Задает направление движения человека вправо.
    /// </summary>
    void GoRight()
    {
        //Меняем направление.
        direction = new Vector3(1.0f, 0.0f, 0.0f);

        //Включаем анимацию на случай, если она была выключена в StandStill().
        animator.enabled = true;
        //Переключаем анимацию.
        animator.SetInteger("AnimationState", (int)CharStates.goRight);
    }

    /// <summary>
    /// Приостанавливает движение человека.
    /// </summary>
    void StandStill()
    {
        //Меняем направление на нулевое.
        direction = new Vector3(0.0f, 0.0f, 0.0f);

        //Приостанавливаем анимацию.
        animator.enabled = false;
    }
}