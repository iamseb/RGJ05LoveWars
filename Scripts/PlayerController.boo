import UnityEngine
import System.Collections

public class PlayerController(MonoBehaviour):

	public disabled as bool = false
	public speed as single = 5.0F
	public level as LevelAttributes
	
	// Update is called once per frame
	def FixedUpdate():
		xmov as single = Input.GetAxis('Horizontal')
		zmov as single = Input.GetAxis('Vertical')
		v = Vector3(xmov, 0, zmov)
		move = v * speed * Time.fixedDeltaTime
		transform.position += move
		if transform.position.x  > level.width / 2:
			transform.position.x = level.width / 2;
		if transform.position.x  < -level.width / 2:
			transform.position.x = -level.width / 2;
		if transform.position.z  > level.height / 2:
			transform.position.z = level.height / 2;
		if transform.position.z  < -level.height / 2:
			transform.position.z = -level.height / 2;
