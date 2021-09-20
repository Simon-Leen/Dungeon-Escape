using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnim;
    private SpriteRenderer _spiteRen;
    private SpriteRenderer _swordSpriteRen;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        _spiteRen = GetComponentInChildren<SpriteRenderer>();
        _swordSpriteRen = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    public void Move(float move)
    {
        FlipSprite(move);
        _anim.SetFloat("Speed", Mathf.Abs(move));
    }

    public void Jump(bool canJump)
    {
        _anim.SetBool("Jump", canJump);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnim");
    }

    void FlipSprite(float flipper)
    {
        if (flipper != 0)
        {
            if (flipper > 0)
            {
                _spiteRen.flipX = false;
                _swordSpriteRen.flipY = false;

                Vector3 newPos = _swordSpriteRen.transform.localPosition;
                newPos.x = 0.75f;
                _swordSpriteRen.transform.localPosition = newPos;
            }
            else
            {
                _spiteRen.flipX = true;
                _swordSpriteRen.flipY = true;

                Vector3 newPos = _swordSpriteRen.transform.localPosition;
                newPos.x = -0.75f;
                _swordSpriteRen.transform.localPosition = newPos;
            }
        }
    }
}
