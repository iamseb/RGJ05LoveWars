import UnityEngine
		
class Defender(MonoBehaviour):
	public health = 100.0F
	public active = true	

	def Awake():
		gameObject.tag = 'player'

	def OnCollisionEnter(collision as Collision):
		for contact as ContactPoint in collision.contacts:
			Debug.DrawRay(contact.point, contact.normal, Color.white)
