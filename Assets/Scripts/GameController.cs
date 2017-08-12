using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    private Base base1;
    private Base base2;
    private Base activeBase;
    Text text;

    private Vector3 targetLocation;
    private int totalTurns;

    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }

    public Vector3 TargetLocation
    {
        get
        {
            return targetLocation;
        }
        private set
        {
            targetLocation = value;
        }
    }

    public Base ActiveBase
    {
        get
        {
            return activeBase;
        }

        private set
        {
            activeBase = value;
        }
    }

    public void AssignNewTarget(Vector3 newTargetLocation)
    {
        TargetLocation = newTargetLocation;
    }

    public void StartGame()
    {
        totalTurns = 0;

        Base[] bases = FindObjectsOfType<Base>();

        if (bases.Length > 1)
        {
            base1 = bases[0];
            base1.onTurnFinished += AssignNextTurn;
            base1.onBaseDestroyed += OnBaseDestroyed;

            base2 = bases[1];
            base2.onTurnFinished += AssignNextTurn;
            base2.onBaseDestroyed += OnBaseDestroyed;

            AssignNextTurn();
        }
    }

    private void AssignNextTurn()
    {
        if (ActiveBase == base1)
        {
            ActiveBase = base2;
        }
        else if (ActiveBase == base2)
        {
            ActiveBase = base1;
            totalTurns += 1;
            text.text = "" + totalTurns;

        }
        else
        {
            ActiveBase = base1;
        }

        ActiveBase.EnableTurn();
        TargetLocation = ActiveBase.transform.position;
    }

    private void OnBaseDestroyed(Base destroyedBase)
    {
        Destroy(destroyedBase.gameObject);
    }

    private void Awake()
    {
        instance = this;
        totalTurns = 0;
        text = GetComponent<Text>();
    }

    private void OnDestroy()
    {
        instance = null;
    }
}