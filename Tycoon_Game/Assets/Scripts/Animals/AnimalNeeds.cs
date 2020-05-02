using UnityEngine;
using UnityEngine.UIElements;

public class AnimalNeeds : MonoBehaviour
{
    [SerializeField]
    private GameObject animalNeedsPanelPrefab;

    private GameObject animalNeedsPanel;

    [SerializeField]
    private float welfare;

    [SerializeField]
    private float food;

    [SerializeField]
    private float water;

    [SerializeField]
    private float entertainment;

    [SerializeField]
    private float inhabitancy;

    // Start is called before the first frame update
    void Start()
    {
        food = 100f;
        water = 100f;
        entertainment = 100f;
        inhabitancy = 0;

        animalNeedsPanel = Instantiate(animalNeedsPanelPrefab, transform.position, transform.rotation) as GameObject;
        animalNeedsPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        animalNeedsPanel.SetActive(false);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    private void FixedUpdate()
    {
        if (food > 0)
        {
            food -= 0.003f;
        }

        if (water > 0)
        {
            water -= 0.003f;
        }

        if (entertainment > 0)
        {
            entertainment -= 0.003f;
        }

        CalculateWelfare();
    }

    private void OnMouseDown()
    {
        var panels = GameObject.FindGameObjectsWithTag("Panel");

        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        animalNeedsPanel.SetActive(true);
    }

    public void CalculateInhabitancy()
    {
        
    }

    /// <summary>
    /// Вычисляет welfare животного, исходя из значений food, water, inhabitancy и entertainment.
    /// </summary>
    private void CalculateWelfare()
    {
        float foodPart;
        float waterPart;
        float entertainmentPart;
        float inhabitancyPart;

        //Считаем вклад entertainment в welfare.
        if (entertainment > 50f)
        {
            entertainmentPart = 25f;
        }
        else
        {
            entertainmentPart = entertainment / 50f * 25f;
        }

        //Считаем вклад food в welfare.
        if (food > 50f)
        {
            foodPart = 25f;
        }
        else
        {
            foodPart = food / 50f * 25f;
        }

        //Считаем вклад water в welfare.
        if (water > 50f)
        {
            waterPart = 25f;
        }
        else
        {
            waterPart = water / 50f * 25f;
        }

        inhabitancyPart = inhabitancy / 100f * 25f;

        welfare = foodPart + waterPart + entertainmentPart + inhabitancyPart;
    }
}
