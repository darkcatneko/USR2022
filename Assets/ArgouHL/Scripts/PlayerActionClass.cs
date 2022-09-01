using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerActionClass : MonoBehaviour
{
    //��controller�]�w��parent
    public PlayerActController parent;
    public GameObject hand;
    //�Ҧ�Action���J(�}�l)�ɳ��|�I�s�@��
    protected virtual void Start()
    {
        //��controller�]�w��parent
        hand = GameObject.FindGameObjectWithTag("hand");
        parent = GetComponent<PlayerActController>();


        Action();
    }

    //�Ҧ�Action���n����function
    protected abstract void Action();
    protected abstract IEnumerator Move();

    public virtual void SkillFinish()
    {
        //��o��script�qobj�W�R��
        Destroy(this);
    }

    public virtual void StopAttack()
    {
        StopCoroutine(Move());
        Destroy(this);
    }
}
