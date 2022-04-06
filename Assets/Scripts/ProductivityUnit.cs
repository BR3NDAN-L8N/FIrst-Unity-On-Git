using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    // new variables
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)  // ensure we only run this code once when we are close to the same pile.
        {
            ResourcePile pile = m_Target as ResourcePile;  // "as ResoucePile" ensures m_Target is of type ResoucePile and not a parent type of ResourcePile

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    protected void ResetProductivity()
    {
        if (m_CurrentPile != null) // if we have a currentPile whose productivy is being increased,
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier; // undo the increase
            m_CurrentPile = null; // unassign out currentPile
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity(); // call your new method
        base.GoTo(target);  // run method from base class - super class
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();   // call your new method
        base.GoTo(position); // run method from base class - super class
    }
}
