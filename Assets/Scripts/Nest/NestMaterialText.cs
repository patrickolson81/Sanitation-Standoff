using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NestMaterialText : MonoBehaviour
{
    private TextMeshProUGUI numMatText; //Text Element showing number of materials Collected
    private TextMeshProUGUI matText; //Text Element showing materials Collected txt
    private string text; //String for the text element
    private int matNum; // Number of materials collected

    private GameObject numMatObj;
    private GameObject matObj;
    void Start()
    {
        matNum = 0;
        text = matNum.ToString();

        numMatObj = GameObject.Find("NumMaterial");
        matObj = GameObject.Find("Mats Collected");
        numMatText = numMatObj.GetComponent<TextMeshProUGUI>();
        matText = matObj.GetComponent<TextMeshProUGUI>();

        numMatText.text = text;

        numMatText.gameObject.SetActive(false);
        matText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {

    }
    public void AddMaterial()
    {
        matNum ++;
        text = matNum.ToString();
        numMatText.text = text;
    }
    public void ShowText()
    {
        numMatText.gameObject.SetActive(true);
        matText.gameObject.SetActive(true);
    }
    public void HideText()
    {
        numMatText .gameObject.SetActive(false);
        matText.gameObject.SetActive(false);
    }
    public void ChangeText()
    {
        matText.text = "Well Done!";
        numMatText.gameObject.SetActive(false);
    }
}
