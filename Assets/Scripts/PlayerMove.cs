using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool changing = false;

    //사운드 설정
    public AudioClip clip;

    //세팅 메인 창
    public GameObject Setting = null;

    //PlayerState playerState = null;
    public GameObject Cube = null;  //기본 캐릭터
    public GameObject Sphere = null; //두번째 캐릭터
    public GameObject Capsule = null; //세번째 캐릭터

    //다음 캐릭터 카드 이미지 게임오브젝트
    public RectTransform Card1 = null; //기본 캐릭터
    public RectTransform Card2 = null; //두번째 캐릭터
    public RectTransform Card3 = null; //세번째 캐릭터
    //카드 위치 
    private float cardx1 = 0.0f; // 카드의 처음 자리 x 값
    private float cardz1 = 0.0f; // 카드의 처음 자리 z 값
    //private float cardx2 = 0.0f;
    //private float cardz2 = 0.0f;
    private float cardx3 = 0.0f; // 카드의 마지막 자리 x 값
    private float cardz3 = 0.0f; // 카드의 마지막 자리 z 값

    //캐릭터 회전 감도.
    public float sensitivity = 2.0f;
    //케릭터 이동 방향
    Vector3 moveDirection = Vector3.zero;
    
    CharacterController characterController = null;
    //Rigidbody rb = null; //추후에 질량을 바꿀때 사용
    //public GameObject Player;
    public Transform cameraTransform;
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -20.0f;
    public float jumpCountMax = 1.0f;
    public float rotationKey = 3.0f; //캐릭터의 회전 크기(높일수록 더 많이 회전)
    private float jumpCount = 0.0f;
    int i = 0; //캐릭터 변화 확인 함수

    private float yVelocity = 0.0f;

    //케릭터 조이스틱 방향 바꾸기 함수
    private float h = 0.0f;

    //다른 스크립트에서 사용하기 위해 싱글톤 화
    public static PlayerMove instance;

    // Use this for initialization
    void Start()
    {
        PlayerMove.instance = this;
        characterController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>(); //추후에 질량을 바꿀때 사용
        //playerState = GetComponent<PlayerState>();//플레이어 컴포넌트 얻어오기

        //최초 위치 저장 함수 //화면 크기에 따라 값이 달라지기 때문에 특정 함수에 저장.
        cardx1 = Card1.position.x;
        cardz1 = Card1.position.z;
        cardx3 = Card3.position.x;
        cardz3 = Card3.position.z;
    }

    //private void OnCollisionEnter(Collision collision) //특정 오브젝트와 충돌시 리지드바디 수정 부분
    //{
    //    //Debug.Log(collision.gameObject.name);
    //    if (collision.gameObject.layer == 15)
    //    {
    //        rb.mass = 100;
    //        Debug.Log("충돌함ㅇㅇㅇㅇㅇㅇ");
    //    }

    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject.name == "GoalInPoint");
    //    Time.timeScale = 0.0f;
    //    //StopAllCoroutines();
    //    Setting.SetActive(true);
    //}
    public void OnChangeDown()
    {
        changing = !changing;
        AudioManager.instance.PlaySfx(clip);
        if (changing == true)
        {
            i++;
            if (i == 1)
            {
                jumpCountMax = 2.0f;
                Cube.SetActive(false);
                Sphere.SetActive(true);
                Capsule.SetActive(false);
            }
            else if (i == 2)
            {
                jumpCountMax = 0.0f;
                Cube.SetActive(false);
                Sphere.SetActive(false);
                Capsule.SetActive(true);
            }
            else if (i == 3)
            {
                jumpCountMax = 1.0f;
                Cube.SetActive(true);
                Sphere.SetActive(false);
                Capsule.SetActive(false);
                i = 0;
            }

            //게임오브젝트 위치 변환을 위한 임시 함수 선언
            Vector3 temp1 = Card1.position;
            Vector3 temp2 = Card2.position;
            Vector3 temp3 = Card3.position;

            //카드 1 옮기기
            temp1.x -= 50;
            temp1.z += 1;
            if (temp1.x < cardx1 && temp1.z > cardz1)
            {
                temp1.x = cardx3;
                temp1.z = cardz3;
            }
            Card1.position = new Vector3(temp1.x, temp1.y, temp1.z);

            //카드 2 옮기기
            temp2.x -= 50;
            temp2.z += 1;
            if (temp2.x < cardx1 && temp2.z > cardz1)
            {
                temp2.x = cardx3;
                temp2.z = cardz3;
            }
            Card2.position = new Vector3(temp2.x, temp2.y, temp2.z);

            //카드 3 옮기기
            temp3.x -= 50;
            temp3.z += 1;
            if (temp3.x < cardx1 && temp3.z > cardz1)
            {
                temp3.x = cardx3;
                temp3.z = cardz3;
            }
            Card3.position = new Vector3(temp3.x, temp3.y, temp3.z);

            //Debug.Log("temp : " + temp1 + "\ntemp2 : " + temp2 + "\ntemp3 : " + temp3);
        }
    }

    public void OnChangeUp()
    {
        changing = false;
    }




    //float h, v;
    //public void OnStickChanged(Vector2 stickPos) //좌측 터치패드
    //{
    //    v = (stickPos.y * -1.0f) * 30.0f; //터치 패드 상, 하 값
    //    Debug.Log("v : " + v);
    //    Vector3 temp = transform.eulerAngles;
    //    transform.eulerAngles = new Vector3(temp.x, v, temp.z);

    public void OnStickChanged(Vector2 stickPos, int num) //터치패드
    {
        h = (stickPos.y * num) * sensitivity; //터치 패드 상, 하 값
        Vector3 temp = transform.eulerAngles;
        float tempNum = (temp.y + h);
        transform.eulerAngles = new Vector3(temp.x, tempNum, temp.z);
    }
    
    void Update()
    {
        if (SettingManager.gameSetting)
        {
            return;
        }

        //자동 카메라 앞방향으로 이동할때
        if (PlayerState.GoalIn)
        {
            moveDirection = Vector3.zero;
        }
        else
        {
            moveDirection = Vector3.forward;
        }
        moveDirection = cameraTransform.TransformDirection(moveDirection);
        if (PigTrigger.PigisTruePlayer|| PanguinTrigger.PanguinisTruePlayer || BirdTrigger.BirdisTruePlayer)
        {
            moveSpeed += 0.5f;
        }
        moveDirection *= moveSpeed;
        if (characterController.isGrounded == true)
        {
            //Debug.Log("땅에 닿음...");
            yVelocity = 0.0f;
            jumpCount = 0.0f;
        }

        //키를 누르고 있을때
        //if (Input.GetKey(KeyCode.E))
        //{
        //    Vector3 temp = transform.eulerAngles;
        //    transform.eulerAngles = new Vector3(temp.x, (temp.y + rotationKey) % 360, temp.z);
        //    //Debug.Log("tmp.y : " + temp.y);
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    Vector3 temp = transform.eulerAngles;
        //    transform.eulerAngles = new Vector3(temp.x, (temp.y - rotationKey) % 360, temp.z);
        //    //Debug.Log("tmp.y : " + temp.y);
        //}
       
        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            yVelocity = jumpSpeed;
            jumpCount++;
        }
        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;
        if (yVelocity <= -20.0f || yVelocity >= 15.0f)
        {
            moveDirection = Vector3.zero;
            transform.position = new Vector3(0.0f, 1.0f, -3.0f);
            yVelocity = 0.0f;
        }
        characterController.Move(moveDirection * Time.deltaTime);
        //Debug.Log("jumpCount : " + jumpCount + " jumpCountMax : " + jumpCountMax + " yVelocity : " + yVelocity);
        //Debug.Log(" yVelocity : " + yVelocity);
    } // End of Update
}
