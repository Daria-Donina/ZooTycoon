using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector2 startPosition;

    private new Camera camera;

    private float targetPositionX;

    private float targetPositionY;

    private void Start()
    {
        camera = GetComponent<Camera>();
        targetPositionX = transform.position.x;
        targetPositionY = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            float positionX = camera.ScreenToWorldPoint(Input.mousePosition).x - startPosition.x;
            float positionY = camera.ScreenToWorldPoint(Input.mousePosition).y - startPosition.y;
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x - positionX, -7.41f, 6.41f),
            //    Mathf.Clamp(transform.position.y - positionY, -10.65f, 7.65f), transform.position.z);
            targetPositionX = Mathf.Clamp(transform.position.x - positionX, -7.41f, 6.41f);
            targetPositionY = Mathf.Clamp(transform.position.y - positionY, -10.65f, 7.65f);

        }
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetPositionX, speed * Time.deltaTime),
            Mathf.Lerp(transform.position.y, targetPositionY, speed * Time.deltaTime),
            transform.position.z);
    }
}
