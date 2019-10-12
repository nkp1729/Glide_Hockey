using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAgents;


public class PlayerAgent : Agent
{
    public GameObject puck;
    public bool invertX;
    public int score;
    public GameObject myRegion;

    private Text textComponent;
    private Rigidbody agentRb;
    private Rigidbody puckRb;
    private float invertMult;

    // Looks for the scoreboard based on the name of the gameObjects.
    // Do not modify the names of the Score GameObjects
    private const string CanvasName = "Canvas";
    private const string ScoreBoardAName = "ScoreA";
    private const string ScoreBoardBName = "ScoreB";
    private ResetParameters resetParams;

    public override void InitializeAgent()
    {
        agentRb = GetComponent<Rigidbody>();
        puckRb = puck.GetComponent<Rigidbody>();
        var canvas = GameObject.Find(CanvasName);
        GameObject scoreBoard;
        var academy = Object.FindObjectOfType<Academy>() as Academy;
        resetParams = academy.resetParameters;
        if (invertX)
        {
            scoreBoard = canvas.transform.Find(ScoreBoardBName).gameObject;

        }
        else
        {
            scoreBoard = canvas.transform.Find(ScoreBoardAName).gameObject;
        }
        textComponent = scoreBoard.GetComponent<Text>();
      //  AddReward(0.0f);

    }

    public override void CollectObservations()
    {
        AddVectorObs(invertMult * (transform.position.x - myRegion.transform.position.x));
        AddVectorObs(transform.position.z - myRegion.transform.position.z);
        AddVectorObs(invertMult * agentRb.velocity.x);
        AddVectorObs(agentRb.velocity.z);

        AddVectorObs(invertMult * (puck.transform.position.x - myRegion.transform.position.x));
        AddVectorObs(puck.transform.position.z - myRegion.transform.position.z);
        AddVectorObs(invertMult * puckRb.velocity.x);
        AddVectorObs(puckRb.velocity.z);
    }


    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(-0.001f);
        float clampLimit = 100f;
        var moveX = Mathf.Clamp(vectorAction[0], -clampLimit, clampLimit) * invertMult;
        var moveZ = Mathf.Clamp(vectorAction[1], -clampLimit, clampLimit);

 
   //     AddReward(0.0f);
   //     AddReward(0.0f);
     

        //if (moveY > 0.5 && transform.position.y - transform.parent.transform.position.y < -1.5f)
        //{
        //    agentRb.velocity = new Vector3(agentRb.velocity.x, 2f, 0f);
        //}

        float k = Random.Range(0.0f, 1.0f);

        //if (k <= 0.1)
        //{

        //    agentRb.velocity = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f));
        //}
        //else
        //{
        if (puckRb.velocity.x* puckRb.velocity.x+ puckRb.velocity.y* puckRb.velocity.y <= 1.0f)
        {
            puckRb.velocity = new Vector3(puckRb.velocity.x*1.1f, 0f, puckRb.velocity.y * 1.1f);
            if (puckRb.velocity.x * puckRb.velocity.x + puckRb.velocity.y * puckRb.velocity.y <= 0.5f)
            {
                puckRb.velocity = new Vector3(Random.Range(-1.0f, 1.0f), 0f, Random.Range(-1.0f, 1.0f));
            }
        }

            agentRb.velocity = new Vector3(moveX * 3f, 0f, moveZ * 3f);
        //}
        if (!invertX && transform.position.x - transform.parent.transform.position.x < -5.0f*invertMult ||
            invertX && transform.position.x - transform.parent.transform.position.x > 5.0f*invertMult)
        {
            transform.position = new Vector3(-invertMult + transform.parent.transform.position.x,
                                                        transform.position.y,
                                                        transform.position.z);
        }

       

        textComponent.text = score.ToString();
    }

    public override void AgentReset()
    {
        if (invertX)
        {
            Debug.Log("you got here!!");
            invertMult = -1.0f;
        }
        else
        {
            invertMult = 1.0f;
            Debug.Log("you got here!!");
        }
      

        transform.position = new Vector3(-invertMult * Random.Range(-2f, -4f), 0.3f, 0f); 
        //+ transform.parent.transform.position;
        agentRb.velocity = new Vector3(0f, 1f, 0f);
    }

    public void SetHandle()
    {

    }

    public void SetBall()
    {
        
    }

    public void SetResetParameters()
    {
        SetHandle();
        SetBall();
    }


}
