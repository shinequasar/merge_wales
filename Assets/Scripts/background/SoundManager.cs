using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Sound
{
    public String soundName;
    public AudioClip clip;
}



public class SoundManager : MonoBehaviour
{

    //----------------싱글톤
    public static SoundManager instance; // 싱글톤을 할당할 전역변수
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
    
    
    public static SoundManager instence;

    [Header("사운드 등록")] 
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;
    
    [Header("브금 플레이어")] 
    [SerializeField] AudioSource bgmPlayer;

    [Header("효과음 플레이어")] 
    [SerializeField] AudioSource[] sfxPlayer;



    public float BGM;
    public float SFX;
    
    
    void Start()
    {
        
        //세팅에서 파일 받아서 비지엠, 효과음에 넣기
        SettingManager.instance.LoadSettingData();
        inputVolume();
        instence = this;
        PlayBGM();
    }



    public void SetBGMVolume(float volume)
    {
        bgmPlayer.volume = volume;
       // Debug.Log(">>>>> bgmPlayer.volume : "+bgmPlayer.volume+"volume ; "+volume);
        SettingManager.instance.SaveSettingData();
    }
    
    
    public void SetSEVolume(float volume)
    {
        for (int x = 0; x < sfxPlayer.Length; x++)
           {  
               sfxPlayer[x].volume = volume;
           }
        SettingManager.instance.SaveSettingData();
    }
    
    
    public void ToggleBGMVolume(float volume) //토글 BGM 볼륨설정
    {
        if (bgmPlayer.volume != 0)
        {
            BGM = 0;
            bgmPlayer.volume = BGM;
            SettingManager.instance.SaveSettingData();
        }
        else if(bgmPlayer.volume == 0)
        {
            BGM = 1f;
            bgmPlayer.volume = BGM;
            SettingManager.instance.SaveSettingData();
        }
        else
        {
            BGM = volume;
            bgmPlayer.volume = BGM;
            SettingManager.instance.SaveSettingData();
        }
        
    }
    
    public void ToggleSEVolume(float volume)  // 토글 SFX 볼륨설정
    {
        
        
        if (sfxPlayer[0].volume != 0)
        {
            for (int x = 0; x < sfxPlayer.Length; x++)
            {  
                SFX = 0;
                sfxPlayer[x].volume = SFX;
            }
            SettingManager.instance.SaveSettingData();
        }
        else if(sfxPlayer[0].volume == 0)
        {
            for (int x = 0; x < sfxPlayer.Length; x++)
            {
                SFX = 1f;
                sfxPlayer[x].volume = SFX;
            }
            
            SettingManager.instance.SaveSettingData();
        }
        else
        {
            for (int x = 0; x < sfxPlayer.Length; x++)
            {
                SFX = volume;
                sfxPlayer[x].volume = SFX;
            }
            SettingManager.instance.SaveSettingData();
        }
        
    }


    public void inputVolume()
    {
        // json에 저장된 BGM, SFX볼륨
        SetBGMVolume(SettingManager.instance.printBGMf());
        SetSEVolume(SettingManager.instance.printSFXf());
    }
    
    public float printBGM()
    {
        return bgmPlayer.volume;
    }
    
    public float printSFX() 
    {
        return sfxPlayer[0].volume;
    }
   

    public void PlayBGM() // BGM 실행
    {
        bgmPlayer.clip = bgmSounds[0].clip;  //만약 bgm개수가 늘어나면 []안의 변수별로 if문 만들어서 상황별로 재생시키면 될듯
        bgmPlayer.Play();
    }
    
    public void PlaySE(string _soundName) // SFX실행
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (_soundName == sfxSounds[i].soundName)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }

                Debug.Log("모든 효과음 플레이어가 사용 중입니다.");
            }
        }
        Debug.Log("등록된 효과음이 없습니다.");
    }
    
}
