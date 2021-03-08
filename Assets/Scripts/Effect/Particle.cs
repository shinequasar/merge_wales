using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    //----------------싱글톤
    public static Particle instance; // 싱글톤을 할당할 전역변수
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //-----------------------
    
    public ParticleSystem particle;
    
    public void particles()
    {
        // 파티클이 있고
        if (particle)
        {
            // 파티클이 재생중이면 재생을 멈추고 지워주기
            if (particle.isPlaying == true)
            {
                particle.Stop();  
 
                //Debug.Log("STOP");
            }
            // 재생중이 아니라면 재생
            else
            {
                particle.Play();
 
                //Debug.Log("PLAY");
            }
        }
    }
}
