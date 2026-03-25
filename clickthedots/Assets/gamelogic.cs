using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Camera cam;

    //Spawning dots
    public GameObject dot;
    public float time_between_spawns = 1f;
    private float dot_spawn_timer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Wait .5 seconds before spawning a dot
        dot_spawn_timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the user pressed the left mouse button
        if(Input.GetMouseButtonDown(0))
        {
            //if so...

            //Take the screen position of the mouse and convert it to world space
            Vector2 world_point = cam.ScreenToWorldPoint(Input.mousePosition);
            //Shoot out a raycast in thge direction of the screen
            RaycastHit2D hit = Physics2D.Raycast(world_point, Vector2.zero);

            //If what we collided with has a collider
            if(hit.collider != null )
            {
                //Destroy the game object attached to it
                Destroy(hit.collider.gameObject);
            }
        }

        //***Spwaning Dots***
        //Make the timer count down
        dot_spawn_timer -= Time.deltaTime;

        //If the timer has counted down...
        if(dot_spawn_timer >= 0f )
        {
            //Reset timer
            dot_spawn_timer = time_between_spawns;
        }

    }
}
