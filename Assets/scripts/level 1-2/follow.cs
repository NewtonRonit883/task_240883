using UnityEngine;

public class follow_player : MonoBehaviour
{
    public Transform player;  //Accessing Player's Transform section
    public Vector3 offset; //Creating a 3d vector
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x,0,-11); //Setting position of the camera
    }
    
}
