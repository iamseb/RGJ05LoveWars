import UnityEngine
		
class LevelAttributes(MonoBehaviour):
	
	public width as int = 36
	public height as int = 24
	
	
	def OnDrawGizmos():
		Debug.DrawLine(
			Vector3(transform.position.x - width/2, 0, transform.position.y - height/2), 
			Vector3(transform.position.x - width/2, 0, transform.position.y + height/2)
		)
		Debug.DrawLine(
			Vector3(transform.position.x - width/2, 0, transform.position.y - height/2), 
			Vector3(transform.position.x + width/2, 0, transform.position.y - height/2)
		)
		Debug.DrawLine(
			Vector3(transform.position.x + width/2, 0, transform.position.y + height/2), 
			Vector3(transform.position.x - width/2, 0, transform.position.y + height/2)
		)
		Debug.DrawLine(
			Vector3(transform.position.x + width/2, 0, transform.position.y + height/2), 
			Vector3(transform.position.x + width/2, 0, transform.position.y - height/2)
		)
