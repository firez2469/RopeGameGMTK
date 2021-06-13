using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePhysics : MonoBehaviour
{
    public Rigidbody2D rigidbody1;
    public Rigidbody2D rigidbody2;

    public int numberOfSubdivisions = 10;
    float lengthOfSubdivisions = 1;
    public float totalLength = 5f;
    public float subDivisionMass = 0.01f;
    public float frequency = 6;

    List<GameObject> springs = new List<GameObject>();
    [SerializeField]
    private LineRenderer lineRend;
    public float lineWidth = 0.1f;
    public Material lineMaterial;

    public enum RopeSide{LEFT,RIGHT};
    public int physicsDelayTime = 1;
    

	[SerializeField]
	private int ropeLayerIndex;

    [SerializeField]
    private bool isGenerated = false;
    


	// Start is called before the first frame update
	void Start()
    {
        if (!isGenerated)
        {
            GenerateRope();
        }
        else
        {
            getRope();
            physicsDelayTime = 0;
        }
		
    }

    void GenerateRope()
    {
        lengthOfSubdivisions = totalLength / numberOfSubdivisions;
        GameObject rend = new GameObject();
        rend.transform.parent = this.transform;
        rend.name = "Lines";
        lineRend = rend.AddComponent<LineRenderer>();
        lineRend.startWidth = this.lineWidth;
        lineRend.endWidth = this.lineWidth;
        lineRend.material = lineMaterial;
        for (int i = 0; i < numberOfSubdivisions; i++)
        {
            GameObject obj = new GameObject();
			obj.layer = this.ropeLayerIndex;
			obj.name = "Rope Element" + i;
            obj.transform.parent = this.transform;
            Rigidbody2D body = obj.AddComponent<Rigidbody2D>();
            body.mass = subDivisionMass;
            springs.Add(obj);
        }


        for (int i = 0; i < springs.Count; i++)
        {
            if (i == 0)
            {
                applyConnectedBody(i, rigidbody1);
               
            }
            else
            {
                applyConnectedBody(i, springs[i - 1].GetComponent<Rigidbody2D>());
                
              
            }
            if (i == springs.Count - 1)
            {
                applyConnectedBody(i, rigidbody2);
                
            }
            else
            {
                applyConnectedBody(i, springs[i + 1].GetComponent<Rigidbody2D>());
              

            }
            springs[i].AddComponent<CircleCollider2D>().radius = this.lengthOfSubdivisions/2;
            springs[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


        }
        rigidbody1.GetComponent<SpringJoint2D>().connectedBody = springs[0].GetComponent<Rigidbody2D>();
        rigidbody1.GetComponent<SpringJoint2D>().distance = this.lengthOfSubdivisions;


        rigidbody2.GetComponent<SpringJoint2D>().connectedBody = springs[springs.Count - 1].GetComponent<Rigidbody2D>();
        rigidbody2.GetComponent<SpringJoint2D>().distance = this.lengthOfSubdivisions;
    }

    void getRope()
    {
        SpringJoint2D[] ropeElements = transform.GetComponentsInChildren<SpringJoint2D>();
        int count = 0;
        foreach(SpringJoint2D spring in ropeElements)
        {
            springs.Add(spring.gameObject);
            //lineRend.positionCount += 1;
            //lineRend.SetPosition(count,spring.transform.position);
            count++;
        }
    }

    void applyConnectedBody(int i,Rigidbody2D rb)
    {
        SpringJoint2D joint = springs[i].AddComponent<SpringJoint2D>();
        joint.autoConfigureDistance = false;
        joint.connectedBody = rb;
        joint.distance = this.lengthOfSubdivisions;
        joint.frequency = this.frequency;
        joint.dampingRatio = 1;
        joint.gameObject.AddComponent<RopeCollisionsExceptions>();
        joint.enableCollision = true;
        
    }
    public void applyRopeEndTo(RopeSide side,Rigidbody2D rb)
    {
        if (side == RopeSide.LEFT)
        {
            this.rigidbody1.GetComponent<SpringJoint2D>().connectedBody = null;
            this.springs[0].GetComponent<SpringJoint2D>().connectedBody = rb;
            this.rigidbody1 = rb;
        }
        else
        {
            this.rigidbody2.GetComponent<SpringJoint2D>().connectedBody = null;
            this.springs[springs.Count - 1].GetComponent<SpringJoint2D>().connectedBody = rb;
            this.rigidbody2 = rb;
        }
    }

    //rope must already have length.
    public void addLength(int count)
    {
       foreach(GameObject spring in springs)
       {
            spring.GetComponent<CircleCollider2D>().radius *= 1.2f;
            
            foreach(SpringJoint2D joint in spring.GetComponents<SpringJoint2D>())
            {
                joint.distance *= 1.2f;
            } 
       }
    }

    //this method works so long as you never hit zero.
    public void removeLength(int count)
    {

        foreach (GameObject spring in springs)
        {
            spring.GetComponent<CircleCollider2D>().radius /= 1.2f;
            foreach (SpringJoint2D joint in spring.GetComponents<SpringJoint2D>())
            {
                joint.distance /= 1.2f;
            }
        }

    }


    public void attachTo(int side, Rigidbody2D body)
    {
        if (side == 0)
        {
            //rigidbody1.GetComponent<SpringJoint2D>().connectedBody = null;
            rigidbody1.GetComponent<SpringJoint2D>().enabled = false;
            foreach(SpringJoint2D joint in springs[0].GetComponents<SpringJoint2D>())
            {
                if (joint.connectedBody.Equals(rigidbody1))
                {
                    joint.connectedBody = body;
                }
            }
            

        } else if(side == 1)
        {
            rigidbody2.GetComponent<SpringJoint2D>().enabled = false;
            foreach (SpringJoint2D joint in springs[springs.Count-1].GetComponents<SpringJoint2D>())
            {
                if (joint.connectedBody.Equals(rigidbody2))
                {
                    joint.connectedBody = body;
                }
            }
        }
        else
        {
            if (body.Equals(rigidbody1))
            {
                rigidbody1.GetComponent<SpringJoint2D>().enabled = true;
                foreach (SpringJoint2D joint in springs[0].GetComponents<SpringJoint2D>())
                {
                    if (!joint.connectedBody.Equals(springs[1].GetComponent<Rigidbody>()))
                    {
                        joint.connectedBody = body;
                    }
                }
            }
            if (body.Equals(rigidbody2))
            {
                rigidbody2.GetComponent<SpringJoint2D>().enabled = true;
                foreach (SpringJoint2D joint in springs[springs.Count - 1].GetComponents<SpringJoint2D>())
                {
                    if (joint.connectedBody.Equals(springs[springs.Count-2]))
                    {
                        joint.connectedBody = body;
                    }
                }
            }
        }
    }

    float t = 0;
    private void Update()
    {
        lineRend.positionCount = springs.Count + 2;
        lineRend.SetPosition(0, rigidbody1.transform.position);
        for(int i = 0;i<this.springs.Count;i++)
        {
            lineRend.SetPosition(i+1,springs[i].transform.position);
        }
        lineRend.SetPosition(springs.Count+1, rigidbody2.transform.position);
        if (t > physicsDelayTime)
        {
            rigidbody1.constraints = RigidbodyConstraints2D.FreezeRotation;
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        else
        {
            rigidbody1.constraints = RigidbodyConstraints2D.FreezeAll;
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        t += Time.deltaTime;
    }
}