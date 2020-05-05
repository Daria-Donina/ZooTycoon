using UnityEngine;
using Assets.Scripts.Animals.Entities;

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

    private AnimalInfo animal;

    // Start is called before the first frame update
    void Start()
    {
        Zoo.AnimalCount++;
        animal = new AnimalInfo(Zoo.AnimalCount)
        {
            Food = 100f,
            Water = 100f,
            Entertainment = 100f,
            Inhabitancy = 0,
            Welfare = 100f
        };

        Zoo.AnimalWelfares.Add(animal.Welfare);

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
        if (animal.Food > 0)
        {
            animal.Food -= 0.3f;
        }

        if (animal.Water > 0)
        {
            animal.Water -= 0.3f;
        }

        if (animal.Entertainment > 0)
        {
            animal.Entertainment -= 0.3f;
        }

        CalculateInhabitancy();
        CalculateWelfare();

        Zoo.AnimalWelfares.Insert(animal.AnimalIndex, animal.Welfare);
        if (animalNeedsPanel.active)
        {
            foodBar.SetValue((int)animal.Food);
            inhabitancyBar.SetValue((int)animal.Inhabitancy);
            entertainmentBar.SetValue((int)animal.Entertainment);
            waterBar.SetValue((int)animal.Water);
            welfareBar.SetValue((int)animal.Welfare);
        }
    }

    private void OnMouseDown()
    {
        var panels = GameObject.FindGameObjectsWithTag("Panel");

        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        foodBar.SetValue((int)animal.Food);
        inhabitancyBar.SetValue((int)animal.Inhabitancy);
        entertainmentBar.SetValue((int)animal.Entertainment);
        waterBar.SetValue((int)animal.Water);
        welfareBar.SetValue((int)animal.Welfare);

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
        if (animal.Entertainment > 50f)
        {
            entertainmentPart = 25f;
        }
        else
        {
            entertainmentPart = animal.Entertainment / 50f * 25f;
        }

        //Считаем вклад food в welfare.
        if (animal.Food > 50f)
        {
            foodPart = 25f;
        }
        else
        {
            foodPart = animal.Food / 50f * 25f;
        }

        //Считаем вклад water в welfare.
        if (animal.Water > 50f)
        {
            waterPart = 25f;
        }
        else
        {
            waterPart = animal.Water / 50f * 25f;
        }

        inhabitancyPart = animal.Inhabitancy / 100f * 25f;

        animal.Welfare = foodPart + waterPart + entertainmentPart + inhabitancyPart;
    }
}
