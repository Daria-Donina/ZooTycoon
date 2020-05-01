using UnityEngine;

public class AnimalNeeds : MonoBehaviour
{
    [SerializeField]
    public float Welfare { get; private set; }

    [SerializeField]
    public float Food { get; private set; }

    [SerializeField]
    public float Water { get; private set; }

    [SerializeField]
    public float Entertainment { get; private set; }

    [SerializeField]
    public float Inhabitancy { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Food = 100f;
        Water = 100f;
        Entertainment = 100f;
        Inhabitancy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Food > 0)
        {
            Food -= 0.05f;
        }

        if (Water > 0)
        {
            Water -= 0.05f;
        }

        if (Entertainment > 0)
        {
            Entertainment -= 0.05f;
        }

        CalculateWelfare();
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
        if (Entertainment > 50f)
        {
            entertainmentPart = 25f;
        }
        else
        {
            entertainmentPart = Entertainment / 50f * 25f;
        }

        //Считаем вклад food в welfare.
        if (Food > 50f)
        {
            foodPart = 25f;
        }
        else
        {
            foodPart = Food / 50f * 25f;
        }

        //Считаем вклад water в welfare.
        if (Water > 50f)
        {
            waterPart = 25f;
        }
        else
        {
            waterPart = Water / 50f * 25f;
        }

        inhabitancyPart = Inhabitancy / 100f * 25f;

        Welfare = foodPart + waterPart + entertainmentPart + inhabitancyPart;
    }
}
