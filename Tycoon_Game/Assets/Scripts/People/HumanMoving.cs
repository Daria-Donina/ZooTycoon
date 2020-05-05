using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HumanMoving : MonoBehaviour
{
    private delegate void Moving();

    private Animator animator;

    private float speed;

    private Vector3 direction;

    private int directionIndex;

    private Vector3Int currentCellPosition;

    [SerializeField]
    private GridLayout grid;

    [SerializeField]
    private Tilemap tilemap;

    // Start is called before the first frame update
    private void Start()
    {
        grid = FindObjectsOfType(typeof(GridLayout))[0] as GridLayout;
        var tilemaps = FindObjectsOfType(typeof(Tilemap));
        foreach (var map in tilemaps)
        {
            if (map.name == "Road")
            {
                tilemap = map as Tilemap;
            }
        }

        animator = GetComponent<Animator>();
        speed = UnityEngine.Random.Range(0.2f, 1f);
        currentCellPosition = grid.WorldToCell(transform.position);

        directionIndex = UnityEngine.Random.Range(0, 4);
        var startedIndex = directionIndex;
        while (!GetNearestTile())
        {
            ++directionIndex;
            if (directionIndex == 4)
            {
                directionIndex = 0;
            }

            if (directionIndex == startedIndex)
            {
                directionIndex = 5;
                StandStill();
                break;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (grid.WorldToCell(CalculatePosition()) != currentCellPosition)
        {
            currentCellPosition = grid.WorldToCell(transform.position);

            var oppositeDirection = GetIndexOfOppositeDirection(directionIndex);
            directionIndex = UnityEngine.Random.Range(0, 4);
            var checkedOppositeDirection = false;

            if (directionIndex == oppositeDirection)
            {
                ++directionIndex;
                if (directionIndex == 4)
                {
                    directionIndex = 0;
                }
            }

            while (!GetNearestTile())
            {
                ++directionIndex;
                if (directionIndex == 4)
                {
                    directionIndex = 0;
                }

                if (directionIndex == oppositeDirection)
                {
                    if (checkedOppositeDirection)
                    {
                        if (!GetNearestTile())
                        {
                            directionIndex = 5;
                            StandStill();
                        }
                        break;
                    }
                    else
                    {
                        ++directionIndex;
                        if (directionIndex == 4)
                        {
                            directionIndex = 0;
                        }
                        checkedOppositeDirection = true;
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (directionIndex == 5)
        {
            directionIndex = UnityEngine.Random.Range(0, 4);
            var startedIndex = directionIndex;
            while (!GetNearestTile())
            {
                ++directionIndex;
                if (directionIndex == 4)
                {
                    directionIndex = 0;
                }

                if (directionIndex == startedIndex)
                {
                    directionIndex = 5;
                    StandStill();
                    break;
                }
            }
        }
    }

    private int GetIndexOfOppositeDirection(int direction)
    {
        switch (direction)
        {
            case 0: return 1;
            case 1: return 0;
            case 2: return 3;
            case 3: return 2;
            default: throw new IndexOutOfRangeException();
        };
    }

    private Vector3 CalculatePosition()
    {
        var previousPosition = transform.position;

        switch (directionIndex)
        {
            case 0:
                previousPosition.y -= 0.5f;
                break;
            case 1:
                previousPosition.y += 0.5f;
                break;
            case 2:
                previousPosition.x += 0.5f;
                break;
            case 3:
                previousPosition.x -= 0.5f;
                break;
        }

        return previousPosition;
    }

    private bool GetNearestTile()
    {
        var nextPosition = currentCellPosition;

        TileBase tile;
        switch (directionIndex)
        {
            case 0:
                nextPosition.y += 1;
                tile = tilemap.GetTile(nextPosition);
                if (tile != null)
                {
                    GoUp();
                    return true;
                }
                return false;

            case 1:
                nextPosition.y -= 1;
                tile = tilemap.GetTile(nextPosition);
                if (tile != null)
                {
                    GoDown();
                    return true;
                }
                return false;

            case 2:
                nextPosition.x -= 1;
                tile = tilemap.GetTile(nextPosition);
                if (tile != null)
                {
                    GoLeft();
                    return true;
                }
                return false;

            case 3:
                nextPosition.x += 1;
                tile = tilemap.GetTile(nextPosition);
                if (tile != null)
                {
                    GoRight();
                    return true;
                }
                return false;
            default:
                throw new IndexOutOfRangeException();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            directionIndex = 5;
            StandStill();
        }
    }

    /// <summary>
    /// Перечисление чисел, каждое из которых соответствует своей анимации по Animation State.
    /// </summary>
    private enum CharStates
    {
        goDown = 1,
        goUp = 2,
        goRight = 3,
        goLeft = 4
    }

    /// <summary>
    /// Метод, задающий направление движения человека вверх.
    /// </summary>
    private void GoUp()
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
    private void GoDown()
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
    private void GoLeft()
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
    private void GoRight()
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
    private void StandStill()
    {
        //Меняем направление на нулевое.
        direction = new Vector3(0.0f, 0.0f, 0.0f);

        //Приостанавливаем анимацию.
        animator.enabled = false;
    }
}