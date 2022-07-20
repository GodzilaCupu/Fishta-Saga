using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum controllerType { Mouse, Keyboard };

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Controller Type")]
    [SerializeField] private controllerType _controlOption;

    [Space(10)]
    [Header("Player Component")]
    [SerializeField] private Animator playerAnim;
    [SerializeField] private float playerSpeed = 2;
    [SerializeField] private bool isImun;
    private int score;

    private CapsuleCollider2D _playerCollider;
    private Vector2 _startPlayerPos;
    private Vector2 _newPlayerPos;
    // private Rigidbody2D rb;

    private SpriteRenderer _playerSprite;
    private bool isPaused;

    [Header("Sound Effect")]
    public AudioClip ikanKecil;
    public AudioClip ikanBesar;
    public AudioClip sampah;
    public AudioClip achivement;

    void Awake()
    {
        _playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        _newPlayerPos = transform.position;
        // rb = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        EventManager.current.onOpenPaused += Paused;
        EventManager.current.onClosePaused += UnPaused;

        // HealthHandler.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        EventManager.current.onOpenPaused -= Paused;
        EventManager.current.onClosePaused -= UnPaused;

        // HealthHandler.OnPlayerDeath -= DisablePlayerMovement;
    }

    private void Update()
    {
        if (isPaused)
            return;

        GetControlType(_controlOption);
    }

    private void FixedUpdate()
    {
        CheckImun(isImun);
    }

    #region Movement Player
    private void ResetPositionPlayer() => transform.position = new Vector2(0, 0);

    private void MouseMovement()
    {
        _startPlayerPos = transform.position;
        if (Input.GetMouseButtonDown(0))
            _newPlayerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.MoveTowards(transform.position, _newPlayerPos, playerSpeed * Time.deltaTime);
        CheckFlip(_startPlayerPos, transform.position);
        PlayAnimation_Swim(_newPlayerPos);
    }

    private void KeyboardMovement()
    {
        _startPlayerPos = transform.position;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        _newPlayerPos = new Vector2(moveX, moveY);

        transform.Translate(_newPlayerPos * playerSpeed * Time.deltaTime);
        CheckFlip(_startPlayerPos, transform.position);
        PlayAnimation_Swim(_newPlayerPos);
    }

    private void CheckFlip(Vector2 lastPos, Vector2 newPos)
    {
        if (lastPos.x < newPos.x)
        {
            _playerSprite.flipX = true;
            return;
        }

        if (lastPos.x > newPos.x)
        {
            _playerSprite.flipX = false;
            return;
        }
    }

    private void GetControlType(controllerType type)
    {
        switch (type)
        {
            case controllerType.Keyboard:
                KeyboardMovement();
                //KeyboardMovementRB();
                break;

            case controllerType.Mouse:
                MouseMovement();
                break;

            default:
                Debug.Log("ur key can't be emptry");
                break;
        }
        Debug.Log($"control type : {type}");
    }
    #endregion 

    public void CheckImun(bool isImun) => _playerCollider.enabled = isImun ? false : true;

    #region Player Health
    public void GetHurt() => EventManager.current.SubtractPlayerHealth(1);
    public void AddHealth() => EventManager.current.AddingPlayerHealth(1);

    #endregion

    #region Paused
    private void Paused() => isPaused = true;
    private void UnPaused() => isPaused = false;
    #endregion

    #region Animation
    private void PlayAnimation_Swim(Vector2 Playerpos)
    {
        if (Playerpos != Vector2.zero)
        {
            playerAnim.SetBool("Swim", true);
            return;
        }
        playerAnim.SetBool("Swim", false);
    }

    private void PlayAnimtion_Imun() => playerAnim.SetTrigger("Imun");

    private void PlayAnimation_Flicker() => playerAnim.SetTrigger("Flicker");
    #endregion

    #region Collision

    private void OnCollisionEnter2D(Collision2D other)
    {
        // ikan kecil
        if (other.gameObject.tag == "Ikan_Kecil")
        {
            AddHealth();
            Destroy(other.gameObject);
            score += 1;
            EventManager.current.AddPlayerScore(1);
            AudioManager.instance.PlaySound(ikanKecil);
            Debug.Log($"This Eat Fish ");

            // AudioSource.PlayClipAtPoint(ikanKecil, transform.position, volumeSound);
            // ParticleFromPlayer.instance.PlayParticle();
        }

        // ikan besar
        if (other.gameObject.tag == "Ikan_Besar")
        {
            GetHurt();
            ResetPositionPlayer();
            StartCoroutine(StartTimer_Imun(3f));
            Debug.Log($"This been eaten");

            AudioManager.instance.PlaySound(ikanBesar);
        }

        // drum
        if (other.gameObject.tag == "Drum")
        {
            GetHurt();
            StartCoroutine(StartTimer_Imun(3f));
            Debug.Log($"This been Attack by drum");

            AudioManager.instance.PlaySound(sampah);
        }

        // jangkar
        if (other.gameObject.tag == "Anchor")
        {
            GetHurt();
            StartCoroutine(StartTimer_Imun(2f));
            Debug.Log($"This been Attack by Anchor");
            AudioManager.instance.PlaySound(sampah);
        }

        // Achivement perl
        if (other.gameObject.tag == "Perl")
        {
            int perl = Database.GetPlayerAchivement("Perl");
            Database.SetPlayerAchivement("Perl", perl + 1);
            Destroy(other.gameObject);
            Debug.Log($" You got Perl");
            AudioManager.instance.PlaySound(achivement);
        }

        // Achivement Starfish
        if (other.gameObject.tag == "Starfish")
        {
            int starfish = Database.GetPlayerAchivement("Starfish");
            Database.SetPlayerAchivement("Starfish", starfish + 1);
            Destroy(other.gameObject);
            Debug.Log($"You got Starfish");
            AudioManager.instance.PlaySound(achivement);
        }

        // Achivement Shell
        if (other.gameObject.tag == "Shell")
        {
            int shell = Database.GetPlayerAchivement("Shell");
            Database.SetPlayerAchivement("Shell", shell + 1);
            Destroy(other.gameObject);
            Debug.Log($"Shell");
            AudioManager.instance.PlaySound(achivement);
        }


    }
    #endregion

    IEnumerator StartTimer_Imun(float time)
    {
        isImun = true;
        PlayAnimtion_Imun();
        yield return new WaitForSeconds(time);
        PlayAnimation_Flicker();
        isImun = false;
    }

    public void DisablePlayerMovement()
    {
        Destroy(GetComponent<PlayerController>());
        Destroy(gameObject);
        // playerAnim.enabled = false;
        // rb.bodyType = RigidbodyType2D.Static;
    }

    void EnablePlayerMovement()
    {
        // playerAnim.enabled = true;
        // rb.bodyType = RigidbodyType2D.Dynamic;
    }

}
