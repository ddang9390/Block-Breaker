using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private int hitCount;

    public AudioClip crack;
    public Sprite[] hitSprites;

    private LevelManager levelManager;

    public static int breakableCount = 0;
    private bool isBreakable;

    public GameObject smoke;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");

        //Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        hitCount = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isBreakable)
        {
            handleHits();
        }
    }

    void handleHits()
    {
        //UnassignedReferenceException: The variable crack of Brick has not been assigned.
        AudioSource.PlayClipAtPoint(crack, transform.position);

        hitCount++;
        int maxHits = hitSprites.Length + 1;
        if (maxHits <= hitCount)
        {
            breakableCount--;
            if (breakableCount <= 0)
            {
                levelManager.loadNextLevel();
            }
            //smoke appears when brick destroyed
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
            ParticleSystem.MainModule  mainSystem = smokePuff.GetComponent<ParticleSystem>().main;
            //smoke color same as brick color
            mainSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
            

            Destroy(gameObject);
        }
        else
        {
            loadSprites();
        }
    }

    void loadSprites()
    {
        int spriteIndex = hitCount - 1;
        if (hitSprites[spriteIndex] != null) { 
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite missing");
        }
    }

}
