using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ZepCam : MonoBehaviour
{
    [SerializeField] private Transform targetTr;
    [SerializeField] private Camera cam;
    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, targetTr.position);

        bool[] boundCheck = CheckBoundary();

        Vector2 currPos = Vector2.Lerp(transform.position,targetTr.position, dist/50f);
        currPos.y = !boundCheck[0] && currPos.y < targetTr.position.y ? transform.position.y : currPos.y ;
        currPos.y = !boundCheck[1] && currPos.y > targetTr.position.y ? transform.position.y : currPos.y ;
        currPos.x = !boundCheck[2] && currPos.x < targetTr.position.x ? transform.position.x : currPos.x ;
        currPos.x = !boundCheck[3] && currPos.x > targetTr.position.x ? transform.position.x : currPos.x ;
        
        currPos.x -= transform.position.x;
        currPos.y -= transform.position.y;
        transform.position += new Vector3(currPos.x, currPos.y,0);
        
    }
    #region 카메라바운더리체크

    //{(1,1),(0,0)}
    private Vector2[] GetMaxMin()
    {
        Vector2 max = cam.ViewportToWorldPoint(Vector2.one);
        Vector2 min = cam.ViewportToWorldPoint(Vector2.zero);
        return new Vector2[2] {max,min};
    }
    public RayGrid GetRays()
    {
        Vector2[] maxMin = GetMaxMin();
        Vector2[] origin = new Vector2[4] { maxMin[0], maxMin[1], maxMin[0], maxMin[1] };
        Vector2[] dirr = new Vector2[4] { Vector2.left, Vector2.right, Vector2.down, Vector2.up };
        return new RayGrid(origin,dirr, Mathf.Abs(maxMin[0].x- maxMin[1].x), Mathf.Abs(maxMin[0].y - maxMin[1].y));
    }
    /// <summary>
    /// up ,down,right,left방향 제어
    /// </summary>
    /// <returns></returns>
    public bool[] CheckBoundary()
    {
        RayGrid grid = GetRays();
        bool[] result = new bool[4] { false,false,false,false};
        for (int i = 0; i < grid.origins.Length; i++)
        {
            if (Physics2D.Raycast(grid.origins[i], grid.dirr[i],(grid.dirr[i].x != 0  ? grid.width:grid.height),1<<3))
            {
                result[i] = true;
                Debug.Log(i);
            }
        }
        return result;
    }
    #endregion
    public class RayGrid
    {
        public Vector2[] origins;
        public Vector2[] dirr;
        public float width;
        public float height;
        public RayGrid(Vector2[] origin, Vector2[] dirr, float width,float height)
        {
            this.origins = origin;
            this.dirr = dirr;
            this.width = width;
            this.height = height;
        }
    }
}
