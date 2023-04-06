using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject bulletPrefab;
    public float speed = 10f;
    public float xLimit = 7f;
    public float reloadTime = 0.5f;

    float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ship Movement
        elapsedTime += Time.deltaTime;

    //Edited Code to allow vertical Movement
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(xInput * speed * Time.deltaTime, yInput * speed * Time.deltaTime, 0f);

        //Clamping Position
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        position.y = Mathf.Clamp(position.y, -5.5f, 5.5f);
        
        transform.position = position;

    //Bullet Fire changed for x-wing shooting position
        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime) {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(-0.5f, 1f, 0);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            elapsedTime = 0f;

            Vector3 spawnPosRight = transform.position;
            spawnPosRight += new Vector3(0.5f, 1f, 0);
            Instantiate(bulletPrefab, spawnPosRight, Quaternion.identity);
        }
    }

    //Player hit meteor
    void OnTriggerEnter2D(Collider2D other) {
        gameManager.PlayerDied();
    }
}
