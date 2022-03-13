using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointScript : MonoBehaviour
{
     public Animator anim;
     public AudioSource Clapping;
     // private static IDictionary<int, IList<GameObject>> layersCache = new Dictionary<int, IList<GameObject>>();
     private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {   Debug.Log(" eee");
        
            anim.SetBool("IsFlagOut",true); 
            Clapping.Play();
            
            // else{
            //     Debug.Log("Still enemies are alive");
            // }
        }
    }

    //  public static bool FindWithLayer(int layer)
    //  {
    //      var cache = layersCache[layer];
    //      if (cache != null && cache.Count > 0)
    //          return true;
    //      else
    //          return false;
    //  }
}
