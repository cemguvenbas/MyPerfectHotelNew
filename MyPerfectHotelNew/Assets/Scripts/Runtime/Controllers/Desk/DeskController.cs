using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskController : MonoBehaviour
{
    [Header("Serialized Variables")]
    [SerializeField] private GameObject dollar;
    [SerializeField] private Transform dollarPlace;

    [Header("Private Variables")]
    private float _yAxis;

    public IEnumerator MakeMoney(){
        var counter = 0;
        var dollarPlaceIndex = 0;

        yield return new WaitForSecondsRealtime(2);

        while(counter < transform.childCount){
            GameObject NewDollar = Instantiate(dollar, new Vector3(dollarPlace.GetChild(dollarPlaceIndex).position.x,
                    _yAxis, dollarPlace.GetChild(dollarPlaceIndex).position.z),
                dollarPlace.GetChild(dollarPlaceIndex).rotation);
            
            if (dollarPlaceIndex < dollarPlace.childCount - 1)
            {
                dollarPlaceIndex++;
            }
            else
            {
                dollarPlaceIndex = 0;
                _yAxis += 0.5f;
            }
            
            yield return new WaitForSecondsRealtime(3f);
        }
    }
}
