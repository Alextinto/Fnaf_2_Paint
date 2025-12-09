using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    //speed in angles in one second
    public float speed = 90f;

    //set fps to 60
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
