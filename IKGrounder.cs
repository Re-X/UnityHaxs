//No animation curves needed

void LegIK()
    {
        anim.bodyPosition = body.transform.position;
		
		//Setting up weights. Just in case.
        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, lGroundWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rGroundWeight);

        RaycastHit2D hitl = Physics2D.Raycast(anim.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down, 1f + DistanceToGround, Walkable);
        
        if (hitl) {
            Vector3 footPosition = hitl.point;
            footPosition.y += DistanceToGround;
            anim.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
        }

        RaycastHit2D hitr = Physics2D.Raycast(anim.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down, 1f + DistanceToGround, Walkable);

        if (hitr)
        {
            Vector3 footPosition = hitr.point;
            footPosition.y += DistanceToGround;
            anim.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
        }
        
        Ground = Physics2D.Raycast(anim.GetIKPosition(AvatarIKGoal.RightFoot), Vector3.down, 5f, Walkable);
        
		//Difference between expected heights of the legs.
		HeightOffset = Mathf.Abs(Physics2D.Raycast(anim.GetIKPosition(AvatarIKGoal.LeftFoot), Vector3.down, 5f, Walkable).point.y - Ground.point.y);
        
		//Settinng the body position to ground the legs.
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.up * (-0.96f - HeightOffset), step);
    }