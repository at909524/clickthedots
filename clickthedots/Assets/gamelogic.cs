using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Camera cam;

    //Spawning dots
    public GameObject dot;
    public float time_between_spawns = 1f;
    private float dot_spawn_timer = 0f;

    //Score
    private int score = 0;
    public TMP_Text score_text;

    //Timer
    private float game_timer = 60; //In seconds
    public TMP_Text game_timer_text;

    //Restarting
    public GameObject restart_button;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Disable the restart button
        restart_button.SetActive(false);

        score_text.text = "Score: 0";

        //Wait .5 seconds before spawning a dot
        dot_spawn_timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //***Game Timer***
        game_timer -= Time.deltaTime;
        if(game_timer < 0)
        {
            game_timer = 0;
            game_timer_text.text = "Time: 0";
            restart_button.SetActive(true);
            return;
        }
        game_timer_text.text = "Time: " + Mathf.Floor(game_timer).ToString();

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
                //Added the clicked dot's point value to the score
                score += hit.collider.gameObject.GetComponent<Dot>().point_value;

                //Update the score text with the new score
                score_text.text = "Score: " + score;

                //Destroy the game object attached to it
                Destroy(hit.collider.gameObject);
            }
        }

        //***Spwaning Dots***
        //Make the timer count down
        dot_spawn_timer -= Time.deltaTime;

        //If the timer has counted down...
        if(dot_spawn_timer <= 0f )
        {
            //Reset timer
            dot_spawn_timer = time_between_spawns;

            //Spawn dots...
            SpawnDot();
        }

    }

    private void SpawnDot()
    {
        //Create a new dot object and add it to the scene
        GameObject new_dot = Instantiate(dot);

        //Get a random x/y screen space position
        int x_pos = Random.Range(0, cam.scaledPixelWidth);
        int y_pos = Random.Range(0, cam.scaledPixelHeight);

        //Convert the random point in screen space to world space
        Vector3 spawn_point = new Vector3(x_pos, y_pos);
        spawn_point = cam.ScreenToWorldPoint(spawn_point);
        spawn_point.z = 0;

        //Move the dot to the spawn point
        new_dot.transform.position = spawn_point; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
