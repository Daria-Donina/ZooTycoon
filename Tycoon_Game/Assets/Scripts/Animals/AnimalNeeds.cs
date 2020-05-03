using UnityEngine;
using UnityEngine.UIElements;

public class AnimalNeeds : MonoBehaviour
{
    [SerializeField]
    private Bar foodBarPrefab;

    [SerializeField]
    private Bar waterBarPrefab;

    [SerializeField]
    private Bar entertainmentBarPrefab;

    [SerializeField]
    private Bar inhabitancyBarPrefab;

    [SerializeField]
    private Bar welfareBarPrefab;

    private Bar foodBar;
    private Bar waterBar;
    private Bar entertainmentBar;
    private Bar inhabitancyBar;
    private Bar welfareBar;

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

        CalculateInhabitancy();

        animalNeedsPanel = Instantiate(animalNeedsPanelPrefab, transform.position, transform.rotation) as GameObject;
        animalNeedsPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        var position = transform.position;
        position.x = -282;
        position.y = 30;
        foodBar = Instantiate(foodBarPrefab, position, transform.rotation) as Bar;
        foodBar.transform.SetParent(animalNeedsPanel.transform, false);

        position.x = -67;
        inhabitancyBar = Instantiate(inhabitancyBarPrefab, position, transform.rotation) as Bar;
        inhabitancyBar.transform.SetParent(animalNeedsPanel.transform, false);

        position.y = -35;
        entertainmentBar = Instantiate(entertainmentBarPrefab, position, transform.rotation) as Bar;
        entertainmentBar.transform.SetParent(animalNeedsPanel.transform, false);

        position.x = -282;
        waterBar = Instantiate(waterBarPrefab, position, transform.rotation) as Bar;
        waterBar.transform.SetParent(animalNeedsPanel.transform, false);

        position.x = 151;
        position.y = -3;
        welfareBar = Instantiate(welfareBarPrefab, position, transform.rotation) as Bar;
        welfareBar.transform.SetParent(animalNeedsPanel.transform, false);

        animalNeedsPanel.SetActive(false);
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        if (food > 0)
        {
            food -= 0.3f;
        }

        if (water > 0)
        {
            water -= 0.3f;
        }

        if (entertainment > 0)
        {
            entertainment -= 0.3f;
        }

        CalculateInhabitancy();
        CalculateWelfare();

        if (animalNeedsPanel.active)
        {
            foodBar.SetValue((int)food);
            inhabitancyBar.SetValue((int)inhabitancy);
            entertainmentBar.SetValue((int)entertainment);
            waterBar.SetValue((int)water);
            welfareBar.SetValue((int)welfare);
        }
    }

    private void OnMouseDown()
    {
        var panels = GameObject.FindGameObjectsWithTag("Panel");

        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        foodBar.SetValue((int)food);
        inhabitancyBar.SetValue((int)inhabitancy);
        entertainmentBar.SetValue((int)entertainment);
        waterBar.SetValue((int)water);
        welfareBar.SetValue((int)welfare);

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
