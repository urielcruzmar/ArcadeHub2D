using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed = 0.5f;
    [SerializeField] private float groundSpeed = 1f;
    [SerializeField] private GameObject[] backgrounds;
    [SerializeField] private GameObject[] grounds;

    private float backgroundWidth;
    private float groundWidth;

    private void Start()
    {
        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        groundWidth = grounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        MoveBackgrounds();
        MoveGrounds();
    }

    private void MoveBackgrounds()
    {
        foreach (GameObject background in backgrounds)
        {
            Vector3 currentPosition = background.transform.position;
            float newPosition = currentPosition.x - (backgroundSpeed * Time.deltaTime);
            float resetPosition = -backgroundWidth;

            if (newPosition < resetPosition)
            {
                currentPosition.x = backgroundWidth;
                background.transform.position = currentPosition;
            }
            else
            {
                currentPosition.x = newPosition;
                background.transform.position = currentPosition;
            }
        }
    }

    private void MoveGrounds()
    {
        foreach (GameObject ground in grounds)
        {
            Vector3 currentPosition = ground.transform.position;
            float newPosition = currentPosition.x - (groundSpeed * Time.deltaTime);
            float resetPosition = -groundWidth;

            if (newPosition < resetPosition)
            {
                currentPosition.x = groundWidth;
                ground.transform.position = currentPosition;
            }
            else
            {
                currentPosition.x = newPosition;
                ground.transform.position = currentPosition;
            }
        }
    }
}
