using System;
using System.Collections;
using System.Collections.Generic;

namespace BadAssTanks
{
    public class BoundingShape2D
    {
        //public struct Edge
        //{
        //    public MathHandler pointA, pointB;

        //    public Edge(MathHandler pointA, MathHandler pointB)
        //    {
        //        this.pointA = pointA;
        //        this.pointB = pointB;
        //    }
        //}

        //private List<MathHandler> m_points = null;
        //private List<MathHandler> m_originalPoints = new List<MathHandler>();
        //private List<Edge> m_edges = null;

        //private MathHandler m_totalTranslation = new MathHandler(0.0f, 0.0f);

        //public List<MathHandler> POINTS
        //{
        //    get { return m_points; }
        //}

        //public List<Edge> EDGES
        //{
        //    get { return m_edges; }
        //}

        //public MathHandler CENTER
        //{
        //    get
        //    {
        //        float totalX = 0;
        //        float totalY = 0;

        //        for (int pointsCount = 0; pointsCount < m_points.Count; pointsCount++)
        //        {
        //            totalX += m_points[pointsCount].X;
        //            totalY += m_points[pointsCount].Y;
        //        }

        //        return new MathHandler(totalX / (float)m_points.Count, totalY / (float)m_points.Count);
        //    }
        //}

        ///// <summary>
        ///// Default constructor.
        ///// </summary>
        //public BoundingShape2D(List<MathHandler> points)
        //{
        //    m_points = points;

        //    if (m_points != null)
        //    {
        //        for (int pointsCount = 0; pointsCount < m_points.Count; pointsCount++)
        //        {
        //            m_originalPoints.Add(new MathHandler(m_points[pointsCount].X, m_points[pointsCount].Y));
        //        }

        //        m_edges = new List<Edge>();

        //        this.BuildEdges();
        //    }
        //}

        //private void BuildEdges()
        //{
        //    MathHandler pointA, pointB;

        //    m_edges.Clear();

        //    for (int pointsCount = 0; pointsCount < m_points.Count; pointsCount++)
        //    {
        //        pointA = m_points[pointsCount];

        //        if (pointsCount + 1 >= m_points.Count)
        //        {
        //            pointB = m_points[0];
        //        }
        //        else
        //        {
        //            pointB = m_points[pointsCount + 1];
        //        }

        //        m_edges.Add(new Edge(pointA, pointB));
        //    }
        //}

        //public void Translate(MathHandler translation)
        //{
        //    for (int pointsCount = 0; pointsCount < m_points.Count; pointsCount++)
        //    {
        //        MathHandler p = m_points[pointsCount];

        //        m_points[pointsCount] = new MathHandler(p.X + translation.X, p.Y + translation.Y);
        //    }

        //    m_totalTranslation = m_totalTranslation + translation;

        //    this.BuildEdges();
        //}

        //public void Rotate(float angle)
        //{
        //    float degAngle = angle * (180.0f / (float)Math.PI);
            
        //    degAngle = (float)Math.Round((double)degAngle);

        //    for (int pointsCount = 0; pointsCount < m_points.Count; pointsCount++)
        //    {
        //        MathHandler pCurr = m_points[pointsCount];
        //        MathHandler pOrig = m_originalPoints[pointsCount];

        //        Matrix matrixCurr = pCurr.ToMatrix();
        //        Matrix matrixOrig = pOrig.ToMatrix();

        //        Matrix rotCurr = new Matrix();
        //        Matrix rotOrig = new Matrix();

        //        TrigHandler trig = TrigHandler.GetInstance();

        //        float sin = 0.0f;
        //        float cos = 0.0f;

        //        if (degAngle == 1.0f)
        //        {
        //            cos = trig.GetCos(1.0f);
        //            sin = trig.GetSin(1.0f);              
        //        }
        //        else if (degAngle == -1.0f)
        //        {
        //            cos = trig.GetCos(359.0f);
        //            sin = trig.GetSin(359.0f);
        //        }

        //        rotCurr.M11 = (matrixCurr.M11 * cos) - (matrixCurr.M21 * sin);
        //        rotCurr.M21 = (matrixCurr.M11 * sin) + (matrixCurr.M21 * cos);

        //        rotOrig.M11 = (matrixOrig.M11 * cos) - (matrixOrig.M21 * sin);
        //        rotOrig.M21 = (matrixOrig.M11 * sin) + (matrixOrig.M21 * cos);

        //        matrixCurr = rotCurr;
        //        matrixOrig = rotOrig;

        //        m_points[pointsCount] = new MathHandler(matrixOrig.M11 + m_totalTranslation.X, matrixOrig.M21 + m_totalTranslation.Y);
        //        m_originalPoints[pointsCount] = new MathHandler(matrixOrig.M11, matrixOrig.M21);
        //    }

        //    this.BuildEdges();
        //}

        //public override string ToString()
        //{
        //    string result = "";

        //    for (int pointsCount = 0; pointsCount < m_points.Count; pointsCount++)
        //    {
        //        if (result != "") 
        //            result += " ";

        //        result += "{" + m_points[pointsCount].ToString(true) + "}";
        //    }

        //    return result;
        //}
    }
}
