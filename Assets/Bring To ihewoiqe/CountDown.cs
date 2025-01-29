using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image timeImage;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float duration, currentTime;

    private PlayerMovement mvP1;
    public GameObject minimap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mvP1 = GameObject.FindObjectOfType<PlayerMovement>();
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        minimap.SetActive(false);
        mvP1.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        timeText.text = "";
        panel.SetActive(true);
    }
}
