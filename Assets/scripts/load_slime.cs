
/*using UnityEngine;
using UnityEngine.UI;
public class load_slime : MonoBehaviour
{
    public RectTransform slimeImage;   // Your slime image (UI Image)
    
    public float speed = 100f;
    // Start is called before the first frame update
    
    public int endX = 173;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slimeImage.position.x < endX)
        {
            float offset = speed * Time.deltaTime;
            slimeImage.position = new Vector3(slimeImage.position.x + offset, slimeImage.position.y, 0);    
        }
        
    }
}
*/
using UnityEngine;
using UnityEngine.UI;

public class load_slime : MonoBehaviour
{
    public RectTransform slimeImage; // Your slime image (UI Image)
    public RectTransform loadingBar; // The loading bar (UI Image)
    public float speed = 100f;       // Movement speed (adjust as needed)
    
    private float startX;
    private float endX;

    void Start()
    {
        // Calculate start and end positions dynamically based on the loading bar
        startX = slimeImage.anchoredPosition.x;
        endX = loadingBar.rect.width - slimeImage.rect.width; // Adjust to fit inside loading bar
    }

    void Update()
    {
        if (slimeImage.anchoredPosition.x < endX)
        {
            float offset = speed * Time.deltaTime;
            slimeImage.anchoredPosition += new Vector2(offset, 0);
        }
    }
}
