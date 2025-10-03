using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    Scroll current;
    Scroll previous;
    public void ActivarRespawn(Scroll a) 
    {
        if (current == null) { ActivarPorPrimeraVez(a); return; }
        previous = current;
        current = a;
        

    }
    public void ActivarPorPrimeraVez(Scroll a) => current = a;
    

}
