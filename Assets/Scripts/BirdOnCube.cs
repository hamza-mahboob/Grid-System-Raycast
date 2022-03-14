using UnityEngine;

public class BirdOnCube : MonoBehaviour
{
    private string bird;

    public void setBird(string bird)
    {
        this.bird = bird;
    }

    public string getBird()
    {
        return bird;
    }
    
    
}