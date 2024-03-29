﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleDB : MonoBehaviour
{
  
  //----------------싱글톤
  public static WhaleDB instance; // 싱글톤을 할당할 전역변수
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
  
  string[] whaleName = new string[60]
  {
    "아기고래","고래곤졸라","배틀고래운드","고래미어워드상","돌고래",
    "영어 잘할 것 같고래","피타고래스","X-ray 고래","누가 소리를 내었고래","인어고래",
    "유령고래","술고래","고랜데말입니다","고래고래","미라고래",
    "양반고래","방전직전고래","고레몬","고래밥","화석학번고래",
    "봉고래파스타","상상도 못한 고래","씰룩씰룩냥고래","거북선고래","막장드라마 놀랄때고래",
    "덩실덩실고래","난다고래", "다빈치고래", "힙합고래","아무것도 하기 싫고래", 
    "안녕히계세요 여러분고래","비너스의 탄생고래","의리고래","이불밖은 위험해고래","마이클잭슨고래",
    "계획대로복면고래","고래비티","진주목걸이를 한 고래","득도고래","레이싱고래",
    "불고래","절규고래","삐에로고래","포토고래퍼","고래노사우르스",
    "외계고래","흰수염고래","혹등고래","참고래","향유고래",
    "밍크고래","망치고래","북태평양 참고래","흰돌고래","북극고래",
    "범고래","귀신고래","외뿔고래","끈모양이빨고래","까치돌고래"
  };

  string[] whaleProfile = new string[]
  {
    "갓 태어난 아기고래. 순수한 눈빛이 사랑스럽다.",
    "이탈리아에서 온 유학파 고래.",
    "다른 고래들이 크릴새우를 먹을 때 혼자 치킨을 찾는 신기한 고래.",
    "100년에 1번씩 열리는 전대양노래자랑에서 가장 우수한 고래에서 주는 전설의 상. 초대 주최자의 모습을 본따 만들었다는 설이 전해진다.",
    "언제나 무표정에 딱딱한 고래처럼 보이지만 사실 여린 마음을 가진 고래. 쑥스러움이 많아 누군가 먼저 말을 걸어주길 기다린다.",
    "주변 친구들에게 너도 할 수 있다고 기운을 북돋아주는 고래. 어느 날부턴가 영어실력이 늘어 비결이 뭔지 궁금하다.",
    "고래마을의 1-2위를 타투는 천재. 직각삼각형만 보면 달려가는 습성이 있다. 요즘엔 철학에 빠진 듯 하다.",
    "친절하고 전문적인 실력으로 고래마을의 의사를 담당하고 있다. 겉과 속이 같아 마을 사람들이 믿고 따른다.",
    "기침소리에 예민한 고래. 조그만 소음에도 성을 내며 누가 그랬냐고 따진다. 최근 고래아파트에 살기 시작하여 층간소음을 겪고 있다고..",
    "전설의 인어공주를 찾아 헤매는 인어고래. 동화와 관련된 이야기를 잘 알아 마을 아기고래들에게 인기가 많다. ",
    "고래 마을의 놀이동산 귀신의 집에 종종 출몰한다는 유령고래. 귀여운 외모를 가지고 있지만, 소문이 심상치 않다. 어떤 비밀을 가지고 있을까..",
    "항상 한손엔 술을 들고 취해있는 고래. 맨정신인 적을 본 고래가 없다고,, 무슨 일이 있던 걸까?",
    "9시 고래뉴스 앵커이자 취재기자. 최근엔 유령고래와 어렵게 인터뷰를 해 유령고래는 귀신의집 알바생이라는걸 밝혀냈다. 어? 근데 그 놀이동산은 문을 닫았는데..",
    "락을 즐기는 고래. 목소리가 매우 커서 고래마을 안내방송을 할때 확성기 역할을 톡톡히 한다.",
    "온 몸에 붕대를 두르고 있는 고래. 붕대 속에는 엄청난 미모를 감추고 있다거나, 무서운 외양을 감추고 있다는 소문이 있다. ",
    "고지식하기로 소문난 고래마을의 어르신. 고집이 많으시고 융통성은 없지만 누구보다 고래마을을 아낀다.",
    "멘탈도, 체력도 항상 아슬아슬한 고래. 아 이것도 해야하고 저것도 해야하고!! 바쁘다바빠! 쉬는 법을 누가 알려줘!",
    "외양은 상큼하고 귀엽지만 입담이 살벌하다. 마음에 들지 않으면 알파카마냥 새콤한 물분수를 쏜다. 눈에 들어가면 매우 따가우니 까탈스러운 그녀의 심기를 거스르지 말길.",
    "고래밥(더 이상의 설명은 생략한다.)",
    "휴학하면 휴하학 휴하학 웃는다고들 하지. 나도 그랬었는데,, 휴하학 휴하학 즐기다보니 화석학번이 되었고래. 화석이라고 어려워하지 말라고래들... ",
    "중후한 초음파소리가 매력적인 고래. 최근에 차린 식당이 매우 잘되어서 셰프로서의 입지가 탄탄해지는 중. ",
    "사소한 것에도 깜짝 놀라는 소심한 고래. 놀랄 때 특유의 포즈가 인상적이다. 상상도 못한 포즈.",
    "한번도 못 볼수는 있어도 한번만 본 사람은 없다는 고래. 계속 보게되는 묘한 매력을 가졌다. ",
    "카리스마+총명함을 고루 갖춘 고래마을의 치안담당. 양반고래 못지않게 마을을 사랑하며, 언제나 한결같은 자세로 고래마을을 위해 힘써주는 감사한 고래.",
    "아침마다 방영되는 드라마를 보는 것이 가장 중요한 하루 일과이다. 상상도 못한 고래와 절친이며 함께 드라마를 보며 항상 놀란다.",
    "현재 양반고래가 키우며, 아직 서당개,,아니 서당고래 2년차라 천자문은 아직 못떼었다. 동네 친구인 씰룩씰룩냥과는 앙숙이지만 내심 서로를 아낀다.",
    "난다. 진짜 난다. 믿기진 않겠지만 나는 고래.", 
    "만능이라는 말이 누구보다 잘어울리는 고래. 악기도, 요리도, 그림도, 발명도 못하는게 없다. 고래마을의 엔지니어!", 
    "자유로움의 대명사. MBTI 검사 타입에서 처음이 E로 시작할 것 같은 외향적인 고래. 하지만 남들은 모르는 여린마음을 감추려 하다보니 외향적으로 보이는 것 같기도 하다.",
    "'...'(자기소개도 귀찮은 상태)", 
    "항상 어디론가 사라진다. 다음날이면 다시 돌아오긴 하는데 자꾸 떠난다. 이 세상의 모든 속박과 굴레를 벗어던지고 제 행복을 찾아 떠납니다. 여러분도 행복하세요!",
    "너무나 아름다운 고래. ",
    "의리고래",
    "이불밖은 위험해고래",
    "마이클잭슨고래",
    "계획대로복면고래",
    "고래비티",
    "진주목걸이를 한 고래",
    "득도고래",
    "레이싱고래",
    "불고래",
    "절규고래",
    "삐에로고래",
    "포토고래퍼",
    "고래노사우르스",
    "외계고래",
    "흰수염고래",
    "혹등고래",
    "참고래",
    "향유고래",
    "밍크고래",
    "망치고래",
    "북태평양 참고래",
    "흰돌고래",
    "북극고래",
    "범고래",
    "귀신고래",
    "외뿔고래",
    "끈모양이빨고래",
    "까치돌고래"
  };
  public string WhaleName(int level)
  {
    return whaleName[level];
  }
  
  public string WhaleProfile(int level)
  {
    return whaleProfile[level];
  }
  
}