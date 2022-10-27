using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatchController : MonoBehaviour
{
    [SerializeField] private Transform catchPoint;
    [SerializeField] private SwipeDetection swipeDetection;
    [SerializeField] private GameDataCtr gameDataCtr;
    [SerializeField] private Animator handAnimator;

    private GameObject lookAtGoods;
    private GameObject holdingGoods;

    public float catchDistance = .5f;
    public float rotateSpeed = 1f;

    public Coroutine coroutine;

    void Start()
    {
       
    }

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 40f);     //偵測有沒有看著貨物
        RaycastHit hit;
        


        if (holdingGoods == null && Physics.Raycast(ray, out hit, 40f,1<<8)) 
        {
            lookAtGoods = hit.collider.gameObject;
            
           
        }
        else
        {
            lookAtGoods = null;
            
        }

        if (lookAtGoods != null && Vector3.Distance(lookAtGoods.transform.position, Camera.main.transform.position) <= catchDistance)   //如果看著貨物又離手很近則接住貨物
        {

            handAnimator.transform.rotation = Quaternion.Euler(-120, 0, 0);
            StopCoroutine("RotateHand");
            holdingGoods = lookAtGoods;
            holdingGoods.GetComponent<GoodsMovement>().Catched();
            holdingGoods.transform.position = catchPoint.transform.position;
            holdingGoods.transform.parent = catchPoint;
            handAnimator.SetTrigger("catch");
           
        }

        if (holdingGoods != null) //如果拿著貨物則判斷滑動方向
        {
            _GoodsType holdingGoodsType = holdingGoods.GetComponent<GoodsData>().goodsType;

            if (swipeDetection.isSwiped) //是否滑動
            {
                switch (swipeDetection.swipeDirectionType)
                {
                    case SwipeDetection.SwipeDirectionType.Up:
                        if (holdingGoodsType == _GoodsType.Lantern)
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        else
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        handAnimator.SetTrigger("putDown");
                        Destroy(holdingGoods);
                        holdingGoods = null;
                        break;
                    case SwipeDetection.SwipeDirectionType.Down:
                        if (holdingGoodsType == _GoodsType.Jar)
                        {
                            gameDataCtr.GetMoney(1);
                        }
                        else
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        handAnimator.SetTrigger("putDown");
                        Destroy(holdingGoods);
                        holdingGoods = null;
                        break;
                    case SwipeDetection.SwipeDirectionType.Left:
                        if (holdingGoodsType == _GoodsType.Cloth)
                        {
                            gameDataCtr.GetMoney(1);
                        }
                        else
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        coroutine = StartCoroutine("RotateHand", -rotateSpeed);
                        handAnimator.SetTrigger("putDown");
                        Destroy(holdingGoods);
                        holdingGoods = null;
                        break;
                    case SwipeDetection.SwipeDirectionType.Right:
                        if (holdingGoodsType == _GoodsType.Suger)
                        {
                            gameDataCtr.GetMoney(1);
                        }
                        else
                        {
                            gameDataCtr.GetMoney(0);
                        }
                        coroutine = StartCoroutine("RotateHand", rotateSpeed);
                        handAnimator.SetTrigger("putDown");
                        Destroy(holdingGoods);
                        holdingGoods = null;
                        break;
                }
            }
            
        }

        swipeDetection.isSwiped = false;
    }

    private IEnumerator RotateHand(float rotateSpeed)
    {
        
        int frame = 0;
        while (frame <= 15) 
        {
            handAnimator.transform.rotation = Quaternion.Euler(handAnimator.transform.rotation.eulerAngles + Vector3.up * rotateSpeed*4);
            frame ++;
            yield return new WaitForEndOfFrame();
        }
        frame = 0;
        while (frame <= 15)
        {
            handAnimator.transform.rotation = Quaternion.Euler(handAnimator.transform.rotation.eulerAngles + Vector3.up * -rotateSpeed*4);
            frame++;
            yield return new WaitForEndOfFrame();
        }
        StopCoroutine(coroutine);
    }
}
