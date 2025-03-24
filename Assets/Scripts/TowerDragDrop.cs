using UnityEngine;

public class TowerDragDrop : MonoBehaviour
{
    private Transform dragTarget = null;

    private void Update()
    {
        // Only allow the player to move towers when game is in building state
        if (GameManger.instance.gameState != GameState.Building)
        {
            if (dragTarget != null)
            {
                dragTarget = null;
            }
            return;
        }

        // Pickup and drop tower when pressing left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Fire raycast at mouse position
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            // Check if hit object is a tower
            if (hit == true && hit.collider.tag == "Tower")
            {
                dragTarget = hit.transform;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragTarget = null;
        }

        // Move tower to mouse position
        if (dragTarget != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragTarget.position = new Vector3(mousePos.x, mousePos.y, -1f);
        }
    }
}
