using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameManager GM;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = PlayerPrefs.GetInt("SpeedUp");
        GM = FindObjectOfType<GameManager>();
        if (GM.score % 11 == 0)
        {
            PlayerPrefs.SetInt("StopSpeedUp", 0);
        }

        Vector3 newRotation = new Vector3(0, 180, 0);
        this.transform.eulerAngles = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.score % 10 == 0 && GM.score != 0 && PlayerPrefs.GetInt("StopSpeedUp") == 0)
        {
            PlayerPrefs.SetInt("StopSpeedUp", 1);
            PlayerPrefs.SetInt("SpeedUp", PlayerPrefs.GetInt("SpeedUp") - 2);
        }
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
