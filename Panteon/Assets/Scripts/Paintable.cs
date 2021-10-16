using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Paintable : MonoBehaviour
{
    public GameObject Brush;
    public GameObject nextLevelButton;
    public float BrushSize ;
    private float xRange = 14.0f;
    private float yRangeUp = 12.25f;
    private float yRangeDown = 3.2f;
   
  
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) 
                {
                    var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                    go.transform.localScale = Vector3.one * BrushSize;
                  

                }

            }

        StartCoroutine(PaintCo());

    }

    IEnumerator PaintCo()
    {
        yield return new WaitForSeconds(10.0f);
        Brush.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(true);
    }

    public void LoadNextLeve()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // increment the index of scene
    }

}
