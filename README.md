# Eco-Guardian

Eco Guardian este un software educaţional, destinat elevilor, cu scopul de a-i ajuta să înveţe principiile reciclării selective a deşeurilor şi efectele negative ale poluării într-un mod interactiv. 
Steve, personajul principal, înfruntă inamicii (deşeurile) şi reciclează.

Eco Guardian poate fi introdus în săptămâna verde sau în orele de geografie, biologie, dirigenţie, fiecare nivel alcătuind o lecţie.

Jocul este realizat în Unity, programat în C#, folosind librăriile default UnityEngine.SceneManagement şi UnityEngine.UI. 

Player-ul are componentele : Rigidbody2D, Capsule Collider 2D, Animator, scriptul PlayerMovement, cu ajutorul căruia jucătorul se poate mișca cu tastele WASD sau Sageți. Scriptul PlayerCombat este folosit pe parcursul primului nivel, tasta F este folosită pentru a ataca inamicii. 
Pentru NPC-uri am folosit un Canvas în care se află caseta de text, butonul pentru a trece la urmatoarea caseta, imaginea NPC-ului și numele acestuia.

Scriptul AISCRIPT află constant poziția player-ului și face inamicii să se deplaseze către acesta.

Scriptul LevelMovement controlează mișcarea Player-ului prin intermediul tastelor WASD sau Săgeți. De asemenea, în funcție de direcția în care caracterul se deplasează vor fi afișate animatiile corespunzătoare.

Scriptul NPC este folosit pentru a afişa dialogul dintre Player şi NPC.

Scriptul WaveSpawner aduc inamici preselectaţi într-o locație aleatorie dintre cele setate de noi. 

Pentru grafică, în Aseprite şi Gimp am animat caracterele. Personajul principal are 12 frame-uri (câte 2 pentru paşi în fiecare direcţie şi 4 statice).  
Frame-uri animate pe straturi/layere
După ce l-am animat în Gimp, am observat că rezoluţia nu coincide cu cea a hărţii, deci am schimbat mărimea lor în Aseprite . (pentru o calitate mai mare) 

Pentru întreaga hartă, am realizat tile-urile in Aseprite pe 16x16 sau 32x32 de pixeli după care le-am exportat în Tiled, unde le-am unit pentru a avea o mapă la rezoluţia jocului.

Grafica este realizată în GIMP 2.10.34, Aseprite, Tiled şi PixilArt, fiind un joc de tip Pixel Art. În Aseprite Şi Gimp am animat caracterele, astfel personajul principal are 12 frame-uri, iar inamicii au 6 frame-uri. În Aseprite şi Tiled am realizat hărţile cu tile-uri de 16x16 sau 32x32, unite. 
