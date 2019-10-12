using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class HitGoal : MonoBehaviour
{
    public GameObject regionObject;
    public int lastAgentHit;

    private HockeyRegion region;
    private PlayerAgent agentA;
    private PlayerAgent agentB;

    // Use this for initialization
    void Start()
    {
        region = regionObject.GetComponent<HockeyRegion>();
        agentA = region.agentA.GetComponent<PlayerAgent>();
        agentB = region.agentB.GetComponent<PlayerAgent>();


    }

 //   private void OnTriggerEnter(Collider other)
 //   {
 //       if (other.name == "Direction")
 //       {
 //           if (lastAgentHit == 0)
 //           {
 //               agentA.AddReward(0.000000001f);
 //           }
 //           else
 //           {
 //               agentB.AddReward(0.000000001f);
 //           }

//        }
//    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            if (collision.gameObject.name == "Goal1")
            {
                if (lastAgentHit == 0)
                {
                    agentA.AddReward(-0.1f);
                    agentB.SetReward(0.1f);
                    agentB.score += 1;
                    Debug.Log("Score Incremented");
                }
                else
                {
                    agentA.SetReward(0.1f);
                    agentB.AddReward(-0.1f);
                    agentA.score += 1;
                    Debug.Log("Score Incremented");
                }
            }
            else if (collision.gameObject.name == "Goal2")
            {
                if (lastAgentHit == 0)
                {
                    agentB.AddReward(-0.1f);
                    agentA.SetReward(0.1f);
                    agentA.score += 1;
                    Debug.Log("Score Incremented");
                }
                else
                {
                    agentB.SetReward(0.1f);
                    agentA.AddReward(-0.1f);
                    agentB.score += 1;
                    Debug.Log("Score Incremented");
                }
            }


            agentA.Done();
            agentB.Done();
            region.MatchReset();
            Debug.Log(agentA.score);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            lastAgentHit = collision.gameObject.name == "Player1" ? 0 : 1;
        }
    }
}