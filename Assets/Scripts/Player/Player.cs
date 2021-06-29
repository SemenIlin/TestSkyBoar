using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                var asteroid = hit.transform.GetComponent<IObstacle>();
                asteroid?.GetBihaviour();

            }
            //asteroid.GetBihaviour();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var asteroid = hit.transform.GetComponent<IObstacle>();
                asteroid?.FullDestoy();

            }
            //asteroid.GetBihaviour();
        }
    }
}
