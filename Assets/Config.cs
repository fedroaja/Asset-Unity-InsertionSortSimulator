using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Config : MonoBehaviour
{
	public Insertion InsertionSort;
	public Insertion Mulai;
	public InputField NumberOfcubesInput;
	public Text textComponent;
	public Text textInfo;
	public bool flag = true;
	public float speed;
    public GameObject FPController;
    public string scr;

    // Start is called before the first frame update
    public void StartSortASC()
    {
    	if(flag && Convert.ToInt32(NumberOfcubesInput.text) > 0){
    		Mulai = Instantiate(InsertionSort);
    		Mulai.NumberOfCubes = Convert.ToInt32(NumberOfcubesInput.text);
    		Mulai.PlaySortingASC();
    		flag = false;
            (FPController.GetComponent(scr) as MonoBehaviour).enabled = true;

        }
    }
    public void StartSortDesc()
    {
    	if(flag && Convert.ToInt32(NumberOfcubesInput.text) > 0){
    		Mulai = Instantiate(InsertionSort);
    		Mulai.NumberOfCubes = Convert.ToInt32(NumberOfcubesInput.text);
    		Mulai.PlaySortingDSC();
    		flag = false;
            (FPController.GetComponent(scr) as MonoBehaviour).enabled = true;

        }
    }
    public void ResetSort()
    {
    	Destroy(Mulai.gameObject);
    	textComponent.text = "0";
    	textInfo.text = "";
    	flag = true;
        (FPController.GetComponent(scr) as MonoBehaviour).enabled = false;
        FPController.transform.position = new Vector3(0,-1.5f,-12);
    }

    void Start()
    {
    	textInfo = GameObject.Find("info").GetComponent<Text>();
    	textComponent = GameObject.Find("Total").GetComponent<Text>();
                (FPController.GetComponent(scr) as MonoBehaviour).enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
        RenderSettings.skybox.SetFloat("_Rotation",Time.time * speed);
    }
    public void configSpeed(float newSpeed)
    {
      speed = newSpeed;
    }
}
