using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldChargeUI : MonoBehaviour
{
    [SerializeField]
    public Image foregroundImage;


    private float fill;
    public float ammount;

    public GameObject _player;
    private bool resetCharge;
    public GameObject shield;


    private void Awake()
    {
        
    }
    
    void Start()
    {
        foregroundImage.fillAmount = 0;
    }

    void Update()
    {
       

        if (foregroundImage.fillAmount == 1 && Input.GetButtonDown("Shield"))
        {
            Debug.Log(" e plin");
            fill = -1;
            shield.SetActive(true);
        }

        fill += ammount;
        foregroundImage.fillAmount = fill;
        Debug.Log(foregroundImage.fillAmount);
    }
}
