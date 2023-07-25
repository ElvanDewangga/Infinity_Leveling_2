using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character_Database_Part : MonoBehaviour {
    public string Name_Character = "";
    // --- Visual_Novel_Canvas :
    public Sprite Cg_VN_Normal; 
    public Visual_Novel_Kalimat [] Dialog_Character_Random;

    void Start () {
        if (Name_Character == "Male_Combat_Master") {
            Dialog_Character_Random = new Visual_Novel_Kalimat [8];
            int x = 0;
            for (x = 0; x < 8; x++) {
                /*
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
                */
                if (x == 0) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, brave warriors, to the world of Sword Master! Prepare to embark on a legendary journey of strength and valor!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 1) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, noble swordsmen! Join the ranks of the Sword Master guild and prove your mettle on the battlefield!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 2) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome to Sword Master, where only the most skilled swordsmen can rise to greatness. Are you ready to accept the challenge?"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 3) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Step into the shoes of a mighty sword master and unleash your formidable skills in epic battles. Welcome to our realm!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 4) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Hail, warrior! As a sword master, your blade will carve a path of glory and honor. Enter our world and leave your mark!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 5) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, aspiring sword master! Your destiny awaits as you train in the ancient arts of swordsmanship and rise to become a true legend."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 6) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, young swordsman! Prepare to hone your skills, face mighty foes, and become the ultimate Sword Master in our immersive world."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 7) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Male_Combat_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Enter the realm of Sword Master and embrace the way of the blade. Welcome, fearless warrior, to a realm of epic battles and heroic deeds!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }  
            }
        }     
        if (Name_Character == "Female_Mage_Master") {
            Dialog_Character_Random = new Visual_Novel_Kalimat [8];
            int x = 0;
            for (x = 0; x < 8; x++) {
                /*
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
                */
                if (x == 0) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, young sorceress, to a realm of mystical powers and enchanting adventures!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 1) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Step into the magical world of our mobile game as a skilled mage master and unleash your extraordinary abilities!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 2) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, magical prodigy! Embark on a journey as a powerful mage master and uncover the secrets of arcane arts."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 3) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, spellcaster! Harness the forces of nature and weave your spells as a fearless mage master in our mobile game."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 4) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Enter a realm of wonder and wizardry, where you, as a mage master, hold the key to unlocking unlimited magical potential."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 5) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, esteemed sorceress! Let your magical prowess shine as a mage master in our captivating mobile game"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 6) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Step into the shoes of a formidable mage master and immerse yourself in a world brimming with arcane wonders and ancient mysteries."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 7) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Male Combat master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Mage_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome to the realm of magic, where you, as a skilled mage master, will shape destiny with your unrivaled spellcasting abilities."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }  
            }
        }  
        if (Name_Character == "Female_Cleric_Master") {
            Dialog_Character_Random = new Visual_Novel_Kalimat [8];
            int x = 0;
            for (x = 0; x < 8; x++) {
                /*
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
                */
                if (x == 0) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, brave adventurer! I am your joyful guide, the cleric master. Prepare to embark on a magical journey filled with joy and wonder!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 1) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, dear traveler! As the mistress of the light, I extend my warmest welcome. Together, we shall spread joy and laughter throughout this enchanting realm!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 2) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ah, a new soul graces our presence! Welcome, welcome! I, the exuberant cleric master, am thrilled to have you join our merry band. Let's make this world shine brighter!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 3) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Hail, noble hero! I am the vivacious cleric master, here to share my boundless joy with you. Together, we shall vanquish darkness and bask in the light of triumph!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 4) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, my dear companion! I, the jubilant cleric master, am delighted to have you by my side. Let's heal the wounded, mend broken hearts, and spread happiness across this realm!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 5) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, chosen one! I, the radiant cleric master, extend my hand in warm welcome. Let us embark on an extraordinary adventure, where laughter and mirth will be our constant companions."; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 6) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ah, a new friend! Welcome to our magical realm, dear adventurer. I, the cheerful cleric master, will be your guiding light. Together, we shall dance through quests and revel in the joy of victory!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 7) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Female Cleric master"; Vn.Right_Name = ""; Vn.Left_Img = "Female_Cleric_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Step into the embrace of my joyful presence, brave soul! I, the spirited cleric master, am thrilled to welcome you. With love and laughter, we shall conquer any obstacle that comes our way!"; Vn.Event =  "Change_Bg_Hall_Of_Masters";
                    Dialog_Character_Random[x] = Vn;
                }  
            }
        }  
        if (Name_Character == "Sage_Shrine_Master") {
            Dialog_Character_Random = new Visual_Novel_Kalimat [8];
            int x = 0;
            for (x = 0; x < 8; x++) {
                /*
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
                */
                if (x == 0) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ah, young traveler, I sense the presence of an eager soul. Welcome to the realm of wisdom and secrets. I am the ancient sage, and I have been expecting your arrival."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 1) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, seeker of knowledge. Your footsteps have led you to the realm of the mysterious. I am the guardian of ancient wisdom, here to guide you on your path. "; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 2) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Hark! A curious soul has entered my domain. You seek enlightenment, do you not? Welcome, young one. I am the enigmatic sage, a master of the arcane arts. Let us embark on a journey of discovery together."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 3) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ah, a visitor arrives, drawn by the whispers of forgotten truths. Welcome, brave adventurer, to the sanctum of the old sage. I have witnessed the ebb and flow of civilizations, and now I shall impart my knowledge unto you."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 4) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "In the realm of shadows and secrets, you have found your way. Welcome, young apprentice, to the abode of the ancient sage. Here, the mysteries of ages past are waiting to be unraveled."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 5) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Hush, for the winds carry a name, and that name is yours. Welcome, wanderer, to the realm of the all-knowing sage. Within these hallowed grounds, answers lie hidden, waiting for you to seek them."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 6) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ah, a new arrival graces my presence. Welcome, seeker of truth, to the sanctuary of the old sage. Together, we shall traverse the labyrinth of forgotten knowledge and unravel the tapestry of destiny."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 7) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Sage Shrine Master"; Vn.Right_Name = ""; Vn.Left_Img = "Sage_Shrine_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Step forth, child of destiny, and behold the dwelling of the timeless sage. You have been chosen to walk the path of illumination. Welcome, for your journey begins here, in the embrace of ancient wisdom."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }  
            }
        }
        if (Name_Character == "Blacksmith_Master") {
            Dialog_Character_Random = new Visual_Novel_Kalimat [8];
            int x = 0;
            for (x = 0; x < 8; x++) {
                /*
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
                */
                if (x == 0) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, adventurer! I am the resourceful blacksmith master, here to forge your weapons and armor. Step forward and let's create something legendary together!"; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 1) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ah, a new face! Welcome to my forge, where the hammer strikes true and the flames burn bright. I am the master blacksmith, ready to shape your destiny. What can I craft for you today?"; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 2) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, young warrior! You have found your way to the realm of the resourceful blacksmith master. Here, steel sings and sparks fly. Tell me, what brings you to my forge?"; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 3) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Hail, brave traveler! I am the master of the anvil, the conductor of heat, and the guardian of craftsmanship. Step into my humble abode, and let us fashion greatness from raw materials."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 4) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, welcome! Ah, the sound of a newcomer's footsteps in my forge is music to my ears. I am the resourceful blacksmith master, ready to channel your aspirations into tangible creations. How may I assist you today?"; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 5) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome, welcome! Ah, the sound of a newcomer's footsteps in my forge is music to my ears. I am the resourceful blacksmith master, ready to channel your aspirations into tangible creations. How may I assist you today?"; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 6) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Well met, intrepid soul! You stand before the resourceful blacksmith master, the keeper of the ancient techniques and guardian of secrets. Share your desires, and I shall breathe life into them with my anvil and hammer."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 7) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Blacksmith Master"; Vn.Right_Name = ""; Vn.Left_Img = "Blacksmith_Master"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Salutations, fellow seeker of greatness! Within these walls, the fires of creation burn eternal. I am the master blacksmith, blessed with the gift of turning ordinary into extraordinary. Together, let's forge a legend worth cherishing."; Vn.Event =  "Change_Bg_Sage_Shrine";
                    Dialog_Character_Random[x] = Vn;
                }  
            }
        }

        if (Name_Character == "Store_Owner") {
            Dialog_Character_Random = new Visual_Novel_Kalimat [8];
            int x = 0;
            for (x = 0; x < 8; x++) {
                /*
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
                */
                if (x == 0) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ahoy, adventurer! Welcome to my humble emporium. Step right in and feast your eyes on the finest treasures this realm has to offer."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 1) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Well met, brave soul! Come closer and peruse my collection of wondrous artifacts. You never know what hidden gem might catch your fancy."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 2) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, traveler! Step into my humble abode and let me show you the most exquisite weapons and armor. Only the best for those who dare to face the perils of this land."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 3) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Hail, wanderer! Seek respite within these walls and discover the secrets I have gathered from the farthest reaches of the kingdom. The rarest potions and enchantments await your perusal."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 4) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ho there, adventurer! Venture forth and behold the splendor of my store. From mystical trinkets to magical scrolls, I have everything an intrepid soul like you could ever desire."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 5) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Salutations, brave one! Come forth and marvel at the bounty I have amassed throughout my journeys. Exotic herbs, mystical relics, and ancient maps are just a taste of what awaits you."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 6) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Greetings, weary traveler! Take solace within my emporium and let me share with you the tales behind each artifact. Each item has a story, and it's up to you to become a part of it."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 7) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Store Owner"; Vn.Right_Name = ""; Vn.Left_Img = "Store_Owner"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Ah, a new face graces my humble establishment! Welcome, seeker of adventure. Prepare to be captivated by the treasures that lie before you. Find what you need to conquer the challenges that await."; Vn.Event =  "Change_Bg_Store_Owner";
                    Dialog_Character_Random[x] = Vn;
                }  
            }
        }
        if (Name_Character == "Hellper") {
            Dialog_Character_Random = new Visual_Novel_Kalimat [10];
            int x = 0;
            for (x = 0; x < 10; x++) {
                /*
                L_Visual_Novel_Kalimat.Add (Parent_Load_Visual_Novel.L_Visual_Novel_Kalimat[x]);
                */
                if (x == 0) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Welcome to the world of infinite leveling!"; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 1) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "You have been given another chance to live a new life, and the possibilities are endless. In this world, you can do anything you set your mind to."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 2) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "To get started, open your inventory and take a look at the New Player Box. Inside, you will find a variety of items that will help you on your journey."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 3) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "The Tower: The Tower is a challenging dungeon that is filled with monsters and treasure. Each floor is different, so you will need to use your skills and abilities to survive. Work with other players to enjoy a better hunting experiences."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 4) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "The Arena: The Arena is a place where you can test your skills against other players. Win or lose, you will earn rewards that can help you improve your character."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 5) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "The Hall of Masters: The Hall of Masters is where you can learn new skills. Each master specializes in a different type of skill, so you can choose the ones that best suit your playstyle."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }
                if (x == 6) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "Have fun! The most important thing is to have fun. Explore the world, fight monsters, and learn new skills. The possibilities are endless!"; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }
                // Ini setelah udah maen dan masuk game welcome text ini 
                if (x == 7) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "I believe in you, adventurer. You can do anything you set your mind to."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }  
                if (x == 8) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "I'm here to help, but I'm not going to hold your hand. Figure it out."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }  
                if (x == 9) {
                    Visual_Novel_Kalimat Vn = new Visual_Novel_Kalimat (); 
                    Vn.Id = 0; Vn.Left_Name = "Hellper"; Vn.Right_Name = ""; Vn.Left_Img = "Hellper"; Vn.Right_Img = ""; Vn.Position = "L";
                    Vn.Dialog_Text = "You're doing great! Keep up the good work."; Vn.Event =  "Change_Bg_Transparant";
                    Dialog_Character_Random[x] = Vn;
                }  
            }
        }
    }
}
