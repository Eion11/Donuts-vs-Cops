using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyValue : MonoBehaviour
{
	public int currency = 0;
	public int MAX_VALUE = 9999;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		GetComponent<Text>().text = currency.ToString();
	}

	public void spendCurrency(int value)
	{
		currency -= value;
	}

	public void gainCurrency(int value)
	{
		currency += value;
	}
}
