using UnityEngine;

public class BoardBuilder : MonoBehaviour
{
    [SerializeField] private Material _materialWhite;
    [SerializeField] private Material _materialBlack;
    [SerializeField] private Tile _tilePrefab;

    private int _sideLength = 8;

    private void Start()

    {
        for (int i = 0; i < _sideLength; i++)
        {
            for (int j = 0; j < _sideLength; j++)
            {
                Tile newTile = Instantiate(_tilePrefab, new Vector3(i, 0f, j), Quaternion.identity, transform);
                newTile.GetComponent<Renderer>().material = (i + j) % 2 == 0 ? _materialWhite : _materialBlack;
            }
        }
    }
}
