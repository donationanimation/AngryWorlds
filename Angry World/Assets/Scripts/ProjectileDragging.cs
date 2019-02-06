using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour
{

    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;


    private Rigidbody2D projectile;
    private Transform catapult;
    private SpringJoint2D spring;
    private bool clickedOn = false;
    private Ray rayToMouse;
    private Ray leftCatapultToProjectile;
    private float maxStretchSqr;
    private float circleRadius;
    private Vector3 prevVelocity;

    public void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        catapult = spring.connectedBody.transform;
    }

    void Start()
    {
        projectile = GetComponent<Rigidbody2D>();
        LineRendererSetup();
        rayToMouse = new Ray(catapult.position, Vector3.zero);
        leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
        maxStretchSqr = maxStretch * maxStretch;
        circleRadius = GetComponent<CircleCollider2D>().radius;

        projectile.isKinematic = true;
    }

    void Update()
    {
        if (clickedOn)
        {
            Dragging();
        }

        if (spring != null)
        {
            if (!projectile.isKinematic && prevVelocity.sqrMagnitude > projectile.velocity.sqrMagnitude)
            {
                Destroy(spring);
                projectile.velocity = prevVelocity;
                EventManager.TriggerEvent("ProjecttileThrowed");
            }

            if (!clickedOn)
            {
                prevVelocity = projectile.velocity;
            }

            LineRendererUpdate();
        }
        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
    }

    void LineRendererSetup()
    {
        catapultLineFront.enabled = true;
        catapultLineBack.enabled = true;

        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "Foreground";
        catapultLineBack.sortingLayerName = "Foreground";

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;
    }

    private void OnMouseDown()
    {
        //spring.enabled = false;
        clickedOn = true;
    }

    private void OnMouseUp()
    {
        //spring.enabled = true;
        projectile.isKinematic = false;
        clickedOn = false;
    }

    private void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
        if (catapultToMouse.sqrMagnitude > maxStretchSqr)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }
        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }

    private void LineRendererUpdate()
    {
        Vector2 catapultToProjectile = this.transform.position - catapultLineFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);
    }
}
