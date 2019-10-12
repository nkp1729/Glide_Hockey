using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class HockeyAcademy : Academy
{
    public GameObject puck;
    public GameObject GoalA;
    public GameObject GoalB;
    private Rigidbody PuckRb;
    private Rigidbody GoalARb;
    private Rigidbody GoalBRb;
    private HockeyRegion region;
    public GameObject regionObject;
    private PlayerAgent AgentA;
    private PlayerAgent AgentB;


    public override void AcademyReset()
    {
    //    Physics.gravity = new Vector3(0, -9.81f, 0);
    //    PuckRb = puck.GetComponent<Rigidbody>();
    //    GoalARb = GoalA.GetComponent<Rigidbody>();
    //    GoalBRb = GoalB.GetComponent<Rigidbody>();
    //    region = regionObject.GetComponent<HockeyRegion>();
    //    AgentA = region.agentA.GetComponent<PlayerAgent>();
    //    AgentB = region.agentB.GetComponent<PlayerAgent>();
    //    AgentA.SetReward(0.0f);
    //    AgentB.SetReward(0.0f);

    }

    public override void AcademyStep()
    {
 //       var relativePositionPuckGoalA = PuckRb.transform.position - GoalARb.transform.position;
 //       var relativePositionPuckGoalB = PuckRb.transform.position - GoalBRb.transform.position;
 //       AgentA.AddReward(relativePositionPuckGoalA.magnitude/100f);
 //       AgentB.AddReward(relativePositionPuckGoalB.magnitude / 100f);
       
}

}
