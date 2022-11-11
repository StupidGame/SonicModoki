using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeeController : MonoBehaviour
{
    [SerializeField] private float length;
    [SerializeField] private float speed;
    [SerializeField] private GameObject canbasText;
    
    private float degree = 0.0f;
    Transform mytrans;
    // Start is called before the first frame update
    void Start()
    {
        mytrans = this.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float sin = Mathf.Sin(degree);
        mytrans.localPosition = new Vector3(mytrans.localPosition.x, sin * length);
        degree += speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject Player = collision.gameObject;
            GameObject Camera = Player.transform.Find("Camera").gameObject;
            Camera.transform.parent = null;
            canbasText.GetComponent<TextMeshProUGUI>().text = "Game Over! \nscore: " + Player.GetComponent<PlayerController>().score;
            canbasText.SetActive(true);
            Destroy(Player);
        }
    }
}