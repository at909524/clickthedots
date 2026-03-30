using UnityEngine;

public class Dot : MonoBehaviour
{
    public int point_value = 10;

    private float timer;
    private float life_time = 3;

    string[] sizes = { "small", "medium", "large" };
    string size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        size = sizes[Random.Range(0, sizes.Length)];

        switch(size)
        {
            case "small":
                gameObject.transform.localScale *= 0.7f;
                point_value = 30;
                life_time = 1;
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case "medium":
                gameObject.transform.localScale *= 1f;
                point_value = 20;
                life_time = 1;
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case "large":
                gameObject.transform.localScale *= 1.3f;
                point_value = 10;
                life_time = 2;
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }

        timer = life_time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
