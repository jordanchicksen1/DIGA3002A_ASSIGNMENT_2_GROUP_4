using UnityEngine;

public class turner : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        float rotateSpeed = 200f * Time.deltaTime;
        this.transform.Rotate(0f, 0f, rotateSpeed);
    }
}
