using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text berryCountText;

    public int berryCount;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBerryCountText();

    }


private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Berry"))
    {
        // Increment the berry count
        berryCount++;
        UpdateBerryCountText();
    }
}

public void UpdateBerryCountText()
    {
        berryCountText.text = "" + berryCount.ToString();
    }



    
}
