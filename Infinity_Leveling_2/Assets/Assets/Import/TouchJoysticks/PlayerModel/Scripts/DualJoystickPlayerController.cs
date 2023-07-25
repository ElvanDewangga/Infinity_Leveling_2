using UnityEngine;
using System.Collections;

public class DualJoystickPlayerController : MonoBehaviour {
		public static DualJoystickPlayerController Ins;
	 void Awake () {
		Ins = this;
	 }
	void Start () {
		Off_Dual_Joy_Stick ();
	}
	//---------- Local_Player
	//----- Dipanggil dari Lis_GameManager :
	// public GameObject Sphere_World_Camera;
	// public GameObject Sphere_World_Forward;
	// public GameObject World_Camera;
	// public Player_Status_Script Real_Player_3d_Script_GO;
	//================= END
	
    public LeftJoystick leftJoystick; // the game object containing the LeftJoystick script
    public RightJoystick rightJoystick; // the game object containing the RightJoystick script
    // public float moveSpeed = 0.8f; // movement speed of the player character
    // public int rotationSpeed = 8; // rotation speed of the player character
	// public GameObject Avatar_GO; // the game object that will rotate to face the input direction
    private Vector3 leftJoystickInput; // holds the input of the Left Joystick
    private Vector3 rightJoystickInput; // hold the input of the Right Joystick
	public float moveSpeed;
	[SerializeField]
	GameObject Player_2d;
	public bool bool_Click_Left = false; // false = player x tekan. true = Player v Tekan.
	CharacterController Player_2d_Controller;
	Online_Player_2d _Online_Player_2d;
	bool b_Have_Player_2d = false;
	Player_2d _Player_2d_Sc;
	// Online_Player_2d :
	public void On_Input_Player_2d (GameObject s) {
		Player_2d = s;
		Player_2d_Controller = Player_2d.GetComponent <CharacterController>();
		_Online_Player_2d = s.GetComponent <Online_Player_2d>();
		_Player_2d_Sc = s.GetComponent <Player_2d>();
		b_Have_Player_2d = true;
	}
	
	//------- Dipanggil dari Team_Formation & Change_System_Script :
	/*
	public void Give_Rotation_Target (string Character_Value) {
		M_Character = Character_Value; StartCoroutine (numerator_Give_Rotation_Target ());
	}

	IEnumerator numerator_Give_Rotation_Target () {
		yield return new WaitForSeconds (1);
	}

	*/
	[SerializeField]
	GameObject Dual_Joy_Stick_Canvas;
	// Tower_Infinity_Manager :
	public void On_Dual_Joy_Stick () {
		Dual_Joy_Stick_Canvas.gameObject.SetActive (true);
	}

	public void Off_Dual_Joy_Stick () {
		Dual_Joy_Stick_Canvas.gameObject.SetActive (false);
	}

    void FixedUpdate()
    {
		if (b_Have_Player_2d) { 
        // get input from both joysticks
        leftJoystickInput = leftJoystick.GetInputDirection();
        rightJoystickInput = rightJoystick.GetInputDirection();

        float xMovementLeftJoystick = leftJoystickInput.x; // The horizontal movement from joystick 01
        float zMovementLeftJoystick = leftJoystickInput.y; // The vertical movement from joystick 01	

        float xMovementRightJoystick = rightJoystickInput.x; // The horizontal movement from joystick 02
        float zMovementRightJoystick = rightJoystickInput.y; // The vertical movement from joystick 02
		
		// Debug.Log (leftJoystickInput.x); -1 to 1
        // if there is no input on the left joystick
        if (leftJoystickInput == Vector3.zero)
        {
			/*
			if (Real_Player_3d_Script_GO.Animator_Char.gameObject.activeInHierarchy) {
				Real_Player_3d_Script_GO.Animator_Char.SetBool ("Anim_Run", false);
				Real_Player_3d_Script_GO.Animator_Pakaian.SetBool ("Anim_Run", false);
			}
			*/
			if (_Player_2d_Sc.b_Can_Skill && _Player_2d_Sc.b_Can_Move) {
				if (_Player_2d_Sc.Last_Code != "Idle") {
					_Player_2d_Sc.On_Character_Animation ("Idle");
				}
			}
        }
        // if there is no input on the right joystick
        if (rightJoystickInput == Vector3.zero)
        {

        }
  
        // if there is only input from the left joystick
		if (leftJoystickInput != Vector3.zero && rightJoystickInput == Vector3.zero) {
			// calculate the player's direction based on angle
			float tempAngle = Mathf.Atan2 (zMovementLeftJoystick, xMovementLeftJoystick);
			xMovementLeftJoystick *= Mathf.Abs (Mathf.Cos (tempAngle));
			zMovementLeftJoystick *= Mathf.Abs (Mathf.Sin (tempAngle));

			// Vector3 temp = World_Camera.transform.position;
			// temp.x += xMovementLeftJoystick;
			// temp.z += zMovementLeftJoystick;
			// Vector3 lookDirection = temp - World_Camera.transform.position;
			// rotate the player to face the direction of input
				//if (lookDirection != Vector3.zero) {
					leftJoystickInput = new Vector3 (xMovementLeftJoystick, 0, zMovementLeftJoystick);
					// leftJoystickInput = World_Camera.transform.TransformDirection (leftJoystickInput);
					leftJoystickInput *= moveSpeed;
					// Avatar_GO.transform.localRotation = Quaternion.Slerp (Avatar_GO.transform.localRotation, Quaternion.LookRotation (lookDirection) * World_Camera.transform.localRotation * Quaternion.Euler (0,90,0), rotationSpeed * Time.fixedDeltaTime);
					//---- Kunci rotasi z :
					// Avatar_GO.transform.eulerAngles = Vector3.RotateTowards(Avatar_GO.transform.eulerAngles, new Vector3(Avatar_GO.transform.eulerAngles.x, Avatar_GO.transform.eulerAngles.y, 0.0f), 50, 100);

					
				//}

			// move the player
			if (_Player_2d_Sc.b_Can_Skill && _Player_2d_Sc.b_Can_Move) {
				if (_Player_2d_Sc.Last_Code != "Walk") {
					_Player_2d_Sc.On_Character_Animation ("Walk");
				}
			}

			if (_Player_2d_Sc.b_Can_Move) {
				if (!_Online_Player_2d.b_GMP_Spawn) {
					Player_2d_Controller.Move (leftJoystickInput * Time.fixedDeltaTime);
				}
			}
				if (leftJoystickInput.x <0) {
					if (Online_Tower_Infinity_Room.Ins.Mine_Player_2d.Cur_Flip == "Right") {
						Online_Tower_Infinity_Room.Ins.Mine_Player_2d.On_Flip ("Left");
					}
				} else if (leftJoystickInput.x > 0) {
					if (Online_Tower_Infinity_Room.Ins.Mine_Player_2d.Cur_Flip == "Left") {
						Online_Tower_Infinity_Room.Ins.Mine_Player_2d.On_Flip ("Right");
					}
				}
				/*
				if (Real_Player_3d_Script_GO.Animator_Char.gameObject.activeInHierarchy) {
					Real_Player_3d_Script_GO.Animator_Char.SetBool ("Anim_Run", true);
					Real_Player_3d_Script_GO.Animator_Pakaian.SetBool ("Anim_Run", true);
				}	
				*/
				bool_Click_Left = true;
			
		}else {
			if (bool_Click_Left == true) {

			}
		}

        // if there is only input from the right joystick
        if (leftJoystickInput == Vector3.zero && rightJoystickInput != Vector3.zero)
        {
			/*
            // calculate the player's direction based on angle
            float tempAngle = Mathf.Atan2(zMovementRightJoystick, xMovementRightJoystick);
            xMovementRightJoystick *= Mathf.Abs(Mathf.Cos(tempAngle));
            zMovementRightJoystick *= Mathf.Abs(Mathf.Sin(tempAngle));

            // rotate the player to face the direction of input
			
			Vector3 temp = transform.position;
			temp.x += xMovementRightJoystick;
			temp.z += zMovementRightJoystick;
			Vector3 lookDirection = temp - transform.position;
			if (lookDirection != Vector3.zero) {

			}
			Sphere_World_Forward.transform.RotateAround(this.transform.position, Vector3.up, xMovementRightJoystick* 80 * Time.fixedDeltaTime);
			Sphere_World_Camera.transform.RotateAround(this.transform.position, Vector3.up, xMovementRightJoystick* 80 * Time.fixedDeltaTime);
			*/
		
        }

        // if there is input from both joysticks (Left And Right)
		if (leftJoystickInput != Vector3.zero && rightJoystickInput != Vector3.zero) {
			/*
			// calculate the player's direction based on angle
			float tempAngleInputRightJoystick = Mathf.Atan2 (zMovementRightJoystick, xMovementRightJoystick);
			xMovementRightJoystick *= Mathf.Abs (Mathf.Cos (tempAngleInputRightJoystick));
			zMovementRightJoystick *= Mathf.Abs (Mathf.Sin (tempAngleInputRightJoystick));

            // rotate the player to face the direction of input
			
			Vector3 temp = transform.position;
			temp.x += xMovementRightJoystick;
			temp.z += zMovementRightJoystick;
			Vector3 lookDirection = temp - transform.position;

			// Sphere_World_Forward.transform.RotateAround(this.transform.position, Vector3.up, xMovementRightJoystick* 80 * Time.fixedDeltaTime);
			// Sphere_World_Camera.transform.RotateAround(this.transform.position, Vector3.up, xMovementRightJoystick* 80 * Time.fixedDeltaTime);
			*/

			// calculate the player's direction based on angle
			float tempAngle = Mathf.Atan2 (zMovementLeftJoystick, xMovementLeftJoystick);
			xMovementLeftJoystick *= Mathf.Abs (Mathf.Cos (tempAngle));
			zMovementLeftJoystick *= Mathf.Abs (Mathf.Sin (tempAngle));

			// rotate the player to face the direction of input
			// Vector3 temp_2 = World_Camera.transform.position;
			// temp_2.x += xMovementLeftJoystick;
			// temp_2.z += zMovementLeftJoystick;
			// Vector3 lookDirection_2 = temp_2 - World_Camera.transform.position;
			
			// rotate the player to face the direction of input
				// if (lookDirection_2 != Vector3.zero) {
					leftJoystickInput = new Vector3 (xMovementLeftJoystick, 0, zMovementLeftJoystick);
					// leftJoystickInput = World_Camera.transform.TransformDirection (leftJoystickInput);
					leftJoystickInput *= moveSpeed;
					
				// }
			//--- sedikit beda dgn left saja karena ketika button kanan di klik sama kiri akan langsung ke arah depan characternya.
			//--- otomatis putar avatar ke arah y sphere_world_Forward posisi.
			/*
					var LookPos = Sphere_World_Forward.transform.position - Avatar_GO.transform.position;
					LookPos.y = 0;
					var rotation = Quaternion.LookRotation (LookPos);
					Avatar_GO.transform.localRotation = Quaternion.Slerp (Avatar_GO.transform.localRotation, rotation * Quaternion.Euler (0,90,0), Time.fixedDeltaTime * 80);
			*/
			if (_Player_2d_Sc.b_Can_Skill && _Player_2d_Sc.b_Can_Move) {
				if (_Player_2d_Sc.Last_Code != "Walk") {
					_Player_2d_Sc.On_Character_Animation ("Walk");
				}
			}
			
			if (_Player_2d_Sc.b_Can_Move) {
				if (!_Online_Player_2d.b_GMP_Spawn) {
					Player_2d_Controller.Move (leftJoystickInput * Time.fixedDeltaTime);
					
				}
			}
			/*
			if (Real_Player_3d_Script_GO.Animator_Char.gameObject.activeInHierarchy) {
				Real_Player_3d_Script_GO.Animator_Char.SetBool ("Anim_Run", true);	
				Real_Player_3d_Script_GO.Animator_Pakaian.SetBool ("Anim_Run", true);
			}
			*/
		}
		}
    }
	
}